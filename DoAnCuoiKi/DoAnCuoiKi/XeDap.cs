using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeDap : XeCo
    {
        //Hàm khởi tạo
        public XeDap() : base()
        {
            this.loaiXe = Scanner.xeDap;
        }
        public XeDap(string maXe, string hangXe) : base(maXe, hangXe)
        {
            this.loaiXe = Scanner.xeDap;
        }
        public XeDap(XeDap xe)
        {
            this.maXe = xe.maXe;
            this.loaiXe = xe.loaiXe;
            this.hangXe = xe.hangXe;
            this.ngayGio = xe.ngayGio;
        }
        //Các phương thức
        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
        //Minh Đăng
        public static string gatChanTrong()
        {
            return "Gat chan trong";
        }
    }
}
