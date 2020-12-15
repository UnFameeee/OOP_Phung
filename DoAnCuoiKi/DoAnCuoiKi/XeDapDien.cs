using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeDapDien : XeCo
    {
        private string BinhDien { set; get; }
        public XeDapDien():base()
        {
        }
        public XeDapDien(int maXe, string loaixe, string bienSoXe, string hangXe, DateTime ngayGio, string BinhDien) : base(maXe, loaixe, bienSoXe, hangXe, ngayGio)
        {
            this.BinhDien = BinhDien;
        }
        public XeDapDien(XeCo xe) : base(xe)
        {
        }
    }
}
