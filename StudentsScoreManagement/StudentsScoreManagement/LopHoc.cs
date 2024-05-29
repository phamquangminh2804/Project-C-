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
    public partial class LopHoc : Form
    {
        private DataUtil data = new DataUtil();
        public string user{ get; set; }
        public LopHoc()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e) // button thêm
        {
            NhapSuaLop nhapSua = new NhapSuaLop();  // khởi tạo from nhập sửa lớp
            nhapSua.ShowDialog(); // hiển thị from nhập sửa lớp
            hienLop(); // hiển thi lại dữ liệu trong from 
        }

        private void LopHoc_Load(object sender, EventArgs e)
        {
            hienLop();
            // kiểm tra người dùng
            if (user.ToUpper().Equals("ADMIN"))
                btnThem.Visible = true;
        }
        private void hienLop()
        {
            dataGridViewLop.Columns.Clear(); // xóa các cột 
            dataGridViewLop.DataSource = data.dsLop();
            dataGridViewLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // thay đổi headertext cho các cột
            dataGridViewLop.Columns[0].HeaderText = "Mã lớp";
            dataGridViewLop.Columns[0].Name = "MaLop";
            dataGridViewLop.Columns[1].HeaderText = "Mã khoa";
            dataGridViewLop.Columns[2].HeaderText = "Tên lớp";

            dataGridViewLop.Columns[3].HeaderText = "Khóa";
            dataGridViewLop.Columns[4].HeaderText = "Hệ đào tạo";
            dataGridViewLop.Columns[5].HeaderText = "Năm nhập học";
            dataGridViewLop.Columns[6].HeaderText = "Sĩ Số";
            // thêm các button cần thiết khi người dùng là admin
            if(user.ToUpper().Equals("ADMIN"))
            {
                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                xoaBtnColumn(btn1);
                suaBtnColumn(btn2);
                dataGridViewLop.Columns.Add(btn1);
                dataGridViewLop.Columns.Add(btn2);
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

        private void dataGridViewLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kiểm tra người dùng 
            if (!user.ToUpper().Equals("ADMIN")||e.RowIndex<0)
                return;
            // lấy giá trị từ datagridview
            int index = dataGridViewLop.Columns["MaLop"].Index;
            string MaLop = dataGridViewLop.CurrentRow.Cells[index].Value.ToString();
            if (e.ColumnIndex == dataGridViewLop.Columns["btnXoa"].Index) // button xóa
            {
                DialogResult dialog = MessageBox.Show("Bạn có muốn xóa lớp này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog.Equals(DialogResult.Yes))
                {
                    if (!MaLop.Equals(""))
                    {
                        if (!data.xoaLop(MaLop))
                        {
                            MessageBox.Show("Không thể xóa lớp do hãn còn học sinh trong lớp !!!");
                        }
                        else
                        {
                            hienLop();
                        }
                    }
                    else
                        MessageBox.Show("Lựa chọn một lớp để xóa !!!");
                }
            }
            if (e.ColumnIndex == dataGridViewLop.Columns["btnSua"].Index) // button sửa
            {
                // hiển thị from nhập sửa lớp
                NhapSuaLop nhapSua = new NhapSuaLop();
                nhapSua.maLop = MaLop;
                nhapSua.ShowDialog();
                hienLop();
            }
        }

        private void dataGridViewLop_DoubleClick(object sender, EventArgs e) // hiển thị danh sách sinh viên theo lớp
        {
            // khởi tạo from sinh viên lớp
            SVLop sv = new SVLop();
            // truyền dữ liệu 
            sv.user = user;
            sv.maLop = dataGridViewLop.CurrentRow.Cells[dataGridViewLop.Columns["MaLop"].Index].Value.ToString();
            sv.tenLop = dataGridViewLop.CurrentRow.Cells[dataGridViewLop.Columns["MaLop"].Index+2].Value.ToString();
            sv.Show(); // hiển thị from sinh viên lớp
        }
    }
}
