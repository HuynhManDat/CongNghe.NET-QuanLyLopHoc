using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebQLDiem.Models
{
    public static class ExcelPackageExtensions
    {
        public static DataTable ToDataTable(this ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.First();
            DataTable Dt = new DataTable();
            foreach (var firstRowCell in workSheet.Cells[1, 1, 1, workSheet.Dimension.End.Column])
            {
                Dt.Columns.Add(firstRowCell.Text);
            }
            for (var rowNumber = 2; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
            {
                var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                var newRow = Dt.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                Dt.Rows.Add(newRow);
            }
            return Dt;
        }
    }
}