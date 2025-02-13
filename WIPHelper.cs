// WIPHelper.cs
using System;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Management;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.IO;
using IWshRuntimeLibrary;
using File = System.IO.File;

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

        private static string DetermineAppPath()
        {
            // 方案一：检查当前目录
            string currentDir = Application.StartupPath;
            string currentExePath = Path.Combine(currentDir, "WIP.AppMain.exe");
            if (File.Exists(currentExePath))
            {
                //MessageBox.Show($"方案一：当前目录存在程序，AppPath = {currentDir}", "路径方案", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return currentDir;
            }

            // 方案二：检查Program Files目录
            string programFilesPath = @"C:\Program Files (x86)\配线检测软件\WIP.AppMain.exe";
            if (File.Exists(programFilesPath))
            {
                string appPath = @"C:\Program Files (x86)\配线检测软件\";
                //MessageBox.Show($"方案二：Program Files目录存在程序，AppPath = {appPath}", "路径方案", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return appPath;
            }

            // 方案三：检查桌面快捷方式
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shortcutPath = Path.Combine(desktopPath, "配线检测软件.lnk");
            if (File.Exists(shortcutPath))
            {
                try
                {
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                    string? targetDir = Path.GetDirectoryName(shortcut.TargetPath);
                    if (!string.IsNullOrEmpty(targetDir) && Directory.Exists(targetDir))
                    {
                        //MessageBox.Show($"方案三：桌面快捷方式有效，AppPath = {targetDir}", "路径方案", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return targetDir;
                    }
                }
                catch
                {
                    // 快捷方式解析失败继续执行
                }
            }

            // 方案四：使用默认路径
            //MessageBox.Show($"方案四：使用注册机当前目录，AppPath = {currentDir}", "路径方案", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return currentDir;
        }

        public static bool SetRegister(string valiteDate)
        {
            try
            {
                string text = "SOFTWARE\\THCSoftware\\Signal";
                string text2 = MD5Decrypt(valiteDate.ToString(), "FreezeZL");
                string[] array = text2.Split('_');
                if (GetCpuID() == array[0])
                {
                    DateTime dateTime = DateTime.Parse(array[1]);
                    DateTime now = DateTime.Now;
                    RegistryKey? registryKey = Registry.LocalMachine.OpenSubKey(text, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.FullControl);
                    if (registryKey == null)
                    {
                        registryKey = Registry.LocalMachine.CreateSubKey(text, RegistryKeyPermissionCheck.ReadWriteSubTree);
                    }

                    // 获取并设置AppPath
                    string appPath = DetermineAppPath();

                    registryKey.SetValue("Version", "1.0", RegistryValueKind.String);
                    registryKey.SetValue("Author", "WIP", RegistryValueKind.String);
                    registryKey.SetValue("InstallDateWIP", DateTime.Now.ToString(), RegistryValueKind.String);
                    registryKey.SetValue("AppPath", appPath, RegistryValueKind.String);
                    registryKey.SetValue("ValiteDateWIP", valiteDate, RegistryValueKind.String);

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}