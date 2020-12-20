using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCuoiKi
{
    public abstract class XeCo
    {
        //Khai báo thuộc tính
        string _maXe;
        protected Scanner _loaiXe;
        protected string _bienSoXe;
        protected string _hangXe;
        DateTime _ngayGio;
        public string maXe
        {
            set { this._maXe = value; }
            get { return this._maXe; }
        }

        public Scanner loaiXe
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

        //Khai báo phương thức
        public XeCo()
        {
            this.maXe = "";
            this.bienSoXe = null;
            this.hangXe = null;
            this.ngayGio = DateTime.Now;
        }

        public XeCo(string maXe, string bienSoXe, string hangXe, DateTime ngayGio)
        {
            this.maXe = maXe;
            this.bienSoXe = bienSoXe;
            this.hangXe = hangXe;
            this.ngayGio = ngayGio;
        }
        public XeCo(XeCo xe)
        {
            this.maXe = xe.maXe;
            this.bienSoXe = xe.bienSoXe;
            this.hangXe = xe.hangXe;
            this.ngayGio = xe.ngayGio;
        }
        public Scanner getTypeOfVehicle()
        {
            return this.loaiXe;
        }
        public abstract string anhXe();
    }
}
