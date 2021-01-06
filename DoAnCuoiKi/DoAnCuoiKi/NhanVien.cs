using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    public enum ChucVu
    {
        NhanVien,
        TruongNhom,
        QuanLy
    }
    public class NhanVien : Nguoi
    {
        public string theNhanVien { get; }
        public ChucVu chucVu { get; }
        public NhanVien():base()
        {
            this.theNhanVien = null;
            this.chucVu = ChucVu.NhanVien;
        }
        public NhanVien(string khuonMat, GioiTinh gioiTinh, string dangNguoi, int theXe, string maNV,ChucVu chucVu) :base(khuonMat,gioiTinh,dangNguoi)
        {
            this.chucVu = chucVu;
            this.theNhanVien = maNV;
        }
        public NhanVien(NhanVien x)
        {
            this.theNhanVien = x.theNhanVien;
            this.chucVu = x.chucVu;
            this.khuonMat = x.khuonMat;
            this.gioiTinh = x.gioiTinh;
            this.dangNguoi = x.dangNguoi;
        }

        public override string hanhDong(hanhDongNV hanhDongCuaNV)
        {
            return hanhDongCuaNV();
        }
        public override string anhNguoi()
        {
            return $"The deo: {this.theNhanVien}\nGioi tinh:  {this.gioiTinh}\nKhuon mat:  {this.khuonMat} \nThe hinh: {this.dangNguoi}";
        }
        public static string quetDon()
        {
            return "Quet don, ve sinh bai giu xe\n";
        }
        public static string kiemTraBaiXe()
        {
            return "Tuan tra bai giu xe\n";
        }
        public static string trucBan()
        {
            return "Tien hanh soat the xe ra va cap the cho xe vao\n";
        }
        public static string moCua()
        {
            return "Mo cua bai giu xe";
        }
        public static string dongCua()
        {
            return "Dong cua bai giu xe\n";
        }
        public static string nghiNgoi()
        {
            return "Nghi ngoi\n";
        }
    }
}
