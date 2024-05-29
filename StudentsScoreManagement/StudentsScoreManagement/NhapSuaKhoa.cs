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
    public partial class NhapSuaKhoa : Form
    {
        public NhapSuaKhoa()
        {
            InitializeComponent();
        }
        public string maKhoa { get; set; }
        public string tenKhoa { get; set; }
        public string dienThoai { get; set; }
        DataUtil data = new DataUtil();
        private void NhapSuaKhoa_Load(object sender, EventArgs e)
        {
            // thay đổi giá trị dựa vào mục đích sửa dụng
            this.Text = "Nhập Thông Tin Khoa";
            if(maKhoa!=null)
            {
                txtDienThoai.Text = dienThoai;
                txtMaKhoa.Text = maKhoa;
                txtTenKhoa.Text = tenKhoa;
                txtMaKhoa.Enabled = false;
            }    
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtDienThoai.Text.Equals("")|| txtMaKhoa.Text.Equals("") || txtTenKhoa.Text.Equals("")) // kiểm tra textbox rỗng hay không
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin ");
                return;
            }    
            if (maKhoa != null)
            {
                if(!data.SuaKhoa(txtMaKhoa.Text, txtTenKhoa.Text,txtDienThoai.Text))
                {
                    MessageBox.Show("Không thể sửa!!!");
                }
                else
                {
                    Close();
                }
            }
            else
            {
                if(!data.NhapKhoa(txtMaKhoa.Text, txtTenKhoa.Text, txtDienThoai.Text))
                {
                    MessageBox.Show("Không thể nhập!!!");

                }
                else
                {
                    txtDienThoai.Text = "";
                    txtMaKhoa.Text = "";
                    txtTenKhoa.Text = "";
                    ActiveControl = txtMaKhoa;
                }
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
