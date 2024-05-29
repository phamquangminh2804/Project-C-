using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsScoreManagement
{
    public partial class TaiKhoan : Form
    {
        public TaiKhoan()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();

        private void TaiKhoan_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = data.dsTK(); // hiển thị datagridview
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // tự động điều chỉnh độ rộng của cột
            // sửa headertext các cột
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Tên đăng nhập";
            dataGridView1.Columns[2].HeaderText = "Mật khẩu";

        }

        private void btnThem_Click(object sender, EventArgs e) // btnThem
        {
            //txtName.Enabled = true;
           
            if (txtName.Text.Equals("") || txtPass.Text.Equals("")) 
            {
                MessageBox.Show("Không được để trống Tên hoặc mật khẩu");
                return;
            }
            else if (txtName.Text.ToUpper().Equals("ADMIN"))
            {
                MessageBox.Show("Tên này không được phép thêm");
                return;
            }
            if(!txtName.Text.Substring(0,2).ToUpper().Equals("GV"))
            {
                MessageBox.Show("Tên bắt buộc phải bắt đầu bằng GV");
                return;
            }    
         
            
            if (data.TimTaiKhoan(txtName.Text).Rows.Count >= 1)// ktra tên tài khoản đã tồn tại chưa
            {
                MessageBox.Show("Tên này đã tồn tại");
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn đã chắc chắn muốn thêm tài khoản:  " + "\n " + txtName.Text + "\n " + txtPass.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult.Equals(DialogResult.Yes)) // chọn yes 
                {
                    data.ThemTaiKhoan(txtName.Text, txtPass.Text);
                    dataGridView1.DataSource = data.dsTK(); // hiển thị datagridview chứa dl tài khoản
                    txtName.Clear();
                    txtPass.Clear();
                    return;
                }
                else
                {
                    Close();
                }

            }

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            //txtName.Enabled = false;
            if (txtPass.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới");
                return;
            }
            else if (txtName.Text.ToUpper().Contains("ADMIN"))
            {
                MessageBox.Show("Bạn không thể sửa tài khoản ADMIN!!!");
                return;

            }
            if (!txtName.Text.Substring(0, 2).ToUpper().Equals("GV"))
            {
                MessageBox.Show("Tên bắt buộc phải bắt đầu bằng GV");
                return;
            }
            foreach (DataRow item in data.dsTK().Rows) // thêm dữ liệu mới vào dsTK
            {
                if (item["Ten"].ToString().Equals(txtName.Text) && item["Password"].ToString().Equals(txtPass.Text))
                {
                    MessageBox.Show("Bạn chưa thay đổi mật khẩu!!!");
                    return;
                }

            }
        
            DialogResult d = MessageBox.Show("Bạn đã chắc chắn thay đổi password thành:  " + "\n " + txtPass.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (d.Equals(DialogResult.Yes))
            {
                if (data.TimTaiKhoan(txtName.Text).Rows.Count != 0) // tìm tài khoản xem có trong data chưa
                {
                    if (!data.SuaTaiKhoan(txtName.Text, txtPass.Text)) // nếu  ko tìm thấy tài khoản vừa sửa 
                    {
                        MessageBox.Show("Sửa không thành công");
                        return;
                    }
                    else 
                    {
                        dataGridView1.DataSource = data.dsTK(); //  nếu thấy tk show lại tài khoản 
                        txtName.Clear();
                        txtPass.Clear();
                    }

                }
                else
                {
                    MessageBox.Show("Không tồn tại tài khoản này"); // nếu ko có trong data thì thông báo 
                    return;
                }
            }
            else
            {
                return;
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtName.Text.ToUpper().Contains("ADMIN"))
            {
                MessageBox.Show("Bạn không thể xóa tài khoản ADMIN !!!");
                return;
            }
            else
            {
                DialogResult d = MessageBox.Show("Bạn đã chắc chắn xóa tài khoản:  " + "\n " + txtName.Text, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (d.Equals(DialogResult.Yes))
                {
                    if (data.TimTaiKhoan(txtName.Text).Rows.Count != 0)
                    {
                        if (!data.XoaTaiKhoan(txtName.Text))
                        {
                            MessageBox.Show("Xóa không thành công");
              
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Xóa thành công");
                            dataGridView1.DataSource = data.dsTK();
                            txtName.Clear();
                            txtPass.Clear();
         
                        }

                    }
                    else
                    {
                        MessageBox.Show("Không tồn tại tài khoản này");
          
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txtName.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtPass.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }
    }
}

