﻿using System;
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
            QuanLyBaiGiuXe a = new QuanLyBaiGiuXe();
            XeCo XeDap1 = new XeDap();
            Nguoi A = new Nguoi();
            a.themXe(XeDap1, A);
            Console.WriteLine(XeDap1.maXe);
            Console.WriteLine(a.tongSoXe());
            Console.WriteLine(a.statusBaiXe());
            Console.WriteLine($"the xe: {A.theXe}");
            XeCo XeMay1 = new XeMay("x", "696969", "HXP con cho","COn cho HxP chet vVCL");
            Nguoi B = new Nguoi();
            a.themXe(XeMay1, B);
            Console.WriteLine(XeMay1.maXe);
            Console.WriteLine(a.tongSoXe());
            Console.WriteLine(a.statusBaiXe());
            Console.WriteLine($"the xe: {B.theXe}");
            //---------------------------------------------------
            // -----------------------TEST - NMD-----------------------
            Console.WriteLine("==============");
            Console.WriteLine("===Xe Dap======");
            Console.WriteLine(XeDap1.anhXe());
            Console.WriteLine("=====Xe May======");
            Console.WriteLine(XeMay1.anhXe());
            Console.WriteLine("=====Anh Nguoi=====");
            Console.WriteLine(A.anhNguoi());
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            QuanLyBaiGiuXe.HinhThucThanhToan hinhThucThanhToan = new QuanLyBaiGiuXe.HinhThucThanhToan(QuanLyBaiGiuXe.ViettelPay);
            Console.WriteLine(a.ChonCachThuc(hinhThucThanhToan));
        }

        //Delegate tính tiền lúc xe đi ra (1)
        //Delegate này sẽ chỉ các hình thức thanh toán: momo, viettel pay, tienmat, quetthe, airpay, zalopay

        //Delegate tính tiền gửi xe (2)
        //Delegate này sẽ tính tiền các loại xe khác nhau như: 4 class trên

        //Delegate status loại xe (3)
        //Delegate này sẽ thông báo status của loại xe tương ứng

        //Delegate hành động của người quản lý (4)
        //Delegate này sẽ bao gồm: quét dọn, kiểm tra, đóng cửa, mở cửa

        //Delegate tiền trả = với lại tiền pt, tiền trả > tiền phải trả
        //delegate(tiền trả = với lại tiền pt) này sẽ xác nhận đã thanh toán thành công
        //delegate(tiền trả > tiền phải trả) thối tiền thừa và xác nhận thanh toán thành công

        //===========================
        //chia ra 3 class chính để từng thằng xây delegate
        //QuanLy
        //Nguoi 
        //XeCo

    }
}
