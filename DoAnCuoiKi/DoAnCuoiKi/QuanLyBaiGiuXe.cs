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
        private int[] slXe = new int[4];
        public int[,] slotXe = new int[4, sucChua]; //khai báo mảng gồm 5 dòng 1000 cột có giá trị = 0
        public List<string> danhSachTTXeDaLay { set; get; }
        public Dictionary<int, string> anhXe { set; get; }
        public Dictionary<int, string> anhNguoi { set; get; }
        public Dictionary<int, string> viTriTrongBai { set; get; }
       
        //Thắng
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
        public void themXe(XeCo xe, Nguoi nguoi)
        {
            int hangXe = (int)xe.loaiXe;
            for(int i = 0; i < sucChua; i++)
            {
                if(slotXe[hangXe, i] == 0)
                {
                    slotXe[hangXe, i] = 1;
                    slXe[hangXe]++;
                    nguoi.theXe = phatTheXe();
                    xe.maXe = (hangXe + "." + i).ToString();
                    break;
                }
                //thêm giá trị của thẻ xe vào chỗ bản đồ trong mảng 2 chiều
            }

        }
        public int slXeBatKy(Scanner x)
        {
            return slXe[(int)x];
        }
        public int tongSoXe()
        {
            int sum = 0;
            foreach (int i in slXe)
            {
                sum += i;
            }
            return sum;
        }
        public string statusBaiXe()
        {
            return $"Xe dap: {sucChua - slXe[0]} slot\nXe dap dien: {sucChua - slXe[1]} slot" +
                $"\nXe may: {sucChua - slXe[2]} slot\nXe hoi: {sucChua - slXe[3]} slot";
        }

        //M.Đăng
        public string thongTinXe(XeCo xe, DateTime thoiGianXacNhan, string anhXeRa, string anhNguoiRa)
        {
            return xe + "\nThoi gian xac nhan lay xe: " + thoiGianXacNhan + "\nAnh xe vao: " + "anhXe[xe.maXe]" + "\nAnh nguoi vao: " + "anhNguoi[xe.maXe]" + "\nAnh xe ra: " + anhXeRa + "\nAnh nguoi ra: " + anhNguoiRa;
        }
        public bool xoaXe(string maTheXe,XeCo xe,Nguoi nguoilayxe)
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
    }
}
