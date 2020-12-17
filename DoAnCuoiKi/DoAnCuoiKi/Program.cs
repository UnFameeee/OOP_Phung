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
            //XeCo xehoi = new XeHoi();
            //gọi hàm thêm xe: xehoi(ascd)
            //Thẻ xe của bạn có mã số: 1234
            //Gọi hàm xóa xe: xehoi(ascd,people nglayxe, xeco xesh)
            //Nhập mã số của thẻ xe: 12345
            //Xác nhận sai, khởi động còi báo ...
            //Xác nhận đúng
            //Scanner a = Scanner.XeHoi;
            //int b = 1+(int)a;

            QuanLyBaiGiuXe a = new QuanLyBaiGiuXe();
            XeCo XeDap1 = new XeDap();
            XeCo Xeduocthem1 = a.themXe(XeDap1);

        }
    }
}
