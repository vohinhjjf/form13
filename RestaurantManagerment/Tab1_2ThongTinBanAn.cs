using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Text.RegularExpressions;

namespace RestaurantManagerment
{
    public partial class Tab1_2ThongTinBanAn : UserControl
    {
        public Tab1_2ThongTinBanAn()
        {
            InitializeComponent();
        }

        private void Tab1_2ThongTinBanAn_Load(object sender, EventArgs e)
        {
            LoadBanAn();
        }

        List<BanAn_DTO> lstBanAn;
        private void LoadBanAn()
        {
            lstBanAn = BanAn_BUS.LoadBanAn();
            dtgrvDanhSachBan.DataSource = lstBanAn;

            if (lstBanAn == null)
                return;

            dtgrvDanhSachBan.Columns["ID"].HeaderText = "ID";
            dtgrvDanhSachBan.Columns["TenBan"].HeaderText = "Tên Bàn";
            dtgrvDanhSachBan.Columns["TrangThai"].HeaderText = "Trạng Thái";
            dtgrvDanhSachBan.Columns["Ngay"].HeaderText = "Thời gian";
            dtgrvDanhSachBan.Columns["TenBan"].Width = 100;
            dtgrvDanhSachBan.Columns["TrangThai"].Width = 100;
            dtgrvDanhSachBan.Columns["Ngay"].Width = 200;
            if (lstBanAn != null)
                lbSoBanHienCo.Text = (lstBanAn.Count).ToString();
            else
                lbSoBanHienCo.Text = "0";
        }

        //----------------- chuẩn hóa chuỗi ---------------------------------
        public static string ChuanHoaChuoi(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTenBan.Text == "")
            {
                MessageBox.Show("Nhập tên bàn");
                return;
            }
            BanAn_DTO banAn = new BanAn_DTO();
            banAn.TenBan = txtTenBan.Text.ToString();
            banAn.TrangThai = "Trống";
            if (lstBanAn != null)
            {
                for (int i = 0; i < lstBanAn.Count; i++)
                {
                    if (ChuanHoaChuoi(banAn.TenBan.ToLower()) == ChuanHoaChuoi(lstBanAn[i].TenBan.ToLower()))
                    {
                        MessageBox.Show("Tên đã có rồi");
                        return;
                    }
                }
            }
            if (BanAn_BUS.ThemBanAn(banAn))
            {
                MessageBox.Show("Thêm thành công");
                LoadBanAn();
                if (lstBanAn != null)
                    lbSoBanHienCo.Text = (lstBanAn.Count).ToString();
                else
                    lbSoBanHienCo.Text = "0";
                return;
            }
            MessageBox.Show("Thêm thất bại");
        }
    }
}
