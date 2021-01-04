﻿using System;
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
        public string BienSoXe { set; get; }
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
        public XeHoi(string maXe, string bienSoXe, string hangXe, int soCuaXe, string mauXe) : base(maXe, hangXe)
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
            this.BienSoXe = BienSoXe;
            this.soCuaXe = xe.soCuaXe;
            this.mauXe = xe.mauXe;
        }

        public override string anhXe()
        {
            return $"\nMa xe: {this.maXe} \nBien so xe: {this.BienSoXe} \nSo cua xe: {this.soCuaXe} \nMau xe: {this.mauXe} \nLoai xe: {this.loaiXe} \nHang xe: {this.hangXe} \nThoi gian gui xe: {this.ngayGio}";
        }
    }
}
