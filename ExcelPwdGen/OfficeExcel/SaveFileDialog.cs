using ExcelPwdGen.Forms;
using Microsoft.Office.Interop.Excel;
using System.IO;

namespace ExcelPwdGen.OfficeExcel
{
    internal class SaveFileDialog
    {
        public const string DefaultTitle = "保存先を選択してください";

        private readonly Workbook _workbook;

        private Workbook Workbook => _workbook;

        public string Title { get; private set; }
        public string InitialFilename { get; private set; }

        private readonly DialogFilter _fileFilter = new DialogFilter().SetFilterType(DialogFilter.FilterType.Office);

        private DialogFilter FileFilter => _fileFilter;

        private Application Application => _workbook.Application;

        public SaveFileDialog(Workbook workbook)
        {
            _workbook = workbook;
        }

        public SaveFileDialog SetTitle(string title)
        {
            Title = title;
            return this;
        }

        public SaveFileDialog SetInitialFilename(string initialFilename)
        {
            InitialFilename = initialFilename;
            return this;
        }

        public SaveFileDialog AddFilter(string ext, string description)
        {
            FileFilter.Add(ext, description);
            return this;
        }

        /// <summary>
        /// Show Save File Dialog.
        /// </summary>
        /// <returns>A <c>FileInfo</c> object by the path of the selected file, if any. Return <c>null</c> in case of cancellation.</returns>
        public FileInfo Show()
        {
            dynamic dialogResult = Application.GetSaveAsFilename(
                    InitialFilename: string.IsNullOrWhiteSpace(InitialFilename) ? Workbook.Name : InitialFilename,
                    Title: string.IsNullOrWhiteSpace(Title) ? DefaultTitle : Title,
                    FileFilter: FileFilter.ToString()
                );

            if (dialogResult is bool ok && !ok) return null;
            return dialogResult is string path ? new FileInfo(path) : null;
        }
    }
}