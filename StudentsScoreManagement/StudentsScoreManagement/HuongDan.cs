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
    public partial class HuongDan : Form
    {
        public HuongDan()
        {
            InitializeComponent();
        }

        private void HuongDan_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate($"https://youtu.be/oPKCo3VkDDY?version=3"); // chuyển tới url
        }
    }
}
