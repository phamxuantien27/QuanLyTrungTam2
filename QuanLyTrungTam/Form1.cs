using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTrungTam_BUS;
using QuanLyNhaHang_Entity;

namespace QuanLyTrungTam
{
    public partial class Form1 : Form
    {
        private string ID;
        private int Quyen;
        static string Ma_GiaoVien;
        LopDay usLopDay;

        public Form1(int _quyen, string _ID)
        {
            Quyen = _quyen;
            ID = _ID;
            InitializeComponent();
            btDaHocXong.Visible = btDangHoc.Visible = false;
            PhanQuyen();
        }

        void PhanQuyen()
        {
            if (Quyen == 1)
            {
                btDaHocXong.Visible = btDangHoc.Visible = btHocPhi.Visible = btLichHoc.Visible = btLopHoc.Visible 
                    = btLichDay.Visible = btLopDangDay.Visible = false;
                QlLopHoc = new QuanLyLopHoc();
                QlLopHoc.btChiTiet.Click += BtChiTiet_Click2;
            }
            else if (Quyen == 2)
            {
                btDaHocXong.Visible = btDangHoc.Visible = btHocPhi.Visible = btLichHoc.Visible = btLopHoc.Visible 
                    = btQl_ThuHocPhi.Visible = btQuanLyGiaoVien.Visible = btQuanLyHocSinh.Visible = btQuanLyLopHoc.Visible = btQuanLyTaiKhoan.Visible = false;
                EC_GiaoVien GiaoVien = new BUS_GiaoVien().SelectByFields("ID", ID)[0];
                btAcc.Text = GiaoVien.Ten_GiaoVien;
                if (GiaoVien.Anh != null)
                {
                    picAvt.Image = HinhAnh.ByteToImage(GiaoVien.Anh);
                }
                Ma_GiaoVien = GiaoVien.Ma_GiaoVien;
                usLopDay = new LopDay(Ma_GiaoVien);
                usLopDay.dgLopHoc.CellClick += DgLopHoc_CellClick;
            }
            else if (Quyen == 3)
            {
                btLichDay.Visible = btLopDangDay.Visible 
                    = btQuanLyGiaoVien.Visible = btQuanLyHocSinh.Visible = btQl_ThuHocPhi.Visible = btQuanLyLopHoc.Visible = btQuanLyTaiKhoan.Visible = false;
                EC_HocSinh HocSinh = new BUS_HocSinh().SelectByFields("ID", ID)[0];
                btAcc.Text = HocSinh.Ten_HocSinh;
                if (HocSinh.Anh != null)
                {
                    picAvt.Image = HinhAnh.ByteToImage(HocSinh.Anh);
                }
                LH_Tuan = new LichHoc_Tuan(ID);
            }
            else
            {
                btDaHocXong.Visible = btDangHoc.Visible = btHocPhi.Visible = btLichHoc.Visible = btLopHoc.Visible
                    = btQuanLyGiaoVien.Visible = btQuanLyHocSinh.Visible = btQuanLyLopHoc.Visible = btQuanLyTaiKhoan.Visible
                    = btLichDay.Visible = btLopDangDay.Visible = false;
            }
        }

        private void BtChiTiet_Click2(object sender, EventArgs e)
        {
            Ma_LopHoc_1 = QlLopHoc.txbMa_LopHoc.Text;
            if (Ma_LopHoc_1 == "")
            {
                MessageBox.Show("Vui lòng chọn lớp học", "Thông báo");
                return;
            }
            QlLichHoc = new QuanLyLichHoc(Ma_LopHoc_1);
            Main.Controls.Clear();
            Main.Controls.Add(QlLichHoc);
            QlLichHoc.btChiTiet.Click += BtChiTiet_Click;
            QlLichHoc.btQuayLai.Click += BtQuayLai_Click;
            QlLichHoc.btDanhSachLop.Click += BtDanhSachLop_Click;
        }

        QuanLyLichHoc QlLichHoc;
        string Ma_LopHoc_1;
        DanhSachLop DanhSachLop;

        private void BtDanhSachLop_Click(object sender, EventArgs e)
        {
            DanhSachLop = new DanhSachLop(Ma_LopHoc_1);
            Main.Controls.Clear();
            Main.Controls.Add(DanhSachLop);
            DanhSachLop.btQuayLai.Click += BtQuayLai_Click4;
        }

        private void BtQuayLai_Click4(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(QlLichHoc);
        }

        private void BtQuayLai_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(QlLopHoc);
        }

        private void BtChiTiet_Click(object sender, EventArgs e)
        {
            DiemDanh dd = new DiemDanh(Ma_LopHoc_1);
            Main.Controls.Clear();
            Main.Controls.Add(dd);
            dd.btQuayLai.Click += BtQuayLai_Click2;
        }

        private void BtQuayLai_Click2(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(QlLichHoc);
        }

        private void DgLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DiemDanh dd = new DiemDanh(usLopDay.dgLopHoc.Rows[e.RowIndex].Cells["Ma_LopHoc"].Value.ToString());
            dd.btQuayLai.Click += BtQuayLai_Click1;
            Main.Controls.Clear();
            Main.Controls.Add(dd);
        }

        private void BtQuayLai_Click1(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(usLopDay);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        bool sttBtLopHoc = false;

        private void btLopHoc_Click(object sender, EventArgs e)
        {
            if (sttBtLopHoc == true)
            {
                btDaHocXong.Visible = btDangHoc.Visible = false;
                sttBtLopHoc = false;
            }
            else
            {
                btDaHocXong.Visible = btDangHoc.Visible = true;
                sttBtLopHoc = true;
            }
        }

        LichHoc_Tuan LH_Tuan;

        private void btLichHoc_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(LH_Tuan);
            LH_Tuan.btChiTiet.Click += BtChiTiet_Click1;

        }

        private void BtChiTiet_Click1(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            QuanLyLichHoc QL_LichHoc = new QuanLyLichHoc(LH_Tuan.Ma_LopHoc);
            QL_LichHoc.btQuayLai.Click += BtQuayLai_Click3;
            QL_LichHoc.btChiTiet.Visible = false;
            Main.Controls.Add(QL_LichHoc);
        }

        private void BtQuayLai_Click3(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(LH_Tuan);
        }

        private void btDangHoc_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new LopHoc_DangHoc("HS00001",1));
        }

        private void btDaHocXong_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new LopHoc_DangHoc("HS00001", 2));
        }

        private void btHocPhi_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new LopHoc_DangHoc("HS00001", 3));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new QuanLyTaiKhoan());
        }
        QuanLyLopHoc QlLopHoc;
        private void button5_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(QlLopHoc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new QuanLyGiaoVien());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new QuanLyHocSinh());
        }

        private void btLichDay_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new LichDay_Tuan(ID));
        }
        private void btAcc_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new ThongTinTaiKhoan(Quyen, ID));
        }

        void ShowLogin()
        {
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
        }

        private void btDangXuat_Click_1(object sender, EventArgs e)
        {
            Thread thr = new Thread(ShowLogin);
            thr.Start();
            this.Close();
        }
        
        private void btLopDangDay_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(usLopDay);
        }

        private void btQl_ThuHocPhi_Click(object sender, EventArgs e)
        {
            Main.Controls.Clear();
            Main.Controls.Add(new QL_ThuHocPhi());
        }
    }
}
