using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    class Program
    {
        static void Main(string[] args)
        {
            //QuanLyBaiGiuXe a = new QuanLyBaiGiuXe();
            //XeCo XeDap1 = new XeDap();
            //XeCo Xedapdien1 = new XeDapDien();
            //Intostr(Xedapdien1);

            Dictionary<string, string> chisokhac = new Dictionary<string, string>()
            {
                { "binhDien", "" },
                { "phanKhoi","" },
                {"...","" }
            };
            QuanLyBaiGiuXe a = new QuanLyBaiGiuXe();
            Console.WriteLine();
            Console.WriteLine("Nhap thong tin xe: ");
            chisokhac["binhDien"] = "50W";
        }
      
        public static void Intostr(XeCo xe)
        {
            Console.WriteLine(xe);
        }
    }
}
