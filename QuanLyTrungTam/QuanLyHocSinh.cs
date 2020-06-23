using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTrungTam_BUS;
using QuanLyNhaHang_Entity;

namespace QuanLyTrungTam
{
    public partial class QuanLyHocSinh : UserControl
    {
        public QuanLyHocSinh()
        {
            InitializeComponent();
            List<EC_HocSinh> listGiaoVien = new BUS_HocSinh().SelectAll();
            LoadForm(listGiaoVien);
            cbLop.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 0;
            cbLop_Search.SelectedIndex = 0;
            cbGioiTinh_Search.SelectedIndex = 0;
            dtNgaySinh.Value = DateTime.Now;
        }
        void LoadForm(List<EC_HocSinh> listGiaoVien)
        {
            dgDanhsach.Rows.Clear();
            int x = 1;
            foreach (EC_HocSinh i in listGiaoVien)
            {
                string GioiTinh = i.GioiTinh == true ? "Nam" : "Nữ";
                dgDanhsach.Rows.Add(x.ToString(), i.Ma_HocSinh, i.Ten_HocSinh, i.NgaySinh.ToShortDateString(), GioiTinh, i.DiaChi, i.SDT, i.Email, i.Lop);
                x++;
            }
        }
        private void btTatCa_Click(object sender, EventArgs e)
        {
            List<EC_HocSinh> listGiaoVien = new BUS_HocSinh().SelectAll();
            LoadForm(listGiaoVien);
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string Ma_HocSinh = txbMa_HocSinh_Search.Text;
            string Ten_HocSinh = txbTen_HocSinh_Search.Text;
            string GioiTinh = cbGioiTinh_Search.SelectedItem.ToString();
            int Lop = cbLop_Search.SelectedIndex;

            List<EC_HocSinh> listResult = new List<EC_HocSinh>();

            if (Ma_HocSinh != "")
            {
                EC_HocSinh GV = new BUS_HocSinh().Select_ByPrimaryKey(Ma_HocSinh);
                if (GV != null)
                {
                    listResult.Add(GV);
                }
            }
            else if (Ten_HocSinh != "")
            {
                List<EC_HocSinh> list1 = new BUS_HocSinh().SelectByFields("Ten_HocSinh", Ten_HocSinh);
                foreach (EC_HocSinh i in list1)
                {
                    if (listResult.IndexOf(i) == -1)
                    {
                        listResult.Add(i);
                    }
                }
            }
            else if (GioiTinh != " ")
            {
                List<EC_HocSinh> list1 = new BUS_HocSinh().SelectByFields("GioiTinh", GioiTinh);
                foreach (EC_HocSinh i in list1)
                {
                    if (listResult.IndexOf(i) == -1)
                    {
                        listResult.Add(i);
                    }
                }
            }
            else if (Lop != 0) 
            {
                List<EC_HocSinh> list1 = new BUS_HocSinh().SelectByFields("Lop", Lop);
                foreach (EC_HocSinh i in list1)
                {
                    if (listResult.IndexOf(i) == -1)
                    {
                        listResult.Add(i);
                    }
                }
            }
            else
            {

            }
            if (listResult.Count > 0)
            {
                LoadForm(listResult);
            }
            else
            {
                List<EC_HocSinh> listGiaoVien = new BUS_HocSinh().SelectAll();
                LoadForm(listGiaoVien);
            }
        }

