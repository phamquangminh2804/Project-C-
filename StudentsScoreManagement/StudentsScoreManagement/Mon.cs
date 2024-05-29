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
    public partial class Mon : Form
    {
      
        private DataUtil data = new DataUtil();
        public string user{ get; set; }
        public Mon()
        {
            InitializeComponent();
        }

        private void Mon_Load(object sender, EventArgs e)
        {
            hienMH();
            // kiểm tra người dùng
            if (user.ToUpper().Equals("ADMIN"))
                btnThem.Visible = true;
        }
        private void btnNhapMH_Click(object sender, EventArgs e) // button nhập môn học
        {
            NhapMH mh = new NhapMH();
            mh.ShowDialog();
            hienMH();
        }
        private void hienMH()
        {
            dataGridViewMH.Columns.Clear(); // xóa cac cột
            dataGridViewMH.DataSource = data.dsMonHoc();
            dataGridViewMH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // sửa headertext cho các cột
            dataGridViewMH.Columns[0].HeaderText = "Mã môn học";
            dataGridViewMH.Columns[0].Name = "MaMH";
            dataGridViewMH.Columns[1].HeaderText = "Tên môn học";
            dataGridViewMH.Columns[2].HeaderText = "Số tín chỉ";
            dataGridViewMH.Columns[3].HeaderText = "Học Kỳ";
            // kiểm tra nếu người dùng là admin thì thêm các button cần thiết
            if (user.ToUpper().Equals("ADMIN"))
            {
                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
                btn1.HeaderText = @"Xóa";
                btn1.Name = "btnXoa";
                btn1.Text = "Xóa";
                btn1.UseColumnTextForButtonValue = true;
                btn2.HeaderText = "Sửa";
                btn2.Name = "btnSua";
                btn2.Text = "Sửa";
                btn2.UseColumnTextForButtonValue = true;
                dataGridViewMH.Columns.Add(btn1);
                dataGridViewMH.Columns.Add(btn2);
            }    
           

        }

        private void dataGridViewMH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // kiểm tra người dùng
            if (!user.ToUpper().Equals("ADMIN")|| e.RowIndex < 0)
                return;
            try
            {
                // lấy dữ liệu từ datagridview
                int index = dataGridViewMH.Columns["MaMH"].Index;
                string MaMH = dataGridViewMH.CurrentRow.Cells[index].Value.ToString();
                
                if (e.ColumnIndex == dataGridViewMH.Columns["btnXoa"].Index)// button xóa
                {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn xóa môn học này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog.Equals(DialogResult.Yes))
                    {
                        if (!MaMH.Equals(""))
                        {
                            if (!data.XoaMH(MaMH))
                            {
                                MessageBox.Show("Không thể xóa môn học do hãn còn học sinh học môn này !!!");
                            }
                            else
                            {
                                dataGridViewMH.Columns.Clear();
                                hienMH();
                            }
                        }
                        else
                            MessageBox.Show("Lựa chọn một môn học !!!");
                    }
                }
                if (e.ColumnIndex == dataGridViewMH.Columns["btnSua"].Index) // button sửa
                {
                    NhapMH SuaMH = new NhapMH(); // khởi tạo from sửa môn học
                    // truyền dữ liệu sang from sửa môn học
                    SuaMH.maMH = MaMH;
                    SuaMH.tenMH = dataGridViewMH.CurrentRow.Cells[index + 1].Value.ToString();
                    SuaMH.soTC = dataGridViewMH.CurrentRow.Cells[index + 2].Value.ToString();
                    SuaMH.hocKy = dataGridViewMH.CurrentRow.Cells[index + 3].Value.ToString();
                    SuaMH.ShowDialog(); // hiển thị from sửa môn học
                    hienMH(); // hiên thị lại dữ liệu 
                }
            }
            catch (Exception)
            {
            }
        }

        private void dataGridViewMH_DoubleClick(object sender, EventArgs e) // xem điểm theo từng môn học
        {
            if (dataGridViewMH.CurrentRow.Index < 0)
                return;
            int index = dataGridViewMH.Columns["MaMH"].Index;
            SVMon formSV = new SVMon(); // khởi tạo from sinh viên theo môn
            // truyền dữ liệu sang from
            formSV.user = user;
            formSV.maMon = dataGridViewMH.CurrentRow.Cells[index].Value.ToString();
            formSV.tenMon = dataGridViewMH.CurrentRow.Cells[index+1].Value.ToString();
            formSV.hocky = dataGridViewMH.CurrentRow.Cells[index+3].Value.ToString();
            formSV.Show(); // hiển thị from sinh viên theo môn
        }

    }
}
