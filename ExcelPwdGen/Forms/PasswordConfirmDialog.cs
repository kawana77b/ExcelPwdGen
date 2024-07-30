using System;
using System.Windows.Forms;
using ExcelPwdGen.Utils.Security;

namespace ExcelPwdGen.Forms
{
    public partial class PasswordConfirmDialog : Form
    {
        private string CorrectPassword { get; set; } = string.Empty;

        private string PasswordText
        {
            get => PwdTextbox.Text;
            set => PwdTextbox.Text = value;
        }

        private bool IsPasswordValid
            => new ExcelPassword(CorrectPassword).Equals(new ExcelPassword(PasswordText));

        public PasswordConfirmDialog()
        {
            InitializeComponent();
            PwdTextbox.UseSystemPasswordChar = true;
        }

        public PasswordConfirmDialog(string password) : this()
        {
            SetCorrectPassword(password);
        }

        public void SetCorrectPassword(string password)
        {
            CorrectPassword = password;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (!IsPasswordValid)
            {
                MessageBox.Show("入力したパスワードが異なります");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}