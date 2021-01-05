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
        private string binhDien;

        //Hàm khởi tạo
        public XeDapDien() : base()
        {
            this.BienSoXe = "";
            this.loaiXe = Scanner.xeDapDien;
        }
        public XeDapDien(string BienSoXe, string hangXe, string binhDien) : base(hangXe)
        {
            this.BienSoXe = BienSoXe;
            this.binhDien = binhDien;
            this.loaiXe = Scanner.xeDapDien;
        }
        public XeDapDien(XeDapDien xe)
        {
            this.maXe = xe.maXe;
            this.loaiXe = xe.loaiXe;
            this.hangXe = xe.hangXe;
            this.ngayGio = xe.ngayGio;
            this.BienSoXe = xe.BienSoXe;
            this.binhDien = xe.binhDien;
        }
        //Các phương thức
        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.BienSoXe} \nBinh dien: {this.binhDien} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}\n";
        }
        //Minh Đăng
        public static string deMay()
        {
            return "De may";
        }
    }
}
