using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Manages security for the IDE
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal static class Security
    {
        // used tokens
        private static List<Security.Token> UsedTokens = new List<Security.Token>();

        /* valid generator codes
         * Verification method: TOKEN_TS + ANY_APPROVED_CODE == TOKEN_GENERATOR_CODE
        */
        private static string[] APPROVED_BASE_GEN_CODES =
        {
            //=// Hard-coded generator base IDs
#if DEBUG
            "130581651526017622911618924812547681191644922684442223615389774992131705524310" // development-only base generator ID; disabled in the release version
#endif
            
        };
        internal const int MIN_EXPIRATION_LIMIT = 60; // the minimum number of seconds from a token's generation until it expires
        internal const int MAX_EXPIRATION_LIMIT = 21600; // the maximum time expiration limit (seconds)
        
        /// <summary>
        /// Contains the result of a token verification process
        /// </summary>
        public struct TokenVerificationStatus
        {
            internal Token token { get; }
            internal string eventMessage { get; }

            public TokenVerificationStatus(Token token, string eventMessage)
            {
                this.token = token;
                this.eventMessage = eventMessage;
            }
        }

        /// <summary>
        /// Defines a token; fields are separeted by 'Token.FIELD_SEPARATOR'
        /// </summary>
        internal class Token
        {
            //=// Format //=//
            // ID-TS-ACCESS_LEVEL-EXPIRATION_LIMIT_SEC
            // Time format used: UTC

            public const char FIELD_SEPARATOR = '-';

            public DateTime TS { get; } = DateTime.MaxValue; // time stamp 
            public Security.AccessLevel ACCESS_LEVEL { get; } = Security.AccessLevel.NONE;
            public string ID { get; } = null; // code used to verify the validity of the token
            
            public int EXPIRATION_LIMIT_SEC = 0; // the number of seconds since the timestamp until the token expires
            public bool VALID { get; } = false;
            public bool EXPIRED { get; } = false;
            public bool USED_TOKEN { get; } = false; // if true, this token was already used in the past and cannot be used again
            public string TOKEN_STRING { get; } = null; // the initial token string used to create the token
            /// <summary>
            /// Splits the provided token string, decodes and retrieves the field values.
            /// </summary>
            /// <param name="tokenString">The string to be parsed</param>
            public Token(string tokenString)
            {
                this.TOKEN_STRING = tokenString;

                string[] fields = tokenString.Split(Token.FIELD_SEPARATOR); // get encoded field value

                if(fields.Length < 4) // invalid length
                {
                    this.VALID = false; //=> invalidate token
                    return;
                }

                // decode fields
                fields[0] = fields[0].Trim();
                this.ID = Encoding.UTF8.GetString(Convert.FromBase64String(fields[0]));

                // check if this token was already used
                foreach (Security.Token usedToken in Security.UsedTokens)
                {
                    if (usedToken.ID.Equals(this.ID)) // this token was already used => disregard it
                    {
                        this.USED_TOKEN = true;
                    }
                }

                fields[1] = fields[1].Trim();
                string tsFieldStr = Encoding.UTF8.GetString(Convert.FromBase64String(fields[1]));
                DateTime ts;
                bool validTs = false;
                
                if(DateTime.TryParse(tsFieldStr, out ts) == true)
                {
                    this.TS = ts;
                    validTs = true;
                }

                fields[2] = fields[2].Trim();
                string accessLevel = Encoding.UTF8.GetString(Convert.FromBase64String(fields[2]));

                fields[3] = fields[3].Trim();
                this.EXPIRATION_LIMIT_SEC = Convert.ToInt32(Encoding.UTF8.GetString(Convert.FromBase64String(fields[3])));
                // check expiration limits
                bool validExp = false;
                if (this.EXPIRATION_LIMIT_SEC >= Security.MIN_EXPIRATION_LIMIT && this.EXPIRATION_LIMIT_SEC <= Security.MAX_EXPIRATION_LIMIT)
                {
                    validExp = true;
                }

                // check expiration limit
                if (DateTime.UtcNow.CompareTo(this.TS.AddSeconds(this.EXPIRATION_LIMIT_SEC)) < 0) // token is still valid (not expired)
                {
                    this.EXPIRED = false;

                }
                else // token expired
                {
                    this.EXPIRED = true;
                }

                // check generator code
                bool validGenCode = false;
                foreach(string approvedGenCode in Security.APPROVED_BASE_GEN_CODES)
                {
                    SHA256 sha256 = SHA256.Create();

                    if( Security.GenerateHash(this.TS + approvedGenCode).Equals(this.ID))
                    {
                        validGenCode = true;
                        break;
                    }
                    
                    sha256.Clear();
                }

                this.VALID = validTs && validGenCode && (!this.EXPIRED) && validExp && (!this.USED_TOKEN); // check if the token is valid

                if(this.VALID == true) //=> valid token
                {
                    // grant the requested access level
                    this.ACCESS_LEVEL = (Security.AccessLevel)Convert.ToInt32(Enum.Parse(typeof(Security.AccessLevel), accessLevel)); // get security access from the decoded field value

                    // add this token to the list of already used tokens on this machine
                    Security.AddUsedToken(this);
                }
                // else => invalid token, no security access is granted (by default, it is set to NONE)

            }

            /// <summary>
            /// Verifies the provided token
            /// </summary>
            /// <param name="token">Token to be verified (string)</param>
            /// <returns>The access level to be granted</returns>
            public static Security.AccessLevel AuthorizeToken(string token)
            {
                Security.AccessLevel accessLevel = Security.AccessLevel.NONE;

                //TODO: Implemeny token authentication


                return accessLevel;
            }

        }
        
        public enum AccessLevel {NONE = 0, ADMIN = 1, USER = 2 , ADMIN_WORKSTATION = 3};

        /// <summary>
        /// Generates the hash of the specified text
        /// </summary>
        /// <param name="input">Text to be hashed</param>
        /// <returns></returns>
        public static string GenerateHash(string input)
        {
            string cipherText = null;
            try
            {
                SHA256 sha256 = SHA256.Create();

                cipherText = Security.ToByteString(sha256.ComputeHash(Encoding.UTF8.GetBytes(input)));

                sha256.Clear();
            }
            catch (Exception e)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERROR_GENERATING_SIGNATURE,e.Message);
            }

            return cipherText;
            
        }

        /// <summary>
        /// Computes the plainText over the provided input text and compares it to the provided plainText
        /// </summary>
        /// <param name="inputText">The signed text</param>
        /// <param name="inputSignature">The plainText to be verified (generated for inputText)</param>
        /// <returns>true if the provided plainText matches the computed one</returns>
        public static bool VerifySignature(string inputText, string inputSignature)
        {
            string computedSignature = GenerateHash(inputText); // compute plainText

            return inputSignature.Equals(computedSignature); // compare signatures and return the result
        }

        /// <summary>
        /// Verifies the given token string and, if valid, sets it as the currently active token
        /// </summary>
        /// <param name="inputText">Token string to be checked</param>
        /// <returns>The token and token verification event message, if an error occurs. The token and null otherwise (see the Security.TokenVerificationStatus struct)</returns>
        public static Security.TokenVerificationStatus VerifyToken(string inputText)
        {
            Token token = new Token(inputText);
            string eventMessage = null;
            
            if (token.VALID == false) //=> invalid token
            {
                // log an error if needed
                if (token.EXPIRED == true) // the token is expired
                {
                    eventMessage = Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.TOKEN_EXPIRED);
                }
                else if(token.USED_TOKEN == true)
                {
                    eventMessage = Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ALREADY_USED_TOKEN);
                }
                else // other reason for which the token is invalid
                {
                    eventMessage = Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.INVALID_TOKEN);
                }
                token = null; //=> reset active token, in case this is a failed attempt to enable another token
            }
            TokenVerificationStatus tokenVerificationStatus = new TokenVerificationStatus(token, eventMessage);
            
            return tokenVerificationStatus;
        }

        /// <summary>
        /// Generates and returns the byte-string corresponding to the given byte array
        /// </summary>
        /// <param name="bytes">Array to be converted</param>
        /// <returns>A hexadecimal string representing the input byte array</returns>
        internal static string ToByteString(byte[] bytes)
        {
            string byteString = "";

            foreach (byte b in bytes)
            {
                byteString += b.ToString();
            }

            return byteString;
        }

        /// <summary>
        /// Encrypts the given text for the current user (C# ProtectedData class; Windows only)
        /// </summary>
        /// <param name="plainText">Text to be encrypted</param>
        /// <returns>The generated cipher text</returns>
        
        //[SupportedOSPlatform("windows")]
        public static string Encrypt(string plainText)
        {
            string cipherText = null;
            try
            {
                // platform handling for possible future extensions
                switch (System.Environment.OSVersion.Platform) // use different encryption methods or do not encrypt the data at all, depending on the OS
                {
                    case PlatformID.Win32NT: // windows
                        {
                            byte[] bytePlainText = Encoding.UTF8.GetBytes(plainText);

                            cipherText = Convert.ToBase64String(ProtectedData.Protect(bytePlainText, Encoding.UTF8.GetBytes(Utility.GetHashedUuid()), DataProtectionScope.CurrentUser));
                            break;
                        }
                    default: // log event and do not encrypt data
                        {
                            cipherText = plainText;
                            Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ENC_ERROR_UNSUPPORTED_OS);
                            break;
                        }
                }
            }
            catch (Exception ex) // error encrypting data -> return null
            {
                cipherText = null; // just in case
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ENC_ERROR, ex.Message);
            }

            return cipherText;
        }

        /// <summary>
        /// Decrypts the provided text (C# ProtectedData class; Windows only)
        /// </summary>
        /// <param name="cipherText">Text to be decrypted</param>
        /// <returns>The plain text representation of the provided cipher-text</returns>
        
        //[SupportedOSPlatform("windows")]
        internal static string Decrypt(string cipherText)
        {
            string plainText = null;

            try
            {
                // platform handling for possible future extensions
                switch (System.Environment.OSVersion.Platform) // use different encryption methods or do not encrypt the data at all, depending on the OS
                {
                    case PlatformID.Win32NT: // windows
                        {
                            plainText = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(cipherText), Encoding.UTF8.GetBytes(Utility.GetHashedUuid()), DataProtectionScope.CurrentUser));

                            break;
                        }
                    default: // log event and return null
                        {
                            plainText = null;
                            Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.DEC_ERROR_UNSUPPORTED_OS);
                            break;
                        }
                }
            }
            catch (Exception ex) // error encrypting data -> return null
            {
                plainText = null; // just in case
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.DEC_ERROR, ex.Message);
            }

            return plainText;
        }
        
        /// <summary>
        /// Adds the token string provided token to a list of used tokens
        /// </summary>
        /// <param name="token">Used token</param>
        public static void AddUsedToken(Security.Token token)
        {
            Security.UsedTokens.Add(token);
        }

        /// <summary>
        /// Returns an array containing the security tokens used in this session
        /// </summary>
        /// <returns></returns>
        public static Security.Token[] GetUsedTokens()
        {
            return Security.UsedTokens.ToArray();
        }
    }
}
