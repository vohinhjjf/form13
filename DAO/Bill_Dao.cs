using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Bill_Dao
    {
        static SQLiteConnection conn;

        public static List<Bill_DTO> LayMonAn()
        {
            string QueryString = "Select * From MonAn";
            conn = DataProvider.OpenConnection();
            DataTable dt = DataProvider.LayDataTable(QueryString, conn);
            if (dt.Rows.Count == 0)
                return null;

            List<Bill_DTO> lstMonAn = new List<Bill_DTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Bill_DTO monAn = new Bill_DTO();

                monAn.Ma = int.Parse(dt.Rows[i]["Ma"].ToString());
                monAn.TenMon = dt.Rows[i]["TenMon"].ToString();
                monAn.SoLuong = int.Parse(dt.Rows[i]["SoLuong"].ToString());
                
                lstMonAn.Add(monAn);
            }
            DataProvider.CloseConnection(conn);
            return lstMonAn;
        }

        public static int tableWidth = 90;
        public static int tableHeight = 90;
        
    }
}
