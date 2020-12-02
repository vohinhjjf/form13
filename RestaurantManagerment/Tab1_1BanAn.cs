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
using DAO;
using System.Threading;

namespace RestaurantManagerment
{
    public partial class Tab1_1BanAn : UserControl
    {
        public Tab1_1BanAn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tab1_2ThongTinBanAn1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tab1_2ThongTinBanAn1.Visible = true;
        }

        List<BanAn_DTO> tableList;
        private void LoadBanAn()
        {
            tableList = BanAn_DAO.LayBanAn();
            for (int i = 0; i < tableList.Count; i++)
            {
                Button btn = new Button() { Width = BanAn_DAO.tableWidth, Height = BanAn_DAO.tableHeight };
                btn.Image = Properties.Resources.icons8_tableware_48px;
                btn.ImageAlign = ContentAlignment.BottomCenter;
                
                btn.Text = Environment.NewLine + tableList[i].TenBan;
                btn.Font = new Font("Arial", 11, FontStyle.Bold);
                btn.TextAlign = ContentAlignment.TopCenter;
                btn.Click += btn_Click;
                
                btn.Tag = tableList[i];
                switch (tableList[i].TrangThai)
                {
                    case "Trống":
                        btn.BackColor = Color.White;
                        break;
                    case "Bận":
                        btn.BackColor = Color.Aqua;                       
                        break;
                }  
                flpSoDoBan.Controls.Add(btn);                
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as BanAn_DTO).ID-1; 
            Add(tableID);
            ShowMonAn(tableID);
            ShowBill(tableID);
        }
        public void ShowMonAn(int i)
        {            
            monAn1.Visible = true;
            
        }
        private void tab1_2ThongTinBanAn1_Load(object sender, EventArgs e)
        {
                    
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            flpSoDoBan.Controls.Clear();
            
            LoadBanAn();         
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {          
            LoadBanAn();
            bunifuFlatButton1.Enabled = false;
        }
        public void Add( int i)
        {
            mTBNgay.Clear();
            List<BanAn_DTO> tableList = BanAn_DAO.LayBanAn();
            txtBan.Text = tableList[i].TenBan;
            if (tableList[i].TrangThai == "Bận")
            {
                mTBNgay.Text = tableList[i].Ngay;               
            }
            else
            {  
                 mTBNgay.Text = "00/00/0000";                   
            }
            txtTT.Text = tableList[i].TrangThai;
        }
        private void mTBNgay_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        public void ShowBill(int i)
        {
            List<Bill_DTO> lstBill = Bill_Dao.LayMonAn();
            foreach (Bill_DTO item in lstBill)
            {
                ListViewItem lsvItem = new ListViewItem(item.Ma.ToString());
                lsvItem.SubItems.Add(item.TenMon.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
            }  
        }
    }
}
