using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeDapDien : XeCo, IXeHienDai
    {
        //Khai báo thuộc tính
        //Interface
        public string BienSoXe { set; get; }
        //class XeDapDien
        private string _binhDien;
        public string binhDien
        {
            set { this._binhDien = value; }
            get { return this._binhDien; }
        }

        //Khai báo phương thức
        public XeDapDien() : base()
        {
            this.BienSoXe = "";
            this.loaiXe = Scanner.xeDapDien;
        }
        public XeDapDien(string maXe, string BienSoXe, string hangXe, string BinhDien) : base(maXe, hangXe)
        {
            this.BienSoXe = BienSoXe;
            this.binhDien = binhDien;
            this.loaiXe = Scanner.xeDapDien;
        }
        public XeDapDien(XeCo xe, string binhDien, string BienSoXe) : base(xe)
        {
            this.BienSoXe = BienSoXe;
            this.binhDien = binhDien;
            this.loaiXe = Scanner.xeDapDien;
        }
        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.BienSoXe} \nBinh dien: {this.binhDien} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
    }
}
