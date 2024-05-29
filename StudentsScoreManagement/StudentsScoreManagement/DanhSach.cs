using FontAwesome.Sharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsScoreManagement
{
    public partial class DanhSach : Form
    {
        private IconButton currentBtn; 
        private Panel leftBorderBtn;
        private Form currentForm;
        public string ma { get; set; } //  mã có thuộc tính set:cung cấp, get:truy cập
        public string welcome { get; set; }
        DataUtil data = new DataUtil(); 
        NhapXuat nx = new NhapXuat(); 
        public DanhSach()
        {
            InitializeComponent();
            leftBorderBtn = new Panel(); //  tạo đường viền cho các button
            leftBorderBtn.Size = new Size(5, 50);
            panelMenu.Controls.Add(leftBorderBtn);
        }

        private struct RGBcolors // tạo cấu trúc màu
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);// các thông số của màu
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 177, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(75, 111, 231);
        }

        private void ActiveButton(object senderBtn, Color color)//  phuong thức kích hoạt màu 
        {
            if (senderBtn != null) // nếu hợp lệ
            {
                DisableButton();// đóng button
                currentBtn = (IconButton)senderBtn;// lấy tham chiếu đến các nút đang hoạt động để thực hiện các hành động trên nút
                currentBtn.BackColor = Color.FromArgb(64, 92, 219);
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter; //Chỉ định căn chỉnh của nội dung   
                currentBtn.IconColor = color;


                iconformCon.IconChar = currentBtn.IconChar; 
                iconformCon.IconColor = currentBtn.IconColor;
                lblTittle.Text = currentBtn.Text; 
            }
        }
        private void DisableButton() // thuộc tính đóng button 
        {
            if (currentBtn != null) // nếu btn hoạt động 
            {
                currentBtn.BackColor = Color.FromArgb(58, 120, 242); 
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;

            }
        }
        //Mở form con vào trong pannel
        private void OpenFormCon(Form formcon)
        {
            if (currentForm != null) // nếu form khác rỗng 
            {
                currentForm.Close();// đóng from đang hiển thị
            }
            currentForm = formcon; // gán from đang hiển thị = fromcon
            formcon.TopLevel = false; // ẩn các fromcon khác
            formcon.FormBorderStyle = FormBorderStyle.None;
            panelDisplay.Controls.Add(formcon); // add fromcon vào panel hiển thị
            panelDisplay.Tag = formcon;
            formcon.BringToFront();  
            formcon.Show(); // hiển thị from con
        }
        private void xoaTextbox() // xóa textbox
        {
            txtTenLop.Clear();
            txtTenMH.Clear();
            txtTimkiem.Clear();
            cbHeDT.Text = "";
            cbKhoa.Text = "";
            cbNam.Text = "";
            comboBoxKH.Text = "";
            comboBoxMH.Text = "";
        }
        private void btnSearch_Click(object sender, EventArgs e) // button tim kiem
        {
            if (panelSearch.Visible == true) 
            {
                panelMenucon.Visible = true;
                panelSearch.Visible = false;
            }
            else
            {
                panelMenucon.Visible = false;
                panelSearch.Visible = true;
                ActiveButton(sender, RGBcolors.color1);
            }
            xoaTextbox();
        }
        private void AnbtnLop()  // ẩn btnLop
        {
            lblKhoa.Visible = false;
            cbKhoa.Visible = false;
            lblHeDD.Visible = false;
            lblNam.Visible = false;
            cbKhoa.Visible = false;
            cbNam.Visible = false;
            cbHeDT.Visible = false;
        }
         
        private void HienBtnLop() // ẩn /hiện cac label, combobox 
        {
            lblKhoa.Visible = true;
            cbKhoa.Visible = true;
            lblHeDD.Visible = true;
            lblNam.Visible = true;
            cbKhoa.Visible = true;
            cbNam.Visible = true;
            cbHeDT.Visible = true;
        }

        private void btnDiem_Click(object sender, EventArgs e) //button diem
        {
            ActiveButton(sender, RGBcolors.color2);
            Diem diem = new Diem(); 
            if (ma != null) // kiem tra ma ( userID ) dang nhap
                diem.ma = ma;  // truyen ma sang from diem
            diem.user = welcome;
            OpenFormCon(diem);
            // Thay doi cac gia tri cua label 
            lblLoc.Text = "Tìm kiếm điểm sinh viên"; 
            btnSearch.Visible = true;
            lbMa.Text = "Mã sinh viên";
            lblMHorT.Text = "Mã môn học";
            lbHocKy.Text = "Kỳ học";
            // An cac textbox va combobox khong can thiet
            txtTenMH.Visible = false;
            txtTenLop.Visible = false;
            comboBoxMH.Visible = true;
            comboBoxKH.Visible = true;
            AnbtnLop();

            comboBoxMH.Items.Clear(); // Xoa du lieu cu cua combobox mon hoc
            // Them du lieu moi
            foreach (DataRow dr in data.dsMonHoc().Rows)
                comboBoxMH.Items.Add(dr["MaMH"].ToString());
            comboKH();
            
        }
        private void comboKH() // them du lieu cho ky hoc
        {
            comboBoxKH.Items.Clear();
            comboBoxKH.Items.Add("1");
            comboBoxKH.Items.Add("2");
            comboBoxKH.Items.Add("3");
            comboBoxKH.Items.Add("4");
            comboBoxKH.Items.Add("5");
            comboBoxKH.Items.Add("6");
            comboBoxKH.Items.Add("7");
            comboBoxKH.Items.Add("8");

        }
        private void btnMonhoc_Click(object sender, EventArgs e)
        {
            comboKH(); // them du lieu cho ky hoc
            ActiveButton(sender, RGBcolors.color3);
            Mon mon = new Mon(); // khoi tao from mon hoc
            mon.user = welcome; // truyen du lieu sang from mon hoc
            OpenFormCon(mon);
            // Thay doi cac gia tri cua label 
            lblLoc.Text = "Tìm kiếm môn học";
            lbMa.Text = "Mã môn học";
            lblMHorT.Text = "Tên môn học";
            lbHocKy.Text = "Kỳ học";
            // An va hien cac combobox va textbox
            btnSearch.Visible = true;
            txtTenMH.Visible = true;
            txtTenLop.Visible = false;
            comboBoxMH.Visible = false;
            comboBoxKH.Visible = true;
            AnbtnLop();
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBcolors.color4);
            LopHoc lop = new LopHoc(); // tao from lophoc
            lop.user = welcome; // truyen du lieu sang from lop hoc
            OpenFormCon(lop); 

            btnSearch.Visible = true; // hien button search 

            // thay doi gia tri cua label ( trong panel tim kiem )

            lblLoc.Text = "Tìm kiếm lớp";
            lbMa.Text = "Mã lớp";
            lblMHorT.Text = "Mã khoa";
            lbHocKy.Text = "Tên lớp";

            // xóa dữ liệu cũ của các combobox
            cbKhoa.Items.Clear();
            cbHeDT.Items.Clear();
            cbNam.Items.Clear();

            foreach (DataRow dr in data.dsLop().Rows) // duyệt dữ liệu danh sách lớp
            {
                // kiểm tra combobox đã tồn tại dữ liệu này hay chưa 
                if (cbKhoa.Items.IndexOf(dr["Khoa"].ToString())==-1) 
                {
                    cbKhoa.Items.Add(dr["Khoa"].ToString()); // nếu chưa tồn tại thì thêm dữ liệu vào combobox
                }

                if (cbNam.Items.IndexOf(dr["NamNhapHoc"].ToString()) == -1)
                {
                    cbNam.Items.Add(dr["NamNhapHoc"].ToString());
                }
                if (cbHeDT.Items.IndexOf(dr["HeDaoTao"].ToString()) == -1)
                {
                    cbHeDT.Items.Add(dr["HeDaoTao"].ToString());
                }
              

            }
            txtTenMH.Visible = true;
            comboBoxMH.Visible = false;
            txtTenLop.Visible = true;
            comboBoxKH.Visible = false;
            HienBtnLop();
        }

        private void btnKhoa_Click(object sender, EventArgs e) //button khoa
        {
            ActiveButton(sender, RGBcolors.color5);
            Khoa khoa = new Khoa(); // khởi tạo from Khoa
            khoa.user = welcome; // truyền dữ liệu sang from khoa

            OpenFormCon(khoa);
            //thay đổi giá trị của label
            lbMa.Text = "Mã Khoa";
            lblMHorT.Text = "Tên khoa";
            lblLoc.Text = "Tìm kiếm khoa";
            lbHocKy.Text = "Số điện thoại";
            //ẩn hiện các button combobox textbox
            btnSearch.Visible = true;
            txtTenMH.Visible = true;
            comboBoxMH.Visible = false;
            txtTenLop.Visible = true;
            comboBoxKH.Visible = false;
            AnbtnLop();
        }

        private void btnTaikhoan_Click(object sender, EventArgs e) // button tài khoản
        {
            if(welcome.ToUpper().Equals("ADMIN")) // kiểm tra xem có phải admin không
            {
                ActiveButton(sender, RGBcolors.color6);
                OpenFormCon(new TaiKhoan()); // mở from tài khoản 
                btnSearch.Visible = false; // ẩn button tìm kiếm
            }
            else
            {
                ActiveButton(sender, RGBcolors.color7); 
                OpenFormCon(new HuongDan()); // mở from hướng dẫn
                btnSearch.Visible = false; // ẩn button tìm kiếm
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e) // picture home
        {
            try
            {
                // Trở lại giao diện trang chủ
                Reset();
                if(currentForm!=null)
                {
                    currentForm.Close();
                }
                panelSearch.Visible = false;
                btnSearch.Visible = false;
                panelSave.Visible = false;
                btnDiem.Visible = true;
                btnKhoa.Visible = true;
                btnLop.Visible = true;
                panelSaveExcel.Visible = false;
                panelSavePDF.Visible = false;
                btnMonhoc.Visible = true;
                btnTaikhoan.Visible = true;
                btnDangXuat.Visible = true;
                panelMenucon.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            
        }

        private void Reset() 
        {
            DisableButton(); 
            leftBorderBtn.Visible = false;
            iconformCon.IconChar = IconChar.Home;
            iconformCon.IconColor = Color.White;
            lblTittle.Text = "Trang Chủ";

        }


        private void DanhSach_Load(object sender, EventArgs e) 
        {
            btnSearch.Visible = false;  // ẩn button tìm kiếm 
            panelSearch.Visible = false; // ẩn panel tìm kiếm
            lblWelcome.Text = "Xin chào " + welcome.ToUpper(); // tạo lời chào 
            if(!welcome.ToUpper().Equals("ADMIN")) // kiểm tra người dùng có phải admin không
            {
                btnTaikhoan.Text = "Hướng Dẫn"; // thay đổi text của button tài khoản thành hướng dẫn
            }    
        }

        private void btnQL_Click(object sender, EventArgs e) // button quay lại
        {
            
            xoaTextbox();

            // ẩn và hiện các panel , button
            panelSearch.Visible = false;
            panelMenucon.Visible = true;
            panelSave.Visible = false;
            btnDiem.Visible = true;
            btnKhoa.Visible = true;
            btnLop.Visible = true;
            btnMonhoc.Visible = true;
            btnDangXuat.Visible = true;
            btnTaikhoan.Visible = true;

            // kiểm tra xem from cần tìm kiếm là from nào

            if (lblLoc.Text.Contains("điểm")) // nếu là form điểm 
            {
                // Khởi tạo from điểm và truyền dữ liệu 
                Diem diem = new Diem(); 
                diem.user = welcome;
                if (ma != null) //kiểm tra mã người đăng nhập
                    diem.ma = ma;
                OpenFormCon(diem);
            }
            else if (lblLoc.Text.Contains("môn học"))
            {
                Mon mon = new Mon();
                mon.user = welcome;
                OpenFormCon(mon);
            }
            else if (lblLoc.Text.Contains("khoa"))
            {
                Khoa khoa = new Khoa();
                khoa.user = welcome;
                OpenFormCon(khoa);
            }
            else
            {
                LopHoc lopHoc = new LopHoc();
                lopHoc.user = welcome;
                OpenFormCon(lopHoc);
            }
        }


        //====================== TÌM KIẾM ==================

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            // kiểm tra from hiện tại thông qua label Lọc
            if (lblLoc.Text.Contains("điểm"))
            {
                TimKiem tk = new TimKiem(); // khởi tạo from tìm kiếm
                List<string> list = new List<string>(); // khởi tạo list biến cần truyền sang from tìm kiếm
                // thêm các dữ liệu cần thiết
                list.Add(txtTimkiem.Text); 
                list.Add(Convert.ToString(comboBoxMH.SelectedItem));
                list.Add(Convert.ToString(comboBoxKH.SelectedItem));

                // truyền dữ liệu sang from tìm kiếm
                tk.list = list; // truyền list sang from tìm kiếm
                tk.user = welcome;
                tk.title = "điểm sinh viên";
                OpenFormCon(tk);
            }
            else if (lblLoc.Text.Contains("môn học"))
            {
                TimKiem tk = new TimKiem(); // khởi tạo from tìm kiếm
                List<string> list = new List<string>();// khởi tạo list biến cần truyền sang from tìm kiếm

                 // thêm các dữ liệu cần thiết
                list.Add(txtTimkiem.Text);
                list.Add(txtTenMH.Text);
                list.Add(Convert.ToString(comboBoxKH.SelectedItem));

                // truyền dữ liệu sang from tìm kiếm
                tk.list = list; // truyền list sang from tìm kiếm 
                tk.user = welcome;
                tk.title = "môn học";
                OpenFormCon(tk);
            }
            else if (lblLoc.Text.Contains("khoa"))
            {
                TimKiem tk = new TimKiem(); // khởi tạo from tìm kiếm
                List<string> list = new List<string>(); // khởi tạo list biến cần truyền sang from tìm kiếm

                   // thêm các dữ liệu cần thiết
                list.Add(txtTimkiem.Text);
                list.Add(txtTenMH.Text);
                list.Add(txtTenLop.Text);

                // truyền dữ liệu sang from tìm kiếm
                tk.list = list; // truyền list sang from tìm kiếm
                tk.user = welcome;
                tk.title = "khoa";
                OpenFormCon(tk);
            }
            else
            {
                TimKiem tk = new TimKiem();// khởi tạo from tìm kiếm
                List<string> list = new List<string>();// khởi tạo list biến cần truyền sang from tìm kiếm

                // thêm các dữ liệu cần thiết
                list.Add(txtTimkiem.Text);
                list.Add(txtTenMH.Text);
                list.Add(txtTenLop.Text);
                list.Add(Convert.ToString(cbKhoa.SelectedItem));
                list.Add(Convert.ToString(cbHeDT.SelectedItem));
                list.Add(Convert.ToString(cbNam.SelectedItem));

                // truyền dữ liệu sang from tìm kiếm
                tk.list = list;
                tk.user = welcome;
                tk.title = "lớp";
                OpenFormCon(tk);
            }
        }



        // =====================Lưu File ====================
        private void btnSave_Click(object sender, EventArgs e) // button lưu file
        {
            // kiểm tra xem đã hiện panel lưu file chưa
            if (panelSave.Visible == false)
            {
                ActiveButton(sender, RGBcolors.color1);
                btnDangXuat.Visible = false;
                panelSave.Visible = true;
                btnDiem.Visible = false;
                btnKhoa.Visible = false;
                btnLop.Visible = false;
                btnTaikhoan.Visible = false;
                btnMonhoc.Visible = false;
                panelSaveExcel.Visible = false;
                panelSavePDF.Visible = false;
            }
            else
            {
                panelSave.Visible = false;
                btnDiem.Visible = true;
                btnKhoa.Visible = true;
                btnLop.Visible = true;
                btnMonhoc.Visible = true;
                btnDangXuat.Visible = true;
                btnTaikhoan.Visible = true;
            }
        }

      

        private void savePDF_Click(object sender, EventArgs e)
        {
            if (panelSavePDF.Visible == false)
            {
                ActiveButton(sender, RGBcolors.color4);
                panelSavePDF.Visible = true;
                panelSaveExcel.Visible = false;
            }
            else
            {
                panelSavePDF.Visible = false;
            }
        }


        private void saveExcel_Click(object sender, EventArgs e)
        {
            if (panelSaveExcel.Visible == false)
            {
                ActiveButton(sender, RGBcolors.color4);
                panelSaveExcel.Visible = true;
                panelSavePDF.Visible = false;
            }
            else
            {
                panelSaveExcel.Visible = false;
            }
        }
        

        private void btnPDFDiem_Click(object sender, EventArgs e) // button lưu bảng điểm thành file pdf
        {
            // kiểm tra xem có phải sinh viên đăng nhập hay không
            if(ma!=null) 
                nx.exportFilePDF(data.timkiem(ma, "", ""));  // lưu file điểm sinh viên
            else
                nx.exportFilePDF(data.dsDiemSV());  // lưu file điểm 
        }

        private void btnPDFMH_Click(object sender, EventArgs e)
        {
            nx.exportFilePDF(data.dsMonHoc()); // lưu danh sách môn học thành file pdf
        }

        private void btnPDFLop_Click(object sender, EventArgs e)
        {
            nx.exportFilePDF(data.dsLop()); // lưu danh sách lớp thành file pdf
        }

        private void btnPDFKhoa_Click(object sender, EventArgs e)
        {
            nx.exportFilePDF(data.dsKhoa()); // lưu danh sách khoa thành file pdf
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            Close();
        }

        private void btnExcelDiem_Click(object sender, EventArgs e)
        {
            // kiểm tra xem có phải sinh viên đăng nhập hay không
            if (ma != null)
                nx.exportToExcel(data.timkiem(ma, "", ""));  // lưu file điểm sinh viên
            else
                nx.exportToExcel(data.dsDiemSV());  // lưu file điểm 
        }

        private void btnExcelMH_Click(object sender, EventArgs e)
        {
            nx.exportToExcel(data.dsMonHoc()); // lưu danh sách môn học sang file excel
        }

        private void btnExcelLop_Click(object sender, EventArgs e)
        {
            nx.exportToExcel(data.dsLop()); // lưu danh sách lớp sang file excel
        }

        private void btnExcelKhoa_Click(object sender, EventArgs e)
        {
            nx.exportToExcel(data.dsKhoa()); // lưu danh sách khoa sang file excel
        }
       
    }
}
