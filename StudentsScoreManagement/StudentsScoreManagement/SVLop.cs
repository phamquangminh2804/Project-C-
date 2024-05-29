using System;
using System.Windows.Forms;

namespace StudentsScoreManagement
{
    public partial class SVLop : Form
    {
        public SVLop()
        {
            InitializeComponent();
        }
        public string maLop { get; set; }
        public string tenLop { get; set; }
        public string user { get; set; }
        DataUtil data = new DataUtil();
        private void SVLop_Load(object sender, EventArgs e)
        {
            loadForm(); // hiển thị dữ liệu lên datagridview
            rdPDF.Checked = true;// khởi tạo mặc định lưu file theo pdf
            rdExcel.Checked = true;
            lblWel.Text = tenLop;
            
        }
        private void loadForm()
        {
            dataSV.DataSource = null;
            dataSV.DataSource = data.dsSVLop(maLop);
            dataSV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //MaSV,HoDem,Ten,NgaySinh,DiaChi,GioiTinh,Email,SoDienThoai
            // sửa headertext cho các cột
            dataSV.Columns[0].HeaderText = "Mã sinh viên";
            dataSV.Columns[1].HeaderText = "Họ đệm";
            dataSV.Columns[2].HeaderText = "Tên";
            dataSV.Columns[3].HeaderText = "Ngày sinh";
            dataSV.Columns[4].HeaderText = "Địa chỉ";
            dataSV.Columns[5].HeaderText = "Giới tính";
            dataSV.Columns[6].HeaderText = "Email";
            dataSV.Columns[7].HeaderText = "Số điện thoại";

            if (user.ToUpper().Equals("ADMIN"))
            {
                btnThem.Visible = true;// hiển thị nút thêm 
                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                xoaBtnColumn(btn2);
                suaBtnColumn(btn1);
                dataSV.Columns.Add(btn1);// thêm vào bảng cột sửa 
                dataSV.Columns.Add(btn2);// thêm vào bảng cột xóa
                
            }
        }
        private void xoaBtnColumn(DataGridViewButtonColumn btn1) // btnXoa
        {
   
            btn1.HeaderText = @"Xóa";// sửa tên header
            btn1.Name = "btnXoa";// tạo tên button
            btn1.Text = "Xóa";// tên nút
            btn1.UseColumnTextForButtonValue = true;
        }

        private void suaBtnColumn(DataGridViewButtonColumn btn2)// btnSua
        {
            btn2.HeaderText = "Sửa";
            btn2.Name = "btnSua";
            btn2.Text = "Sửa";
            btn2.UseColumnTextForButtonValue = true;
        }

        private void btnSave_Click(object sender, EventArgs e) // button lưu file
        {
            if (rdExcel.Checked) // nếu chọn file excel
            {
                new NhapXuat().exportToExcel(data.dsSVLop(maLop));
            }
            else // nếu chọn file pdf
            {
                new NhapXuat().exportFilePDF(data.dsSVLop(maLop));
            }
        }

        private void dataSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string masv = dataSV.CurrentRow.Cells[dataSV.Columns["MaSV"].Index].Value.ToString(); // lấy dữ liệu từ datagridview
            if (e.ColumnIndex == dataSV.Columns["btnSua"].Index)// button sua
            {
                NhapSuaSV sua = new NhapSuaSV();// khởi tạo from 
                sua.maSV = masv;
                sua.ShowDialog();// hiện form NhapSuaSV
                dataSV.Columns.Clear();
                loadForm();
            }
            else if (e.ColumnIndex == dataSV.Columns["btnXoa"].Index) // button xóa
            {
                // xuat hiện messagebox và thông báo có muốn xóa điểm của sv ko
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa điểm của sinh viên này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog.Equals(DialogResult.Yes)) // chọn yes -> thực hiện xóa và load lại form
                {
                    data.XoaSV(masv); 
                    dataSV.Columns.Clear();
                    loadForm();
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            NhapSuaSV nhapSv = new NhapSuaSV();
            nhapSv.maLop = maLop; 
            nhapSv.ShowDialog();
            dataSV.Columns.Clear();
            loadForm();
        }
    }
}
