using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
namespace StudentsScoreManagement
{
    public partial class Dangnhap : Form
    {
        public Dangnhap()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)  // button Close
        {
            Close();
        }
        DataUtil data = new DataUtil();
        private void button1_Click(object sender, EventArgs e)   // Button Dang nhap
        {
            string ten = txtUserName.Text; 
            string passw = txtPassword.Text;
            int ID =-1;
            try
            {
                ID = int.Parse(txtUserName.Text);
            }
            catch (Exception)
            {

            }
            try
            {
                DataTable dataTable = data.DangNhap(ten, passw, ID);
                if (dataTable.Rows.Count > 0)
                {
                    ten = dataTable.Rows[0]["Ten"].ToString();
                    DanhSach dssv = new DanhSach();
                    dssv.welcome = ten;
                    dssv.ShowDialog();
                    cleartb();
                }
                else
                {
                    if (txtUserName.Text.Equals(txtPassword.Text)) // kiem tra mat khau
                    {
                        DataTable dataTable1 = data.DangNhapSV(ten);
                        if (dataTable1.Rows.Count > 0)
                        {
                            ten = dataTable1.Rows[0]["HoDem"].ToString() + " " + dataTable1.Rows[0]["Ten"].ToString();
                            DanhSach dssv = new DanhSach();
                            dssv.welcome = ten;
                            dssv.ma = txtUserName.Text;
                            dssv.ShowDialog();
                            cleartb();
                        }
                        else
                        {
                            MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối " + ex.Message);
            }
        }
        private void cleartb()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            ActiveControl = txtUserName;
        }
    }
}
