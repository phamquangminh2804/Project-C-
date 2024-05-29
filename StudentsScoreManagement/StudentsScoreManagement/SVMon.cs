using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsScoreManagement
{
    public partial class SVMon : Form
    {
        public SVMon()
        {
            InitializeComponent();
        }
        public string maMon { get; set; }
        public string tenMon{ get; set; }
        public string hocky { get; set; }
        public  string user { get; set; }
        DataUtil data = new DataUtil();
        private void SVMon_Load(object sender, EventArgs e)
        {
            lblWel.Text = tenMon;
            rdPDF.Checked = true; // khởi tạo mặc định theo file pdf
            loadForm(); // hiển thị lại dữ liệu
        }

        private void loadForm()
        {
            dataSV.DataSource = null;
            dataSV.DataSource = data.dsSVMon(maMon);
            dataSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //SinhVien.MaSV,HoDem,Ten,MaLop,MonHoc.MaMH,MonHoc.TenMH,KyHoc,SoTinChi,Diem
            // sửa headertext của cột
            dataSV.Columns[0].HeaderText = "Mã sinh viên";
            dataSV.Columns[0].Name = "MaSV";
            dataSV.Columns[1].HeaderText = "Họ đệm";
            dataSV.Columns[2].HeaderText = "Tên";
            dataSV.Columns[3].HeaderText = "Mã lớp";
            dataSV.Columns[4].HeaderText = "Mã môn học";
            dataSV.Columns[5].HeaderText = "Tên môn học";
            dataSV.Columns[6].HeaderText = "Kỳ học";
            dataSV.Columns[7].HeaderText = "Số tín chỉ";
            dataSV.Columns[8].HeaderText = "Điểm";  
            //thêm các button
            if(user.ToUpper().Equals("ADMIN")||user.ToUpper().Contains("GV")) // nếu người dùng là admin hoặc giáo viên
            {
                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();// thêm các button
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                xoaBtnColumn(btn2);
                suaBtnColumn(btn1);
                dataSV.Columns.Add(btn1);
                dataSV.Columns.Add(btn2);
                iconButton1.Visible = true;
            }    
            
        }
        private void xoaBtnColumn(DataGridViewButtonColumn btn1) // sửa tên cột, text, tên button
        {
            btn1.HeaderText = @"Xóa";
            btn1.Name = "btnXoa";
            btn1.Text = "Xóa";
            btn1.UseColumnTextForButtonValue = true;
        }

        private void suaBtnColumn(DataGridViewButtonColumn btn2)
        {
            btn2.HeaderText = "Sửa";
            btn2.Name = "btnSua";
            btn2.Text = "Sửa";
            btn2.UseColumnTextForButtonValue = true;
        }

        private void dataSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kiểm tra người dùng
            if (!user.ToUpper().Equals("ADMIN") && !user.ToUpper().Contains("GV") || e.RowIndex<0)
                return;
            try
            {
                // lấy dữ liệu từ datagridview
                int index = dataSV.Columns["MaSV"].Index;
                string masv = dataSV.Rows[e.RowIndex].Cells[index].Value.ToString();
                string mamh = dataSV.Rows[e.RowIndex].Cells[index + 4].Value.ToString();


                if (e.ColumnIndex == dataSV.Columns["btnSua"].Index) // button sửa--------
                {
                    string kyhoc = dataSV.Rows[e.RowIndex].Cells[index + 6].Value.ToString();// lấy dữ liệu từ datagridview
                    string diem = dataSV.Rows[e.RowIndex].Cells[index + 8].Value.ToString();
                    NhapSuaDiem sua = new NhapSuaDiem(); // khởi tạo form NhapSuaDiem
                    // truyền dữ liệu vào
                    sua.masv = masv;
                    sua.mamh = mamh;
                    sua.kyhoc = kyhoc;
                    sua.diem = diem;
                    sua.ShowDialog(); // hiện form
                    dataSV.Columns.Clear();
                    loadForm();
                }   
                else if(e.ColumnIndex == dataSV.Columns["btnXoa"].Index) // button xóa-----
                {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn xóa điểm của sinh viên này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog.Equals(DialogResult.Yes))
                    {
                        data.DeleteDiem(mamh, masv);
                        dataSV.Columns.Clear();
                        loadForm();
                    }
                }
            }
            catch (Exception)
            {

            }
    
        }


        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if(rdExcel.Checked)
            {
                new NhapXuat().exportToExcel(data.dsSVMon(maMon)); // lưu file theo dạng excel
            }   
            else
            { 
                new NhapXuat().exportFilePDF(data.dsSVMon(maMon)); // lưu file theo dạng pdf
            }    
        }

        private void iconButton1_Click(object sender, EventArgs e) // button thêm
        {
            
            NhapSuaDiem sua = new NhapSuaDiem();
            sua.mamh = maMon;
            sua.kyhoc = hocky;
            sua.tm = "a";
            sua.ShowDialog();
            dataSV.Columns.Clear();
            loadForm();
        }
    }
}
