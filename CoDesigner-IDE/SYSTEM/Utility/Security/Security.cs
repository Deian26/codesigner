using CoDesigner_IDE.SYSTEM.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace CoDesigner_IDE
{
    /// <summary>
    /// Manages security for the IDE
    /// </summary>
    [SupportedOSPlatform("windows")]
    internal static class Security
    {
        // RSA enc/dec 
        private static readonly string RSA_KEY_CONTAINER_NAME = "RSA_KEY_CONTAINER";
        private static readonly int AES_KEY_SIZE = 128;

        // used tokens
        private static List<Security.Token> UsedTokens = new List<Security.Token>();
        private static FileStream SEC_USED_TOKENS_FILESTREAM = null;

        /// <summary>
        /// Defines the status of security properties
        /// </summary>
        public struct SecurityProperties
        {
            public bool ADMIN_WORKSTATION { get; }

            public SecurityProperties(bool ADMIN_WORKSTATION)
            {
                this.ADMIN_WORKSTATION = ADMIN_WORKSTATION;
            }
        }

        internal static SecurityProperties CurrentSecurityProperties { get; set; }
        private static bool CurrentSecurityPropertiesLoaded = false; // if true, new security properties cannot be loaded (reset when the program is started)

        /* valid generator codes
         * Verification method: TOKEN_TS + ANY_APPROVED_CODE == TOKEN_GENERATOR_CODE
        */
        private static List<string> APPROVED_BASE_GEN_CODES = new List<string>();

        internal const int MIN_EXPIRATION_LIMIT = 60; // the minimum number of seconds from a token's generation until it expires
        internal const int MAX_EXPIRATION_LIMIT = 21600; // the maximum time expiration limit (seconds)

        #region statis-structs
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
        /// Stores details about the verification of a given file
        /// </summary>
        public struct FileCheckResults
        {
            public string filePath { get; } = null;
            public bool recognized { get; } = false; // true if the file is recognized for security check, false otherwise; note that checking an unrecognized file will result in 'validFile' to be false, but this flag will also be false
            public bool validFile { get; } = false; // result of the check operation (true = valid file, false = invalid file)
        
            public FileCheckResults(string filePath, bool recognized, bool validFile)
            {
                this.filePath = filePath;
                this.recognized = recognized;
                this.validFile = validFile;
            }
        }
        #endregion
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
        /// <param name="inputSignature">The plainText to be verified (generated for inputText)</param>
        /// <param name="inputText">The signed text</param>
        /// <returns>true if the provided plainText matches the computed one</returns>
        public static bool VerifySignature(string inputSignature, string inputText)
        {
#if DEBUG //TODO: Remove this dev bypass
            return true; // bypass check for development
#endif
            string computedSignature = GenerateHash(inputText); // compute plainText
            return inputSignature.Trim().Equals(computedSignature); // compare signatures and return the result
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
                byteString += b.ToString().PadLeft(2, '0');
            }

            return byteString;
        }

        /// <summary>
        /// Determines if the given input is a a valid hexadecimal string
        /// </summary>
        /// <param name="input">Text to be checked</param>
        /// <returns>true, if the string is a valid hexadecimal string, false otherwise</returns>
        public static bool IsByteString(string input)
        {
            for(int i = 0; i<input.Length; i+=2)
            {
                try
                {
                    Convert.ToByte(input[i] + input[i + 1]);
                } catch (Exception ex) // invalid string
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Encrypts the given text for the current user (C# ProtectedData class; Windows only)
        /// </summary>
        /// <param name="plainText">Text to be encrypted</param>
        /// <returns>The generated cipher text</returns>
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

                            cipherText = Convert.ToBase64String(ProtectedData.Protect(bytePlainText, Encoding.UTF8.GetBytes(Security.GetHashedGuid()), DataProtectionScope.CurrentUser));
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
                            plainText = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(cipherText), Encoding.UTF8.GetBytes(Security.GetHashedGuid()), DataProtectionScope.CurrentUser));

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
        /// Decrypts the provided text (C# ProtectedData class; Windows only) and directly logs errors; this is to be used in 
        /// case the events have not yet been loaded or an error causes loading errors.
        /// </summary>
        /// <param name="cipherText">Text to be decrypted</param>
        /// <returns>The plain text representation of the provided cipher-text</returns>

        internal static string DirectLoggingDecrypt(string cipherText)
        {
            string plainText = null;

            try
            {
                // platform handling for possible future extensions
                switch (System.Environment.OSVersion.Platform) // use different encryption methods or do not encrypt the data at all, depending on the OS
                {
                    case PlatformID.Win32NT: // windows
                        {
                            plainText = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(cipherText), Encoding.UTF8.GetBytes(Security.GetHashedGuid()), DataProtectionScope.CurrentUser));

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
                Diagnostics.LogDirectSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.DEC_ERROR, Diagnostics.EVENT_SEVERITY.Fatal , ex.Message);
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


        /// <summary>
        /// Checks the given file, if its extension is recognized for this
        /// </summary>
        /// <param name="filePath">Path to the file to be checked</param>
        /// <returns>A struct containing the file check results</returns>
        public static Security.FileCheckResults CheckFileIntegrity(string filePath)
        {
            bool valid = false, recognized = true;
            try
            {
                string[] filePathSegments = filePath.Split(".");

                switch (filePathSegments[filePathSegments.Length-1])
                {
                    case "appconfig": // configuration file (the useful data is in XML format)
                        {
                            // get file segments
                            Dictionary<string, string> fileSegments = Utility.GetConfigFileSegments(filePath);

                            // check file signature
                            if (Security.VerifySignature(fileSegments[Utility.ConfigFileSegmentHeaders.SIGNATURE], fileSegments[Utility.ConfigFileSegmentHeaders.XML_DATA]))
                            {
                                valid = true;
                            }

                            break;
                        }

                    default: // unrecognized => ignore file and a failure result
                        {
                            recognized = false;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_INAUTHENTIC_FILE, ex.Message);
            }

            return new Security.FileCheckResults(
                filePath,
                recognized, // recognized file
                valid // valid file
                );
        }

        /// <summary>
        /// Stores the currently approved generator IDs on the disk
        /// </summary>
        public static void StoreGeneratorIds()
        {
            try
            {
                if (Security.APPROVED_BASE_GEN_CODES.Count == 0) return; // if there are no memorized gen IDs, exit the method

                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.Encoding = Encoding.UTF8;
                xmlWriterSettings.IndentChars = "\t";
                xmlWriterSettings.NewLineChars = "\r\n";

                StringBuilder xmlText = new StringBuilder();
                XmlWriter xmlWriter = XmlWriter.Create(xmlText, xmlWriterSettings);

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("gen-ids");

                foreach(string approvedGenId in Security.APPROVED_BASE_GEN_CODES)
                {
                    xmlWriter.WriteStartElement("gen-id");
                        
                    xmlWriter.WriteAttributeString("id",approvedGenId);

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();

                xmlWriter.Close();

                File.WriteAllText(GeneralPaths.SEC_GEN_IDS_FILE_PATH,Security.Encrypt(xmlText.ToString())); //create the file anew, with the currently memorized, approved generator IDs
                
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.GENERAL_FATAL_SECURITY_ERROR, ex.Message);
            }
        }

        /// <summary>
        /// Stores the given generator ID into memory, in the list of approved generator IDs
        /// </summary>
        /// <param name="genId">Gen ID to be saved</param>
        public static void MemorizeGeneratorId(string genId)
        {
            if(!genId.Equals(null) && !genId.Equals(string.Empty))
            {
                Security.APPROVED_BASE_GEN_CODES.Add(genId);
            }
        }
    
        /// <summary>
        /// Loads the list of approved generator IDs from the disk
        /// </summary>
        /// <returns>true if the file exists, false if the file does not exist or an error occurred trying to parse it</returns>
        public static bool LoadApprovedGeneratorId()
        {
            bool validFile = false;

            try
            {
                if (File.Exists(GeneralPaths.SEC_GEN_IDS_FILE_PATH) == false) throw new Exception("Missing generator IDs file."); // the file could not be found => no data can be read

                string genIds = Security.Decrypt(File.ReadAllText(GeneralPaths.SEC_GEN_IDS_FILE_PATH));

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(genIds);
                XmlNode root = xml.DocumentElement;

                // parse generator IDs
                foreach (XmlNode node in root.ChildNodes)
                {
                    switch(node.Name)
                    {
                        case "gen-id":
                            {
                                Security.APPROVED_BASE_GEN_CODES.Add(node.Attributes["id"].Value.ToString()); // get ID and add it to the list of approvd IDs
                                validFile = true;
                                break;
                            }
                        default: // unrecognized node => ignore it
                            {
                                break;
                            }
                    }
                }
                

            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.GENERAL_FATAL_SECURITY_ERROR, ex.Message);
            }

            return validFile;
        }

        /// <summary>
        /// Stores the tokens used in this session, together with the ones stored so far, in a local file
        /// </summary>
        /// <param name="createFile">If the file does not exist, and this variable is true, it is created</param>
        public static void StoreUsedTokens(bool createFile)
        {
            try
            {
                // store tokens (used across all sessions so far)
                if (File.Exists(GeneralPaths.SEC_USED_TOKENS_FILE_PATH) == false && createFile == false) return; //=> do not create file (security)

                // parse XML file
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.Encoding = Encoding.UTF8;
                xmlWriterSettings.IndentChars = "\t";
                xmlWriterSettings.NewLineChars = "\r\n";
                StringBuilder xmlText = new StringBuilder();

                XmlWriter xmlWriter = XmlWriter.Create(xmlText, xmlWriterSettings);

                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("USED-TOKENS");

                foreach (Security.Token usedToken in Security.GetUsedTokens())
                {
                    xmlWriter.WriteStartElement("USED-TOKEN");

                    xmlWriter.WriteAttributeString("machine-id", Security.GetHashedGuid());
                    xmlWriter.WriteAttributeString("token-string", usedToken.TOKEN_STRING);

                    xmlWriter.WriteEndElement();
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();

                // unlock the file
                if (Security.SEC_USED_TOKENS_FILESTREAM != null) Security.SEC_USED_TOKENS_FILESTREAM.Close();

                // write details on the disk
                File.WriteAllText(GeneralPaths.SEC_USED_TOKENS_FILE_PATH, Security.Encrypt(xmlText.ToString()));
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_STORING_APP_EXIT_DATA, ex.Message);
            }
        }

        /// <summary>
        /// Loads into memory the tokens used so far, accross different sessions
        /// </summary>
        public static void LoadUsedSecurityTokens()
        {
            try
            {
                // read the file, if it exists
                string usedTokensPlainText = null;
                if (File.Exists(GeneralPaths.SEC_USED_TOKENS_FILE_PATH) == true)
                {
                    usedTokensPlainText = Security.Decrypt(File.ReadAllText(GeneralPaths.SEC_USED_TOKENS_FILE_PATH)); // load already used tokens in memory

                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(usedTokensPlainText);
                    XmlNode root = xml.DocumentElement;

                    foreach (XmlNode usedToken in root.ChildNodes)
                    {
                        switch (usedToken.Name)
                        {
                            case "USED-TOKEN":
                                {
                                    // verify machine id
                                    if (usedToken.Attributes["machine-id"].Value.Equals(Security.GetHashedGuid()) == true)
                                    {
                                        // create a Token object and add it to the list of used tokens
                                        Security.AddUsedToken(new Security.Token(usedToken.Attributes["token-string"].Value));
                                    }
                                    break;
                                }
                            default: // unrecognized node => ignore it
                                {
                                    break;
                                }
                        }
                    }

                    // lock file; this will be closed when the application is closed
                    Security.SEC_USED_TOKENS_FILESTREAM = File.Open(GeneralPaths.SEC_USED_TOKENS_FILE_PATH, FileMode.Open);
                }
                else // error: the used tokens file was deleted => stop application
                {
                    Diagnostics.LogEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_LOADING_USED_SEC_TOKENS);
                }
            
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERR_LOADING_USED_SEC_TOKENS, ex.Message);
            }
        }

        /// <summary>
        /// Loads local properties from the disk
        /// </summary>
        public static void LoadSecurityProperties()
        {
            if (Security.CurrentSecurityPropertiesLoaded == false)
            {
                bool adminWorkstation = false;

                try
                {
                    string plainText = Security.Decrypt(File.ReadAllText(GeneralPaths.SEC_PROPERTIES_FILE_PATH));

                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(plainText);
                    XmlNode root = xml.DocumentElement;

                    // load security properties (only valid for the current machine)
                    foreach (XmlNode node in root.ChildNodes)
                    {
                        switch (node.Name)
                        {
                            case "ADMIN-WORKSTATION":
                                {
                                    if (Security.GetHashedGuid().Equals(node.Attributes["id"].Value) == true)
                                    {
                                        adminWorkstation = Convert.ToBoolean(node.Attributes["value"].Value.ToString());
                                    }
                                    break;
                                }
                            default: // unknown property => ignore it
                                break;
                        }
                    }


                }
                catch (Exception ex)
                {
                    Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.ERROR_LOADING_SECURITY_PROPERTIES, ex.Message);
                }

                Security.CurrentSecurityProperties = new Security.SecurityProperties(
                    adminWorkstation);
                Security.CurrentSecurityPropertiesLoaded = true;

            }

        }

        /// <summary>
        /// Loads the public key used to encrypt data before being sent for analysis; should only be called on setup
        /// </summary>
        public static void LoadReportEncKey()
        {
            try
            {
                // extract and store the public key
                byte[] publicKey = Convert.FromBase64String(File.ReadAllText(GeneralPaths.SEC_PUBLIC_REPORT_ENC_KEY_FILE_PATH));

                CspParameters rsaCsp = new CspParameters();
                rsaCsp.KeyContainerName = Security.RSA_KEY_CONTAINER_NAME;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(rsaCsp);

                rsa.PersistKeyInCsp = true;
                rsa.ImportRSAPublicKey(publicKey, out _);

                // delete public key file
                File.Delete(GeneralPaths.SEC_PUBLIC_REPORT_ENC_KEY_FILE_PATH);
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.SEC_ERROR_LOADING_REPORT_ENC_KEY, ex.Message);
            }
        }

        /// <summary>
        /// Encrypts the given text using the public RSA key stored when the program was configured
        /// </summary>
        /// <param name="plainText">The plain text to be encrypted</param>
        /// <returns>The cipher text</returns>
        public static string RsaEncrypt(string plainText)
        {
            string cipherText = null;

            try
            {
                CspParameters cspRsa = new CspParameters();
                cspRsa.KeyContainerName = Security.RSA_KEY_CONTAINER_NAME;

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspRsa))
                {
                    cipherText = Convert.ToBase64String(rsa.Encrypt(Convert.FromBase64String(plainText),RSAEncryptionPadding.Pkcs1));
                }
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.SEC_DIAG_ENC_ERROR, ex.Message);
            }

            return cipherText;
        }

        /// <summary>
        /// Encrypts the specified string using AES and adds the key (RSA-encrypted)
        /// </summary>
        /// <param name="plainText">The plain text to be encrypted</param>
        /// <returns>The AES encrypted cipher text, along with the RSA-encrypted key (1st line)</returns>
        public static string AesEncrypt(string plainText)
        {
            string cipherText = null;

            try
            {
                // generate and encrypt AES key
                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = Security.AES_KEY_SIZE;
                    aes.GenerateKey();
                    aes.GenerateIV();
                    
                    cipherText = Security.RsaEncrypt(Convert.ToBase64String(aes.Key)) + "\r\n"; // key
                    cipherText += Security.RsaEncrypt(Convert.ToBase64String(aes.IV)) + "\r\n"; // IV

                    // encrypt text
                    using (MemoryStream outputStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(outputStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }
                        }

                        cipherText += Convert.ToBase64String(outputStream.ToArray());
                    }

                    

                }
            }
            catch (Exception ex)
            {
                Diagnostics.LogSilentEvent(Diagnostics.DEFAULT_IDE_ORIGIN_CODE, Diagnostics.DefaultEventCodes.SEC_DIAG_ENC_ERROR, ex.Message);
            }

            return cipherText;
        }

        /// <summary>
        /// Retrieves the GUI generated for the current machine, stored in a local file, then hashes and returns it.
        /// If the GUID was not generated before or the local file was deleted, a new GUID will be generated 
        /// (data created / updated using the previous GUIDs might not be accessible anymore!), 
        /// encrypted it for the current machine and stored in a local file.
        /// 
        /// </summary>
        /// <returns>The hashed ID or null (if an error occurs)</returns>
        public static string GetHashedGuid()
        {
            // read the generated GUID for this computer, if it exists
            string hashedGuid = null;

            if (File.Exists(GeneralPaths.SEC_HASHED_GUID_FILE_PATH) == true)
            {
                string encryptedFileText = File.ReadAllText(GeneralPaths.SEC_HASHED_GUID_FILE_PATH);
                hashedGuid = Security.GenerateHash(Convert.ToBase64String(ProtectedData.Unprotect(Convert.FromBase64String(encryptedFileText), null, DataProtectionScope.LocalMachine)));
            }
            else // generate a new GUID and store it on the disk
            {
                Guid guid = Guid.NewGuid();
            
                hashedGuid = Security.GenerateHash(Convert.ToBase64String(guid.ToByteArray())); // string

                // store the hashed, encrypted GUID
                File.WriteAllText(GeneralPaths.SEC_HASHED_GUID_FILE_PATH, Convert.ToBase64String(ProtectedData.Protect(guid.ToByteArray(), null, DataProtectionScope.LocalMachine)));
            }
            
            return hashedGuid;
        }
    }
}
