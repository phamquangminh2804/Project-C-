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
    public partial class XemChiTiet : Form
    {
        private DataTable dt = new DataTable();
        private DataUtil data = new DataUtil();
        public XemChiTiet()
        {
            InitializeComponent();
        }

        public XemChiTiet(DataTable sv)
        {
            InitializeComponent();
            dt = sv; // lấy dữ liệu truyền vào từ form DanhSachDiemSV
        }
        private void XemChiTiet_Load(object sender, EventArgs e)
        {
            hienThi();
        }
        // Hàm hiển thị ra tất cả thông tin trong form XemChiTiet
        private void hienThi()
        {
            // Set giá trị cho các label

            lblMaSV.Text = dt.Rows[0]["MaSV"].ToString();
            lblHoTen.Text = dt.Rows[0]["HoDem"].ToString() + " " + dt.Rows[0]["Ten"].ToString();
            lblNgaySinh.Text = ((DateTime)dt.Rows[0]["NgaySinh"]).ToString("dd/MM/yyyy");
            lblDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            lblGioiTinh.Text = dt.Rows[0]["GioiTinh"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
            lblMaLop.Text = dt.Rows[0]["MaLop"].ToString();
            lblTenLop.Text = dt.Rows[0]["TenLop"].ToString();
            lblKhoa.Text = dt.Rows[0]["Khoa"].ToString();
            lblHeDaoTao.Text = dt.Rows[0]["HeDaoTao"].ToString();
            lblNamNhapHoc.Text = dt.Rows[0]["NamNhapHoc"].ToString();
            lblSiSo.Text = dt.Rows[0]["SiSo"].ToString();
            lblMaKhoa.Text = dt.Rows[0]["MaKhoa"].ToString();
            lblTenKhoa.Text = dt.Rows[0]["TenKhoa"].ToString();
            lblSoDienThoaiKhoa.Text = dt.Rows[0]["DienThoai"].ToString();

            // Tính tổng số tín chỉ
            int tongSoTin = 0;
            foreach (DataRow dr in dt.Rows)
            {
                tongSoTin += Convert.ToInt32(dr["SoTinChi"].ToString());
            }
            lblSoTinChi.Text = tongSoTin + "";

            // Set dữ liệu cho dataGridView2 tức hiển thị điểm trung bình trung của từng học kỳ
            hienThiTrungBinhTrungHK();

            lblTrungBinhTichLuy.Text = Math.Round(tinhTrungBinhTrungTichLuy(tongSoTin), 2) + ""; // Hiển thị trung bình trung tích lũy của sinh viên
            lblXepHang.Text = xepHang(tinhTrungBinhTrungTichLuy(tongSoTin)); // Hiển thị xếp hạng của sinh viên

            dataGridView1.DataSource = data.layDiemThi(lblMaSV.Text); // Set dữ liệu cho dataGridView1 
                                                                      // tức hiển thị danh sách mã môn học, tên môn học, số tín chỉ, kỳ học, điểm.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns[0].HeaderText = "Mã môn học";
            dataGridView1.Columns[0].Name = "MaMH";
            dataGridView1.Columns[1].HeaderText = "Tên môn học";
            dataGridView1.Columns[1].Name = "TenMH";
            dataGridView1.Columns[2].HeaderText = "Số Tín Chỉ";
            dataGridView1.Columns[2].Name = "SoTinChi";
            dataGridView1.Columns[3].HeaderText = "Học Kỳ";
            dataGridView1.Columns[3].Name = "HocKy";
            dataGridView1.Columns[4].HeaderText = "Điểm";
            dataGridView1.Columns[4].Name = "Diem";
        }

        private void hienThiTrungBinhTrungHK()
        {
            // Lưu điểm trung bình trung học kỳ vào mảng string
            string[] arr = new string[8];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = tinhTrungBinhTrungHK((i + 1).ToString()).ToString();
            }

            // Thêm cột cho dataGridView2
            dataGridView2.Columns.Add("HocKy1", "Học Kỳ 1");
            dataGridView2.Columns.Add("HocKy2", "Học Kỳ 2");
            dataGridView2.Columns.Add("HocKy3", "Học Kỳ 3");
            dataGridView2.Columns.Add("HocKy4", "Học Kỳ 4");
            dataGridView2.Columns.Add("HocKy5", "Học Kỳ 5");
            dataGridView2.Columns.Add("HocKy6", "Học Kỳ 6");
            dataGridView2.Columns.Add("HocKy7", "Học Kỳ 7");
            dataGridView2.Columns.Add("HocKy8", "Học Kỳ 8");

            // Thêm dữ liệu vào hàng của dataGridView2 là một mảng string
            dataGridView2.Rows.Add(arr);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private double tinhTrungBinhTrungHK(string kyHoc) // Tính trung bình trung học kỳ
        {
            double tongSoTinCuaHK = 0;
            double tongSoDiem = 0;
            foreach (DataRow dr in dt.Rows) // Duyệt DataTable dt
            {
                if (dr["KyHoc"].ToString() == kyHoc) // Kiểm tra xem hàng của dt tại cột "HocKy" khớp vớ kyHoc truyền vào không
                {
                    try
                    {
                        // trung bình trung học kỳ= sum(số tín của môn trong học kỳ * điểm thang 4)/ (tổng số tín trong học kỳ)
                        if (Convert.ToDouble(dr["Diem"].ToString()) >= 8.5)
                        {
                            tongSoDiem += 4 * Convert.ToInt32(dr["SoTinChi"].ToString());
                        }
                        else if (Convert.ToDouble(dr["Diem"].ToString()) < 8.5 && Convert.ToDouble(dr["Diem"].ToString()) >= 7.7)
                        {
                            tongSoDiem += 3.5 * Convert.ToInt32(dr["SoTinChi"].ToString());
                        }
                        else if (Convert.ToDouble(dr["Diem"].ToString()) < 7.7 && Convert.ToDouble(dr["Diem"].ToString()) >= 7)
                        {
                            tongSoDiem += 3 * Convert.ToInt32(dr["SoTinChi"].ToString());
                        }
                        else if (Convert.ToDouble(dr["Diem"].ToString()) < 7 && Convert.ToDouble(dr["Diem"].ToString()) >= 6.2)
                        {
                            tongSoDiem += 2.5 * Convert.ToInt32(dr["SoTinChi"].ToString());
                        }
                        else if (Convert.ToDouble(dr["Diem"].ToString()) < 6.2 && Convert.ToDouble(dr["Diem"].ToString()) >= 5.5)
                        {
                            tongSoDiem += 2 * Convert.ToInt32(dr["SoTinChi"].ToString());
                        }
                        else if (Convert.ToDouble(dr["Diem"].ToString()) < 5.5 && Convert.ToDouble(dr["Diem"].ToString()) >= 4.7)
                        {
                            tongSoDiem += 1.5 * Convert.ToInt32(dr["SoTinChi"].ToString());
                        }
                        else if (Convert.ToDouble(dr["Diem"].ToString()) < 4.7 && Convert.ToDouble(dr["Diem"].ToString()) >= 4)
                        {
                            tongSoDiem += 1 * Convert.ToInt32(dr["SoTinChi"].ToString());
                        }
                        tongSoTinCuaHK += Convert.ToInt32(dr["SoTinChi"].ToString());
                    }
                    catch (Exception)
                    {

                    }
                    

                }
            }

            if (tongSoTinCuaHK == 0) // Nếu học kỳ đó không học môn nào thì trả về 0;
            {
                return 0;
            }
            return Math.Round(tongSoDiem / tongSoTinCuaHK, 2);
        }

        private double tinhTrungBinhTrungTichLuy(int tongSoTin)
        {
            double tongSoDiem = 0;
            foreach (DataRow dr in dt.Rows) // Duyệt DataTable dt
            {

                try
                {
                    // trung bình trung tích lũy = sum(số tín * điểm thang 4)/ (tổng số tín)
                    if (Convert.ToDouble(dr["Diem"].ToString()) >= 8.5)
                    {
                        tongSoDiem += 4 * Convert.ToInt32(dr["SoTinChi"].ToString());
                    }
                    else if (Convert.ToDouble(dr["Diem"].ToString()) < 8.5 && Convert.ToDouble(dr["Diem"].ToString()) >= 7.7)
                    {
                        tongSoDiem += 3.5 * Convert.ToInt32(dr["SoTinChi"].ToString());
                    }
                    else if (Convert.ToDouble(dr["Diem"].ToString()) < 7.7 && Convert.ToDouble(dr["Diem"].ToString()) >= 7)
                    {
                        tongSoDiem += 3 * Convert.ToInt32(dr["SoTinChi"].ToString());
                    }
                    else if (Convert.ToDouble(dr["Diem"].ToString()) < 7 && Convert.ToDouble(dr["Diem"].ToString()) >= 6.2)
                    {
                        tongSoDiem += 2.5 * Convert.ToInt32(dr["SoTinChi"].ToString());
                    }
                    else if (Convert.ToDouble(dr["Diem"].ToString()) < 6.2 && Convert.ToDouble(dr["Diem"].ToString()) >= 5.5)
                    {
                        tongSoDiem += 2 * Convert.ToInt32(dr["SoTinChi"].ToString());
                    }
                    else if (Convert.ToDouble(dr["Diem"].ToString()) < 5.5 && Convert.ToDouble(dr["Diem"].ToString()) >= 4.7)
                    {
                        tongSoDiem += 1.5 * Convert.ToInt32(dr["SoTinChi"].ToString());
                    }
                    else if (Convert.ToDouble(dr["Diem"].ToString()) < 4.7 && Convert.ToDouble(dr["Diem"].ToString()) >= 4)
                    {
                        tongSoDiem += 1 * Convert.ToInt32(dr["SoTinChi"].ToString());
                    }
                }
                catch (Exception)
                {

                }                
            }
            return tongSoDiem / tongSoTin;
        }

        private string xepHang(double n)
        {
            if (n >= 3.6)
            {
                return "Xuất Sắc";
            }
            else if (n < 3.6 && n >= 3.2)
            {
                return "Giỏi";
            }
            else if (n < 3.2 && n >= 2.5)
            {
                return "Khá";
            }
            else if (n < 2.5 && n >= 1)
            {
                return "Trung Bình";
            }
            return "Kém";
        }
    }
}
