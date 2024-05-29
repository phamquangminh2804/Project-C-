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
    public partial class Khoa : Form
    {
        private DataUtil data = new DataUtil();
        public string user{ get; set; }
        public Khoa()
        {
            InitializeComponent();
        }

        private void Khoa_Load(object sender, EventArgs e)
        {
            hienKhoa(); // hàm hiển thị dữ liệu lên datagridview
            // kiểm tra người dùng
            if(user.ToUpper().Equals("ADMIN"))
            {
                btnThem.Visible = true;
            }    
            
        }
        private void hienKhoa()
        {
            dataGridViewKhoa.Columns.Clear(); // xóa cột
            dataGridViewKhoa.DataSource = data.dsKhoa(); 
            dataGridViewKhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // sửa lại headertext cho các cột
            dataGridViewKhoa.Columns[0].HeaderText = "Mã khoa";
            dataGridViewKhoa.Columns[0].Name = "MaKhoa";
            dataGridViewKhoa.Columns[1].HeaderText = "Tên khoa";
            dataGridViewKhoa.Columns[2].HeaderText = "Điện thoại";
            // thêm các button nếu người dùng là admin
            if (user.ToUpper().Equals("ADMIN"))
            {
                // khởi tạo các button trong datagridview
                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                xoaBtnColumn(btn1);
                suaBtnColumn(btn2);
                dataGridViewKhoa.Columns.Add(btn1);
                dataGridViewKhoa.Columns.Add(btn2);
            }    
        }
        private void suaBtnColumn(DataGridViewButtonColumn btn2)
        {
            btn2.HeaderText = "Sửa";
            btn2.Name = "btnSua";
            btn2.Text = "Sửa";
            btn2.UseColumnTextForButtonValue = true;
        }
        private void xoaBtnColumn(DataGridViewButtonColumn btn1)
        {
            btn1.HeaderText = @"Xóa";
            btn1.Name = "btnXoa";
            btn1.Text = "Xóa";
            btn1.UseColumnTextForButtonValue = true;
        }
        private void btnThem_Click(object sender, EventArgs e) // button thêm
        {
            NhapSuaKhoa nhapSuaKhoa = new NhapSuaKhoa(); // khởi tạo from nhập sửa khoa
            nhapSuaKhoa.ShowDialog(); // hiển thị from
            hienKhoa(); // hiển thị lại dữ liệu
        }

        private void dataGridViewKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kiểm tra người dùng
            if (!user.ToUpper().Equals("ADMIN")|| e.RowIndex < 0)
                return;
            // lấy dữ liệu trong datagridview
            string MaKhoa = dataGridViewKhoa.CurrentRow.Cells[dataGridViewKhoa.Columns["MaKhoa"].Index].Value.ToString();

            if (e.ColumnIndex == dataGridViewKhoa.Columns["btnXoa"].Index) // button xóa
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa lớp này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog.Equals(DialogResult.Yes))
                {
                    if (!MaKhoa.Equals(""))
                    {
                        if (!data.xoaKhoa(MaKhoa))
                        {
                            MessageBox.Show("Không thể xóa khoa này!!!");
                        }
                        else
                        {
                            hienKhoa();
                        }
                    }
                    else
                        MessageBox.Show("Lựa chọn một lớp để xóa !!!");
                }
            }
            if (e.ColumnIndex == dataGridViewKhoa.Columns["btnSua"].Index) // button sửa
            {
                NhapSuaKhoa sua = new NhapSuaKhoa(); // khởi tạo from nhâp , sửa khoa
                // truyền dữ liệu 
                sua.maKhoa = MaKhoa; 
                sua.tenKhoa = dataGridViewKhoa.CurrentRow.Cells[dataGridViewKhoa.Columns["MaKhoa"].Index+1].Value.ToString();
                sua.dienThoai = dataGridViewKhoa.CurrentRow.Cells[dataGridViewKhoa.Columns["MaKhoa"].Index+2].Value.ToString();
                sua.ShowDialog(); // hiển thị from nhập sửa khoa
                hienKhoa(); // hiển thị lại dữ liệu
            }

        }
    }
}
