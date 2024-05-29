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
    public partial class TimKiem : Form
    {
        public TimKiem()
        {
            InitializeComponent();
        }
        public string title{ get; set; }
        public string user { get; set; }
        DataUtil data = new DataUtil();
        public List<String> list{ get; set; }


        private void TimKiem_Load(object sender, EventArgs e) // form Tìm kiếm 
        {
            lblTT.Text = "Tìm kiếm " + title;
            loadForm();
        }
        private void loadForm()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear(); // xóa cột
            
            // hiển thị dữ liệu lên datagridview dựa vào mục đích tìm kiếm ( theo biến title )
            if (title.Contains("điểm"))
            {
                dataGridView1.DataSource = data.timkiem(list[0],list[1],list[2]); // tìm kiếm điểm sv
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // sửa headertext cột
                dataGridView1.Columns[0].HeaderText = "Mã môn học";
                dataGridView1.Columns[0].Name = "MaMH";
                dataGridView1.Columns[1].HeaderText = "Tên môn học";
                dataGridView1.Columns[1].Name = "TenMH";
                dataGridView1.Columns[2].HeaderText = "Mã sinh viên";
                dataGridView1.Columns[2].Name = "MaSV";
                dataGridView1.Columns[3].HeaderText = "Họ đệm";
                dataGridView1.Columns[4].HeaderText = "Tên";
                dataGridView1.Columns[5].HeaderText = "Điểm";
                dataGridView1.Columns[5].Name = "Diem";
                dataGridView1.Columns[6].HeaderText = "Kỳ Học";
                dataGridView1.Columns[6].Name = "KyHoc";
                // thêm button nếu người dùng là giáo viên
                if (user.ToUpper().Contains("GV"))
                {
                    addButtonData();
                }
            }
            else if (title.Contains("môn")) // nếu tiêu đề cần tìm là môn
            {
                dataGridView1.DataSource = data.timkiemMH(list[0], list[1], list[2]); // tìm kiếm môn học
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // sửa headertext cột
                dataGridView1.Columns[0].HeaderText = "Mã môn học";
                dataGridView1.Columns[0].Name = "MaMh";
                dataGridView1.Columns[1].HeaderText = "Tên môn học";
                dataGridView1.Columns[2].HeaderText = "Số tín chỉ";
                dataGridView1.Columns[3].HeaderText = "Học Kỳ";
            }
            else if (title.Contains("khoa"))
            {
                dataGridView1.DataSource = data.timkiemKhoa(list[0], list[1], list[2]); // hiển thị datagridview
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //Thuộc tính định cấu hình điều khiển để độ rộng cột 

                // sửa headertext cột
                dataGridView1.Columns[0].HeaderText = "Mã khoa";
                dataGridView1.Columns[0].Name = "MaKhoa";
                dataGridView1.Columns[1].HeaderText = "Tên khoa";
                dataGridView1.Columns[2].HeaderText = "Điện thoại";
            }
            else
            {
                dataGridView1.DataSource = data.timkiemLop(list[0], list[1], list[2], list[3], list[4], list[5]);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                // sửa headertext cột
                dataGridView1.Columns[0].HeaderText = "Mã lớp";
                dataGridView1.Columns[0].Name = "MaLop";
                dataGridView1.Columns[1].HeaderText = "Mã khoa";
                dataGridView1.Columns[2].HeaderText = "Tên lớp";
                dataGridView1.Columns[3].HeaderText = "Khóa";
                dataGridView1.Columns[4].HeaderText = "Hệ đào tạo";
                dataGridView1.Columns[5].HeaderText = "Năm nhập học";
                dataGridView1.Columns[6].HeaderText = "Sĩ Số";
            }
            // thêm button nếu người dùng là admin
            if (user.ToUpper().Equals("ADMIN"))
            {
                if (title.Contains("điểm"))
                {
                    addButtonData();
                    return;
                }
                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn(); // thêm button xoa
                DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();// thêm button sửa
                xoaBtnColumn(btn1);
                suaBtnColumn(btn2);
                dataGridView1.Columns.Add(btn1);
                dataGridView1.Columns.Add(btn2);
            }
                
        }
        private void addButtonData() // thêm các button sửa, xóa, xem chi tiết
        {
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            DataGridViewButtonColumn btn3 = new DataGridViewButtonColumn();
            xoaBtnColumn(btn1);
            suaBtnColumn(btn2);
            xemChiTiet(btn3);
            dataGridView1.Columns.Add(btn1);
            dataGridView1.Columns.Add(btn2);
            dataGridView1.Columns.Add(btn3);
        }
        private void xoaBtnColumn(DataGridViewButtonColumn btn1) //  cột chứa btnXoa
        {
            btn1.HeaderText = @"Xóa";
            btn1.Name = "btnXoa";
            btn1.Text = "Xóa";
            btn1.UseColumnTextForButtonValue = true; // hiện btnxoa
        }

        private void suaBtnColumn(DataGridViewButtonColumn btn2)
        {
            btn2.HeaderText = "Sửa";
            btn2.Name = "btnSua";
            btn2.Text = "Sửa";
            btn2.UseColumnTextForButtonValue = true;
        }

        private void xemChiTiet(DataGridViewButtonColumn btn3)
        {
            btn3.HeaderText = "Xem chi tiết";
            btn3.Name = "btnXem";
            btn3.Text = "Xem thông tin";
            btn3.UseColumnTextForButtonValue = true;
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // các button dựa theo mục đích tìm kiếm
            if (title.Contains("điểm"))
            {
                // kiểm tra người dùng
                if ((!user.ToUpper().Equals("ADMIN") && !user.ToUpper().Contains("GV")) || e.RowIndex < 0)
                    return;
                try
                {
                    // lấy dữ liệu từ datagridview 
                    string masv = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaSV"].Index].Value.ToString();
                    string mamh = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaMH"].Index].Value.ToString();

                    if (e.ColumnIndex == dataGridView1.Columns["btnXem"].Index) //  button xem chi tiết
                    {
                        try
                        {
                            XemChiTiet xem = new XemChiTiet(data.thongTinChiTiet(masv)); // tạo form xem chi tiết
                            xem.ShowDialog(); // hiển thị from

                        }
                        catch (Exception)
                        {

                        }
                    }
                    if (e.ColumnIndex == dataGridView1.Columns["btnSua"].Index) // button sửa
                    {
                        // lấy dữ liệu từ datagridview 
                        string kyhoc = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["KyHoc"].Index].Value.ToString();
                        string diem = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["Diem"].Index].Value.ToString();
                        // khởi tạo from nhập sửa điểm
                        NhapSuaDiem sua = new NhapSuaDiem();
                        // truyền dữ liệu
                        sua.masv = masv;
                        sua.mamh = mamh;
                        sua.kyhoc = kyhoc;
                        sua.diem = diem;
                        sua.ShowDialog();
                        loadForm();
                      
                    }
                    if (e.ColumnIndex == dataGridView1.Columns["btnXoa"].Index) // button xóa
                    {
                        DialogResult dialog = MessageBox.Show("Bạn có muốn xóa điểm của sinh viên này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog.Equals(DialogResult.Yes))
                        {
                            data.DeleteDiem(mamh, masv);
                            loadForm();
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
            else if (title.Contains("môn"))
            {
                // kiểm tra người dùng
                if (!user.ToUpper().Equals("ADMIN") || e.RowIndex < 0)
                    return;
                try
                {
                    // lấy dữ liệu từ datagridview
                    int index = dataGridView1.Columns["MaMH"].Index;
                    string MaMH = dataGridView1.CurrentRow.Cells[index].Value.ToString();
                    if (e.ColumnIndex == dataGridView1.Columns["btnXoa"].Index) // button xóa
                    {
                        DialogResult dialog = MessageBox.Show("Bạn có muốn xóa môn học này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialog.Equals(DialogResult.Yes))
                        {
                            if (!MaMH.Equals(""))
                            {
                                if (!data.XoaMH(MaMH))
                                {
                                    MessageBox.Show("Không thể xóa môn học do  còn  sinh viên học môn này !!!");
                                }
                                else
                                {
                                    dataGridView1.Columns.Clear();
                                    loadForm();
                                }
                            }
                            else
                                MessageBox.Show("Lựa chọn một môn học !!!");
                        }
                    }
                    if (e.ColumnIndex == dataGridView1.Columns["btnSua"].Index) // button sửa
                    {
                        // khởi tạo from nhập sửa môn hoc
                        NhapMH nhapMH = new NhapMH();
                        //truyền dữ liệu 
                        nhapMH.maMH = MaMH;
                        nhapMH.tenMH = dataGridView1.CurrentRow.Cells[index + 1].Value.ToString();
                        nhapMH.soTC = dataGridView1.CurrentRow.Cells[index + 2].Value.ToString();
                        nhapMH.hocKy = dataGridView1.CurrentRow.Cells[index + 3].Value.ToString();
                        nhapMH.ShowDialog();
                        loadForm();
                    }
                }
                catch (Exception)
                {
                }
            }
            else if (title.Contains("khoa"))
            {
                // kiểm tra người dùng
                if (!user.ToUpper().Equals("ADMIN") || e.RowIndex < 0)
                    return;
                // lấy dữ liệu từ datagridview
                string MaKhoa = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaKhoa"].Index].Value.ToString();
                if (e.ColumnIndex == dataGridView1.Columns["btnXoa"].Index) // button xóa
                {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn xóa lớp này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog.Equals(DialogResult.Yes))
                    {
                        if (!MaKhoa.Equals(""))
                        {
                            if (!data.xoaKhoa(MaKhoa))
                            {
                                MessageBox.Show("Không thể xóa khoa này !!!");
                            }
                            else
                            {
                                loadForm();
                            }
                        }
                        else
                            MessageBox.Show("Lựa chọn một lớp để xóa !!!");
                    }
                }
                if (e.ColumnIndex == dataGridView1.Columns["btnSua"].Index) // button sửa
                {
                    // khởi tạo from nhâp sửa khoa
                    NhapSuaKhoa nhap = new NhapSuaKhoa();
                    //truyền dữ liệu 
                    nhap.maKhoa = MaKhoa;
                    nhap.tenKhoa = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaKhoa"].Index+1].Value.ToString();
                    nhap.dienThoai = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaKhoa"].Index+2].Value.ToString();
                    nhap.ShowDialog();
                    loadForm();
                }
            }
            else
            {
                // kiểm tra người dùng
                if (!user.ToUpper().Equals("ADMIN") || e.RowIndex < 0)
                    return;
                // lấy dữ liệu từ datagridview
                int index = dataGridView1.Columns["MaLop"].Index;
                string MaLop = dataGridView1.CurrentRow.Cells[index].Value.ToString();

                if (e.ColumnIndex == dataGridView1.Columns["btnXoa"].Index) // button xóa
                {
                    DialogResult dialog = MessageBox.Show("Bạn có muốn xóa lớp này không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialog.Equals(DialogResult.Yes))
                    {
                        if (!MaLop.Equals(""))
                        {
                            if (!data.xoaLop(MaLop))
                            {
                                MessageBox.Show("Không thể xóa lớp do còn sinh viên trong lớp !!!");
                            }
                            else
                            {
                                loadForm();
                            }
                        }
                        else
                            MessageBox.Show("Lựa chọn một lớp để xóa !!!");
                    }
                }
                if (e.ColumnIndex == dataGridView1.Columns["btnSua"].Index) // button sửa
                {
                    //khởi tạo from nhập sửa lớp 
                    NhapSuaLop nhapSua = new NhapSuaLop();
                    nhapSua.maLop = MaLop; // truyền dữ liệu
                    nhapSua.ShowDialog(); // hiện from nhấp sửa lớp
                    loadForm();
                }
            }
            
            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            // hiển thị danh sách theo from 
            if (title.Contains("lớp"))
            {
                SVLop sv = new SVLop();// tạo from SVLop
                //truyền dữ liệu vào
                sv.user = user;
                sv.maLop = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaLop"].Index].Value.ToString();
                sv.tenLop = dataGridView1.CurrentRow.Cells[dataGridView1.Columns["MaLop"].Index + 2].Value.ToString();
                sv.ShowDialog();
            }
            else if (title.Contains("môn"))
            {
                if (dataGridView1.CurrentRow.Index < 0)
                    return;
                //lấy dữ liệu từ datagridview
                int index = dataGridView1.Columns["MaMH"].Index;
                SVMon formSV = new SVMon(); //tạo from SVMon
                formSV.user = user;
                formSV.maMon = dataGridView1.CurrentRow.Cells[index].Value.ToString(); 
                formSV.tenMon = dataGridView1.CurrentRow.Cells[index + 1].Value.ToString();
                formSV.hocky = dataGridView1.CurrentRow.Cells[index + 3].Value.ToString();
                formSV.ShowDialog();// hiện fromSVMon
            }
        }
    }
}
