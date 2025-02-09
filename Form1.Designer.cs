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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRequest = new System.Windows.Forms.Label();
            this.txtRequest = new System.Windows.Forms.TextBox();
            this.lblExpiry = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.lblDay = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(45, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 22);
            this.lblTitle.TabIndex = 14;
            this.lblTitle.Text = "铁路信号配线检测软件注册机";
            // 
            // lblRequest
            // 
            this.lblRequest.AutoSize = true;
            this.lblRequest.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblRequest.ForeColor = System.Drawing.Color.White;
            this.lblRequest.Location = new System.Drawing.Point(20, 40);
            this.lblRequest.Name = "lblRequest";
            this.lblRequest.Size = new System.Drawing.Size(65, 20);
            this.lblRequest.TabIndex = 0;
            this.lblRequest.Text = "申请号:";
            // 
            // txtRequest
            // 
            this.txtRequest.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequest.ForeColor = System.Drawing.Color.White;
            this.txtRequest.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtRequest.Location = new System.Drawing.Point(90, 37);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.Size = new System.Drawing.Size(200, 26);
            this.txtRequest.TabIndex = 1;
            this.txtRequest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // lblExpiry
            // 
            this.lblExpiry.AutoSize = true;
            this.lblExpiry.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblExpiry.ForeColor = System.Drawing.Color.White;
            this.lblExpiry.Location = new System.Drawing.Point(20, 80);
            this.lblExpiry.Name = "lblExpiry";
            this.lblExpiry.Size = new System.Drawing.Size(51, 20);
            this.lblExpiry.TabIndex = 2;
            this.lblExpiry.Text = "有效期:";
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.ForeColor = System.Drawing.Color.White;
            this.txtYear.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtYear.Location = new System.Drawing.Point(90, 77);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(55, 26);
            this.txtYear.TabIndex = 3;
            this.txtYear.Text = "9999";
            this.txtYear.Enter += new System.EventHandler(this.DateTextBox_Enter);
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberTextBox_KeyPress);
            this.txtYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateTextBox_KeyDown);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblYear.ForeColor = System.Drawing.Color.White;
            this.lblYear.Location = new System.Drawing.Point(145, 80);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(23, 20);
            this.lblYear.TabIndex = 4;
            this.lblYear.Text = "年";
            // 
            // txtMonth
            // 
            this.txtMonth.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMonth.ForeColor = System.Drawing.Color.White;
            this.txtMonth.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtMonth.Location = new System.Drawing.Point(170, 77);
            this.txtMonth.MaxLength = 2;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(35, 26);
            this.txtMonth.TabIndex = 5;
            this.txtMonth.Text = "12";
            this.txtMonth.Enter += new System.EventHandler(this.DateTextBox_Enter);
            this.txtMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberTextBox_KeyPress);
            this.txtMonth.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateTextBox_KeyDown);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblMonth.ForeColor = System.Drawing.Color.White;
            this.lblMonth.Location = new System.Drawing.Point(210, 80);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(23, 20);
            this.lblMonth.TabIndex = 6;
            this.lblMonth.Text = "月";
            // 
            // txtDay
            // 
            this.txtDay.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDay.ForeColor = System.Drawing.Color.White;
            this.txtDay.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.txtDay.Location = new System.Drawing.Point(235, 77);
            this.txtDay.MaxLength = 2;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(35, 26);
            this.txtDay.TabIndex = 7;
            this.txtDay.Text = "31";
            this.txtDay.Enter += new System.EventHandler(this.DateTextBox_Enter);
            this.txtDay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberTextBox_KeyPress);
            this.txtDay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DateTextBox_KeyDown);
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblDay.ForeColor = System.Drawing.Color.White;
            this.lblDay.Location = new System.Drawing.Point(270, 80);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(23, 20);
            this.lblDay.TabIndex = 8;
            this.lblDay.Text = "日";
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(20, 120);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(135, 35);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "生成注册码";
            this.btnGenerate.UseVisualStyleBackColor = false;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            this.btnGenerate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_KeyDown);
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.SeaGreen;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.Location = new System.Drawing.Point(155, 120);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(135, 35);
            this.btnVerify.TabIndex = 10;
            this.btnVerify.Text = "验证注册码";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            this.btnVerify.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_KeyDown);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lblKey.ForeColor = System.Drawing.Color.White;
            this.lblKey.Location = new System.Drawing.Point(20, 170);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(65, 20);
            this.lblKey.TabIndex = 11;
            this.lblKey.Text = "注册码：";
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey.ForeColor = System.Drawing.Color.White;
            this.txtKey.Font = new System.Drawing.Font("Consolas", 10.5F);
            this.txtKey.Location = new System.Drawing.Point(90, 170);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(200, 60);
            this.txtKey.TabIndex = 12;
            this.txtKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyTextBox_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Brown;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(20, 240);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(270, 35);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button_KeyDown);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
            this.ClientSize = new System.Drawing.Size(310, 290);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.lblExpiry);
            this.Controls.Add(this.txtRequest);
            this.Controls.Add(this.lblRequest);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.8;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "铁路信号配线检测软件注册机";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}