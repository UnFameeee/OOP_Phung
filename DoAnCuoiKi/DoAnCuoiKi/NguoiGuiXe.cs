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
        public NguoiGuiXe():base()
        {
            this.theXe = -1;
        }
        public NguoiGuiXe(string khuonMat, GioiTinh gioiTinh, string dangNguoi):base(khuonMat,gioiTinh,dangNguoi)
        {

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
        public override string hanhDong(hanhDongNV hanhDongCuaKhach)
        {
            return hanhDongCuaKhach();
        }
        
    }
}
