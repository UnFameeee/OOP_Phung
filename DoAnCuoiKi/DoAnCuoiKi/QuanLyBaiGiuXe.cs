using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoAnCuoiKi
{
    public enum Scanner { KhongXacDinh, XeDap, XeDapDien, XeMay, XeHoi }
    public struct ThongTinXeTrongBai
    {
        public string anhXe;
        public string anhNguoi;
        public int hang;
        public int cot;
    }
    public class QuanLyBaiGiuXe
    {
        //Khai báo thuộc tính
        public const int sucChua = 1000;
        private int[] slXe = new int[4];
        public int[,] slotXe = new int[4, sucChua]; //khai báo mảng gồm 5 dòng 1000 cột có giá trị = 0
        public Dictionary<string,string> danhSachTTXeDaLay { set; get; }
        //public Dictionary<int, string> anhXe { set; get; }
        //public Dictionary<int, string> anhNguoi { set; get; }
        //public Dictionary<int, string> viTriTrongBai { set; get; }
        public Dictionary<string, ThongTinXeTrongBai> TTXeTrongBai { set; get; }
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
            for (int i = 0; i < sucChua; i++)
            {
                if (slotXe[hangXe, i] == 0)
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
        //private void layViTriTu_Ma(string maTheXe,out int hang, out int cot)
        //{
        //    int len = maTheXe.Length;
        //    int canduoi,cantren=len-1;
        //    int dem = 1;
        //    cot = 0; hang = 0;
        //    while(maTheXe[cantren]!='.')
        //    {
        //        cot += (maTheXe[cantren] - 48) * dem;
        //        dem *= 10;
        //        --cantren;
        //    }
        //    dem = 1;
        //    canduoi = cantren-1;
        //    while(canduoi!=-1)
        //    {
        //        hang += (maTheXe[canduoi]-48)*dem;
        //        dem *= 10;
        //        --canduoi;
        //    }
        //}
        public string thongTinXe(string maTheXe,DateTime thoiGianXeVao, DateTime thoiGianXacNhan, string anhXeRa, string anhNguoiRa)
        {
            return "Thoi gian xe vao: "+thoiGianXeVao+"\nThoi gian xac nhan lay xe: " + thoiGianXacNhan + "\nAnh xe vao: " + TTXeTrongBai[maTheXe].anhXe + "\nAnh nguoi vao: " + TTXeTrongBai[maTheXe].anhNguoi + "\nAnh xe ra: " + anhXeRa + "\nAnh nguoi ra: " + anhNguoiRa;
        }
        public string xoaXe(string maTheXe, XeCo xe, Nguoi nguoilayxe)
        {
            string anhXeVao, anhNguoiVao,anhXeRa, anhNguoiRa;
            anhNguoiVao = TTXeTrongBai[maTheXe].anhNguoi;
            anhXeVao = TTXeTrongBai[maTheXe].anhXe;
            anhXeRa = xe.anhXe();
            anhNguoiRa = nguoilayxe.anhNguoi();
            if (anhXeVao==anhXeRa&&anhNguoiVao==anhNguoiRa)
            {
                DateTime timeNow = DateTime.Now;
                TTXeTrongBai.Remove(maTheXe);
                slotXe[TTXeTrongBai[maTheXe].hang, TTXeTrongBai[maTheXe].cot] =0;
                int sotien = tinhTienGuiXe(tinhThoiGianGuiXe(xe.ngayGio, timeNow),xe.loaiXe);
                danhSachTTXeDaLay.Add(maTheXe,thongTinXe(maTheXe,xe.ngayGio,timeNow, anhXeRa, anhNguoiRa));
                return "So tien phai tra la: "+sotien+"\n";
            }
            else
                return "Loi xac thuc.\n";
        }
        public int tinhTienGuiXe(int sogio, Scanner loaixe)
        {
            return loaixe != Scanner.XeHoi ? (2000 + (int)loaixe * 1000) + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
        }
        public int tinhThoiGianGuiXe(DateTime timeGuiXe, DateTime timeNow)
        {
            TimeSpan temp = timeNow.Subtract(timeGuiXe);
            return temp.Hours;
        }
    }
}
