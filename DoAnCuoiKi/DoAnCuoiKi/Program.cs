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
            //Dictionary<string, string> chisokhac = new Dictionary<string, string>()
            //{
            //    { "binhDien", "" },
            //    { "phanKhoi","" },
            //    {"...","" }
            //};
            //QuanLyBaiGiuXe a = new QuanLyBaiGiuXe();
            //Console.WriteLine();
            //Console.WriteLine("Nhap thong tin xe: ");
            //chisokhac["binhDien"] = "50W";


            //--------------Đã Xong Q.Thắng----------------------
            QuanLyBaiGiuXe a = new QuanLyBaiGiuXe();
            XeCo XeDap1 = new XeDap();
            Nguoi A = new Nguoi();
            a.themXe(XeDap1, A);
            Console.WriteLine(XeDap1.maXe);
            Console.WriteLine(a.tongSoXe());
            Console.WriteLine(a.statusBaiXe());
            Console.WriteLine($"the xe: {A.theXe}");
            XeCo XeMay1 = new XeMay();
            Nguoi B = new Nguoi();
            a.themXe(XeMay1, B);
            Console.WriteLine(XeMay1.maXe);
            Console.WriteLine(a.tongSoXe());
            Console.WriteLine(a.statusBaiXe());
            Console.WriteLine($"the xe: {B.theXe}");
            //---------------------------------------------------
            // -----------------------TEST - NMD-----------------------
            Console.WriteLine("==============");
            Console.WriteLine("===Xe Dap======");
            Console.WriteLine(XeDap1.anhXe());
            Console.WriteLine("=====Xe May======");
            Console.WriteLine(XeMay1.anhXe());
            Console.WriteLine("=====Anh Nguoi=====");
            Console.WriteLine(A.anhNguoi());
        }
    }
}
