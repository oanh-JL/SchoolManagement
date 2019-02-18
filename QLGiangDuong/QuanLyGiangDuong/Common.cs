using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiangDuong
{
    class Common
    {
        public string SinhMa(string stringStart)
        {
            Random rd = new Random();
            string id;
            id = stringStart + rd.Next(0, 1000000000);
            return id;
        }
    }
}
