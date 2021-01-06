using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class NguoiGuiXe:Nguoi
    {
        public int theXe { set; get; }
        public NguoiGuiXe() : base()
        {
            this.theXe = -1;   
        }
        public NguoiGuiXe(string khuonMat, GioiTinh gioiTinh, string dangNguoi) : base(khuonMat, gioiTinh, dangNguoi)
        {
<<<<<<< HEAD
            this.theXe = -1; 
=======
            this.theXe = -1;
>>>>>>> f341ce4357a6a46d73f2da5b0531c52663a2c028
        }
        public NguoiGuiXe(NguoiGuiXe x)
        {
            this.theXe = x.theXe;
            this.khuonMat = x.khuonMat;
            this.gioiTinh = x.gioiTinh;
            this.dangNguoi = x.dangNguoi;
        }
        public override string anhNguoi()
        {
            return $"Gioi tinh:  {this.gioiTinh}\nKhuon mat:  {this.khuonMat} \nThe hinh: {this.dangNguoi}";
        }
        //Tiến
        public static string tatDenXe()
        {
            return "Tat den xe\n";
        }
        public static string thaoKhauTrang()
        {
            return "Thao khau trang\n";
        }
        public static string layThe()
        {
            return "Lay the\n";
        }
        public static string duaThe()
        {
            return "Dua The\n";
        }
        public static string duaTien()
        {
            return "Dua Tien\n";
        }
        public delegate string hanhDongKhach();
        public string hanhDongCuaKhach(hanhDongKhach hanhDongCuaKhach)
        {
            return hanhDongCuaKhach();
        }
    }
}
