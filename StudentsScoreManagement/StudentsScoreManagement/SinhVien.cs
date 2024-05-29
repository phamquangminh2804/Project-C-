using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsScoreManagement
{
    class SinhVien
    {
        private string masv;
        private string hodem;
        private string ten;
        private DateTime ngaysinh;
        private string diachi;
        private string gioitinh;
        private string email;
        private string sodienthoai;
        private string malop;

        public string Masv { get => masv; set => masv = value; }
        public string Hodem { get => hodem; set => hodem = value; }
        public string Ten { get => ten; set => ten = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Email { get => email; set => email = value; }
        public string Sodienthoai { get => sodienthoai; set => sodienthoai = value; }
        public string Malop { get => malop; set => malop = value; }
        public SinhVien()
        {

        }
        public SinhVien(string masv, string hodem, string ten, DateTime ngaysinh, string diachi, string gioitinh, string email, string sodienthoai, string malop)
        {
            this.masv = masv;
            this.hodem = hodem;
            this.ten = ten;
            this.ngaysinh = ngaysinh;
            this.diachi = diachi;
            this.gioitinh = gioitinh;
            this.email = email;
            this.sodienthoai = sodienthoai;
            this.malop = malop;
        }
    }
}
