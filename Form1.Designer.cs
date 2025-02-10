namespace WIP.Keygen
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblRequest;
        private TextBox txtRequest;
        private Label lblExpiry;
        private TextBox txtYear;
        private Label lblYear;
        private TextBox txtMonth;
        private Label lblMonth;
        private TextBox txtDay;
        private Label lblDay;
        private Button btnGenerate;
        private Button btnVerify;
        private Label lblKey;
        private TextBox txtKey;
        private Button btnExit;
        private Label lblTitle;
        private Button btnOneClickRegister;
        private Label lblTips;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblTitle = new Label();
            lblRequest = new Label();
            txtRequest = new TextBox();
            lblExpiry = new Label();
            txtYear = new TextBox();
            lblYear = new Label();
            txtMonth = new TextBox();
            lblMonth = new Label();
            txtDay = new TextBox();
            lblDay = new Label();
            btnGenerate = new Button();
            btnVerify = new Button();
            lblKey = new Label();
            txtKey = new TextBox();
            btnExit = new Button();
            btnOneClickRegister = new Button();
            lblTips = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(45, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(218, 22);
            lblTitle.TabIndex = 14;
            lblTitle.Text = "铁路信号配线检测软件注册机";
            // 
            // lblRequest
            // 
            lblRequest.AutoSize = true;
            lblRequest.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblRequest.ForeColor = Color.White;
            lblRequest.Location = new Point(20, 40);
            lblRequest.Name = "lblRequest";
            lblRequest.Size = new Size(54, 20);
            lblRequest.TabIndex = 0;
            lblRequest.Text = "申请号:";
            // 
            // txtRequest
            // 
            txtRequest.BackColor = Color.FromArgb(30, 30, 30);
            txtRequest.BorderStyle = BorderStyle.FixedSingle;
            txtRequest.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtRequest.ForeColor = Color.White;
            txtRequest.Location = new Point(90, 37);
            txtRequest.Name = "txtRequest";
            txtRequest.Size = new Size(200, 26);
            txtRequest.TabIndex = 1;
            txtRequest.KeyDown += TextBox_KeyDown;
            // 
            // lblExpiry
            // 
            lblExpiry.AutoSize = true;
            lblExpiry.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblExpiry.ForeColor = Color.White;
            lblExpiry.Location = new Point(20, 80);
            lblExpiry.Name = "lblExpiry";
            lblExpiry.Size = new Size(54, 20);
            lblExpiry.TabIndex = 2;
            lblExpiry.Text = "有效期:";
            // 
            // txtYear
            // 
            txtYear.BackColor = Color.FromArgb(30, 30, 30);
            txtYear.BorderStyle = BorderStyle.FixedSingle;
            txtYear.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtYear.ForeColor = Color.White;
            txtYear.Location = new Point(90, 77);
            txtYear.MaxLength = 4;
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(55, 26);
            txtYear.TabIndex = 3;
            txtYear.Text = "9999";
            txtYear.Enter += DateTextBox_Enter;
            txtYear.KeyDown += DateTextBox_KeyDown;
            txtYear.KeyPress += NumberTextBox_KeyPress;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblYear.ForeColor = Color.White;
            lblYear.Location = new Point(145, 80);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(23, 20);
            lblYear.TabIndex = 4;
            lblYear.Text = "年";
            // 
            // txtMonth
            // 
            txtMonth.BackColor = Color.FromArgb(30, 30, 30);
            txtMonth.BorderStyle = BorderStyle.FixedSingle;
            txtMonth.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtMonth.ForeColor = Color.White;
            txtMonth.Location = new Point(170, 77);
            txtMonth.MaxLength = 2;
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(35, 26);
            txtMonth.TabIndex = 5;
            txtMonth.Text = "12";
            txtMonth.Enter += DateTextBox_Enter;
            txtMonth.KeyDown += DateTextBox_KeyDown;
            txtMonth.KeyPress += NumberTextBox_KeyPress;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblMonth.ForeColor = Color.White;
            lblMonth.Location = new Point(210, 80);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(23, 20);
            lblMonth.TabIndex = 6;
            lblMonth.Text = "月";
            // 
            // txtDay
            // 
            txtDay.BackColor = Color.FromArgb(30, 30, 30);
            txtDay.BorderStyle = BorderStyle.FixedSingle;
            txtDay.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtDay.ForeColor = Color.White;
            txtDay.Location = new Point(235, 77);
            txtDay.MaxLength = 2;
            txtDay.Name = "txtDay";
            txtDay.Size = new Size(35, 26);
            txtDay.TabIndex = 7;
            txtDay.Text = "31";
            txtDay.Enter += DateTextBox_Enter;
            txtDay.KeyDown += DateTextBox_KeyDown;
            txtDay.KeyPress += NumberTextBox_KeyPress;
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblDay.ForeColor = Color.White;
            lblDay.Location = new Point(270, 80);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(23, 20);
            lblDay.TabIndex = 8;
            lblDay.Text = "日";
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.Black;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(20, 161);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(130, 35);
            btnGenerate.TabIndex = 9;
            btnGenerate.Text = "生成注册码";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            btnGenerate.KeyDown += Button_KeyDown;
            // 
            // btnVerify
            // 
            btnVerify.BackColor = Color.Black;
            btnVerify.FlatStyle = FlatStyle.Flat;
            btnVerify.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnVerify.ForeColor = Color.White;
            btnVerify.Location = new Point(155, 161);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(130, 35);
            btnVerify.TabIndex = 10;
            btnVerify.Text = "验证注册码";
            btnVerify.UseVisualStyleBackColor = false;
            btnVerify.Click += btnVerify_Click;
            btnVerify.KeyDown += Button_KeyDown;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblKey.ForeColor = Color.White;
            lblKey.Location = new Point(20, 210);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(65, 20);
            lblKey.TabIndex = 11;
            lblKey.Text = "注册码：";
            // 
            // txtKey
            // 
            txtKey.BackColor = Color.FromArgb(30, 30, 30);
            txtKey.BorderStyle = BorderStyle.FixedSingle;
            txtKey.Font = new Font("Consolas", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            txtKey.ForeColor = Color.White;
            txtKey.Location = new Point(90, 210);
            txtKey.Multiline = true;
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(200, 60);
            txtKey.TabIndex = 12;
            txtKey.KeyPress += KeyTextBox_KeyPress;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Black;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(20, 280);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(270, 35);
            btnExit.TabIndex = 13;
            btnExit.Text = "退出";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.KeyDown += Button_KeyDown;
            btnExit.MouseHover += btnExit_MouseHover;
            // 
            // btnOneClickRegister
            // 
            btnOneClickRegister.BackColor = Color.Brown;
            btnOneClickRegister.FlatStyle = FlatStyle.Flat;
            btnOneClickRegister.Font = new Font("微软雅黑", 10.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnOneClickRegister.ForeColor = Color.White;
            btnOneClickRegister.Location = new Point(20, 120);
            btnOneClickRegister.Name = "btnOneClickRegister";
            btnOneClickRegister.Size = new Size(270, 35);
            btnOneClickRegister.TabIndex = 15;
            btnOneClickRegister.Text = "一键激活";
            btnOneClickRegister.UseVisualStyleBackColor = false;
            btnOneClickRegister.Click += btnOneClickRegister_Click;
            btnOneClickRegister.MouseHover += btnOneClickRegister_MouseHover;
            // 
            // lblTips
            // 
            lblTips.AutoSize = true;
            lblTips.Font = new Font("微软雅黑", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblTips.ForeColor = Color.GreenYellow;
            lblTips.Location = new Point(20, 241);
            lblTips.Name = "lblTips";
            lblTips.Size = new Size(68, 17);
            lblTips.TabIndex = 16;
            lblTips.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(310, 330);
            Controls.Add(lblTips);
            Controls.Add(btnOneClickRegister);
            Controls.Add(lblTitle);
            Controls.Add(btnExit);
            Controls.Add(txtKey);
            Controls.Add(lblKey);
            Controls.Add(btnVerify);
            Controls.Add(btnGenerate);
            Controls.Add(lblDay);
            Controls.Add(txtDay);
            Controls.Add(lblMonth);
            Controls.Add(txtMonth);
            Controls.Add(lblYear);
            Controls.Add(txtYear);
            Controls.Add(lblExpiry);
            Controls.Add(txtRequest);
            Controls.Add(lblRequest);
            Font = new Font("微软雅黑", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Opacity = 0.8D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "铁路信号配线检测软件注册机";
            TopMost = true;
            MouseDown += Form1_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

    }
}