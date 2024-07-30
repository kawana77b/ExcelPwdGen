using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using ExcelPwdGen.OfficeExcel;
using ExcelPwdGen.Ribbons;

namespace ExcelPwdGen
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO で生成されたコード

        /// <summary>
        /// デザイナーのサポートに必要なメソッドです。
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion VSTO で生成されたコード

        public void SaveEncryptExcelFile()
        {
            if (Application?.ActiveWorkbook == null) return;
            var wbService = new ExcelWorkbookService(Application);
            wbService.DoSave();
        }

        public void SaveAsEncryptExcelFile()
        {
            if (Application?.ActiveWorkbook == null) return;
            var wbService = new ExcelWorkbookService(Application);
            wbService.DoSaveAs();
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new Ribbon();
        }
    }
}