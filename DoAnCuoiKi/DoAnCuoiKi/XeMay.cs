using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeMay : XeCo
    {
        private string _phankhoi;

        public XeMay():base()
        {
            this.phankhoi = null;
        }

        public XeMay(int maXe, string loaiXe, string bienSoXe, string hangXe, DateTime ngayGio, string phankhoi) : base(maXe, loaiXe, bienSoXe, hangXe, ngayGio)
        {
            this.phankhoi = phankhoi;
        }
        public XeMay(XeCo xe,string phankhoi) : base(xe)
        {
            this.phankhoi = phankhoi;
        }

        public string phankhoi
        {
            set { this._phankhoi = value; }
            get { return _phankhoi; }
        }
        public override string ToString()
        {
            return base.ToString() + "\nMa xe " + this.maXe + "\nBien s xe: " + this.bienSoXe +"\nPhan khoi: "+this.phankhoi+ "\nLoai xe: " + this.loaiXe + "\nHang xe: " + this.hangXe + "\nThoi gian gui xe: " + this.ngayGio;
        }
    }
}
