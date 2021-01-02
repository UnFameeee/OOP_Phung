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
            this.loaiXe = Scanner.xeDap;
        }
        public XeDap(string maXe, string hangXe) : base(maXe, hangXe)
        {
            this.loaiXe = Scanner.xeDap;
        }
        public XeDap(XeCo xe) : base(xe)
        {
            this.loaiXe = Scanner.xeDap;
        }
        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
    }
}
