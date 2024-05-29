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
    public partial class NhapSuaLop : Form
    {
        public NhapSuaLop()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        public string maLop { get; set; }
        private void NhapSuaLop_Load(object sender, EventArgs e)
        {
            // thay đổi giá trị dựa vào mục đích sửa dụng
            this.Text = "Nhập Thông Tin Lớp";
            btnOK.Text = "Thêm";
            cbHeDT.SelectedIndex = 0;
            cbMaKhoa.DataSource = data.dsKhoa();
            cbMaKhoa.DisplayMember = "TenKhoa";
            cbMaKhoa.ValueMember = "MaKhoa";
            cbMaKhoa.SelectedIndex = 0;
            if(maLop!=null)
            {
                this.Text = "Sửa Thông Tin Lớp";
                btnOK.Text = "Sửa";
                DataRow x = data.timkiemLop(maLop, "", "", "", "", "").Rows[0];
                // gán giá trị cho các textbox
                txtNam.Text = x["NamNhapHoc"].ToString();
                cbHeDT.SelectedItem = x["HeDaoTao"].ToString();
                txtKhoa.Text = x["Khoa"].ToString();
                cbMaKhoa.SelectedValue = x["MaKhoa"].ToString();
                txtMaLop.Text = x["MaLop"].ToString();
                txtMaLop.Enabled = false;
                txtSiSo.Text = x["SiSo"].ToString();
                txtTenLop.Text = x["TenLop"].ToString();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // kiểm tra các textbox 
            if(txtTenLop.Text.Equals("")|| txtNam.Text.Equals("")|| txtKhoa.Text.Equals("")|| txtMaLop.Text.Equals("")|| txtSiSo.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu !!!");
                return;
            }

            Lop lop = new Lop();
            lop.maLop = txtMaLop.Text;
            lop.maKhoa = cbMaKhoa.SelectedValue.ToString();
            lop.khoa = txtKhoa.Text;
            lop.heDaoTao = cbHeDT.Text;
            lop.nam = int.Parse(txtNam.Text);
            lop.siso = int.Parse(txtSiSo.Text);
            lop.tenLop = txtTenLop.Text;
            if (maLop != null)
            {
                if (!data.SuaLop(lop))
                {
                    MessageBox.Show("Không thể sửa!!!\nLưu ý nhập đúng mã");
                }
                else
                {
                    Close();
                }
            }
            else
            {
                if (!data.NhapLop(lop))
                {
                    MessageBox.Show("Không thể thực hiện!!!\nLưu ý nhập đúng mã");
                }
                else
                {
                    txtNam.Text = "";
                    cbHeDT.SelectedIndex = 0;
                    txtKhoa.Text = "";
                    cbMaKhoa.SelectedIndex =0;
                    txtMaLop.Text ="";
                    txtSiSo.Text = "";
                    txtTenLop.Text = "";
                    ActiveControl = txtMaLop;
                }    
            }

        }
     }
}
