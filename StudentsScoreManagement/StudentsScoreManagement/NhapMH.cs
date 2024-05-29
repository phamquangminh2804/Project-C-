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
    public partial class NhapMH : Form
    {
        public NhapMH()
        {
            InitializeComponent();
        }
        public string maMH { get; set; }
        public string tenMH { get; set; }
        public string soTC { get; set; }
        public string hocKy { get; set; }
        DataUtil data = new DataUtil();
        private void NhapMH_Load(object sender, EventArgs e)
        {
            // thay đổi giá trị dựa theo mục đích from
            this.Text = "Thêm Môn Học"; 
            if(maMH!=null)
            {
                this.Text = "Sửa Môn Học";
                lblTieuDe.Text = "Sửa Môn Học";
                txtHocKy.Text = hocKy;
                txtMaMH.Text = maMH;
                txtTenMH.Text = tenMH;
                txtTinChi.Text = soTC;
                txtMaMH.Enabled = false;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e) // button hủy
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e) // button thêm
        {
            if (txtHocKy.Text.Equals("") || txtMaMH.Text.Equals("") || txtTenMH.Text.Equals("") || txtTinChi.Text.Equals("")) // kiểm tra textbox
            {
                MessageBox.Show("Yêu cầu nhập đủ dữ liệu !!!");
                return;
            }
            MonHoc m = new MonHoc();
            m.Mamh = txtMaMH.Text;
            m.Tenmh = txtTenMH.Text;
            try
            {
                m.Hocky = int.Parse(txtHocKy.Text);
                m.Sotinchi = int.Parse(txtTinChi.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Nhập dữ liệu không đúng !!!");
                return;
            }
            if (maMH != null)
            {
                if (data.SuaMH(m))
                    this.Close();
                else
                    MessageBox.Show("Sửa thông tin không thành công !!!");
            }   
            else
            {
                
                if(!data.nhapMH(m))
                {
                    MessageBox.Show("Nhập thông tin không thành công !!!");
                }
                else
                {
                    txtMaMH.Text = "";
                    txtHocKy.Text = "";
                    txtTenMH.Text = "";
                    txtTinChi.Text = "";
                    ActiveControl = txtMaMH;
                }
                
            }    
        }
    }
}
