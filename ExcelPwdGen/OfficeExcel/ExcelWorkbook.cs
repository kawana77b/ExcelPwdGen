using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace ExcelPwdGen.OfficeExcel
{
    /// <summary>
    /// Perform basic Excel workbook operations.
    /// </summary>
    /// <remarks>
    /// this class implements <c>IDisposable</c>
    /// </remarks>
    internal class ExcelWorkbook : IDisposable
    {
        /// <summary>
        /// Open Excel Workbook
        /// </summary>
        /// <param name="path"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public static ExcelWorkbook Open(Application app, string path, string password = null)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("File not found", path);
            if (app == null) throw new ArgumentNullException(nameof(app));

            var workbook = OpenWorkbook(app, path, password);
            return new ExcelWorkbook(workbook);
        }

        private static Workbook OpenWorkbook(Application app, string path, string password = null)
        {
            if (password == null)
                return app.Workbooks.Open(path);
            else
                return app.Workbooks.Open(path, Password: password);
        }

        private Workbook _workbook = null;

        /// <summary>
        /// Check if Excel Workbook is Set
        /// </summary>
        public bool IsSet => _workbook != null;

        public Workbook Workbook => _workbook;

        /// <summary>
        /// Get Excel Workbook Full path
        /// </summary>
        public string FullName => _workbook.FullName;

        /// <summary>
        /// Check if Excel Workbook File Exists
        /// </summary>
        public bool Exists => File.Exists(FullName);

        public string _password = string.Empty;

        /// <summary>
        /// Get or Set Excel Workbook ReadOnlyRecommended
        /// </summary>
        public bool ReadOnlyRecommended
        {
            get => _workbook.ReadOnlyRecommended;
            set => _workbook.ReadOnlyRecommended = value;
        }

        public ExcelWorkbook(Workbook workbook)
        {
            _workbook = workbook;
        }

        ~ExcelWorkbook()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: false);
        }

        private bool _disposed;

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here.
                }

                if (_workbook != null && Marshal.IsComObject(_workbook))
                {
                    Marshal.ReleaseComObject(_workbook);
                    _workbook = null;
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Save Excel Workbook
        /// </summary>
        /// <returns></returns>
        public FileInfo Save(string password = null)
        {
            if (!IsSet) return null;

            var dirExists = Directory.Exists(Path.GetDirectoryName(FullName));
            if (!dirExists)
                throw new DirectoryNotFoundException("Directory not found");

            if (!string.IsNullOrWhiteSpace(password))
                _workbook.Password = password;

            _workbook.Save();
            return new FileInfo(FullName);
        }

        /// <summary>
        /// Save Excel Workbook As New File
        /// </summary>
        /// <param name="path"></param>
        /// <param name="password"></param>
        /// <param name="readOnlyRecommended"></param>
        /// <returns></returns>
        public FileInfo SaveAs(string path, string password = null)
        {
            if (!IsSet) return null;

            var dirExists = Directory.Exists(Path.GetDirectoryName(path));
            if (!dirExists) throw new DirectoryNotFoundException("Directory not found");

            _workbook.SaveAs(
                path,
                FileFormat: GetXlFileFormatByPath(path),
                Password: string.IsNullOrWhiteSpace(password) ? string.Empty : password,
                ReadOnlyRecommended: _workbook.ReadOnlyRecommended
            );
            return new FileInfo(path);
        }

        private static XlFileFormat GetXlFileFormatByPath(string path)
        {
            var ext = Path.GetExtension(path).ToLower();
            switch (ext)
            {
                case ".xlsx":
                    return XlFileFormat.xlOpenXMLWorkbook;

                case ".xlsm":
                    return XlFileFormat.xlOpenXMLWorkbookMacroEnabled;

                // case ".xls":
                //     return Excel.XlFileFormat.xlExcel8;

                default:
                    throw new ArgumentException($"Not Supported Format Extension: {ext}");
            }
        }

        /// <summary>
        /// Close Excel Workbook
        /// </summary>
        /// <param name="saveChanges"></param>
        public void Close(bool saveChanges = false)
        {
            _workbook?.Close(SaveChanges: saveChanges);
        }

        /// <summary>
        /// Get FileInfo from Excel Workbook
        /// </summary>
        /// <returns></returns>
        public FileInfo GetFileInfo()
        {
            if (!IsSet) return null;
            return new FileInfo(FullName);
        }

        /// <summary>
        /// Set DisplayAlerts
        /// </summary>
        /// <param name="value"></param>
        public void SetDisplayAlerts(bool value)
        {
            if (!IsSet) return;
            _workbook.Application.DisplayAlerts = value;
        }
    }
}