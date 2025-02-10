// WIPHelper.cs
using System.Security.Cryptography;
using System.Text;
using System.Management;

namespace WIP.Keygen
{
    public static class WIPHelper
    {
        public static string MD5Encrypt(string pToEncrypt, string sKey)
        {
            DES dESCryptoServiceProvider = DES.Create();
            byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
            dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
            dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(bytes, 0, bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            byte[] array = memoryStream.ToArray();
            foreach (byte b in array)
            {
                stringBuilder.AppendFormat("{0:X2}", b);
            }
            return stringBuilder.ToString();
        }

        public static string MD5Decrypt(string pToDecrypt, string sKey)
        {
            string @string;
            try
            {
                DES dESCryptoServiceProvider = DES.Create();
                byte[] array = new byte[pToDecrypt.Length / 2];
                for (int i = 0; i < pToDecrypt.Length / 2; i++)
                {
                    int num = Convert.ToInt32(pToDecrypt.Substring(i * 2, 2), 16);
                    array[i] = (byte)num;
                }
                dESCryptoServiceProvider.Key = Encoding.ASCII.GetBytes(sKey);
                dESCryptoServiceProvider.IV = Encoding.ASCII.GetBytes(sKey);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
                cryptoStream.Write(array, 0, array.Length);
                cryptoStream.FlushFinalBlock();
                StringBuilder stringBuilder = new StringBuilder();
                @string = Encoding.Default.GetString(memoryStream.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("Error during decryption", ex);
            }
            return @string;
        }

        public static string GetCpuID()
        {
            try
            {
                string cpuInfo = "BFEBFBFF000B0672";
                ManagementClass val = new ManagementClass("Win32_Processor");
                ManagementObjectCollection instances = val.GetInstances();
                using (ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = instances.GetEnumerator())
                {
                    if (managementObjectEnumerator.MoveNext())
                    {
                        ManagementObject mo = (ManagementObject)managementObjectEnumerator.Current;
                        cpuInfo = mo.Properties["ProcessorId"].Value?.ToString() ?? "BFEBFBFF000B0672";
                    }
                }
                return cpuInfo;
            }
            catch
            {
                return "BFEBFBFF000B0672";
            }
        }

    }
}