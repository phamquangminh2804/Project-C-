using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsScoreManagement
{

    class DataUtil
    {
        SqlConnection con; // tạo biến sqlconncetion
        public DataUtil()
        {
            string strconnect = @"Data Source=LAPTOP-SLPAVCGQ\SQLEXPRESS;Initial Catalog=QLDiem;Integrated Security=True"; //tạo biến lưu string kết nối
            con = new SqlConnection(strconnect);  // khởi tạo biến sqlconnection

        }


        // ------------------------- Bảng Điểm -----------------------

        public DataTable dsDiemSV() // trả về datatable danh sách điểm sinh viên
        {
            con.Open(); // mở kết nối
            DataTable table = new DataTable(); // khởi tạo datatable
            //câu lệnh truy vấn sql
            string sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con); // tạo sqldataAdapter
            adap.Fill(table); // đổ dữ liệu vào datatable
            con.Close(); // đóng kết nối 
            return table; // trả về datatable
        }

        public DataTable dsSVMon(string mamh) // hàm trả về danh sách sinh viên của môn học
        {
            con.Open(); // mở kết nối
            DataTable table = new DataTable(); // khỏi tạo datatable
            // tạo câu lệnh truy vấn sql
            string sql = "select SinhVien.MaSV,HoDem,Ten,MaLop,MonHoc.MaMH,MonHoc.TenMH,KyHoc,SoTinChi,Diem from SinhVien inner join DiemThi on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH where MonHoc.MaMH='" + mamh+"'";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table); // đổ dữ liệu vào datatable
            con.Close(); /// đóng kết nối
            return table; // trả về datatable
        }

        // hàm nhâp điểm sinh viên
        public Boolean NhapDiem(string maMH, string masv, int diem, int kyhoc)
        {
            con.Open(); // mở kết nối
            try
            {
                // kiểm tra điểm nhập và kỳ học nhập vào
                if (diem >= 0 && diem <= 10 && kyhoc >= 1 && kyhoc <= 8) 
                {
                    // tạo sqlCommand
                    SqlCommand sql = new SqlCommand("insert into DiemThi values (@mamh,@masv,@diem,@kyhoc)");
                    // thêm giá trị tham số
                    sql.Parameters.AddWithValue("@mamh", maMH);
                    sql.Parameters.AddWithValue("@masv", masv);
                    sql.Parameters.AddWithValue("@diem", diem);
                    sql.Parameters.AddWithValue("@kyhoc", kyhoc);
                    sql.Connection = con;
                    if (sql.ExecuteNonQuery() > 0)
                    {
                        con.Close();
                        return true;
                    }
                    {
                        con.Close();
                        return false;
                    }
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }

        // hàm sửa điểm
        public Boolean SuaDiem(int diemThi, string maMH, string masv)
        {
            con.Open(); // mở kết nối
            try
            {
                // kiểm tra điểm thi nhập vào
                if (diemThi >= 0 && diemThi <= 10)
                {
                    // tạo sqlcommand
                    SqlCommand sql = new SqlCommand("update DiemThi set Diem=@diemthi where MaMH=@mamh and MaSV=@masv");
                    // thêm giá trị cho các tham số
                    sql.Parameters.AddWithValue("@diemthi", diemThi);
                    sql.Parameters.AddWithValue("@mamh", maMH);
                    sql.Parameters.AddWithValue("@masv", masv);
                    sql.Connection = con;
                    if (sql.ExecuteNonQuery() > 0)
                    {
                        con.Close();
                        return true;
                    }
                    {
                        con.Close();
                        return false;
                    }
                }
                con.Close();
                return false;
            }
            catch (Exception)
            {

                con.Close();
                return false;
            }

        }
        // hàm xóa điểm
        public Boolean DeleteDiem(string maMH, string masv)
        {
            try
            {
                con.Open(); // mở kết nối 
                            // khởi tạo sqlcommand
                SqlCommand sql = new SqlCommand("delete from DiemThi where MaMH=@mamh and MaSV=@masv");
                // thêm giá trị cho các tham số
                sql.Parameters.AddWithValue("@mamh", maMH);
                sql.Parameters.AddWithValue("@masv", masv);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)// chạy câu lệnh
                {

                    con.Close(); // đóng kết nối
                    return true;
                }
                con.Close(); // đóng kết nối
                return false;

            }
            catch (Exception)
            {
                con.Close(); // đóng kết nối
                return false;
            }
            
        }
        // hàm trả về điểm 
        public DataTable layDiemThi(string masv)
        {
            con.Open(); // mở kết nối
            DataTable table = new DataTable(); // tạo datatable
            // tạo câu lệnh truy vấn
            string sql = "select MonHoc.MaMH, TenMH, SoTinChi, HocKy, Diem from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV"
                + " inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH"
                + " where SinhVien.MaSV = '" + masv + "'";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table); // đổ dữ liệu vào datatable
            con.Close(); // đóng kết nối
            return table; // trả về dữ liệu
        }

        // hàm tìm kiếm điểm
        public DataTable timkiem(string msv, string mmh, string hk)
        {
            // khởi tạo datatable
            DataTable table = new DataTable();
            // khởi tạo câu lệnh truy vấn
            string sql = "";
            // xét các trường hợp để có câu lệnh truy vấn phù hợp
            if (hk.Trim().Equals("") && !msv.Trim().Equals("") && !mmh.Trim().Equals(""))
            {
                sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH where SinhVien.MaSV='" + msv + "'and MonHoc.MaMH='" + mmh + "'";
            }

            else if (msv.Trim().Equals("") && !hk.Trim().Equals("") && !mmh.Trim().Equals(""))
            {
                sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH where MonHoc.MaMH='" + mmh + "' and KyHoc=" + hk + "";
            }

            else if (mmh.Trim().Equals("") && !hk.Trim().Equals("") && !msv.Trim().Equals(""))
            {
                sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH where SinhVien.MaSV='" + msv + "'and KyHoc=" + hk + "";
            }

            else if (hk.Trim().Equals("") && msv.Trim().Equals("") && !mmh.Trim().Equals(""))
            {
                sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH where MonHoc.MaMH='" + mmh + "'";
            }

            else if (mmh.Trim().Equals("") && hk.Trim().Equals("") && !msv.Trim().Equals(""))
            {
                sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH where SinhVien.MaSV='" + msv + "'";
            }

            else if (msv.Trim().Equals("") && mmh.Trim().Equals("") && !hk.Trim().Equals(""))
            {
                sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH where KyHoc=" + hk + "";
            }
            else if (!msv.Trim().Equals("") && !mmh.Trim().Equals("") && !hk.Trim().Equals(""))
            {
                sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH where SinhVien.MaSV='" + msv + "'and MonHoc.MaMH='" + mmh + "' and KyHoc=" + hk + "";
            }
            else
            {
                sql = "select MonHoc.MaMH,TenMH,SinhVien.MaSV,HoDem,Ten,Diem,KyHoc from DiemThi inner join SinhVien on SinhVien.MaSV = DiemThi.MaSV inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH";
            }

            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table); // đổ dữ liệu vào datatable
            con.Close(); // đóng kết nối
            return table;
        }







        //--------------------------------------------------





        // hàm trả về thông tin chi tiết
        public DataTable thongTinChiTiet(string masv)
        {
            DataTable table = new DataTable(); // khởi tạo datatable
            // tạo câu lệnh truy vấn
            string sql = "select * from SinhVien inner join Lop on SinhVien.MaLop = Lop.MaLop"
                + " inner join DiemThi on SinhVien.MaSV = DiemThi.MaSV"
                + " inner join KhoaDaoTao on KhoaDaoTao.MaKhoa = Lop.MaKhoa"
                + " inner join MonHoc on DiemThi.MaMH = MonHoc.MaMH"
                + " where SinhVien.MaSV = '" + masv + "'";

            SqlDataAdapter adap = new SqlDataAdapter(sql, con); 
            adap.Fill(table);
            con.Close();
            return table;
        }



        // ------------------------- BẢNG MÔN HỌC  ----------------------

         
        public DataTable dsMonHoc() // hàm trả về danh sách môn học
        {
            DataTable table = new DataTable();
            string sql = "select * from MonHoc";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
       
        public DataTable timkiemMH(string mamh, string tenmh, string hk) // hàm tìm kiếm môn học
        {
            DataTable table = new DataTable();
            string sql = "";

            if (hk.Trim().Equals("") && !mamh.Trim().Equals("") && !tenmh.Trim().Equals(""))
            {
                sql = "select * from MonHoc where MaMH='" + mamh + "'and TenMH=N'" + tenmh + "'";
            }

            else if (mamh.Trim().Equals("") && !hk.Trim().Equals("") && !tenmh.Trim().Equals(""))
            {
                sql = "select * from MonHoc where TenMH=N'" + tenmh + "' and HocKy=" + hk + "";
            }

            else if (tenmh.Trim().Equals("") && !hk.Trim().Equals("") && !mamh.Trim().Equals(""))
            {
                sql = "select * from MonHoc where MaMH='" + mamh + "'and HocKy=" + hk + "";
            }

            else if (hk.Trim().Equals("") && mamh.Trim().Equals("") && !tenmh.Trim().Equals(""))
            {
                sql = "select * from MonHoc where TenMH=N'" + tenmh + "'";
            }

            else if (tenmh.Trim().Equals("") && hk.Trim().Equals("") && !mamh.Trim().Equals(""))
            {
                sql = "select * from MonHoc where MaMH='" + mamh + "'";
            }

            else if (mamh.Trim().Equals("") && tenmh.Trim().Equals("") && !hk.Trim().Equals(""))
            {
                sql = "select * from MonHoc where HocKy='" + hk + "'";
            }
            else if (!mamh.Trim().Equals("") && !tenmh.Trim().Equals("") && !hk.Trim().Equals(""))
            {
                sql = "select * from MonHoc where MaMH='" + mamh + "'and TenMH=N'" + tenmh + "' and HocKy=" + hk + "'";
            }
            else
            {
                sql = "select * from MonHoc";
            }
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
   
        public Boolean XoaMH(string maMH) // hàm xóa môn học
        {
            try
            { 
                // xóa điểm thi theo mã môn học
                con.Open();
                SqlCommand sql1 = new SqlCommand("delete from DiemThi where MaMH=@mamh");
                sql1.Parameters.AddWithValue("@mamh", maMH);
                sql1.Connection = con;
                int result1 = sql1.ExecuteNonQuery();
                if (result1 == -1)
                {
                    con.Close();
                    return false;
                }

                // xóa môn học
                SqlCommand sql2 = new SqlCommand("delete from MonHoc where MaMH=@mamh");
                sql2.Parameters.AddWithValue("@mamh", maMH);
                sql2.Connection = con;
                int result2 = sql2.ExecuteNonQuery();
                if (result2 == 2)
                {
                    con.Close();
                    return false;
                }
                con.Close();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }


        public Boolean SuaMH(MonHoc mh) // hàm sửa thông tin môn học
        {
            try
            {
                con.Open();
                SqlCommand sql = new SqlCommand("update MonHoc set TenMH=@tenMH,SoTinChi=@sotc,HocKy=@hocky where MaMH=@mamh");
                sql.Parameters.AddWithValue("@tenMH", mh.Tenmh);
                sql.Parameters.AddWithValue("@sotc", mh.Sotinchi);
                sql.Parameters.AddWithValue("@hocky", mh.Hocky);
                sql.Parameters.AddWithValue("@mamh", mh.Mamh);
                sql.Connection = con;
                if(sql.ExecuteNonQuery()>0)
                {
                    con.Close();
                    return true;
                }
                con.Close();
                return false;
            }
            catch (Exception)
            {

                con.Close();
                return false;
            }
            
        }

        public Boolean nhapMH(MonHoc monHoc) // hàm nhập môn học
        {
            con.Open();
            try
            {

                SqlCommand sql = new SqlCommand("insert into MonHoc values (@mamh,@tenmh,@sotinchi,@hocky)");
                sql.Parameters.AddWithValue("@mamh", monHoc.Mamh);
                sql.Parameters.AddWithValue("@tenmh", monHoc.Tenmh);
                sql.Parameters.AddWithValue("@sotinchi", monHoc.Sotinchi);
                sql.Parameters.AddWithValue("@hocky", monHoc.Hocky);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }

        }



        // -------------------------------- BẢNG SINH VIÊN -----------------------

        public DataTable dsSV() // hàm trả về danh sashc sinh viên
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from SinhVien";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }




        // -------------------------------- BẢNG KHOA -----------------------
        public DataTable dsKhoa() // hàm trả về danh sách khoa
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from KhoaDaoTao";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        public Boolean xoaKhoa(string maKhoa) // hàm xóa khoa
        {
            con.Open();
            try
            {
                DataTable table1 = new DataTable();
                SqlDataAdapter adap1 = new SqlDataAdapter("select MaLop from Lop where MaKhoa='" + maKhoa + "'", con);
                adap1.Fill(table1);// Lay ra danh sach ma lop
                foreach (DataRow dr1 in table1.Rows) // duyet tung lop
                {
                    DataTable table2 = new DataTable();
                    SqlDataAdapter adap2 = new SqlDataAdapter("select MaSV from SinhVien where MaLop='" + dr1["MaLop"] + "'", con);
                    adap2.Fill(table2);// Lay ra danh sach sinh vien theo tung lop
                    foreach (DataRow dr2 in table2.Rows) // duyet sinh vien
                    {
                        SqlCommand sql3 = new SqlCommand("delete from DiemThi where MaSV=@masv");
                        sql3.Parameters.AddWithValue("@masv", dr2["MaSV"].ToString());
                        sql3.Connection = con;
                        int result3 = sql3.ExecuteNonQuery();
                        if (result3 == -1)
                        {
                            con.Close();
                            return false;
                        }
                    }
                    // Xoa sinh vien theo ma lop
                    SqlCommand sql2 = new SqlCommand("delete from SinhVien where MaLop=@malop");
                    sql2.Parameters.AddWithValue("@malop", dr1["MaLop"].ToString());
                    sql2.Connection = con;
                    int result2 = sql2.ExecuteNonQuery();
                    if (result2 == -1)
                    {
                        con.Close();
                        return false;
                    }

                }
                // Xoa Lop theo ma Khoa
                SqlCommand sql1 = new SqlCommand("delete from Lop where MaKhoa=@makhoa");
                sql1.Parameters.AddWithValue("@makhoa", maKhoa);
                sql1.Connection = con;
                int result1 = sql1.ExecuteNonQuery();
                if (result1 == -1)
                {
                    con.Close();
                    return false;
                }

                // Xoa Khoa
                SqlCommand sql4 = new SqlCommand("delete from KhoaDaoTao where MaKhoa=@maKhoa");
                sql4.Parameters.AddWithValue("@maKhoa", maKhoa);
                sql4.Connection = con;
                int result4 = sql4.ExecuteNonQuery();
                if (result4 == -1)
                {
                    con.Close();
                    return false;
                }
                con.Close();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }

        }

        public DataTable timkiemKhoa(string maKhoa, string tenKhoa, string DienThoai) // hàm tìm kiếm khoa
        {
            DataTable table = new DataTable();
            string sql = "select * from KhoaDaoTao";

            if(!maKhoa.Equals(""))
            {
                sql = sql + " where MaKhoa='" + maKhoa + "'";
                if(!tenKhoa.Equals(""))
                {
                    sql = sql + " and TenKhoa=N'" + tenKhoa + "'";
                    if(!DienThoai.Equals(""))
                    {
                        sql = sql + " and DienThoai='" + DienThoai + "'";
                    }    
                }
            }
            else
            {
                if (!tenKhoa.Equals(""))
                {
                    sql = sql + " where TenKhoa=N'" + tenKhoa + "'";
                    if (!DienThoai.Equals(""))
                    {
                        sql = sql + " and DienThoai='" + DienThoai + "'";
                    }
                }
                else
                {
                    if (!DienThoai.Equals(""))
                    {
                        sql = sql + " where DienThoai='" + DienThoai + "'";
                    }
                }    
            }    
            
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }

        public Boolean SuaKhoa(string makhoa,string tenkhoa,string dienthoai) // hàm sửa khoa
        {
            con.Open();
            try
            {
                SqlCommand sql = new SqlCommand("update KhoaDaoTao set TenKhoa=@tenKhoa,DienThoai=@dienthoai where MaKhoa=@maKhoa");
                sql.Parameters.AddWithValue("@tenKhoa", tenkhoa);
                sql.Parameters.AddWithValue("@dienthoai", dienthoai);
                sql.Parameters.AddWithValue("@maKhoa", makhoa);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }

        }
        public Boolean NhapKhoa(string makhoa, string tenkhoa, string dienthoai) // hàm nhập khoa
        {
            con.Open();
            try
            {

                SqlCommand sql = new SqlCommand("insert into KhoaDaoTao values (@maKhoa,@tenKhoa,@dienThoai)");
                sql.Parameters.AddWithValue("@maKhoa", makhoa);
                sql.Parameters.AddWithValue("@tenKhoa", dienthoai);
                sql.Parameters.AddWithValue("@dienThoai", makhoa);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }

        }


        // --------------------------- BẢNG LỚP--------------------------

        public DataTable dsLop() // hàm trả về danh sách lớp
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from Lop";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        public DataTable dsSVLop(string malop) // hàm trả về danh sách sinh viên theo lớp
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select MaSV,HoDem,Ten,NgaySinh,DiaChi,GioiTinh,Email,SoDienThoai from SinhVien inner join Lop on SinhVien.MaLop = Lop.MaLop where Lop.MaLop = '"+malop+"'";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }

        public Boolean xoaLop(string maLop) // hàm xóa lớp
        {
            try
            {
                // tìm tất cả sinh viên có trong lớp
                con.Open();
                DataTable table = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter("select MaSV from SinhVien where MaLop='" + maLop + "'", con);
                adap.Fill(table);
                foreach (DataRow dr in table.Rows) // duyệt sinh viên trong lớp
                {
                    // xóa điểm thi của sinh viên trong lớp
                    SqlCommand sql = new SqlCommand("delete from DiemThi where MaSV=@masv");
                    sql.Parameters.AddWithValue("@masv", dr["MaSV"].ToString());
                    sql.Connection = con;
                    int result = sql.ExecuteNonQuery();
                    if (result == -1)
                    {
                        con.Close();
                        return false;
                    }
                }
                // xóa sinh viên trong lớp
                SqlCommand sql1 = new SqlCommand("delete from SinhVien where MaLop=@malop");
                sql1.Parameters.AddWithValue("@malop", maLop);
                sql1.Connection = con;
                int result1 = sql1.ExecuteNonQuery();
                if (result1 == -1)
                {
                    con.Close();
                    return false;
                }
                // xóa lớp
                SqlCommand sql2 = new SqlCommand("delete from Lop where MaLop=@malop");
                sql2.Parameters.AddWithValue("@malop", maLop);
                sql2.Connection = con;
                int result2 = sql2.ExecuteNonQuery();
                if (result2 == -1)
                {
                    con.Close();
                    return false;
                }
                con.Close();
                return true;
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }

        public Boolean SuaLop(Lop lop) // hàm sửa lớp
        {
            con.Open();
            try
            {
                SqlCommand sql = new SqlCommand("update Lop set MaKhoa=@makhoa,TenLop=@tenLop,Khoa=@khoa,HeDaoTao=@hedt,NamNhapHoc=@namnh,SiSo=@siso where MaLop=@malop");
                sql.Parameters.AddWithValue("@makhoa", lop.maKhoa);
                sql.Parameters.AddWithValue("@tenLop", lop.tenLop);
                sql.Parameters.AddWithValue("@khoa", lop.khoa);
                sql.Parameters.AddWithValue("@hedt", lop.heDaoTao);
                sql.Parameters.AddWithValue("@namnh", lop.nam);
                sql.Parameters.AddWithValue("@siso", lop.siso);
                sql.Parameters.AddWithValue("@malop", lop.maLop);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
           
        }

        public Boolean NhapLop(Lop lop) // hàm nhập lớp
        {
            con.Open();
            try
            {

                SqlCommand sql = new SqlCommand("insert into Lop values (@malop,@makhoa,@tenLop,@khoa,@hedt,@namnh,@siso)");
                sql.Parameters.AddWithValue("@malop", lop.maLop);
                sql.Parameters.AddWithValue("@makhoa", lop.maKhoa);
                sql.Parameters.AddWithValue("@tenLop", lop.tenLop);
                sql.Parameters.AddWithValue("@khoa", lop.khoa);
                sql.Parameters.AddWithValue("@hedt", lop.heDaoTao);
                sql.Parameters.AddWithValue("@namnh", lop.nam);
                sql.Parameters.AddWithValue("@siso", lop.siso);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }

        }

        public DataTable timkiemLop(string malop, string makhoa, string tenlop,string khoa,string hedt,string nam) // hàm tìm kiếm lớp
        {
            DataTable table = new DataTable();
            string sql = "select * from Lop";
            List<string> a = new List<string>(); // tạo list a lưu tên thuộc tính
            List<string> b = new List<string>(); // tạo list b lưu thuộc tính
            // thêm các giá trị vào các list
            if (!malop.Equals(""))
            {
                a.Add(malop);
                b.Add("MaLop");
            }
            if (!makhoa.Equals(""))
            {
                a.Add(makhoa);
                b.Add("MaKhoa");
            }
            if (!tenlop.Equals(""))
            {
                b.Add("TenLop"); 
                a.Add(tenlop);
            }
            if (!khoa.Equals(""))
            {
                a.Add(khoa);
                b.Add("Khoa");
            }
            if (!hedt.Equals(""))
            {
                a.Add(hedt);
                b.Add("HeDaoTao");
            }
            if (!nam.Equals(""))
            {
                a.Add(nam);
                b.Add("NamNhapHoc");
            }
            // nối chuỗi tạo thành câu lệnh truy vấn cần thiết
            if(!(a.Count == 0))
            {
                sql = sql + " where";
                for (int i = 0; i < a.Count; i++)
                {
                    if(i == 0)
                        sql +=" "+ b[i] + "=N'" + a[i] + "'";
                    else 
                        sql += " and " + b[i] + "=N'" + a[i] + "'";

                }
            }
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }


        public DataTable dsTK() // hàm trả về danh sach tài khoản
        {
            con.Open();
            DataTable table = new DataTable();
            string sql = "select * from DangNhap";
            SqlDataAdapter adap = new SqlDataAdapter(sql, con);
            adap.Fill(table);
            con.Close();
            return table;
        }
        public Boolean ThemTaiKhoan(string ten, string passWord) // hàm thêm tài khoản
        {
            con.Open();
            try
            {
                SqlCommand sql = new SqlCommand("insert into DangNhap values (@Ten,@Password)");
                sql.Parameters.AddWithValue("@Ten", ten);
                sql.Parameters.AddWithValue("@Password", passWord);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }

        }
        public Boolean SuaTaiKhoan(string Ten, string passWord) // hàm sửa tài khoản
        {
            con.Open();
            try
            {
                SqlCommand sql = new SqlCommand("update DangNhap set Password=@passWord where Ten=@ten");
                sql.Parameters.AddWithValue("@passWord", passWord);
                sql.Parameters.AddWithValue("@ten", Ten);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }

        }
        public Boolean XoaTaiKhoan(string ten) // hàm xóa tài khoản
        {
            try
            {

                con.Open();
                SqlCommand sql = new SqlCommand("delete from DangNhap where Ten=@ten");
                sql.Parameters.AddWithValue("@ten", ten);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }

        public DataTable TimTaiKhoan(string ten)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("select Ten from DangNhap where Ten =N'" + ten + "' ", con);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            con.Close();
            return dataTable;
        }


        //Đăng nhập

        public DataTable DangNhap(string ten,string passw,int ID)
        {
            con.Open(); // mo ket noi
            string sql = "select * from DangNhap where ( Ten=@ten and Password=@passw ) or ( UserID=@ID and Password=@passw )"; // cau truy van sql
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ten", ten);
            cmd.Parameters.AddWithValue("@passw", passw);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Connection = con;
            SqlDataReader dta = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dta);
            con.Close();
            return dataTable;
        }

        public DataTable DangNhapSV(string ten)
        {
            con.Open();
            string sql = "select * from SinhVien where MaSV=@ten";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.Parameters.AddWithValue("@ten", ten);
            cmd.Connection = con;
            SqlDataReader dta = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dta);
            con.Close();
            return dataTable;
        }

        // --------------------- Sinh Viên 
        public DataTable TimSV(string masv)
        {
            DataTable data = new DataTable();
            con.Open();
            string sql = "select * from SinhVien where MaSV='" + masv + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(data);
            con.Close();
            return data;
        }

        public Boolean ThemSv(SinhVien sinhVien)
        {
            con.Open();
            try
            {
                SqlCommand sql = new SqlCommand("insert into SinhVien values(@MaSV,@HoDem,@Ten,@NgaySinh,@DiaChi,@GioiTinh,@Email,@SoDienThoai,@MaLop)");
                sql.Parameters.AddWithValue("@MaSV", sinhVien.Masv);
                sql.Parameters.AddWithValue("@HoDem", sinhVien.Hodem);
                sql.Parameters.AddWithValue("@Ten", sinhVien.Ten);
                sql.Parameters.AddWithValue("@NgaySinh", sinhVien.Ngaysinh.ToString("yyyy/MM/dd"));
                sql.Parameters.AddWithValue("@DiaChi", sinhVien.Diachi);
                sql.Parameters.AddWithValue("@GioiTinh", sinhVien.Gioitinh);
                sql.Parameters.AddWithValue("@Email", sinhVien.Email);
                sql.Parameters.AddWithValue("@SoDienThoai", sinhVien.Sodienthoai);
                sql.Parameters.AddWithValue("@MaLop", sinhVien.Malop);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
                
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }

        public Boolean XoaSV(string maSV) // hàm xóa sinh viên
        {
            try
            {

                con.Open();
                SqlCommand sql = new SqlCommand("delete from DiemThi where MaSV=@MaSV");
                sql.Parameters.AddWithValue("@MaSV", maSV);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() < 0)
                {
                    con.Close();
                    return false;
                    
                }
                con.Close();
                con.Open();
                SqlCommand sql1 = new SqlCommand("delete from SinhVien where MaSV=@MaSV");
                sql1.Parameters.AddWithValue("@MaSV", maSV);
                sql1.Connection = con;
                if (sql1.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception)
            {
                con.Close();
                return false;
            }
        }

        public Boolean SuaTTSV(SinhVien sinhVien)
        {
            con.Open(); // mở kết nối
            try
            {
                SqlCommand sql = new SqlCommand("Update SinhVien set HoDem = @HoDem,Ten = @Ten,NgaySinh = @NgaySinh,DiaChi = @DiaChi,GioiTinh = @GioiTinh,Email = @Email,SoDienThoai = @SoDienThoai,MaLop = @MaLop where MaSV = @MaSV");
                sql.Parameters.AddWithValue("@MaSV", sinhVien.Masv);
                sql.Parameters.AddWithValue("@HoDem", sinhVien.Hodem);
                sql.Parameters.AddWithValue("@Ten", sinhVien.Ten);
                sql.Parameters.AddWithValue("@NgaySinh", sinhVien.Ngaysinh.ToString("yyyy/MM/dd"));
                sql.Parameters.AddWithValue("@DiaChi", sinhVien.Diachi);
                sql.Parameters.AddWithValue("@GioiTinh", sinhVien.Gioitinh);
                sql.Parameters.AddWithValue("@Email", sinhVien.Email);
                sql.Parameters.AddWithValue("@SoDienThoai", sinhVien.Sodienthoai);
                sql.Parameters.AddWithValue("@MaLop", sinhVien.Malop);
                sql.Connection = con;
                if (sql.ExecuteNonQuery() > 0)
                {
                    con.Close();
                    return true;
                }
                {
                    con.Close();
                    return false;
                }

            }
            catch (Exception)
            {

                con.Close();
                return false;
            }

        }
    }
}
