using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCuoiKi
{
    public abstract class XeCo
    {
        int _maXe; //string maXe
        protected string _loaiXe;
        protected string _bienSoXe;
        protected string _hangXe;
        DateTime _ngayGio;
        public XeCo()
        {
            this.maXe = -1;
            this.loaiXe = null;
            this.bienSoXe = null;
            this.hangXe = null;
            this.ngayGio = DateTime.Now;
        }

        public XeCo(int maXe, string loaiXe, string bienSoXe, string hangXe, DateTime ngayGio)
        {
            this.maXe = maXe;
            this.loaiXe = loaiXe;
            this.bienSoXe = bienSoXe;
            this.hangXe = hangXe;
            this.ngayGio = ngayGio;
        }
        public XeCo(XeCo xe)
        {
            this.maXe = xe.maXe;
            this.loaiXe = xe.loaiXe;
            this.bienSoXe = xe.bienSoXe;
            this.hangXe = xe.hangXe;
            this.ngayGio = xe.ngayGio;
        }
        public int maXe
        {
            set { this._maXe = value; }
            get { return this._maXe; }
        }

        public string loaiXe
        {
            set { this._loaiXe = value; }
            get { return this._loaiXe; }
        }
        public string bienSoXe
        {
            set { this._bienSoXe = value; }
            get { return this._bienSoXe; }
        }
        public string hangXe
        {
            set { this._hangXe = value; }
            get { return this._hangXe; }
        }
        public DateTime ngayGio
        {
            set { this._ngayGio = value; }
            get { return this._ngayGio; }
        }
        public override string ToString()
        {
            return base.ToString();                 //chưa biết làm gì?
        }
    }
}
