using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeHoi : XeCo, IXeHienDai
    {
        //Khai báo thuộc tính
        //Interface
        public string BienSoXe { set; get; }
        //class XeHoi
        private int _soCuaXe;
        private string _mauXe;
        public int soCuaXe
        {
            set { this._soCuaXe = value; }
            get { return this._soCuaXe; }
        }
        public string mauXe
        {
            set { this._mauXe = value; }
            get { return this._mauXe; }
        }
        //Khai báo phương thức
        public XeHoi() : base()
        {
            this.BienSoXe = "";
            this.mauXe = "";
            this.soCuaXe = -1;
            this.loaiXe = Scanner.xeHoi;
        }
        public XeHoi(string maXe, string bienSoXe, string hangXe, int soCuaXe, string mauXe) : base(maXe, hangXe)
        {
            this.BienSoXe = BienSoXe;
            this.soCuaXe = soCuaXe;
            this.mauXe = mauXe;
            this.loaiXe = Scanner.xeHoi;
        }
        public XeHoi(XeCo xe, int soCuaXe, string mauXe) : base(xe)
        {
            this.BienSoXe = BienSoXe;
            this.soCuaXe = soCuaXe;
            this.mauXe = mauXe;
            this.loaiXe = Scanner.xeHoi;
        }

        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.BienSoXe} \nSo cua xe: {this.soCuaXe} \nMau xe: {this.mauXe} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
    }
}
