using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public enum Scanner { XeDap, XeDapDien, XeMay, XeHoi}              
    public class QuanLyBaiGiuXe
    {
        public int demSlotGiuXe { set; get; }
        public int demXeDap { set; get; }
        public int demXeDapDien { set; get; }
        public int demXeMay { set; get; }
        public int demXeHoi { set; get; }
        public List<int> chodexe { set; get; } 
        public List<string> anhXe { set; get; }
        public List<string> anhNguoi { set; get; }
        //khởi tạo false hết, có xe để vô thì chuyển thành true
        //0-24: xe dap 3 (25-3)*100
        //25-49: xe may 2 (25-2)*100
        //50-74: xe dap dien 0 (25-0)*100
        //75-99: xe hoi 1 (25-1)*100
        public void Inthongtindsxe()
        {
            //Tạo hàm in tất cả thông tin của xe
        }
        public void BaiXe(int[,] a)
        {
            for (int i = 0; i < 100; ++i)
                for (int j = 0; j < 100; ++j)
                    if (i % 2 == 0) //chan: xe, le: duong di
                        a[i, j] = 4; //4: khoang trong ko co xe
                    else a[i, j] = 5; //5: duong di
        }
        public string HetCho()
        {
            return "Het Cho";
        }
        public void themXe(int[,] a, XeCo xe, string loaiXe, string bienSoXe, string hangXe, DateTime ngayGio)
        {
            //XeCo temp = new XeCo();
            //int maXe = 1;
            //temp = new XeCo(maXe, loaiXe, bienSoXe, hangXe, ngayGio);
            //return temp;
            //day la dong test
            int h = -1, k = -1, i = 0, n = 25;
            if (scanner(xe) == "XeDapDien")
            {
                i = 25;
                n = 50;
            }
            else if (scanner(xe) == "XeMay")
            {
                i = 50;
                n = 75;
            }
            else if (scanner(xe) == "XeHoi")
            {
                i = 75;
                n = 100;
            } 
            while (i < n)
            {
                for (int j = 0; j < 100; ++j)
                    if (a[i, j] == 4)
                    {
                        h = i;
                        k = j;
                        i = 100;
                        break;
                    }
                ++i;
            }
            if (h == -1)
                HetCho();
            else if (scanner(xe) == "XeDap")
            {
                a[h, k] = 0;
                ++demXeDap;
            }
            else if (scanner(xe) == "XeDapDien")
            {
                a[h, k] = 1;
                ++demXeDapDien;
            }
            else if (scanner(xe) == "XeMay")
            {
                a[h, k] = 2;
                ++demXeHoi;
            }
            else
            {
                a[h, k] = 3;
                ++demXeMay;
            }
        }
        public int demSlotTrong()
        {
            return 10000 - (demXeDap + demXeDapDien + demXeMay + demXeMay);
        }
        public void xoaXe()
        {

        }
        public static string scanner(XeCo xe)
        {
            if (xe.GetType() == typeof(XeDap))
                return "XeHoi";
            else if (xe.GetType() == typeof(XeDapDien))
                return "XeDapDien";
            else if (xe.GetType() == typeof(XeMay))
                return "XeMay";
            else
                return "XeHoi";
        }
        public void demXe(params object[] thamso)
        {

        }
        public int tinhTienGuiXe(int sogio, Scanner loaixe)
        {
            //params tới thằng scanner để lấy cái kiểu dữ liệu xe của cái thẻ
            //tùy xe
            //Xe đạp: 2000+(sogio/5)*2000; 
            // dưới 0-4h59p59s tiếng 3 ngàn 4,59..../5=0 -->3000
            //10 tiếng là 9000
            //11 tiếng 3000+(2) * 3000 -->
            //Xe đạp điện: 4000+(sogio/5)*4000;
            //Xe máy: 5000+(sogio/5)*5000;
            //Xe hơi: 15000+(sogio/5)*15000;
            //Xe đạp: 2000      Xe đạp điện: 3000       Xe máy: 4000        Xe hơi: 10000
            return loaixe != Scanner.XeHoi ? (2000 + (int)loaixe * 1000) + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
        }
        public int tinhThoiGianGuiXe(XeCo xe)
        {
            DateTime timenow = DateTime.Now;

            return -1;
        }
        //list chỗ để xe [có 100 phần tử] --> chỗ trống trong bãi: 100 - anhxe.length();
        //list ảnh xe :anhxe              --> số xe: anhxe.Length();
        //list ảnh người   

    }
}
