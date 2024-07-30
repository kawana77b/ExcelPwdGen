namespace ExcelPwdGen.Forms
{
    partial class PasswordDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PwdLabel = new System.Windows.Forms.Label();
            this.PwdTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ROComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PwdGenBtn = new System.Windows.Forms.Button();
            this.CopyBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PwdLabel
            // 
            this.PwdLabel.AutoSize = true;
            this.PwdLabel.Location = new System.Drawing.Point(24, 12);
            this.PwdLabel.Name = "PwdLabel";
            this.PwdLabel.Size = new System.Drawing.Size(54, 12);
            this.PwdLabel.TabIndex = 0;
            this.PwdLabel.Text = "Password";
            // 
            // PwdTextbox
            // 
            this.PwdTextbox.Location = new System.Drawing.Point(87, 9);
            this.PwdTextbox.Name = "PwdTextbox";
            this.PwdTextbox.Size = new System.Drawing.Size(281, 19);
            this.PwdTextbox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ROComboBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.PwdLabel);
            this.panel1.Controls.Add(this.PwdTextbox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 107);
            this.panel1.TabIndex = 2;
            // 
            // ROComboBox
            // 
            this.ROComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ROComboBox.FormattingEnabled = true;
            this.ROComboBox.Location = new System.Drawing.Point(247, 37);
            this.ROComboBox.Name = "ROComboBox";
            this.ROComboBox.Size = new System.Drawing.Size(121, 20);
            this.ROComboBox.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.PwdGenBtn);
            this.panel2.Controls.Add(this.CopyBtn);
            this.panel2.Controls.Add(this.SaveBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(393, 34);
            this.panel2.TabIndex = 2;
            // 
            // PwdGenBtn
            // 
            this.PwdGenBtn.Location = new System.Drawing.Point(141, 3);
            this.PwdGenBtn.Name = "PwdGenBtn";
            this.PwdGenBtn.Size = new System.Drawing.Size(115, 23);
            this.PwdGenBtn.TabIndex = 0;
            this.PwdGenBtn.Text = "パスワード生成";
            this.PwdGenBtn.UseVisualStyleBackColor = true;
            this.PwdGenBtn.Click += new System.EventHandler(this.PwdGenBtn_Click);
            // 
            // CopyBtn
            // 
            this.CopyBtn.Location = new System.Drawing.Point(268, 3);
            this.CopyBtn.Name = "CopyBtn";
            this.CopyBtn.Size = new System.Drawing.Size(115, 23);
            this.CopyBtn.TabIndex = 0;
            this.CopyBtn.Text = "クリップボードにコピー";
            this.CopyBtn.UseVisualStyleBackColor = true;
            this.CopyBtn.Click += new System.EventHandler(this.CopyBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(14, 3);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(115, 23);
            this.SaveBtn.TabIndex = 0;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 107);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "パスワードを設定";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PwdLabel;
        private System.Windows.Forms.TextBox PwdTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button PwdGenBtn;
        private System.Windows.Forms.Button CopyBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.ComboBox ROComboBox;
    }
}