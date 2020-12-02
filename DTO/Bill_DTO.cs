using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill_DTO
    {
        public Bill_DTO()
        { }
        private int ma;
        private string tenmon;
        private int soluong;
        public int Ma { get=>ma; set=>ma=value; }
        public string TenMon { get=>tenmon; set=>tenmon=value; }
        public int SoLuong { get=>soluong; set=>soluong=value; }
    }
}
