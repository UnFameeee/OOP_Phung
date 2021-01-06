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
    public abstract class Nguoi
    { 
        public string khuonMat { set; get; }
        public GioiTinh gioiTinh { set; get; }
        public string dangNguoi { set; get; }
        public Nguoi()
        {
            this.khuonMat = null;
            this.gioiTinh = GioiTinh.Nam;
            this.dangNguoi = null;
        }
        public Nguoi(string khuonMat, GioiTinh gioiTinh, string dangNguoi)
        {
            this.khuonMat = khuonMat;
            this.gioiTinh = gioiTinh;
            this.dangNguoi = dangNguoi;
        }
        public Nguoi(Nguoi x)
        {
            this.khuonMat = x.khuonMat;
            this.gioiTinh = x.gioiTinh;
            this.dangNguoi = x.dangNguoi;
        }

        public abstract string anhNguoi();
    }
}
