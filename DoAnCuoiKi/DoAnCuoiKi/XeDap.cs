using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeDap : XeCo
    {
        public XeDap() : base()
        {
            this.bienSoXe = null;
            this.loaiXe = Scanner.xeDap;
        }
        public XeDap(string maXe, string bienSoXe, string hangXe, DateTime ngayGio) : base(maXe, bienSoXe, hangXe, ngayGio)
        {
            this.bienSoXe = null;
            this.loaiXe = Scanner.xeDap;
        }
        public XeDap(XeCo xe) : base(xe)
        {
            this.bienSoXe = null;
            this.loaiXe = Scanner.xeDap;
        }
        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
    }
}
