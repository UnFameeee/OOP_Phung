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
        public int tongTien = 500000;
        private int[] slXe = new int[4];
        public int[,] slotXe = new int[4, sucChua]; //khai báo mảng gồm 4 dòng 1000 cột có giá trị = 0
        public List<string> danhSachTTXeDaLay = new List<string>();
        public Dictionary<int, ThongTinXeTrongBai> TTXeTrongBai = new Dictionary<int, ThongTinXeTrongBai>();
        //Hàm khởi tạo
        public QuanLyBaiGiuXe()
        {
            this.tongTien = 500000;
        }
        public QuanLyBaiGiuXe(QuanLyBaiGiuXe qly)
        {
            this.tongTien = qly.tongTien;
            this.slXe = qly.slXe;
            this.slotXe = qly.slotXe;
            this.danhSachTTXeDaLay = qly.danhSachTTXeDaLay;
            this.TTXeTrongBai = qly.TTXeTrongBai;
        }
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
        public string themXe(XeCo xe, NguoiGuiXe nguoi)
        {
            int hangXe = (int)xe.getTypeOfVehicle();
            for (int i = 0; i < sucChua; i++)
            {
                if (slotXe[hangXe, i] == 0)
                {
                    //Đánh dấu = 1 tại chỗ nào có xe
                    slotXe[hangXe, i] = 1;
                    //Tăng số lượng xe hiện đang gửi của hàng đó
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
            return $"Da them xe {xe.getTypeOfVehicle()}";
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
        public delegate string delegateStatusLoaiXe();
        public string statusLoaiXe(delegateStatusLoaiXe stt)
        {
            string kq = stt();
            return kq;
        }
        public string statusXeDap()
        {
            return $"Xe dap: {sucChua - slXe[0]} slot";
        }
        public string statusXeDapDien()
        {
            return $"Xe dap dien: {sucChua - slXe[1]} slot";
        }
        public string statusXeMay()
        {
            return $"Xe may: {sucChua - slXe[2]} slot";
        }
        public string statusXeHoi()
        {
            return $"Xe hoi: {sucChua - slXe[3]} slot";
        }

        //M.Đăng
        public string thongTinXe(int maTheXe, DateTime thoiGianXeVao, DateTime thoiGianXacNhan, string anhXeVao, string anhNguoiVao, string anhXeRa, string anhNguoiRa)
        {
            return $"Thoi gian xe vao: {thoiGianXeVao}\nThoi gian xac nhan lay xe: {thoiGianXacNhan}\nAnh xe vao: {anhXeVao}\nAnh xe ra: {anhXeRa} \nAnh NguoiGuiXe vao:  {anhNguoiVao} \nAnh NguoiGuiXe ra: {anhNguoiRa}";
        }
        public int xuLyTheXe(XeCo xe, NguoiGuiXe nguoilayxe)
        {
            foreach (KeyValuePair<int, ThongTinXeTrongBai> TimKiem in this.TTXeTrongBai)
                if (xe.maXe == TimKiem.Value.maXe && nguoilayxe.anhNguoi() == TimKiem.Value.anhNguoi && xe.anhXe() == TimKiem.Value.anhXe)
                    return TimKiem.Key;
            return -1;
        }
        public string xuLyLayXe(XeCo xe, NguoiGuiXe nguoilayxe, HinhThucThanhToan hinhThucThanhToan, int tienNguoiGuiXe, tinhTienGXe cachTinhTien)
        {
            int maTheXe = nguoilayxe.theXe;
            DateTime thoiGianXacNhan = DateTime.Now;
            Scanner loaiXe = xe.getTypeOfVehicle();
            int soTienCanPhaiTra = tinhTienGuiXe(cachTinhTien, tinhThoiGianGuiXe(xe.ngayGio, thoiGianXacNhan), loaiXe);
            if (maTheXe == -1)                          //Người lấy xe bị mất thẻ xe
            {
                soTienCanPhaiTra += 50000;
                maTheXe = xuLyTheXe(xe, nguoilayxe);
            }
            if (thucHienXacNhan(maTheXe, xe, nguoilayxe) == true)
            {
                string anhNguoiVao = this.TTXeTrongBai[maTheXe].anhNguoi;
                string anhXeVao = this.TTXeTrongBai[maTheXe].anhXe;
                //Loại bỏ các dữ liệu về xe trong cơ sở dữ liệu
                xoaThongTinXe(maTheXe, (int)loaiXe);
                //Lưu thông tin cơ bản của xe vào Dictionary để xử lý trường hợp mất xe
                this.danhSachTTXeDaLay.Add(thongTinXe(maTheXe, xe.ngayGio, thoiGianXacNhan, anhXeVao, anhNguoiVao, xe.anhXe(), nguoilayxe.anhNguoi()));
                //Lấy tiền gửi xe
                if (tienNguoiGuiXe < soTienCanPhaiTra)
                    return $"{thanhToan(hinhThucThanhToan, tienNguoiGuiXe, soTienCanPhaiTra)}\nLay {xe.getTypeOfVehicle()} khong thanh cong\n";
                return $"{thanhToan(hinhThucThanhToan, tienNguoiGuiXe, soTienCanPhaiTra)}\nDa lay {xe.getTypeOfVehicle()} thanh cong\n";
            }
            else
                return "Canh bao: Anh khong khop";
        }
        private bool thucHienXacNhan(int maTheXe, XeCo xe, NguoiGuiXe nguoilayxe)
        {
            string anhXeVao, anhNguoiVao, anhXeRa, anhNguoiRa;
            anhNguoiVao = this.TTXeTrongBai[maTheXe].anhNguoi;
            anhXeVao = this.TTXeTrongBai[maTheXe].anhXe;
            anhXeRa = xe.anhXe();
            anhNguoiRa = nguoilayxe.anhNguoi();
            if (anhXeVao == anhXeRa && anhNguoiVao == anhNguoiRa)
                return true;
            else
                return false;
        }
        private void xoaThongTinXe(int maTheXe, int loaiXe)
        {
            slotXe[this.TTXeTrongBai[maTheXe].hang, this.TTXeTrongBai[maTheXe].cot] = 0;
            --slXe[loaiXe];
            this.TTXeTrongBai.Remove(maTheXe);
        }
        public delegate int tinhTienGXe(int sogio, Scanner loaixe);
        public int tinhTienGuiXe(tinhTienGXe tinhTien, int sogio, Scanner loaixe)
        {
            return tinhTien(sogio, loaixe);
        }
        public static int tinhTienTheoGio(int sogio, Scanner loaixe)
        {
            //Xe đạp: 2000/5h
            //Xe đạp điện: 3000/5h
            //Xe máy: 4000/5h
            //Xe hơi: 10000/5h
            return loaixe != Scanner.xeHoi ? (2000 + (int)loaixe * 1000) 
                             + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
        }
        public static int tinhTienTheoNgay(int sogio, Scanner loaixe)
        {
            //Theo ngày + Theo giờ (<24)
            //Theo ngày:
            //Xe đạp: 8000/ngày
            //Xe đạp điện: 12000/ngày
            //Xe máy: 20000/ngày
            //Xe hơi: 40000/ngày
            int songay = sogio / 24;
            sogio = sogio % 24;
            int tienngay;
            tienngay = loaixe != Scanner.xeHoi ? (2000 + (int)loaixe * 1000) * 4 * songay 
                                                 : 10000 * 4 * songay;
            int tiengio = loaixe != Scanner.xeHoi ? (2000 + (int)loaixe * 1000) 
                          + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
            return tienngay + tiengio;
        }
        public int tinhThoiGianGuiXe(DateTime timeGuiXe, DateTime timeNow)
        {
            TimeSpan temp = timeNow.Subtract(timeGuiXe);
            return temp.Hours;
        }

        //wibu
        public static ThanhToan quetThe()
        {
            return ThanhToan.QuetThe;
        }
        public static ThanhToan airPay()
        {
            return ThanhToan.AirPay;
        }
        public static ThanhToan moMo()
        {
            return ThanhToan.MoMo;
        }
        public static ThanhToan viettelPay()
        {
            return ThanhToan.ViettelPay;
        }
        public static ThanhToan zaloPay()
        {
            return ThanhToan.ZaloPay;
        }
        public static ThanhToan tienMat()
        {
            return ThanhToan.TienMat;
        }
        public string chonCachThuc(HinhThucThanhToan hinhThucThanhToan)
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
        
        public static string denTinHieuXanh()
        {
            return "Xanh";
        }
        public static string denTinHieuDo()
        {
            return "Do";
        }
        public delegate string DenTinHieu();
        public string thanhChanBarrier(DenTinHieu denTinHieu)
        {
            string kq = denTinHieu();
            if (kq == "Xanh")
                return "Mo thanh chan";
            return "Dong thanh chan";
        }
        
        //Tổng kết số tiền thu được
        public delegate ThanhToan HinhThucThanhToan();
        public string thanhToan(HinhThucThanhToan hinhThucThanhToan,int tienNguoiGuiXe, int tongTienCanPhaiTra)
        {
            ThanhToan kq = hinhThucThanhToan();
            if (tienNguoiGuiXe == tongTienCanPhaiTra)
                tongTien += tienNguoiGuiXe;
            else 
                if (tienNguoiGuiXe < tongTienCanPhaiTra)
                        return "Thanh toan khong du!";
                else 
                    if (tienNguoiGuiXe > tongTienCanPhaiTra)
                        if (kq == ThanhToan.TienMat)
                        {
                            tienNguoiGuiXe -= tongTienCanPhaiTra;
                            tongTien += tongTienCanPhaiTra;
                            return $"Thanh toan thanh cong! Tien can tra cho quy khach: {tienNguoiGuiXe}";
                        }
            return $"Thanh toan {kq} thanh cong!";
        }
        //Status số tiền hiện đang có
        public string statusSoTIenHienDangCo()
        {
            return $"Tong so tien hien dang co la: {tongTien}";
        }
        //event sửa chữa và bảo trì bãi xe
        public delegate object SCvaBT(params object[] thamso);
        public event SCvaBT eventSCvaBT;
        public object thucThiSCBT(params object[] thamso)
        {
            return eventSCvaBT?.Invoke(thamso);
        }
        //event update driver
        public delegate object update(params object[] thamso);
        public event update eventUpdateDriver;
        public object thucThiUpdate(params object[] thamso)
        {
            return eventUpdateDriver?.Invoke(thamso);
        }
        //event mở rộng bãi giữ xe
        public delegate object moRong(params object[] thamso);
        public event moRong eventMoRong;
        public object thucThiMoRongBaiGiuXe(params object[] thamso)
        {
            return eventMoRong?.Invoke(thamso);
        }
    }
}
