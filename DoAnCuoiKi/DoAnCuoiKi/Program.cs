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
            //Dictionary<string, string> chisokhac = new Dictionary<string, string>()
            //{
            //    { "binhDien", "" },
            //    { "phanKhoi","" },
            //    {"...","" }
            //};
            //QuanLyBaiGiuXe a = new QuanLyBaiGiuXe();
            //Console.WriteLine();
            //Console.WriteLine("Nhap thong tin xe: ");
            //chisokhac["binhDien"] = "50W";


            //--------------Đã Xong Q.Thắng----------------------
            //QuanLyBaiGiuXe quanly1 = new QuanLyBaiGiuXe();
            //XeCo XeDap1 = new XeDap();
            //NguoiGuiXe A = new NguoiGuiXe();
            //quanly1.themXe(XeDap1, A);
            //Console.WriteLine(XeDap1.maXe);
            //Console.WriteLine(quanly1.tongSoXe());
            //Console.WriteLine(quanly1.statusBaiXe());
            //Console.WriteLine($"the xe: {A.theXe}");

            //XeCo XeMay1 = new XeMay("696969", "123", "456");
            //NguoiGuiXe B = new NguoiGuiXe();
            //quanly1.themXe(XeMay1, B);
            //Console.WriteLine(XeMay1.maXe);

            ////In ra tổng số xe
            //Console.WriteLine(quanly1.tongSoXe());

            ////In ra status của cả bãi xe
            ////Console.WriteLine(a.statusBaiXe());

            //Delegate gọi đến để in ra status của từng loại xe
            //QuanLyBaiGiuXe.delegateStatusLoaiXe sttxemay = new QuanLyBaiGiuXe.delegateStatusLoaiXe(quanly1.statusXeMay);
            //Console.WriteLine(quanly1.statusLoaiXe(sttxemay));
            //---------------------------------------------------

            // -----------------------TEST - NMD-----------------------
            //Console.WriteLine("==============");
            //Console.WriteLine("===Xe Dap======");
            //Console.WriteLine(XeDap1.anhXe());
            //Console.WriteLine("=====Xe May======");
            //Console.WriteLine(XeMay1.anhXe());
            //Console.WriteLine("=====Anh Nguoi=====");
            //Console.WriteLine(A.anhNguoi());
            //QuanLyBaiGiuXe.tinhTienGXe cachTinhTien = new QuanLyBaiGiuXe.tinhTienGXe(quanly1.tinhTienTheoGio);
            //Console.WriteLine(quanly1.xuLyLayXe(XeDap1, A, cachTinhTien));

            ////Khởi động xe
            //XeCo.cachKhoiDong cachkd = new XeCo.cachKhoiDong(XeDap.gatChanTrong);
            //Console.WriteLine(XeDap1.khoiDongXe(cachkd));

            ////hành động của nhân viên
            //NhanVien nam = new NhanVien();
            //NhanVien.hanhDongNV hd = new NhanVien.hanhDongNV(NhanVien.moCua);
            //Console.WriteLine(nam.hanhDong(hd));

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();


            //Thực thi chương trình
            /*Tạo hàm quản lý bãi giữ xe*/
            QuanLyBaiGiuXe quanly2 = new QuanLyBaiGiuXe();
            /*Người gửi xe và xe*/
            NguoiGuiXe NguyenVanA = new NguoiGuiXe("Tron", 0, "Thon");
            XeDap XeDap_CuaA = new XeDap();
            NguoiGuiXe NguyenVanB = new NguoiGuiXe("Gay", 0, "To");
            XeMay XeMay_CuaB = new XeMay();
            /*Khởi tạo nhân viên*/
            NhanVien NV1 = new NhanVien();
            /*Nhân viên mở cửa bãi xe*/
            NhanVien.hanhDongNV hdong = new NhanVien.hanhDongNV(NhanVien.moCua);
            Console.WriteLine(NV1.hanhDong(hdong));
            /*Gửi xe vào bãi*/
            quanly2.themXe(XeDap_CuaA, NguyenVanA);
            /*In thông tin đã chụp lại của XeDap_CuaA đã gửi vào bãi*/
            Console.WriteLine(XeDap_CuaA.anhXe() + "\n" + NguyenVanA.anhNguoi());
            /*In thông tin đã chụp lại của XeMay_CuaB và NguyenVanB đã gửi vào bãi*/
            Console.WriteLine(XeMay_CuaB.anhXe() + "\n" + NguyenVanB.anhNguoi());

            /*In ra thông tin bãi xe*/
            Console.WriteLine("\n" + quanly2.statusBaiXe());

            /*Tính tiền */
            QuanLyBaiGiuXe.tinhTienGXe cachTinhTien = new QuanLyBaiGiuXe.tinhTienGXe(quanly2.tinhTienTheoGio);
            /*Thanh toán*/

            /*Lấy xe ra*/
            Console.WriteLine(quanly2.xuLyLayXe(XeDap_CuaA, NguyenVanA, cachTinhTien));
            //Console.WriteLine(quanly2.xuLyLayXe(XeDap1, A, cachTinhTien)); --> phải return không lấy được

            /*In lại thông tin của bãi xe đạp*/
            QuanLyBaiGiuXe.delegateStatusLoaiXe sttxe = new QuanLyBaiGiuXe.delegateStatusLoaiXe(quanly2.statusXeDap);
            Console.WriteLine(quanly2.statusLoaiXe(sttxe));

            /*Event sửa chữa và bảo trì bãi xe*/
            quanly2.eventSCvaBT += Quanly1_eventSCvaBT;
            Console.WriteLine((string)quanly2.thucThiSCBT());

            /*Event update phần mềm của chương trình quản lý*/
            quanly2.eventUpdateDriver += Quanly1_eventUpdateDriver;
            Console.WriteLine((string)quanly2.thucThiUpdate());



















        }
        private static object Quanly1_eventUpdateDriver(params object[] thamso)
        {
            return "Update Driver!!!";
        }

        private static object Quanly1_eventSCvaBT(params object[] thamso)
        {
            return "Bai xe dang trong tinh trang bao tri va sua chua";
        }
        //Delegate tính tiền lúc xe đi ra (1)
        //Delegate này sẽ chỉ các cách thức thanh toán: momo, viettel pay, tienmat, quetthe, airpay, zalopay

        //Delegate tính tiền gửi xe (2)
        //Delegate này sẽ tính tiền các loại xe khác nhau như: 4 class trên

        //Delegate status loại xe (3)
        //Delegate này sẽ thông báo status của loại xe tương ứng

        //Delegate hành động của người quản lý (4)
        //Delegate này sẽ bao gồm: quét dọn, kiểm tra, đóng cửa, mở cửa

        //Delegate tiền trả = với lại tiền pt, tiền trả > tiền phải trả
        //delegate(tiền trả = với lại tiền pt) này sẽ xác nhận đã thanh toán thành công
        //delegate(tiền trả > tiền phải trả) thối tiền thừa và xác nhận thanh toán thành công
    }
}
