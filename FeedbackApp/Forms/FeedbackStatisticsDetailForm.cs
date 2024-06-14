using FeedbackApp.Models.Feedback;
using FeedbackApp.Utilities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XAct;

namespace FeedbackApp.Forms
{
    public partial class FeedbackStatisticsDetailForm : Form
    {
        private DataTable table;
        private int index = -1;
        public IEnumerable<IGrouping<string, FeedbackDetailStatisticsModel>> Data;
        private string feedbackName = null;

        public FeedbackStatisticsDetailForm(DateTime startDate, DateTime endDate, string feedbackTypeId, string feedbackName, bool? insurance)
        {
            InitializeComponent();
            this.Data = Service.feedbackService.CompileFeedbackDetail(startDate, endDate, feedbackTypeId, insurance).GroupBy(x => x.ScoreTypeId);
            this.feedbackName = feedbackName.ToLower();
            this.btRight.PerformClick();
            string insu = "";
            if (insurance != null)
            {
                if (insurance == true)
                {
                    insu = "(Có sử dụng BHYT)";
                }
                else
                {
                    insu = "(Không sử dụng BHYT)";
                }
            }
            this.lbTitle.Text = $"Thống kê {feedbackName.ToLower()} {insu}";
        }

        private void updateData()
        {
            if (this.index == 0)
            {
                this.btLeft.Visible = false;
                this.btRight.Visible = true;
            }
            if (this.index > 0 && this.index < this.Data.Count() -1)
            {
                this.btLeft.Visible = true;
                this.btRight.Visible = true;
            }
            if (this.index == this.Data.Count() - 1)
            {
                this.btLeft.Visible = true;
                this.btRight.Visible = false;
            }
            DataTable table = new DataTable();
            table.Columns.Add("Mã loại câu hỏi", typeof(string));
            table.Columns.Add("Mã câu hỏi", typeof(int));
            table.Columns.Add("Tên câu hỏi", typeof(string));
            table.Columns.Add("Tổng phản hồi", typeof(long));
            List<FeedbackDetailStatisticsModel> data = null;
            string scoreType = null;
            int i = -1;
            foreach (var g in this.Data)
            {
                i++;
                if (i == this.index)
                {
                    scoreType = g.Key;
                    data = g.OrderBy(x => x.CloseQuestionCategoryId).ThenBy(x => x.CloseQuestionNumber).ToList();
                    break;
                }
            }
            var scores = Service.scoreService.GetScoreByTypeId(scoreType);
            var score = Service.scoreTypeService.GetScoreTypeById(scoreType);
            this.sfdExport.Title = $"Vị trí lưu Thống kê {this.feedbackName} thang điểm {score.Name.ToLower()}";
            foreach (var item in scores)
            {
                table.Columns.Add(item.Name, typeof(string));
            }

            table.Columns.Add("Đánh giá trung bình", typeof(string));


            foreach (var item in data)
            {
                var row = new List<object>();
                row.Add(item.CloseQuestionCategoryId);
                row.Add(item.CloseQuestionId);
                row.Add(item.CloseQuestionName);
                row.Add(item.FeedbackTotals);
                foreach (var j in item.ScoreStatisticsModels)
                {
                    var race = (j.Number / (double)item.FeedbackTotals) * 100;
                    row.Add($"{j.Number} ({(int)Math.Round(race)}%)");
                }
                string scoreName = null;
                foreach (var s in scores)
                {
                    if (s.Number == item.AvergraveScore)
                    {
                        scoreName = s.Name;
                        break;
                    }
                }
                row.Add(scoreName);
                table.Rows.Add(row.ToArray());
            }
            this.dtList.DataSource = table;
            this.dtList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            /*for(int k = 0; k < table.Rows.Count -2; k++)
            {
                if (k == 0 || k== 1 ||  k== 2 || k== 3)
                { 
                    continue; 
                }
                this.dtList.Columns[k].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }*/
            this.updatePgaeNumber();

        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (this.sfdExport.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                //Excel.toExcel(this.dtList, this.sfdExport.FileName);
                this.toExcel();
            }
        }

        private void btRight_Click(object sender, EventArgs e)
        {
            this.index++;
            this.updateData();
        }

        private void btLeft_Click(object sender, EventArgs e)
        {
            this.index--;
            this.updateData();
        }
        private void updatePgaeNumber()
        {
            this.tbPageNumber.Text = $"{this.index + 1}/{this.Data.Count()}";
        }

        private void dtList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = this.dtList.CurrentCell.RowIndex;
            this.dtList.Rows[rowIndex].Selected = true;
        }

        private void toExcel()
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
            for (int i = 0; i < this.dtList.ColumnCount; i++)
            {
                worksheet.Cells[1, i + 1] = this.dtList.Columns[i].HeaderText;
            }
            // export nội dung trong DataGridView
            for (int i = 0; i < this.dtList.RowCount -1; i++)
            {
                for (int j = 0; j < this.dtList.ColumnCount; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = this.dtList.Rows[i].Cells[j].Value.ToString();
                }
            }
            // sử dụng phương thức SaveAs() để lưu workbook với filename
            workbook.SaveAs(this.sfdExport.FileName);
            //đóng workbook
            workbook.Close();
            excel.Quit();
            MessageBox.Show("Xuất dữ liệu ra Excel thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}