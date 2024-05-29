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
    public partial class Diem : Form
    {
        private DataUtil data = new DataUtil();
        public string user { get; set; }
        public string ma { get; set; }
        public Diem()
        {
            InitializeComponent();
        }
        private void Diem_Load(object sender, EventArgs e)
        {
            hienThiDiemSV(); // hàm load danh sách điểm sinh viên
            // kiểm tra xem người dùng nào đăng nhập
            if (!(user.ToUpper().Equals("ADMIN") || user.ToUpper().Contains("GV")))
            {
                lblTT.Text = "Kết quả học tập";
                btnThem.Text = "Xem thêm";
            }

        }
        private void hienThiDiemSV() // hàm hiển thị danh sách điểm
        {
            dataGridView1.Columns.Clear(); // xóa các column
            dataGridView1.DataSource = null; 
            // kiểm tra người dùng nào đăng nhập
            if (user.ToUpper().Equals("ADMIN") || user.ToUpper().Contains("GV"))
            {
                dataGridView1.DataSource = data.dsDiemSV();
            }
            else
                dataGridView1.DataSource = data.timkiem(ma, "", "");
            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            // Đổi tên headerText cho từng cột
            //MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc
            dataGridView1.Columns[0].HeaderText = "Mã môn học";
            dataGridView1.Columns[0].Name = "MaMH";
            dataGridView1.Columns[1].HeaderText = "Tên môn học";
            dataGridView1.Columns[1].Name = "TenMH";
            dataGridView1.Columns[2].HeaderText = "Mã sinh viên";
            dataGridView1.Columns[2].Name = "MaSV";
            dataGridView1.Columns[3].HeaderText = "Họ đệm";
            dataGridView1.Columns[4].HeaderText = "Tên";
            dataGridView1.Columns[5].HeaderText = "Điểm";
            dataGridView1.Columns[5].Name = "Diem";
            dataGridView1.Columns[6].HeaderText = "Kỳ Học";
            dataGridView1.Columns[6].Name = "KyHoc";
            if (user.ToUpper().Equals("ADMIN") || user.ToUpper().Contains("GV"))
            {
                addButtonData(); // thêm các button cần thiết nếu người đăng nhập không phải sinh viên
            }
        }
        private void addButtonData() // hàm thêm button trong datagridview
        {
            // khởi tạo các button trong datagridview
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btn3 = new DataGridViewButtonColumn();

            xoaBtnColumn(btn1);
            suaBtnColumn(btn2);
            xemChiTiet(btn3);

            dataGridView1.Columns.Add(btn1);
            dataGridView1.Columns.Add(btn2);
            dataGridView1.Columns.Add(btn3);
        }
        private void xoaBtnColumn(DataGridViewButtonColumn btn1) 
        {
            btn1.HeaderText = @"Xóa"; // them headertext cho button
            btn1.Name = "btnXoa"; // thêm tên cho button
            btn1.Text = "Xóa"; // thêm text cho button
            btn1.UseColumnTextForButtonValue = true;
        }

        private void suaBtnColumn(DataGridViewButtonColumn btn2)
        {
            btn2.HeaderText = "Sửa"; // them headertext cho button
            btn2.Name = "btnSua"; // thêm tên cho button
            btn2.Text = "Sửa"; // thêm text cho button
            btn2.UseColumnTextForButtonValue = true;
        }

        private void xemChiTiet(DataGridViewButtonColumn btn3)
        {
            btn3.HeaderText = "Xem chi tiết"; // them headertext cho button
            btn3.Name = "btnXem";  // thêm tên cho button
            btn3.Text = "Xem thông tin";// thêm text cho button
            btn3.UseColumnTextForButtonValue = true;
        }
        private void cellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kiểm tra người dùng
            if ((!user.ToUpper().Equals("ADMIN") && !user.ToUpper().Contains("GV"))|| e.RowIndex < 0)
                return;
            try
            {
                // lấy giá trị của datagridview
                string masv = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaSV"].Index].Value.ToString();
                string mamh = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaMH"].Index].Value.ToString();

                // kiểm tra xem người dùng có click vào button nào

                if (e.ColumnIndex == dataGridView1.Columns["btnXem"].Index) 
                {
                    try
                    {
                        // mở from xem chi tiết
                        XemChiTiet xem = new XemChiTiet(data.thongTinChiTiet(masv)); 
                        xem.ShowDialog();
                    }
                    catch (Exception)
                    {

                    }
                }
                if (e.ColumnIndex == dataGridView1.Columns["btnSua"].Index)
                {
                    // lấy dữ liệu trong datagridview
                    string kyhoc = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["KyHoc"].Index].Value.ToString();
                    string diem = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns["Diem"].Index].Value.ToString();

                    NhapSuaDiem sua = new NhapSuaDiem(); // khởi tạo from nhập hoặc sửa điểm
                    // truyền các dữ liệu cần thiết
                    sua.masv = masv;
                    sua.mamh = mamh;
                    sua.kyhoc = kyhoc;
                    sua.diem = diem;
                    sua.ShowDialog(); // hiển thị from nhạp sửa điểm

                    hienThiDiemSV(); // load lại from
                }
                if (e.ColumnIndex == dataGridView1.Columns["btnXoa"].Index) // button xóa trong datagridview
                {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn xóa điểm của sinh viên này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog.Equals(DialogResult.Yes))
                    {
                        if (data.DeleteDiem(mamh, masv))
                            hienThiDiemSV();
                        else
                            MessageBox.Show("Xóa không thành công !!!");
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        private void btnThem_Click_1(object sender, EventArgs e) // button thêm 
        {
            if (user.ToUpper().Equals("ADMIN") || user.ToUpper().Contains("GV"))
            {
                NhapSuaDiem nhap = new NhapSuaDiem(); // khởi tạo from nhập hoặc sửa điểm
                nhap.ShowDialog(); // hiển thị frorm nhập sửa điểm
                hienThiDiemSV(); // hiển thị lại dữ liệu from
            }    
            else
            {
                try
                {
                    // mở from xem chi tiết
                    XemChiTiet xem = new XemChiTiet(data.thongTinChiTiet(ma));
                    xem.ShowDialog();
                }
                catch (Exception)
                {

                }
            }    
        }
    }
}
