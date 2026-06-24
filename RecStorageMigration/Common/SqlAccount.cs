using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Common
{
    public class SqlAccount
    {
        /// <summary>암호화된 MSSQL 계정을 복호화합니다.</summary>
        /// <param name="sqlAccount">암호화된 MSSQL 계정</param>
        /// <returns>복호화된 MSSQL 계정</returns>
        public String DecodeSqlAccount(String sqlAccount)
        {
            int asciiCodeValue;
            String asciiCodeChar;
            String asciiCodeString;
            String forward;
            String back;
            String decodeSqlAccount;

            sqlAccount = sqlAccount.Trim();

            if (sqlAccount.Length < 4)
            {
                return decodeSqlAccount = "";
            }

            forward = sqlAccount.Substring(sqlAccount.Length - 3, 3);
            back = sqlAccount.Substring(0, sqlAccount.Length - 3);
            sqlAccount = forward + back;

            if (sqlAccount.Substring(0, 1) != "1")
            {
                return decodeSqlAccount = "";
            }

            sqlAccount = sqlAccount.Substring(1);

            if ((sqlAccount.Length % 3) != 0)
            {
                return decodeSqlAccount = "";
            }

            asciiCodeString = "";

            for (int loop = 0; loop < sqlAccount.Length; loop = loop + 3)
            {
                asciiCodeValue = Convert.ToInt32(sqlAccount.Substring(loop, 3));
                asciiCodeChar = Convert.ToChar(asciiCodeValue).ToString();
                asciiCodeString = asciiCodeString + asciiCodeChar;
            }
            decodeSqlAccount = asciiCodeString;
            return decodeSqlAccount;
        }

        /// <summary>MSSQL 계정을 암호화합니다.</summary>
        /// <param name="sqlAccount">MSSQL 계정</param>
        /// <returns>암호화된 MSSQL 계정</returns>
        public String EncodeSqlAccount(String sqlAccount)
        {
            int asciiCodeValue;
            String asciiCodeChar;
            String asciiCodeString;
            String forward;
            String back;
            String encodeSqlAccount;

            if (sqlAccount == "")
                return "";

            sqlAccount = sqlAccount.Trim();

            asciiCodeString = "";

            for (int loopA = 0; loopA < sqlAccount.Length; loopA++)
            {
                asciiCodeChar = sqlAccount.Substring(loopA, 1);
                asciiCodeValue = Convert.ToChar(asciiCodeChar);
                asciiCodeChar = asciiCodeValue.ToString();

                if (asciiCodeChar.Length <= 3)
                {
                    for (int loopB = 0; loopB < 3 - asciiCodeChar.Length; loopB++)
                    {
                        asciiCodeChar = "0" + asciiCodeChar;
                    }
                }

                asciiCodeString = asciiCodeString + asciiCodeChar;
            }

            asciiCodeString = "1" + asciiCodeString;

            forward = asciiCodeString.Substring(0, 3);
            back = asciiCodeString.Substring(3);

            encodeSqlAccount = back + forward;
            return encodeSqlAccount;
        }


        // AES256 암호화 함수
        public string AES256ENC(string strOrigin)
        {
            try
            {
                if (strOrigin == "")
                    return "";

                RijndaelManaged AES256 = new RijndaelManaged
                {
                    KeySize = 256,
                    BlockSize = 128,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    Key = Encoding.UTF8.GetBytes("betterwaybetterworldluciswelcome"),
                    IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

                ICryptoTransform ENC = AES256.CreateEncryptor(AES256.Key, AES256.IV);
                byte[] bytENCBuf = null;
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, ENC, CryptoStreamMode.Write))
                    {
                        byte[] bytXML = Encoding.UTF8.GetBytes(strOrigin);
                        cs.Write(bytXML, 0, bytXML.Length);
                    }
                    bytENCBuf = ms.ToArray();
                }
                AES256.Dispose();
                return Convert.ToBase64String(bytENCBuf);
            }
            catch (Exception ex)
            {
                return "ENC_ERROR";
            }
        }


        // AES256 복호화 함수
        public string AES256DEC(string strEncrypt)
        {
            try
            {
                if (strEncrypt == "")
                    return "";

                RijndaelManaged AES256 = new RijndaelManaged
                {
                    KeySize = 256,
                    BlockSize = 128,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7,
                    Key = Encoding.UTF8.GetBytes("betterwaybetterworldluciswelcome"),
                    IV = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

                ICryptoTransform DEC = AES256.CreateDecryptor();
                byte[] bytDECBuf = null;
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, DEC, CryptoStreamMode.Write))
                    {
                        byte[] bytXML = Convert.FromBase64String(strEncrypt);
                        cs.Write(bytXML, 0, bytXML.Length);
                    }
                    bytDECBuf = ms.ToArray();
                }
                AES256.Dispose();
                return Encoding.UTF8.GetString(bytDECBuf);
            }
            catch (Exception ex)
            {
                return "DEC_ERROR";
            }
        }
    }
}
