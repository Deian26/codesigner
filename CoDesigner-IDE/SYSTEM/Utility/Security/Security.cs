using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    internal static class Security
    {
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

        private static byte[] GEN_KEY; // general enc/dec key

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

            /// <summary>
            /// Splits the provided token string, decodes and retrieves the field values.
            /// </summary>
            /// <param name="tokenString">The string to be parsed</param>
            public Token(string tokenString)
            {
                string[] fields = tokenString.Split(Token.FIELD_SEPARATOR); // get encoded field value

                if(fields.Length < 4) // invalid length
                {
                    this.VALID = false; //=> invalidate token
                    return;
                }

                // decode fields
                fields[0] = fields[0].Trim();
                this.ID = Encoding.UTF8.GetString(Convert.FromBase64String(fields[0]));
                
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
                bool validTokenTsExp = false;

                if (DateTime.UtcNow.CompareTo(this.TS.AddSeconds(this.EXPIRATION_LIMIT_SEC)) < 0) // token is still valid (not expired)
                {
                    validTokenTsExp = true;

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

                this.VALID = validTs && validGenCode && validTokenTsExp && validExp; // check if the token is valid

                if(this.VALID == true) //=> valid token
                {
                    // grant the requested access level
                    this.ACCESS_LEVEL = (Security.AccessLevel)Convert.ToInt32(Enum.Parse(typeof(Security.AccessLevel), accessLevel)); // get security access from the decoded field value
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
        /// Encrypts the given text
        /// </summary>
        /// <param name="inputText">Text to be encrypted/param>
        /// <returns>The generated cipher text<</returns>
        public static string Encrypt(string inputText)
        {
            string cipherText = null;

            using (Aes aes = Aes.Create())
            {
                byte[] bytePlainText = Encoding.UTF8.GetBytes(inputText);

                aes.Key = Security.GEN_KEY;
                aes.GenerateIV();

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                
                using (MemoryStream outputStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(bytePlainText);
                        }
                    }

                    cipherText = Encoding.UTF8.GetString(outputStream.ToArray());
                }

            }

            return cipherText;
        }

        /// <summary>
        /// Decrypts the provided text
        /// </summary>
        /// <param name="cipherText">Text to be decrypted</param>
        /// <returns>The plain text representation of the provided cipher-text</returns>
        internal static string Decrypt(string cipherText)
        {
            string plainText = null;

            using (Aes aes = Aes.Create())
            {
                byte[] byteCipherText = Encoding.UTF8.GetBytes(cipherText);

                aes.Key = Security.GEN_KEY;
                aes.GenerateIV();

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream outputStream = new MemoryStream(byteCipherText))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(outputStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            plainText = streamReader.ReadToEnd();
                        }
                    }
                }

            }

            return plainText;
        }
        
        #region utility
        /// <summary>
        /// Set the general-purpose enc/dec key
        /// </summary>
        public static void SetGenKey()
        {

        }

        #endregion
    }
}
