using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoAnCuoiKi
{
    public enum Scanner { KhongXacDinh, XeDap, XeDapDien, XeMay, XeHoi}

    public class QuanLyBaiGiuXe
    {
        //Khai báo thuộc tính
        public const int sucChua = 1000;

        public Scanner DemXeBatKi { set; get; }
        public int demXeDap { set; get; }
        public int demXeDapDien { set; get; }
        public int demXeMay { set; get; }
        public int demXeHoi { set; get; }
        public int[,] slotXe = new int[5, sucChua]; //khai báo mảng gồm 5 dòng 1000 cột có giá trị = 0
        public List<string> danhSachTTXeDaLay { set; get; }
        public Dictionary<int, string> anhXe { set; get; }
        public Dictionary<int, string> anhNguoi { set; get; }
        public Dictionary<int, string> viTriTrongBai { set; get; }

        //khởi tạo false hết, có xe để vô thì chuyển thành true
        //0-24: xe dap 3 (25-3)*100
        //25-49: xe may 2 (25-2)*100
        //50-74: xe dap dien 0 (25-0)*100
        //75-99: xe hoi 1 (25-1)*100

        //Khai báo phương thức
        
        public string thongTinXe(XeCo xe, DateTime thoiGianXacNhan,string anhXeRa,string anhNguoiRa)
        {
            return xe + "\nThoi gian xac nhan lay xe: " + thoiGianXacNhan + "\nAnh xe vao: " + "anhXe[xe.maXe]" + "\nAnh nguoi vao: " + "anhNguoi[xe.maXe]" + "\nAnh xe ra: " + anhXeRa + "\nAnh nguoi ra: " + anhNguoiRa;
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
        //public QuanLyBaiGiuXe()
        //{
        //    this.demXeDap = 0;
        //    this.demXeDapDien = 0;
        //    this.demXeHoi = 0;
        //    this.demXeMay = 0;
        //}
        //public void themXe(int[,] a, XeCo xe, string loaiXe, string bienSoXe, string hangXe, DateTime ngayGio)
        //{
        //    int h = -1, k = -1, i = 0, n = 25;
        //    if (scanner(xe) == "XeDapDien")
        //    {
        //        i = 25;
        //        n = 50;
        //    }
        //    else if (scanner(xe) == "XeMay")
        //    {
        //        i = 50;
        //        n = 75;
        //    }
        //    else if (scanner(xe) == "XeHoi")
        //    {
        //        i = 75;
        //        n = 100;
        //    } 
        //    while (i < n)
        //    {
        //        for (int j = 0; j < 100; ++j)
        //            if (a[i, j] == 4)
        //            {
        //                h = i;
        //                k = j;
        //                i = 100;
        //                break;
        //            }
        //        ++i;
        //    }
        //    if (h == -1)
        //        HetCho();
        //    else if (scanner(xe) == "XeDap")
        //    {
        //        a[h, k] = 0;
        //        ++demXeDap;
        //    }
        //    else if (scanner(xe) == "XeDapDien")
        //    {
        //        a[h, k] = 1;
        //        ++demXeDapDien;
        //    }
        //    else if (scanner(xe) == "XeMay")
        //    {
        //        a[h, k] = 2;
        //        ++demXeHoi;
        //    }
        //    else
        //    {
        //        a[h, k] = 3;
        //        ++demXeMay;
        //    }

        //}
        //public int demSlotTrong()
        //{
        //    return 10000 - (demXeDap + demXeDapDien + demXeMay + demXeMay);
        //}
        public void themXe(XeCo xe)
        {
            int hangXe = (int)xe.loaiXe;
            for(int i = 0; i < sucChua; i++)
            {
                if(slotXe[hangXe, i] == 0)
                {
                    slotXe[hangXe, i] = 1;
                    if(hangXe == 1)
                    {
                        demXeDap++;
                    }
                    else if(hangXe == 2)
                    {
                        demXeDapDien++;
                    }
                    else if(hangXe == 3)
                    {
                        demXeMay++;
                    }
                    else
                    {
                        demXeHoi++;
                    }
                }
                //thêm giá trị của thẻ xe vào chỗ bản đồ trong mảng 2 chiều
            }

        }
        public void demSlotGiuXe()
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
                //danhSachTTXeDaLay.Add(thongTinXe(xe, DateTime.Now, anhXeRa, anhNguoiRa));
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
            return loaixe != Scanner.XeHoi ? (2000 + (int)loaixe * 1000) + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
        }


        public int tinhThoiGianGuiXe(DateTime timeGuiXe)
        {
            DateTime timeNow = DateTime.Now;
            TimeSpan temp = timeNow.Subtract(timeGuiXe);
            return temp.Hours;
        }

        List<int> listTheXe = new List<int>(101) { 0 };
        public int phatTheXe()
        {
            int n = 0;
            bool isExists = true;
            Random _r = new Random();
            while (isExists == true)
            {
                n = _r.Next() % 1000;
                isExists = listTheXe.Contains(n);
            }
            listTheXe.Add(n);
            return n;
        }
    }
}
