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
        public XeMay() : base()
        {
            this.phankhoi = "";
            this.loaiXe = Scanner.xeMay;
        }
        public XeMay(string maXe, string bienSoXe, string hangXe, DateTime ngayGio, string phankhoi) : base(maXe, bienSoXe, hangXe, ngayGio)
        {
            this.phankhoi = phankhoi;
            this.loaiXe = Scanner.xeMay;
        }
        public XeMay(XeCo xe, string phankhoi) : base(xe)
        {
            this.phankhoi = phankhoi;
            this.loaiXe = Scanner.xeMay;
        }

        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.bienSoXe} \nPhan khoi: {this.phankhoi} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
    }
}
