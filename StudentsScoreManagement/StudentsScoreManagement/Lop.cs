using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsScoreManagement
{
    class Lop
    {
        public string maLop{ get; set; }
        public string maKhoa { get; set; }
        public string tenLop { get; set; }
        public string khoa { get; set; }
        public string heDaoTao { get; set; }
        public int nam { get; set; }
        public int siso { get; set; }
        public Lop()
        {

        }
        public Lop(string  malop,string maKhoa,string tenLop,string khoa,string heDaoTao,int nam,int siso)
        {
            this.maKhoa = maKhoa;
            this.maLop = malop;
            this.tenLop = tenLop;
            this.nam = nam;
            this.siso = siso;
            this.khoa = khoa;
            this.heDaoTao = heDaoTao;
        }
    }
}
