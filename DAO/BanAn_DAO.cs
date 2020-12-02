using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class BanAn_DAO
    {
        static SQLiteConnection conn;

        public static List<BanAn_DTO> LayBanAn()
        {
            string QueryString = "Select * From BanAn";
            conn = DataProvider.OpenConnection();
            DataTable dt = DataProvider.LayDataTable(QueryString, conn);
            
            if (dt.Rows.Count == 0)
                return null;

            List<BanAn_DTO> lstBanAn = new List<BanAn_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                BanAn_DTO banAn = new BanAn_DTO();

                banAn.ID = int.Parse(dt.Rows[i]["ID"].ToString());
                banAn.TenBan = dt.Rows[i]["TenBan"].ToString();
                banAn.TrangThai = dt.Rows[i]["TrangThai"].ToString();
                banAn.Ngay = dt.Rows[i]["Ngay"].ToString();
                
                lstBanAn.Add(banAn);
            }
            DataProvider.CloseConnection(conn);
            return lstBanAn;
        }

        public static int tableWidth = 90;
        public static int tableHeight = 90;
        public static bool ThemBanAn(BanAn_DTO banAn)
        {
            // chuỗi truy vấn thêm 1 món ăn vào bảng Món Ăn
            string QueryString = string.Format("insert into BanAn(TenBan,TrangThai) values('{0}','{1}')", banAn.TenBan, banAn.TrangThai);
            conn = DataProvider.OpenConnection();
            try
            {
                DataProvider.ThucThiTruyVanNonQuery(QueryString, conn);
                DataProvider.CloseConnection(conn);
                return true;
            }
            catch (Exception)
            {
                DataProvider.CloseConnection(conn);
                return false;
            }
        }
    }
}
