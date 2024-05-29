using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsScoreManagement
{
    class MonHoc
    {
        private string mamh;
        private string tenmh;
        private int sotinchi;
        private int hocky;

        public string Mamh { get => mamh; set => mamh = value; }
        public string Tenmh { get => tenmh; set => tenmh = value; }
        public int Sotinchi { get => sotinchi; set => sotinchi = value; }
        public int Hocky { get => hocky; set => hocky = value; }
        public MonHoc()
        {
            
        }
        public MonHoc(string mamh, string tenmh, int sotinchi, int hocky)
        {
            this.mamh = mamh;
            this.tenmh = tenmh;
            this.sotinchi = sotinchi;
            this.hocky = hocky;
        }
    }
}
