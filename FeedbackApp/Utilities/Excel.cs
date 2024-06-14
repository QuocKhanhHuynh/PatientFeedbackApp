using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedbackApp.Utilities
{
    public class Excel
    {
        public static void toExcel(DataGridView dtgv, string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            //Tạo đối tượng COM.
            excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = false;
            excel.DisplayAlerts = false;
            //tạo mới một Workbooks bằng phương thức add()
            workbook = excel.Workbooks.Add(Type.Missing);
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
            //đặt tên cho sheet
            worksheet.Name = "Quản lý phản hồi bệnh nhân";

            // export header trong DataGridView
            for (int i = 0; i < dtgv.ColumnCount; i++)
            {
                worksheet.Cells[1, i + 1] = dtgv.Columns[i].HeaderText;
            }
            // export nội dung trong DataGridView
            for (int i = 0; i < dtgv.RowCount; i++)
            {
                for (int j = 0; j < dtgv.ColumnCount; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtgv.Rows[i].Cells[j].Value.ToString();
                }
            }
            // sử dụng phương thức SaveAs() để lưu workbook với filename
            workbook.SaveAs(fileName);
            //đóng workbook
            workbook.Close();
            excel.Quit();
            MessageBox.Show("Xuất dữ liệu ra Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
