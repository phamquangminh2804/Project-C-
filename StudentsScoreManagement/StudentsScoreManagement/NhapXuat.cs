using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsScoreManagement
{
    class NhapXuat
    {

        public void exportToExcel(DataTable x)
        {
            if (x.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XLS (*.xls)|*.xls";
                sfd.FileName = "Output.xls";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    
                   
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi nào được Export!!!", "Info");
            }
        }

        public void exportFilePDF(DataTable x)
        {
            // kiểm tra dữ liệu
            if (x.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog(); 
                sfd.Filter = "PDF (*.pdf)|*.pdf"; // lưu file dạng pdf
                sfd.FileName = "Output.pdf"; // tên mặc định
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Không thể ghi dữ liệu tới ổ đĩa. Mô tả lỗi:" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            // chọn font chữ ( để lưu được dưới dạng utf-8 )
                            string TimeNewR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "TIMES.TTF"); 
                            BaseFont bf = BaseFont.CreateFont(TimeNewR, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                            iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                            PdfPTable pdfTable = new PdfPTable(x.Columns.Count); // khởi tạo pdfTable
                            pdfTable.DefaultCell.Padding = 10; 
                            pdfTable.WidthPercentage = 100;  // chia %

                            List<string> name = new List<string>(); // list name chứa tên của cột

                            foreach (DataColumn column in x.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                                pdfTable.AddCell(cell);
                                name.Add(column.ColumnName);
                            }


                            foreach (DataRow row in x.Rows)  // duyệt từng hàng 
                            {
                                for (int i = 0; i < name.Count; i++) // duyệt từng cột
                                {
                                    PdfPCell pdfCell = new PdfPCell(new Phrase(row[name[i]].ToString(), f)); // khởi tạo ô 
                                    pdfTable.AddCell(pdfCell); // thêm ô vào pdftable
                                }
                            }
                            // lưu file
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                pdfDoc.Add(new Phrase("Danh Sách", f));
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document xlsDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(xlsDoc, stream);
                                xlsDoc.Open();
                                xlsDoc.Add(new Phrase("Danh Sách", f));
                              
                                xlsDoc.Close();
                                stream.Close();
                            }
                            MessageBox.Show("Lưu file thành công!!!", "Thông Báo");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không thể lưu file!!!", "Thông Báo");
            }

        }
    }
}
