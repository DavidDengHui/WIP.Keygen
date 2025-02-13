using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace WIP.Keygen
{
    public partial class Form1 : Form
    {
        private const string SecretKey = "FreezeZL";

        public Form1()
        {
            InitializeComponent();
            this.TopMost = true;
            // 设置窗体圆角
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            // 设置默认申请号
            txtRequest.Text = WIPHelper.GetCpuID();

            // Add event handlers for focus leave events
            txtKey.Leave += new EventHandler(txtKey_Leave);
            txtRequest.Leave += new EventHandler(txtRequest_Leave);

            // Add event handlers for dragging the window
            AddDragControl(lblRequest);
            AddDragControl(lblExpiry);
            AddDragControl(lblYear);
            AddDragControl(lblMonth);
            AddDragControl(lblDay);
            AddDragControl(lblKey);
            AddDragControl(lblTitle);
            AddDragControl(lblTips);
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
                string encryptedString = WIPHelper.MD5Encrypt(plainText, SecretKey);
                txtKey.Text = encryptedString;

                // Set focus to txtKey and select all text
                txtKey.Focus();
                txtKey.SelectAll();
                Clipboard.SetText(txtKey.Text);

                lblTips.Text = "已复制！";
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
                string decryptedString = WIPHelper.MD5Decrypt(txtKey.Text, SecretKey);

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

                // Set focus to txtRequest and select all text
                txtRequest.Focus();
                txtRequest.SelectAll();

                // Change background color of date text boxes
                txtYear.BackColor = Color.GreenYellow;
                txtYear.ForeColor = Color.Black;
                txtMonth.BackColor = Color.GreenYellow;
                txtMonth.ForeColor = Color.Black;
                txtDay.BackColor = Color.GreenYellow;
                txtDay.ForeColor = Color.Black;

                lblTips.Text = "验证成功！";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"验证失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtKey_Leave(object? sender, EventArgs e)
        {
            lblTips.Text = "";
        }

        private void txtRequest_Leave(object? sender, EventArgs e)
        {
            lblTips.Text = "";

            // Reset background color of date text boxes
            txtYear.BackColor = Color.FromArgb(30, 30, 30);
            txtYear.ForeColor = Color.White;
            txtMonth.BackColor = Color.FromArgb(30, 30, 30);
            txtMonth.ForeColor = Color.White;
            txtDay.BackColor = Color.FromArgb(30, 30, 30);
            txtDay.ForeColor = Color.White;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnExit, "Alt+Q 退出");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.Q))
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region 一键激活
        private void btnOneClickRegister_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            if (IsAdministrator())
                toolTip.SetToolTip(btnOneClickRegister, "立即完成激活！注意：软件启动用户和密码都是dwduser");
            else toolTip.SetToolTip(btnOneClickRegister, "一键激活需要管理员权限，点击后请允许授权！");
        }

        private bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void RestartAsAdministrator()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                WorkingDirectory = Environment.CurrentDirectory,
                FileName = Application.ExecutablePath,
                Verb = "runas"
            };

            try
            {
                Process.Start(startInfo);
                Application.Exit();
            }
            catch
            {
                MessageBox.Show("提权失败！\n请尝试手动以管理员权限运行程序！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnOneClickRegister_Click(object sender, EventArgs e)
        {
            if (IsAdministrator())
            {
                btnGenerate_Click(sender, e);
                string valiteDate = txtKey.Text;
                bool result = WIPHelper.SetRegister(valiteDate);
                if (result)
                {
                    MessageBox.Show("仅供内部使用，请勿外传！", "激活成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("注册失败，请检查申请号！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                RestartAsAdministrator();
            }

        }
        #endregion

        #region 输入验证
        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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

        private void DateTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;

            // 处理日期输入框的导航
            if (e.KeyCode == Keys.Right)
            {
                if (textBox.SelectionStart >= textBox.Text.Length)
                {
                    if (textBox == txtYear)
                    {
                        txtMonth.Focus();
                        txtMonth.SelectionStart = 0;
                    }
                    else if (textBox == txtMonth)
                    {
                        txtDay.Focus();
                        txtDay.SelectionStart = 0;
                    }
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (textBox.SelectionStart == 0)
                {
                    if (textBox == txtDay)
                    {
                        txtMonth.Focus();
                        txtMonth.SelectionStart = txtMonth.Text.Length;
                    }
                    else if (textBox == txtMonth)
                    {
                        txtYear.Focus();
                        txtYear.SelectionStart = txtYear.Text.Length;
                    }
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Divide)
            {
                if (textBox == txtYear)
                {
                    txtMonth.Focus();
                    txtMonth.SelectAll();
                    e.Handled = true;
                }
                else if (textBox == txtMonth)
                {
                    txtDay.Focus();
                    txtDay.SelectAll();
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnGenerate_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void DateTextBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == txtKey)
                {
                    btnVerify_Click(sender, e);
                }
                else
                {
                    btnGenerate_Click(sender, e);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == btnGenerate)
                {
                    btnGenerate_Click(sender, e);
                }
                else if (sender == btnVerify)
                {
                    btnVerify_Click(sender, e);
                }
                else if (sender == btnExit)
                {
                    btnExit_Click(sender, e);
                }
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region 窗体拖动
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void AddDragControl(Control control)
        {
            control.MouseDown += new MouseEventHandler(Control_MouseDown);
        }

        private void Control_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
    }
}