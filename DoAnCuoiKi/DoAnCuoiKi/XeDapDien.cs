using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeDapDien : XeCo
    {
        private string binhDien { set; get; }
        public XeDapDien():base()
        {
        }
        public XeDapDien(int maXe, string loaixe, string bienSoXe, string hangXe, DateTime ngayGio, string BinhDien) : base(maXe, loaixe, bienSoXe, hangXe, ngayGio)
        {
            this.binhDien = binhDien;
        }
        public XeDapDien(XeCo xe, string binhDien) : base(xe)
        {
            this.binhDien = binhDien;
        }
        public override string ToString()
        {
            return base.ToString()+"\nMa xe "+this.maXe+"\nBien so xe: "+this.bienSoXe+"\nBinh dien: " + this.binhDien+"\nLoai xe: " +this.loaiXe+"\nHang xe: "+this.hangXe+"\nThoi gian gui xe: "+this.ngayGio;
        }
    }
}
