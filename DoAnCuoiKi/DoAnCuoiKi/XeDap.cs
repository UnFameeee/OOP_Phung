using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeDap : XeCo
    {
        public XeDap():base()
        {
        }
        public XeDap(int maXe, string loaiXe, string bienSoXe, string hangXe, DateTime ngayGio) : base(maXe, loaiXe, bienSoXe, hangXe, ngayGio)
        {
            this.bienSoXe = null;
        }
        public XeDap(XeCo xe) : base(xe)
        {
            this.bienSoXe = null;
        }
        public override string ToString()
        {
            return base.ToString() + "\nMa xe " + this.maXe + "\nBien so xe: " + this.bienSoXe + "\nLoai xe: " + this.loaiXe + "\nHang xe: " + this.hangXe + "\nThoi gian gui xe: " + this.ngayGio;
        }
    }
}
