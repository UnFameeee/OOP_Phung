using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeMay : XeCo
    {
        //Khai báo thuộc tính
        private string _phankhoi;
        public string phankhoi
        {
            set { this._phankhoi = value; }
            get { return _phankhoi; }
        }
        //Khai báo phương thức
        public XeMay():base()
        {
            this.phankhoi = null;
        }
        public XeMay(int maXe, Scanner loaiXe, string bienSoXe, string hangXe, DateTime ngayGio, string phankhoi) : base(maXe, loaiXe, bienSoXe, hangXe, ngayGio)
        {
            this.phankhoi = phankhoi;
        }
        public XeMay(XeCo xe,string phankhoi) : base(xe)
        {
            this.phankhoi = phankhoi;
        }

        public override string ToString()
        {
            return base.ToString() + "\nMa xe " + this.maXe + "\nBien s xe: " + this.bienSoXe +"\nPhan khoi: "+this.phankhoi+ "\nLoai xe: " + this.loaiXe + "\nHang xe: " + this.hangXe + "\nThoi gian gui xe: " + this.ngayGio;
        }
    }
}
