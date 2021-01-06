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
        public string BienSoXe { get; }
        //class XeHoi
        private int soCuaXe;
        private string mauXe;
        //Khai báo phương thức
        public XeHoi() : base()
        {
            this.BienSoXe = "";
            this.mauXe = "";
            this.soCuaXe = -1;
            this.loaiXe = Scanner.xeHoi;
        }
        public XeHoi(string bienSoXe, string hangXe, int soCuaXe, string mauXe) : base(hangXe)
        {
            this.BienSoXe = BienSoXe;
            this.soCuaXe = soCuaXe;
            this.mauXe = mauXe;
            this.loaiXe = Scanner.xeHoi;
        }
        public XeHoi(XeHoi xe)
        {
            this.maXe = xe.maXe;
            this.hangXe = xe.hangXe;
            this.ngayGio = xe.ngayGio;
            this.loaiXe = xe.loaiXe;
            this.BienSoXe = xe.BienSoXe;
            this.soCuaXe = xe.soCuaXe;
            this.mauXe = xe.mauXe;
        }

        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.BienSoXe} \nSo cua xe: {this.soCuaXe} \nMau xe: {this.mauXe} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}\n";
        }
        //Minh Đăng
        public static string deMay()
        {
            return "De may\n";
        }
    }
}
