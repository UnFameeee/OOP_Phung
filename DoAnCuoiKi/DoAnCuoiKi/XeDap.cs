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
        public XeDap(int maXe, Scanner loaiXe, string bienSoXe, string hangXe, DateTime ngayGio) : base(maXe, loaiXe, bienSoXe, hangXe, ngayGio)
        {
            this.bienSoXe = null;
        }
        public XeDap(XeCo xe) : base(xe)
        {
            this.bienSoXe = null;
        }
        public override string anhXe()
        {
            return base.anhXe();
        }
    }
}
