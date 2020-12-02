using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantManagerment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            tab1QLBanAn1.BringToFront();
        }
        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn Có Muốn Thoát Hay Không ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
                Application.Exit();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            tab3QuanLiNhanSu1.BringToFront();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            tab1QLBanAn1.BringToFront();
        }

        private void QLTD_Click(object sender, EventArgs e)
        {
            tab2QLThucDon1.BringToFront();
        }
    }
}
