using ExcelPwdGen.Forms;
using Microsoft.Office.Interop.Excel;
using System;

namespace ExcelPwdGen.OfficeExcel
{
    internal class ExcelWorkbookService
    {
        private readonly Application _application;

        private Workbook ActiveWorkbook => _application.ActiveWorkbook;

        public ExcelWorkbookService(Application app)
        {
            _application = app ?? throw new ArgumentNullException(nameof(app));
        }

        public void DoSave()
        {
            using (var wb = new ExcelWorkbook(ActiveWorkbook))
            {
                if (wb.Exists)
                {
                    DoSave(wb);
                }
                else
                {
                    DoSaveAs(wb);
                }
            }
        }

        public void DoSave(ExcelWorkbook wb)
        {
            wb.Save();
        }

        public void DoSaveAs()
        {
            using (var wb = new ExcelWorkbook(ActiveWorkbook))
            {
                DoSaveAs(wb);
            }
        }

        private void DoSaveAs(ExcelWorkbook wb)
        {
            var sd = new SaveFileDialog(wb.Workbook)
                .AddFilter(".xlsx", "Excel Workbook")
                .AddFilter(".xlsm", "Excel Macro-Enabled Workbook");

            var saveFi = sd.Show();
            if (saveFi == null) return;

            var pd = new PasswordDialog();
            var pdRes = pd.ShowDialogWithResult();
            if (!pdRes.IsOk()) return;

            var savePath = saveFi.FullName;
            var password = pdRes.Password;
            wb.ReadOnlyRecommended = pdRes.IsReadOnlyRecommended();
            wb.SaveAs(savePath, password);
            if (pdRes.IsReadOnly())
            {
                wb.Close();
                saveFi.IsReadOnly = true;
                using (var _ = ExcelWorkbook.Open(_application, savePath, password)) { }
            }
        }
    }
}