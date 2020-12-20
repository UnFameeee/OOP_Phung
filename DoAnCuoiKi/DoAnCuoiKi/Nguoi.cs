using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public enum GioiTinh
    {
        Nam,
        Nu
    }
    public class Nguoi
    {
        public int theXe { set; get; }
        public string khuonMat { set; get; }
        public GioiTinh gioiTinh { set; get; }
        public string dangNguoi { set; get; }
        public Nguoi()
        {
            this.khuonMat = null;
            this.gioiTinh = GioiTinh.Nam;
            this.dangNguoi = null;
            this.theXe = -1;
        }
        public Nguoi(string khuonMat, GioiTinh gioiTinh, string dangNguoi, int theXe)
        {
            this.khuonMat = khuonMat;
            this.gioiTinh = gioiTinh;
            this.dangNguoi = dangNguoi;
            this.theXe = theXe;
        }
        public Nguoi(Nguoi x)
        {
            this.khuonMat = x.khuonMat;
            this.gioiTinh = x.gioiTinh;
            this.dangNguoi = x.dangNguoi;
            this.theXe = x.theXe;
        }
        public string anhNguoi()
        {
            return "Gioi tinh: " + this.gioiTinh + "\nKhuon mat: " + this.khuonMat + "\nThe hinh: " + this.dangNguoi;
        }
    }
}
