using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoAnCuoiKi
{
    public enum Scanner { xeDap, xeDapDien, xeMay, xeHoi }
    public enum ThanhToan { MoMo, ViettelPay, AirPay, ZaloPay, QuetThe, TienMat }
    public struct ThongTinXeTrongBai
    {
        public string maXe;
        public string anhXe;
        public string anhNguoi;
        public int hang;
        public int cot;
    }
    public class QuanLyBaiGiuXe
    {
        //Khai báo thuộc tính
        public const int sucChua = 1000;
        private int[] slXe = new int[4];
        public int[,] slotXe = new int[4, sucChua]; //khai báo mảng gồm 4 dòng 1000 cột có giá trị = 0
        public Dictionary<int, string> danhSachTTXeDaLay = new Dictionary<int, string>();
        public Dictionary<int, ThongTinXeTrongBai> TTXeTrongBai = new Dictionary<int, ThongTinXeTrongBai>();
        //Thắng
        List<int> listTheXe = new List<int>(1000000) { 0 };
        public int phatTheXe()
        {
            int n = 0;
            bool isExists = true;
            Random _r = new Random();
            while (isExists == true)
            {
                n = _r.Next() % 1000000;
                isExists = listTheXe.Contains(n);
            }
            listTheXe.Add(n);
            return n;
        }
        public void themXe(XeCo xe, Nguoi nguoi)
        {
            int hangXe = (int)xe.getTypeOfVehicle();
            for (int i = 0; i < sucChua; i++)
            {
                if (slotXe[hangXe, i] == 0)
                {
                    //Đánh dấu = 1 tại chỗ nào có xe
                    slotXe[hangXe, i] = 1;
                    //Tăng số lượng xe của hàng đó
                    slXe[hangXe]++;
                    //Gán thẻ xe đó cho người lái xe
                    nguoi.theXe = phatTheXe();
                    //Mã hóa vị trí đỗ xe thành mã xe
                    xe.maXe = (hangXe + "." + i).ToString();
                    //Thêm thông tin cho người và xe
                    ThongTinXeTrongBai TTXTB;
                    TTXTB.maXe = xe.maXe;
                    TTXTB.anhNguoi = nguoi.anhNguoi();
                    TTXTB.anhXe = xe.anhXe();
                    TTXTB.hang = hangXe;
                    TTXTB.cot = i;
                    TTXeTrongBai.Add(nguoi.theXe, TTXTB);
                    break;
                }
            }
        }
        public int slXeBatKy(Scanner x)
        {
            return slXe[(int)x];
        }
        public int tongSoXe()
        {
            int sum = 0;
            foreach (int i in slXe)
            {
                sum += i;
            }
            return sum;
        }
        public string statusBaiXe()
        {
            return $"Xe dap: {sucChua - slXe[0]} slot\nXe dap dien: {sucChua - slXe[1]} slot" +
                $"\nXe may: {sucChua - slXe[2]} slot\nXe hoi: {sucChua - slXe[3]} slot";
        }

        //M.Đăng
        public string thongTinXe(int maTheXe, DateTime thoiGianXeVao, DateTime thoiGianXacNhan, string anhXeRa, string anhNguoiRa)
        {
            return $"Thoi gian xe vao: {thoiGianXeVao}\nThoi gian xac nhan lay xe: {thoiGianXacNhan}\nAnh xe vao: {TTXeTrongBai[maTheXe].anhXe}\nAnh xe ra: {anhXeRa} \nAnh nguoi vao:  {TTXeTrongBai[maTheXe].anhNguoi} \nAnh nguoi ra: {anhNguoiRa}";
        }
        public string xuLyLayXe(XeCo xe, Nguoi nguoilayxe)
        {
            int maTheXe = nguoilayxe.theXe;
            string anhXeVao, anhNguoiVao,anhXeRa, anhNguoiRa;
            anhNguoiVao = TTXeTrongBai[maTheXe].anhNguoi;
            anhXeVao = TTXeTrongBai[maTheXe].anhXe;
            anhXeRa = xe.anhXe();
            anhNguoiRa = nguoilayxe.anhNguoi();
            if (anhXeVao==anhXeRa&&anhNguoiVao==anhNguoiRa)
            {
                DateTime thoiGianXacNhan = DateTime.Now;
                int loaiXe = (int)xe.getTypeOfVehicle();
                //Loại bỏ các dữ liệu về xe trong cơ sở dữ liệu
                TTXeTrongBai.Remove(maTheXe);
                slotXe[TTXeTrongBai[maTheXe].hang, TTXeTrongBai[maTheXe].cot] =0;
                --slXe[loaiXe];
                //Tính tiền gửi xe
                int sotien = tinhTienGuiXe(tinhThoiGianGuiXe(xe.ngayGio, thoiGianXacNhan), (Scanner)loaiXe);
                //Lưu thông tin cơ bản của xe vào Dictionary để xử lý trường hợp mất xe
                danhSachTTXeDaLay.Add(maTheXe,thongTinXe(maTheXe,xe.ngayGio,thoiGianXacNhan, anhXeRa, anhNguoiRa));
                return $"So tien phai tra la: {sotien} \n";
            }
            else
                return "Loi xac thuc.\n";
        }
        public int tinhTienGuiXe(int sogio, Scanner loaixe)
        {
            return loaixe != Scanner.xeHoi ? (2000 + (int)loaixe * 1000) + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
        }
        public int tinhThoiGianGuiXe(DateTime timeGuiXe, DateTime timeNow)
        {
            TimeSpan temp = timeNow.Subtract(timeGuiXe);
            return temp.Hours;
        }
        public static ThanhToan QuetThe()
        {
            return ThanhToan.QuetThe;
        }
        public static ThanhToan AirPay()
        {
            return ThanhToan.AirPay;
        }
        public static ThanhToan MoMo()
        {
            return ThanhToan.MoMo;
        }
        public static ThanhToan ViettelPay()
        {
            return ThanhToan.ViettelPay;
        }
        public static ThanhToan ZaloPay()
        {
            return ThanhToan.ZaloPay;
        }
        public static ThanhToan TienMat()
        {
            return ThanhToan.TienMat;
        }        
        public string ChonCachThuc(HinhThucThanhToan hinhThucThanhToan)
        {
            ThanhToan kq = hinhThucThanhToan();
            if (kq == ThanhToan.QuetThe)
                return "Thanh toan bang hinh thuc quet the";
            else if (kq == ThanhToan.AirPay)
                return "Thanh toan bang hinh thuc AirPay";
            else if (kq == ThanhToan.MoMo)
                return "Thanh toan bang hinh thuc MoMo";
            else if (kq == ThanhToan.ViettelPay)
                return "Thanh toan bang hinh thuc ViettelPay";
            else if (kq == ThanhToan.ZaloPay)
                return "Thanh toan bang hinh thuc ZaloPay";
            return "Thanh toan bang hinh thuc tien mat";
        }
        public delegate ThanhToan HinhThucThanhToan();
        //Tổng kết số tiền thu được
        //Status số tiền hiện đang có
        //
    }
}
