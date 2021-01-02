using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeMay : XeCo, IXeHienDai
    {
        //Khai báo thuộc tính
        //Interface
        public string BienSoXe { set; get; }
        //class XeMay
        private string _phankhoi;
        public string phankhoi
        {
            set { this._phankhoi = value; }
            get { return _phankhoi; }
        }
        //Khai báo phương thức
        public XeMay() : base()
        {
            this.BienSoXe = "";
            this.phankhoi = "";
            this.loaiXe = Scanner.xeMay;
        }
        public XeMay(string maXe, string BienSoXe, string hangXe, string phankhoi) : base(maXe, hangXe)
        {
            this.BienSoXe = BienSoXe;
            this.phankhoi = phankhoi;
            this.loaiXe = Scanner.xeMay;
        }
        public XeMay(XeCo xe, string phankhoi, string BienSoXe) : base(xe)
        {
            this.BienSoXe = BienSoXe;
            this.phankhoi = phankhoi;
            this.loaiXe = Scanner.xeMay;
        }

        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.BienSoXe} \nPhan khoi: {this.phankhoi} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
    }
}
