using System;
using System.Collections.Generic;
using System.Text;

namespace DoAnCuoiKi
{
    public abstract class XeCo
    {
        //Khai báo thuộc tính
        public string maXe { set; get; }
        public Scanner loaiXe { set; get; }
        public string hangXe { set; get; }
        public DateTime ngayGio { set; get; }

        //Hàm khởi tạo
        public XeCo()
        {
            this.maXe = "";
            this.hangXe = null;
            this.ngayGio = DateTime.Now;
        }

        public XeCo(string maXe, string hangXe)
        {
            this.maXe = maXe;
            this.hangXe = hangXe;
            this.ngayGio = DateTime.Now;
        }
        public XeCo(XeCo xe)
        {
            this.maXe = xe.maXe;
            this.hangXe = xe.hangXe;
            this.ngayGio = xe.ngayGio;
            this.loaiXe = xe.loaiXe;
        }
        //Các phương thức
        public Scanner getTypeOfVehicle()
        {
            return this.loaiXe;
        }
        //Phương thức ảo
        public abstract string anhXe();
        //Delegate khởi động xe (Minh Đăng)
        public delegate string cachKhoiDong();
        public string khoiDongXe(cachKhoiDong khoiDong)
        {
            return khoiDong();
        }

    }
}
