using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Admin_Utility.Security;

namespace Admin_Utility
{
    /// <summary>
    /// Handles security-relevant avtions
    /// </summary>
    internal static class Security
    {
        private static string GeneratorId { get; set; } = null;

        internal enum AccessLevel { NONE = 0, ADMIN = 1, USER = 2 , ADMIN_WORKSTATION = 3};
        
        internal static string[] TokenExpirationLimits = // seconds
        {
            Token.MIN_EXPIRATION_LIMIT.ToString(),
            ((int)Token.MAX_EXPIRATION_LIMIT/2).ToString(),
            Token.MAX_EXPIRATION_LIMIT.ToString()

        };
        /// <summary>
        /// Defines a token; fields are separeted by 'Token.FIELD_SEPARATOR'
        /// </summary>
        internal class Token
        {
            internal const char FIELD_SEPARATOR = '-';
            internal const int MIN_EXPIRATION_LIMIT = 60; // the minimum number of seconds from a token's generation until it expires
            internal const int MAX_EXPIRATION_LIMIT = 21600; // the maximum time expiration limit (seconds)
            
            private DateTime TS { get; } = DateTime.MaxValue; // time stamp
            private Security.AccessLevel ACCESS_LEVEL { get; } = Security.AccessLevel.NONE;
            private string ID { get; } = null; // code used to verify the validity of the token
            private int EXPIRATION_LIMIT_SEC = 0; // the number of seconds from the token's generation until it expires and can no longer be used
            private bool VALID { get; } = false; // valid generation flag
            /// <summary>
            /// Generates a new token which grants the specified access level
            /// </summary>
            /// <param name="accessLevel">Access to be provided by the token</param>
            internal Token(string accessLevel, int expirationLimitSec)
            {
                // assign fields
                if (Enum.IsDefined(typeof(Security.AccessLevel), accessLevel) == false) //=> unrecognized access level code
                {
                    MessageBox.Show($"Access level code {accessLevel} is undefined!", "Unrecognized Access Level Code", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.VALID = false;
                }else if (expirationLimitSec < Token.MIN_EXPIRATION_LIMIT)
                {
                    MessageBox.Show($"The expiration time limit {expirationLimitSec}s is lower than the minimum of {Token.MIN_EXPIRATION_LIMIT}s !", "Invalid Token Expiration Limit", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.VALID = false;
                }else if (expirationLimitSec > Token.MAX_EXPIRATION_LIMIT)
                {
                    MessageBox.Show($"The expiration time limit {expirationLimitSec}s is higher than the maximum of {Token.MAX_EXPIRATION_LIMIT}s !", "Invalid Token Expiration Limit", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    this.VALID = false;
                }
                else
                {
                    this.TS = DateTime.UtcNow;

                    this.ID = Security.GenerateHash(this.TS.ToString() + Security.GeneratorId);

                    this.ACCESS_LEVEL = (Security.AccessLevel)Enum.Parse(typeof(Security.AccessLevel),accessLevel);

                    this.EXPIRATION_LIMIT_SEC = expirationLimitSec;

                    this.VALID = true;
                }

            }

            /// <summary>
            /// Returns the string representation of the current Token object
            /// </summary>
            /// <returns>Token string or null, if the token is invalid</returns>
            internal string ToString()
            {
                string tokenString = null;

                if (this.VALID == true)
                {
                    tokenString =
                            Convert.ToBase64String(Encoding.UTF8.GetBytes(this.ID))                         + Token.FIELD_SEPARATOR +   // field 0
                            Convert.ToBase64String(Encoding.UTF8.GetBytes(this.TS.ToString()))              + Token.FIELD_SEPARATOR +   // field 1
                            Convert.ToBase64String(Encoding.UTF8.GetBytes(this.ACCESS_LEVEL.ToString()))    + Token.FIELD_SEPARATOR +   // field 2
                            Convert.ToBase64String(Encoding.UTF8.GetBytes(this.EXPIRATION_LIMIT_SEC.ToString()));                       // field 3
                }

                return tokenString;
            }
        
        }


        /// <summary>
        /// Generates the hash for the provided input text
        /// </summary>
        /// <param name="input">Text to be hashed</param>
        /// <returns>Hashed text or null</returns>
        internal static string GenerateHash(string input)
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
                MessageBox.Show($"Details: {e.Message}","Hash Generation Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            return cipherText;
        }
        
        /// <summary>
        /// Generates the machine's generator base ID
        /// </summary>
        /// <param name="developmentToken">if true, the development generator id will be used</param>
        /// <returns>The machine's generator ID</returns>
        internal static string GetGeneratorId(bool developmentToken)
        {
            //=// Generate ID
            string id = null;

            if (developmentToken == true)
            {
                id = "DEVELOPMENT";
            }
            else //=> use development generator ID (not usable for released versions of the target application)
            {
                ManagementClass mng = new ManagementClass("Win32_ComputerSystemProduct");

                foreach (ManagementObject obj in mng.GetInstances())
                {
                    id = obj.Properties["UUID"].Value.ToString(); //=> get the machine UUID


                    id = id.Replace("-", ""); //=> remove separators
                }
            }

            Security.GeneratorId = Security.GenerateHash(id); //=> store ID
            

            return Security.GeneratorId;
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
        /// Generates a new token, with the specified access level and returns its string representation
        /// </summary>
        /// <param name="accessLevel">Access to be granted</param>
        /// <returns>The generated token string</returns>
        internal static string GenerateToken(string accessLevel, string expirationLimitSec)
        {
            int intExpirationLimitSec = 0;

            if(accessLevel.Equals(string.Empty)) // valud checked since it is passed to the Token generator; the expiration limit is checked in more detail when the token is generated
            {
                MessageBox.Show($"Invalid access level selected for token generation: {accessLevel}","Invalid access level selected",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            if(Int32.TryParse(expirationLimitSec, out intExpirationLimitSec) == false)
            {
                MessageBox.Show($"Invalid access level selected for token generation: {accessLevel}", "Invalid access level selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            Token token = new Token(accessLevel, intExpirationLimitSec); //=> generate new token

            // store the token generation detailsin the database
            //TODO: Implement security database tables

            // return token string
            if (token != null)
            {
                return token.ToString();
            }
            else
            {
                return null;
            }
            
        }
        

    }
}
