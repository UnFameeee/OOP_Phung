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
            QuanLyBaiGiuXe quanly1 = new QuanLyBaiGiuXe();
            XeCo XeDap1 = new XeDap();
            Nguoi A = new Nguoi();
            quanly1.themXe(XeDap1, A);
            Console.WriteLine(XeDap1.maXe);
            Console.WriteLine(quanly1.tongSoXe());
            Console.WriteLine(quanly1.statusBaiXe());
            Console.WriteLine($"the xe: {A.theXe}");

            XeCo XeMay1 = new XeMay("x", "696969", "123", "456");
            Nguoi B = new Nguoi();
            quanly1.themXe(XeMay1, B);
            Console.WriteLine(XeMay1.maXe);

            //In ra tổng số xe
            Console.WriteLine(quanly1.tongSoXe());

            //In ra status của cả bãi xe
            //Console.WriteLine(a.statusBaiXe());

            //Delegate gọi đến để in ra status của từng loại xe
            QuanLyBaiGiuXe.delegateStatusLoaiXe sttxedap = new QuanLyBaiGiuXe.delegateStatusLoaiXe(quanly1.statusXeDap);
            Console.WriteLine(quanly1.statusLoaiXe(sttxedap));

            //test event update driver và event bảo trì sữa chữa
            quanly1.eventSCvaBT += Quanly1_eventSCvaBT;
            Console.WriteLine((string)quanly1.thucThiSCBT());
            quanly1.eventUpdateDriver += Quanly1_eventUpdateDriver;
            Console.WriteLine((string)quanly1.thucThiUpdate());
            //---------------------------------------------------

            // -----------------------TEST - NMD-----------------------
            Console.WriteLine("==============");
            Console.WriteLine("===Xe Dap======");
            Console.WriteLine(XeDap1.anhXe());
            Console.WriteLine("=====Xe May======");
            Console.WriteLine(XeMay1.anhXe());
            Console.WriteLine("=====Anh Nguoi=====");
            Console.WriteLine(A.anhNguoi());
            QuanLyBaiGiuXe.tinhTienGXe cachTinhTien = new QuanLyBaiGiuXe.tinhTienGXe(quanly1.tinhTienTheoGio);
            Console.WriteLine(quanly1.xuLyLayXe(XeDap1, A, cachTinhTien));
            //Khởi động xe
            XeCo.cachKhoiDong cachkd = new XeCo.cachKhoiDong(XeDap.gatChanTrong);
            Console.WriteLine(XeDap1.khoiDongXe(cachkd));

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