        private void btThem_Click_1(object sender, EventArgs e)
        {
            bool gt;
            if (cbGioiTinh.SelectedIndex == 0)
            {
                MessageBox.Show("Giới tính không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                gt = cbGioiTinh.SelectedIndex == 1 ? true : false;
            }
            int Lop;
            if (cbLop.SelectedIndex == 0)
            {
                MessageBox.Show("Trình độ không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Lop = cbLop.SelectedIndex + 1;
            }
            if (dtNgaySinh.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                EC_HocSinh HocSinh = new EC_HocSinh(txbMa_HocSinh.Text, txbTen_HocSinh.Text, dtNgaySinh.Value, gt, txbDiaChi.Text, txbSDT.Text, txbEmail.Text, Lop, "", null);
                BUS_HocSinh busHS = new BUS_HocSinh();
                busHS.ThemDuLieu(HocSinh);
                MessageBox.Show("Thêm học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Thêm học sinh thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
            if (txbMa_HocSinh.Text == "")
            {
                return;
            }
            bool GioiTinh = cbGioiTinh.SelectedIndex == 0 ? true : false;
            EC_HocSinh HocSinh = new EC_HocSinh(txbMa_HocSinh.Text, txbTen_HocSinh.Text, dtNgaySinh.Value, GioiTinh,
                txbDiaChi.Text, txbSDT.Text, txbEmail.Text, Int32.Parse(cbLop.SelectedItem.ToString()), txbID.Text,null);
            try
            {
                new BUS_HocSinh().SuaDuLieu(HocSinh);
                MessageBox.Show("Sửa thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Sửa không thành công!", "Thông báo");
            }
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            string Ma_HocSinh = txbMa_HocSinh.Text;
            if (Ma_HocSinh == "")
            {
                MessageBox.Show("Chọn giáo viên để xóa", "Thông báo");
                return;
            }
            EC_HocSinh HocSinh = new EC_HocSinh();
            HocSinh.Ma_HocSinh = Ma_HocSinh;
            try
            {
                new BUS_HocSinh().XoaDuLieu(HocSinh);
                MessageBox.Show("Xóa thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo");
            }
        }

        private void dgDanhsach_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            txbMa_HocSinh.Text = txbTen_HocSinh.Text = txbSDT.Text = txbDiaChi.Text = txbEmail.Text = txbSDT.Text
                = txbTenDangNhap.Text = txbID.Text = "";
            dtNgaySinh.Value = DateTime.Now;
            cbGioiTinh.Text = cbLop.Text = "";

            DataGridViewRow row = dgDanhsach.Rows[e.RowIndex];
            txbMa_HocSinh.Text = row.Cells["Ma_HocSinh"].Value.ToString();
            txbTen_HocSinh.Text = row.Cells["Ten_HocSinh"].Value.ToString();
            txbDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            txbEmail.Text = row.Cells["Email"].Value.ToString();
            txbSDT.Text = row.Cells["SDT"].Value.ToString();
            cbGioiTinh.SelectedIndex = row.Cells["GioiTinh"].Value.ToString() == "Nam" ? 0 : 1;
            dtNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value.ToString());
            foreach (string i in cbLop.Items)
            {
                if (i == row.Cells["LopHoc"].Value.ToString())
                {
                    cbLop.SelectedItem = i;
                }
            }

            string Ma_HocSinh = row.Cells["Ma_HocSinh"].Value.ToString();
            string ID = new BUS_HocSinh().Select_ByPrimaryKey(Ma_HocSinh).ID;
            if (ID == "")
            {
                txbID.Enabled = txbTenDangNhap.Enabled = true;
                txbMatKhau.Visible = true;
            }
            else
            {
                EC_TaiKhoan TaiKhoan = new BUS_TaiKhoan().SelectByMa(ID);
                txbID.Text = ID;
                if (TaiKhoan == null)
                {
                    txbID.Enabled = false;
                    txbTenDangNhap.Enabled = true;
                    txbMatKhau.Visible = true;
                }
                else
                {
                    txbID.Enabled = txbTenDangNhap.Enabled = false;
                    txbMatKhau.Visible = false;
                    txbTenDangNhap.Text = TaiKhoan.TenDangNhap;
                }
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMa_HocSinh.Text = txbTen_HocSinh.Text = txbSDT.Text = txbDiaChi.Text = txbEmail.Text = txbSDT.Text
                = txbTenDangNhap.Text = txbID.Text = "";
            dtNgaySinh.Value = DateTime.Now;
            cbGioiTinh.Text = cbLop.Text = "";
        }
        string Tao_ID()
        {
            List<EC_TaiKhoan> listTaiKhoan = new BUS_TaiKhoan().SelectAll();
            int ID_Max = 0;
            foreach (EC_TaiKhoan i in listTaiKhoan)
            {
                int ID_Int = Int32.Parse(i.ID.Substring(4));
                if (ID_Int > ID_Max)
                {
                    ID_Max = ID_Int;
                }
            }

            string So_Moi = (ID_Max + 1).ToString();
            string ID_Moi = "TTHT";
            int x = 9 - So_Moi.Length - 4;
            for (int i = 0; i < x; i++)
            {
                ID_Moi += "0";
            }
            ID_Moi += So_Moi;
            return ID_Moi;
        }
        private void btThem_TaiKhoan_Click(object sender, EventArgs e)
        {
            string Ma_HocSinh = txbMa_HocSinh.Text;
            if (Ma_HocSinh == "")
            {
                return;
            }
            EC_HocSinh HocSinh = new BUS_HocSinh().Select_ByPrimaryKey(Ma_HocSinh);
            if (HocSinh.ID == "")
            {
                try
                {
                    string MatKhau = Hash.getHashString(txbMatKhau.Text);
                    string ID = Tao_ID();
                    EC_TaiKhoan TaiKhoan = new EC_TaiKhoan(ID, txbTenDangNhap.Text, MatKhau);
                    new BUS_TaiKhoan().ThemDuLieu(TaiKhoan);
                    HocSinh.ID = ID;
                    new BUS_HocSinh().SuaDuLieu(HocSinh);
                    MessageBox.Show("Tạo tài khoản thành công", "Thông báo");
                }
                catch
                {
                    MessageBox.Show("Xem lại các thông tin đã tạo", "Thông báo");
                }
            }
            else
            {
                try
                {
                    string MatKhau = Hash.getHashString(txbMatKhau.Text);
                    EC_TaiKhoan TaiKhoan = new EC_TaiKhoan(HocSinh.ID, txbTenDangNhap.Text, MatKhau);
                    new BUS_TaiKhoan().ThemDuLieu(TaiKhoan);
                }
                catch
                {
                    MessageBox.Show("Xem lại các thông tin đã tạo", "Thông báo");
                }

            }
        }
    }
}
