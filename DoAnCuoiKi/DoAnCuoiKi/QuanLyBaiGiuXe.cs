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
        //Khai báo thuộc tính
        public const int sucChua = 1000;

        public Scanner demXeBatKi { set; get; }
        public int demXeDap { set; get; }
        public int demXeDapDien { set; get; }
        public int demXeMay { set; get; }
        public int demXeHoi { set; get; }
        public int[,] slotXe = new int[4, sucChua]; //khai báo mảng gồm 5 dòng 1000 cột có giá trị = 0
        public List<string> danhSachTTXeDaLay { set; get; }
        public Dictionary<int, string> anhXe { set; get; }
        public Dictionary<int, string> anhNguoi { set; get; }
        public Dictionary<int, string> viTriTrongBai { set; get; }
        //a[ramdom]=3.50 nghia la dong 3 cot 50
        public QuanLyBaiGiuXe()
        {
            this.demXeDap = 0;
            this.demXeDapDien = 0;
            this.demXeMay = 0;
            this.demXeHoi = 0;
        }
        public QuanLyBaiGiuXe(int[,] slotXe, List<string> danhSachTTXeDaLay, Dictionary<int, string> anhXe, Dictionary<int, string> anhNguoi, Dictionary<int, string> viTriTrongBai, List<int> listTheXe)
        {
            this.demXeDap = 0;
            this.demXeDapDien = 0;
            this.demXeMay = 0;
            this.demXeHoi = 0;
            this.slotXe = slotXe;
            this.danhSachTTXeDaLay = danhSachTTXeDaLay;
            this.anhXe = anhXe;
            this.anhNguoi = anhNguoi;
            this.viTriTrongBai = viTriTrongBai;
        }
        public QuanLyBaiGiuXe(QuanLyBaiGiuXe QL)
        {
            this.demXeDap = 0;
            this.demXeDapDien = 0;
            this.demXeMay = 0;
            this.demXeHoi = 0;
            this.slotXe = QL.slotXe;
            this.danhSachTTXeDaLay = QL.danhSachTTXeDaLay;
            this.anhXe = QL.anhXe;
            this.anhNguoi = QL.anhNguoi;
            this.viTriTrongBai = QL.viTriTrongBai;
        }

        //Khai báo phương thức

        public string thongTinXe(XeCo xe, DateTime thoiGianXacNhan,string anhXeRa,string anhNguoiRa)
        {
            return xe + "\nThoi gian xac nhan lay xe: " + thoiGianXacNhan + "\nAnh xe vao: " + "anhXe[xe.maXe]" + "\nAnh nguoi vao: " + "anhNguoi[xe.maXe]" + "\nAnh xe ra: " + anhXeRa + "\nAnh nguoi ra: " + anhNguoiRa;
        }

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
                        ++demXeDap;
                    }
                    else if(hangXe == 2)
                    {
                        ++demXeDapDien;
                    }
                    else if(hangXe == 3)
                    {
                        ++demXeMay;
                    }
                    else
                    {
                        ++demXeHoi;
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
                n = _r.Next() % 1000000;
                isExists = listTheXe.Contains(n);
            }
            listTheXe.Add(n);
            return n;
        }
    }
}
