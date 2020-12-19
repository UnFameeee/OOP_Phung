using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeDapDien : XeCo
    {
        //Khai báo thuộc tính
        private string _binhDien;
        public string binhDien
        {
            set { this._binhDien = value; }
            get { return this._binhDien; }
        }

        //Khai báo phương thức
        public XeDapDien():base()
        {
        }
        public XeDapDien(int maXe, Scanner loaixe, string bienSoXe, string hangXe, DateTime ngayGio, string BinhDien) : base(maXe, loaixe, bienSoXe, hangXe, ngayGio)
        {
            this.binhDien = binhDien;
        }
        public XeDapDien(XeCo xe, string binhDien) : base(xe)
        {
            this.binhDien = binhDien;
        }
        public override string anhXe()
        {
            return $"{base.anhXe()} \nBinh dien: {this.binhDien}";
        }
    }
}
