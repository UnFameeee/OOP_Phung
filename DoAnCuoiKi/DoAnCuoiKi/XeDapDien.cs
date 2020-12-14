using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeDapDien : XeCo
    {
        public XeDapDien():base()
        {
        }
        public XeDapDien(int maXe, string loaixe, string bienSoXe, string hangXe, DateTime ngayGio) : base(maXe, loaixe, bienSoXe, hangXe, ngayGio)
        {
            this.bienSoXe = "asdasdasda";
        }
        public XeDapDien(XeCo xe) : base(xe)
        {
        }
    }
}
