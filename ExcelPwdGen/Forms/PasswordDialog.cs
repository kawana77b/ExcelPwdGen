using ExcelPwdGen.Utils.Security;
using System;
using System.Windows.Forms;

namespace ExcelPwdGen.Forms
{
    public partial class PasswordDialog : Form
    {
        public class ExtraDialogResult
        {
            public string Password { get; private set; } = string.Empty;
            public ReadOptions.ReadOption ReadOption { get; private set; } = ReadOptions.ReadOption.None;

            public DialogResult DialogResult { get; private set; } = DialogResult.Cancel;

            public ExtraDialogResult(string password, ReadOptions.ReadOption readOption, DialogResult dialogResult)
            {
                Password = password;
                ReadOption = readOption;
                DialogResult = dialogResult;
            }

            public bool IsOk() => DialogResult == DialogResult.OK;

            public bool IsReadOnly() => ReadOption == ReadOptions.ReadOption.ReadOnly;

            public bool IsReadOnlyRecommended() => ReadOption == ReadOptions.ReadOption.ReadOnlyRecommended;
        }

        private ReadOptions.Item SelectedReadOnlyItem => (ReadOptions.Item)ROComboBox.SelectedItem;

        private string PasswordText
        {
            get { return PwdTextbox.Text; }
            set { PwdTextbox.Text = value; }
        }

        public PasswordDialog()
        {
            InitializeComponent();

            // ComboBox
            ROComboBox.DisplayMember = "Name";
            ROComboBox.ValueMember = "Value";
            ROComboBox.DataSource = ReadOptions.Options;
            ROComboBox.SelectedIndex = 0;

            UpdateGeneratedPassword();
        }

        /// <summary>
        /// Works the same as <c>ShowDialog</c>, but gets additional information as a return value.
        /// </summary>
        /// <returns></returns>
        public ExtraDialogResult ShowDialogWithResult()
        {
            var res = ShowDialog();
            return GetExtraResult(res);
        }

        private ExtraDialogResult GetExtraResult(DialogResult res)
            => new ExtraDialogResult(PasswordText, SelectedReadOnlyItem.Value, res);

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var (ok, _) = new ExcelPassword(PasswordText).Validate();
            if (!ok)
            {
                MessageBox.Show(
                    $"半角アルファベット大文字・小文字・数字・記号を混ぜた{ExcelPassword.MinLength}字以上{ExcelPassword.MaxLength}字以下で入力してください",
                    "設定パスワードが正しくありません",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var dialog = new PasswordConfirmDialog();
            dialog.SetCorrectPassword(PasswordText);
            if (dialog.ShowDialog() != DialogResult.OK) return;

            DialogResult = DialogResult.OK;

            Close();
        }

        private void PwdGenBtn_Click(object sender, EventArgs e)
        {
            UpdateGeneratedPassword();
        }

        private void CopyBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordText))
            {
                Clipboard.SetText(PasswordText);
            }
        }

        private void UpdateGeneratedPassword()
        {
            PasswordText = ExcelPassword.Generate().ToString();
        }
    }
}