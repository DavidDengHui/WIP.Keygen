using System.Drawing;
using System.Windows.Forms;

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
            SuspendLayout();
            // 
            // lblRequest
            // 
            lblRequest.AutoSize = true;
            lblRequest.Location = new Point(18, 20);
            lblRequest.Name = "lblRequest";
            lblRequest.Size = new Size(47, 17);
            lblRequest.TabIndex = 0;
            lblRequest.Text = "申请号:";
            // 
            // txtRequest
            // 
            txtRequest.Location = new Point(79, 17);
            txtRequest.Name = "txtRequest";
            txtRequest.Size = new Size(176, 23);
            txtRequest.TabIndex = 1;
            txtRequest.KeyDown += InputFields_KeyDown;
            txtRequest.KeyPress += OnlyAllowLettersAndDigits;
            // 
            // lblExpiry
            // 
            lblExpiry.AutoSize = true;
            lblExpiry.Location = new Point(18, 54);
            lblExpiry.Name = "lblExpiry";
            lblExpiry.Size = new Size(47, 17);
            lblExpiry.TabIndex = 2;
            lblExpiry.Text = "有效期:";
            // 
            // txtYear
            // 
            txtYear.Location = new Point(79, 51);
            txtYear.MaxLength = 4;
            txtYear.Name = "txtYear";
            txtYear.Size = new Size(40, 23);
            txtYear.TabIndex = 3;
            txtYear.KeyDown += InputFields_KeyDown;
            txtYear.KeyPress += OnlyAllowLettersAndDigits;
            // 
            // lblYear
            // 
            lblYear.AutoSize = true;
            lblYear.Location = new Point(125, 54);
            lblYear.Name = "lblYear";
            lblYear.Size = new Size(20, 17);
            lblYear.TabIndex = 4;
            lblYear.Text = "年";
            // 
            // txtMonth
            // 
            txtMonth.Location = new Point(152, 51);
            txtMonth.MaxLength = 2;
            txtMonth.Name = "txtMonth";
            txtMonth.Size = new Size(26, 23);
            txtMonth.TabIndex = 5;
            txtMonth.KeyDown += InputFields_KeyDown;
            txtMonth.KeyPress += OnlyAllowLettersAndDigits;
            // 
            // lblMonth
            // 
            lblMonth.AutoSize = true;
            lblMonth.Location = new Point(181, 54);
            lblMonth.Name = "lblMonth";
            lblMonth.Size = new Size(20, 17);
            lblMonth.TabIndex = 6;
            lblMonth.Text = "月";
            // 
            // txtDay
            // 
            txtDay.Location = new Point(206, 51);
            txtDay.MaxLength = 2;
            txtDay.Name = "txtDay";
            txtDay.Size = new Size(26, 23);
            txtDay.TabIndex = 7;
            txtDay.KeyDown += InputFields_KeyDown;
            txtDay.KeyPress += OnlyAllowLettersAndDigits;
            // 
            // lblDay
            // 
            lblDay.AutoSize = true;
            lblDay.Location = new Point(235, 54);
            lblDay.Name = "lblDay";
            lblDay.Size = new Size(20, 17);
            lblDay.TabIndex = 8;
            lblDay.Text = "日";
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(18, 85);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(118, 30);
            btnGenerate.TabIndex = 9;
            btnGenerate.Text = "生成注册码";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            btnGenerate.KeyDown += InputFields_KeyDown;
            // 
            // btnVerify
            // 
            btnVerify.Location = new Point(136, 85);
            btnVerify.Name = "btnVerify";
            btnVerify.Size = new Size(118, 30);
            btnVerify.TabIndex = 10;
            btnVerify.Text = "验证注册码";
            btnVerify.UseVisualStyleBackColor = true;
            btnVerify.Click += btnVerify_Click;
            btnVerify.KeyDown += btnVerify_Click;
            // 
            // lblKey
            // 
            lblKey.AutoSize = true;
            lblKey.Location = new Point(18, 128);
            lblKey.Name = "lblKey";
            lblKey.Size = new Size(56, 17);
            lblKey.TabIndex = 11;
            lblKey.Text = "注册码：";
            // 
            // txtKey
            // 
            txtKey.Location = new Point(79, 128);
            txtKey.Multiline = true;
            txtKey.Name = "txtKey";
            txtKey.Size = new Size(176, 52);
            txtKey.TabIndex = 12;
            txtKey.KeyPress += KeyTextBox_KeyPress;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(271, 196);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "WIP.注册机";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}