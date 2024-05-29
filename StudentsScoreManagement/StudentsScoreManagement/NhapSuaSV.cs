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
    public partial class NhapSuaSV : Form
    {
        public string maSV { get; set; }
        public string maLop{ get; set; }
      


        DataUtil data = new DataUtil();
        public NhapSuaSV()
        {
            InitializeComponent();
        }

        private void NhapSuaSV_Load(object sender, EventArgs e)
        {
            cbGioiTinh.Items.Add("Nam");
            cbGioiTinh.Items.Add("Nữ");
            cbGioiTinh.SelectedIndex = 0;
            cbLop.DataSource = data.dsLop();
            cbLop.DisplayMember = "TenLop";
            cbLop.ValueMember = "MaLop";
            if(maLop!=null)
                cbLop.SelectedValue = maLop;
            cbLop.Enabled = false;
            if (maSV!=null)
            {
                DataTable dataTable = data.TimSV(maSV);
                btnOK.Text = "Sửa";
                this.Text = "Sửa thông tin sinh viên";
                txtMaSV.Text = dataTable.Rows[0]["MaSV"].ToString();
                txtMaSV.Enabled = false;
                txtHo.Text = dataTable.Rows[0]["HoDem"].ToString();
                txtDiaChi.Text = dataTable.Rows[0]["DiaChi"].ToString();
                txtSDT.Text = dataTable.Rows[0]["SoDienThoai"].ToString();
                txtTen.Text = dataTable.Rows[0]["Ten"].ToString();
                txtEmail.Text = dataTable.Rows[0]["Email"].ToString();
                cbGioiTinh.SelectedItem = dataTable.Rows[0]["GioiTinh"];
                cbLop.SelectedValue = dataTable.Rows[0]["MaLop"];
                date.Value = (DateTime)dataTable.Rows[0]["NgaySinh"];
                cbLop.Enabled = true;
            }
            

        }
        private void ShowNhapSuaSV()
        {
            NhapSuaSV suaSV = new NhapSuaSV();
            suaSV.ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtDiaChi.Text.Equals("")|| txtEmail.Text.Equals("")|| txtHo.Text.Equals("")|| txtMaSV.Text.Equals("")|| txtSDT.Text.Equals("")|| txtTen.Text.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu !!!");
                return;
            }
            if(DateTime.Now.Year - date.Value.Year <5)
            {
                MessageBox.Show("Bạn chưa nhập đúng dữ liệu !!!");
                return;
            }    
            SinhVien sinhVien = new SinhVien();
            try
            {
                sinhVien.Masv = txtMaSV.Text;
                sinhVien.Hodem = txtHo.Text;
                sinhVien.Ten = txtTen.Text;
                sinhVien.Ngaysinh = date.Value;
                int x = int.Parse(txtSDT.Text);
                sinhVien.Sodienthoai = txtSDT.Text;
                sinhVien.Gioitinh = cbGioiTinh.Text;
                sinhVien.Email = txtEmail.Text;
                sinhVien.Malop = cbLop.SelectedValue.ToString();
                sinhVien.Diachi = txtDiaChi.Text;
               
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn chưa nhập đúng dữ liệu");
                return;
            }
            if(maSV!=null)
            {
                if (data.SuaTTSV(sinhVien))
                {
                    MessageBox.Show("Sửa thông tin thành công !!!");
                    Close();
                }
                MessageBox.Show("Sửa thông tin không thành công !!!");
            }   
            else
            {
                if(!data.ThemSv(sinhVien))
                {
                    MessageBox.Show("Thêm sinh viên không thành công !!!");
                }
                else
                {
                    txtDiaChi.Clear();
                    txtEmail.Clear();
                    txtHo.Clear();
                    txtMaSV.Clear();
                    txtSDT.Clear();
                    txtTen.Clear();
                    cbGioiTinh.SelectedIndex = 0;
                    cbLop.SelectedIndex = 0;
                    ActiveControl = txtMaSV;
                }
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
