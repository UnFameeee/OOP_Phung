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
        public List<string> danhSachTTXeDaLay { set; get; }
        //khởi tạo false hết, có xe để vô thì chuyển thành true
        //0-24: xe dap 3 (25-3)*100
        //25-49: xe may 2 (25-2)*100
        //50-74: xe dap dien 0 (25-0)*100
        //75-99: xe hoi 1 (25-1)*100
        public string thongTinXe(XeCo xe, DateTime thoiGianXacNhan,string anhXeRa,string anhNguoiRa)
        {
            return xe + "\nThoi gian xac nhan lay xe: " + thoiGianXacNhan + "\nAnh xe vao: " + "anhXe[xe.maXe]" + "\nAnh nguoi vao: " + "anhNguoi[xe.maXe]" + "\nAnh xe ra: " + anhXeRa + "\nAnh nguoi ra: " + anhNguoiRa;
        }
        public XeCo themXe(string loaiXe, string bienSoXe, string hangXe, DateTime ngayGio)
        {
            //XeCo temp = new XeCo();
            //int maXe = 1;
            //temp = new XeCo(maXe, loaiXe, bienSoXe, hangXe, ngayGio);
            //return temp;
            //day la dong test
            XeDap a = new XeDap();
            return a;
        }
        public void demSlotTrong()
        {

        }
        public bool xoaXe(int maTheXe,XeCo xe,Nguoi nguoilayxe)
        {
            if(maTheXe==xe.maXe)
            {
                string anhXeRa,anhNguoiRa;
                anhXeRa = ""+xe;
                anhNguoiRa = ""+nguoilayxe;
                //... Đợi Wibu
                danhSachTTXeDaLay.Add(thongTinXe(xe, DateTime.Now, anhXeRa, anhNguoiRa));
                return true;
            }
            else
                return false;
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
            //Xe đạp: 2000      Xe đạp điện: 3000       Xe máy: 4000        Xe hơi: 10000
            //Xe đạp: 2000+(sogio/5)*2000; 
            // dưới 0-4h59p59s tiếng 2 ngàn 4,59..../5=0 -->3000
            //5 tiếng là 4000
            //9 tiếng là 4000
            //10 tiếng là 9000
            return loaixe != Scanner.XeHoi ? (2000 + (int)loaixe * 1000) + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
        }
        public int tinhThoiGianGuiXe(DateTime timeGuiXe)
        {
            DateTime timeNow = DateTime.Now;
            TimeSpan temp = timeNow.Subtract(timeGuiXe);
            return temp.Hours;
        }
        //list chỗ để xe [có 100 phần tử] --> chỗ trống trong bãi: 100 - anhxe.length();
        //list ảnh xe :anhxe              --> số xe: anhxe.Length();
        //list ảnh người   

    }
}
