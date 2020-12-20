using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeHoi : XeCo
    {
        //Khai báo thuộc tính
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
            this.mauXe = "";
            this.soCuaXe = -1;
            this.loaiXe = Scanner.xeHoi;
        }
        public XeHoi(string maXe, string bienSoXe, string hangXe, DateTime ngayGio, int soCuaXe, string mauXe) : base(maXe, bienSoXe, hangXe, ngayGio)
        {
            this.soCuaXe = soCuaXe;
            this.mauXe = mauXe;
            this.loaiXe = Scanner.xeHoi;
        }
        public XeHoi(XeCo xe, int soCuaXe, string mauXe) : base(xe)
        {
            this.soCuaXe = soCuaXe;
            this.mauXe = mauXe;
            this.loaiXe = Scanner.xeHoi;
        }

        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.bienSoXe} \nSo cua xe: {this.soCuaXe} \nMau xe: {this.mauXe} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
    }
}
