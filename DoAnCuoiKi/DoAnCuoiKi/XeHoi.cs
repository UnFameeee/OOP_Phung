using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeHoi : XeCo
    {
        private int _soCuaXe;
        private string _mauXe;
        public XeHoi():base()
        {

        }

        public XeHoi(int maXe, string loaiXe, string bienSoXe, string hangXe, DateTime ngayGio, int soCuaXe, string mauXe) : base(maXe, loaiXe, bienSoXe, hangXe, ngayGio)
        {
            this.soCuaXe = soCuaXe;
            this.mauXe = mauXe;
        }
        public XeHoi(XeCo xe,int soCuaXe,string mauXe) : base(xe)
        {
            this.soCuaXe = soCuaXe;
            this.mauXe = mauXe;
        }
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
    }
}
