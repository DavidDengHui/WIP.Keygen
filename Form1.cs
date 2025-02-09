using System;
using System.Windows.Forms;

namespace WIP.Keygen
{
    public partial class Form1 : Form
    {
        private const string SecretKey = "FreezeZL";

        public Form1()
        {
            InitializeComponent();
            // 设置默认日期
            txtYear.Text = "9999";
            txtMonth.Text = "12";
            txtDay.Text = "31";
        }

        private string BuildExpiryDate()
        {
            return $"{txtYear.Text.Trim()}/{txtMonth.Text.Trim()}/{txtDay.Text.Trim()}";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRequest.Text))
            {
                MessageBox.Show("请输入申请号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string plainText = $"{txtRequest.Text.Trim()}_{BuildExpiryDate()}";
                string encryptedString = MD5Helper.MD5Encrypt(plainText, SecretKey);
                txtKey.Text = encryptedString;

                // 自动复制并提示
                txtKey.SelectAll();
                Clipboard.SetText(txtKey.Text);
                MessageBox.Show("已复制注册码！\n注意：激活后软件默认用户名和密码都是dwduser",
                                "提示",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"生成失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKey.Text))
            {
                MessageBox.Show("请输入注册码！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string decryptedString = MD5Helper.MD5Decrypt(txtKey.Text, SecretKey);

                if (!decryptedString.Contains("_"))
                {
                    throw new Exception("无效的注册码格式");
                }

                string[] parts = decryptedString.Split('_');
                if (parts.Length != 2)
                {
                    throw new Exception("注册码验证失败");
                }

                txtRequest.Text = parts[0];
                string[] dateParts = parts[1].Split('/');
                if (dateParts.Length != 3)
                {
                    throw new Exception("有效期格式错误");
                }

                txtYear.Text = dateParts[0];
                txtMonth.Text = dateParts[1];
                txtDay.Text = dateParts[2];

                MessageBox.Show($"该注册码验证成功，有效期到{dateParts[0]}年{dateParts[1]}月{dateParts[2]}日！",
                                "验证成功",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"验证失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyAllowLettersAndDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void InputFields_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGenerate_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void KeyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                btnVerify_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}