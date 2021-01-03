using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoAnCuoiKi
{
    public enum Scanner { xeDap, xeDapDien, xeMay, xeHoi }
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
        public List<string> danhSachTTXeDaLay =new List<string>();
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
            return $"Xe may: {sucChua - slXe[2]} slot"; ;
        }
        public string statusXeHoi()
        {
            return $"Xe hoi: {sucChua - slXe[3]} slot"; ;
        }

        //M.Đăng
        public string thongTinXe(int maTheXe, DateTime thoiGianXeVao, DateTime thoiGianXacNhan,string anhXeVao,string anhNguoiVao, string anhXeRa, string anhNguoiRa)
        {
            return $"Thoi gian xe vao: {thoiGianXeVao}\nThoi gian xac nhan lay xe: {thoiGianXacNhan}\nAnh xe vao: {anhXeVao}\nAnh xe ra: {anhXeRa} \nAnh nguoi vao:  {anhNguoiVao} \nAnh nguoi ra: {anhNguoiRa}";
        }
        public string xuLyLayXe(XeCo xe, Nguoi nguoilayxe, tinhTienGXe cachTinhTien)
        {
            int maTheXe = nguoilayxe.theXe;
            string anhXeVao, anhNguoiVao,anhXeRa, anhNguoiRa;
            anhNguoiVao = this.TTXeTrongBai[maTheXe].anhNguoi;
            anhXeVao = this.TTXeTrongBai[maTheXe].anhXe;
            anhXeRa = xe.anhXe();
            anhNguoiRa = nguoilayxe.anhNguoi();
            if (anhXeVao==anhXeRa&&anhNguoiVao==anhNguoiRa)
            {
                DateTime thoiGianXacNhan = DateTime.Now;
                int loaiXe = (int)xe.getTypeOfVehicle();
                //Loại bỏ các dữ liệu về xe trong cơ sở dữ liệu
                slotXe[this.TTXeTrongBai[maTheXe].hang, this.TTXeTrongBai[maTheXe].cot] =0;
                --slXe[loaiXe];
                this.TTXeTrongBai.Remove(maTheXe);
                //Tính tiền gửi xe
                int sotien = tinhTienGuiXe(cachTinhTien,tinhThoiGianGuiXe(xe.ngayGio, thoiGianXacNhan), (Scanner)loaiXe);
                //Lưu thông tin cơ bản của xe vào Dictionary để xử lý trường hợp mất xe
                this.danhSachTTXeDaLay.Add(thongTinXe(maTheXe,xe.ngayGio,thoiGianXacNhan, anhXeVao,anhNguoiVao, anhXeRa, anhNguoiRa));
                return $"So tien phai tra la: {sotien} \n";
            }
            else
                return "Loi xac thuc.\n";
        }
        public delegate int tinhTienGXe(int sogio, Scanner loaixe);
        public int tinhTienGuiXe(tinhTienGXe tinhTien,int sogio, Scanner loaixe)
        {
            return tinhTien(sogio,loaixe);
        }
        public int tinhTienTheoGio(int sogio, Scanner loaixe)
        {
            //Xe đạp: 2000/5h
            //Xe đạp điện: 3000/5h
            //Xe máy: 4000/5h
            //Xe hơi: 10000/5h
            return loaixe != Scanner.xeHoi ? (2000 + (int)loaixe * 1000) + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
        }
        public int tinhTienTheoNgay(int sogio, Scanner loaixe)
        {
            //Theo ngày + Theo giờ (<24)
            //Theo ngày:
            //Xe đạp: 8000/ngày
            //Xe đạp điện: 12000/ngày
            //Xe máy: 20000/ngày
            //Xe hơi: 40000/ngày
            int songay = sogio / 24;
            sogio = sogio % 24;
            int tienngay=0;
            tienngay = loaixe != Scanner.xeHoi ? (2000 + (int)loaixe * 1000) * 4 * songay : 10000 * 4 * songay;
            int tiengio = loaixe != Scanner.xeHoi ? (2000 + (int)loaixe * 1000) + (2000 + (int)loaixe * 1000) * (sogio / 5) : 10000 + 10000 * (sogio / 5);
            return tienngay+tiengio;
        }
        public int tinhThoiGianGuiXe(DateTime timeGuiXe, DateTime timeNow)
        {
            TimeSpan temp = timeNow.Subtract(timeGuiXe);
            return temp.Hours;
        }

        //Tổng kết số tiền thu được
        //Status số tiền hiện đang có
        //
    }
}
