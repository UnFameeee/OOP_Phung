using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnCuoiKi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thực thi chương trình
            /*Tạo hàm quản lý bãi giữ xe*/
            QuanLyBaiGiuXe quanly2 = new QuanLyBaiGiuXe();
            /*Người gửi xe và xe*/
            NguoiGuiXe NguyenVanA = new NguoiGuiXe("Tron", 0, "Thon");
            XeDap XeDap_CuaA = new XeDap();
            NguoiGuiXe NguyenVanB = new NguoiGuiXe("Gay", 0, "To");
            XeMay XeMay_CuaB = new XeMay();
            /*Nhân viên*/
            NhanVien NV1 = new NhanVien();
            /*Nhân viên mở cửa bãi xe*/
            NhanVien.hanhDongNV hdong1 = new NhanVien.hanhDongNV(NhanVien.moCua);
            Console.WriteLine(NV1.hanhDongCuaNV(hdong1));
            /*Tạo đèn tín hiệu*/
            QuanLyBaiGiuXe.DenTinHieu denTinHieuXanh = new QuanLyBaiGiuXe.DenTinHieu(QuanLyBaiGiuXe.denTinHieuXanh);
            QuanLyBaiGiuXe.DenTinHieu denTinHieuDo = new QuanLyBaiGiuXe.DenTinHieu(QuanLyBaiGiuXe.denTinHieuDo);
            /*Mở thanh chắn*/
            Console.WriteLine(quanly2.thanhChanBarrier(denTinHieuXanh));
            /*Gửi xe vào bãi*/
            Console.WriteLine(quanly2.themXe(XeDap_CuaA, NguyenVanA));
            Console.WriteLine(quanly2.themXe(XeMay_CuaB, NguyenVanB));
            /*Đóng thanh chắn*/
            Console.WriteLine(quanly2.thanhChanBarrier(denTinHieuDo));
            /*In thông tin đã chụp lại của XeDap_CuaA đã gửi vào bãi*/
            Console.WriteLine(XeDap_CuaA.anhXe() + "\n" + NguyenVanA.anhNguoi());
            /*In thông tin đã chụp lại của XeMay_CuaB và NguyenVanB đã gửi vào bãi*/
            Console.WriteLine(XeMay_CuaB.anhXe() + "\n" + NguyenVanB.anhNguoi());
            /*In ra thông tin bãi xe*/
            Console.WriteLine("\n" + quanly2.statusBaiXe());
            /*Chọn cách tính tiền*/
            QuanLyBaiGiuXe.tinhTienGXe cachTinhTien = new QuanLyBaiGiuXe.tinhTienGXe(QuanLyBaiGiuXe.tinhTienTheoGio);
            /*Chọn cách thanh toán*/
            QuanLyBaiGiuXe.HinhThucThanhToan hinhThucThanhToan = new QuanLyBaiGiuXe.HinhThucThanhToan(QuanLyBaiGiuXe.tienMat);
            /*Lấy xe ra*/
            Console.Write($"Nhap so tien can tra: "); int tien1 = int.Parse(Console.ReadLine());
            Console.WriteLine(quanly2.xuLyLayXe(XeDap_CuaA, NguyenVanA, hinhThucThanhToan, tien1, cachTinhTien));
            Console.Write($"Nhap so tien can tra: "); int tien2 = int.Parse(Console.ReadLine());
            Console.WriteLine(quanly2.xuLyLayXe(XeMay_CuaB, NguyenVanB, hinhThucThanhToan, tien2, cachTinhTien));
            /*Mở thanh chắn*/
            Console.WriteLine(quanly2.thanhChanBarrier(denTinHieuXanh));
            /*Đóng thanh chắn*/
            Console.WriteLine(quanly2.thanhChanBarrier(denTinHieuDo));
            /*In lại thông tin của bãi xe đạp*/
            QuanLyBaiGiuXe.delegateStatusLoaiXe sttxe1 = new QuanLyBaiGiuXe.delegateStatusLoaiXe(quanly2.statusXeDap);
            Console.WriteLine(quanly2.statusLoaiXe(sttxe1));
            /*In lại thông tin của bãi xe đạp*/
            QuanLyBaiGiuXe.delegateStatusLoaiXe sttxe2 = new QuanLyBaiGiuXe.delegateStatusLoaiXe(quanly2.statusXeMay);
            Console.WriteLine(quanly2.statusLoaiXe(sttxe2));
            /*Nhân viên đóng cửa bãi xe*/
            NhanVien.hanhDongNV hdong2 = new NhanVien.hanhDongNV(NhanVien.dongCua);
            Console.WriteLine(NV1.hanhDongCuaNV(hdong2));



            /*Event sửa chữa và bảo trì bãi xe*/
            quanly2.eventSCvaBT += Quanly2_eventSCvaBT;
            Console.WriteLine((string)quanly2.thucThiSCBT());
            /*Event update phần mềm của chương trình quản lý*/
            quanly2.eventUpdateDriver += Quanly2_eventUpdateDriver;
            Console.WriteLine((string)quanly2.thucThiUpdate());
            /*Event mở rộng bãi giữ xe*/
            quanly2.eventMoRong += Quanly2_eventMoRongBaiGiuXe;
            Console.WriteLine((string)quanly2.thucThiMoRongBaiGiuXe());

        }
        private static object Quanly2_eventUpdateDriver(params object[] thamso)
        {
            return "Update Driver!!!";
        }
        private static object Quanly2_eventSCvaBT(params object[] thamso)
        {
            return "Bai xe dang trong tinh trang bao tri va sua chua";
        }
        private static object Quanly2_eventMoRongBaiGiuXe(params object[] thamso)
        {
            return "Mo rong bai giu xe";
        }
    }
}
