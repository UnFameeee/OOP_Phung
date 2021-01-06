using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public class XeMay : XeCo, IXeHienDai
    {
        //Khai báo thuộc tính
        //Interface
        public string BienSoXe { get; }
        //class XeMay
        private string phanKhoi;
        //Hàm khởi tạo
        public XeMay() : base()
        {
            this.BienSoXe = "";
            this.phanKhoi = "";
            this.hangXe = "";
            this.loaiXe = Scanner.xeMay;
        }
        public XeMay(string BienSoXe, string hangXe, string phanKhoi) : base(hangXe)
        {
            this.BienSoXe = BienSoXe;
            this.phanKhoi = phanKhoi;
            this.loaiXe = Scanner.xeMay;
        }
        public XeMay(XeMay xe)
        {
            this.maXe = xe.maXe;
            this.loaiXe = xe.loaiXe;
            this.hangXe = xe.hangXe;
            this.ngayGio = xe.ngayGio;
            this.BienSoXe = xe.BienSoXe;
            this.phanKhoi = xe.phanKhoi;
        }
        //Các phương thức
        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.BienSoXe} \nPhan khoi: {this.phanKhoi} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}\n";
        }
        //Minh Đăng
        public static string deMay()
        {
            return "De may\n";
        }
        public static string dapBanDap()
        {
            return "Dap ban dap\n";
        }
    }
}
