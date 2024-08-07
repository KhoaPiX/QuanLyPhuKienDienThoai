using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhuKienDienThoai
{
    public partial class frm_Main : Form
    {
        #region variable
        DBConnect db = new DBConnect();
        //SanPham
        DataTable dtgvSP = new DataTable();
        DataTable dtSanPham = new DataTable();
        //NhanVien
        DataTable dtgvNV = new DataTable();
        DataTable dtNhanVien = new DataTable();
        DataTable dtTaiKhoan = new DataTable();
        //PhieuNhap
        DataTable dtPhieuNhap = new DataTable();
        DataTable dtCTPN = new DataTable();
        DataTable dtgvCTPN = new DataTable();
        //HoaDon
        DataTable dtHoaDon = new DataTable();
        DataTable dtCTHD = new DataTable();
        DataTable dtgvCTHD = new DataTable();

        List<DataRow> ldrIns = new List<DataRow>();
        List<DataRow> ldrDel = new List<DataRow>();
        string selectSP = "select * from SanPham";
        string selectNV = "Select * from NhanVien";
        string selectTK = "Select * from TaiKhoan";
        string selectPN = "select * from PhieuNhapKho";
        string selectCTPN = "select * from ChiTietPhieuNhap";
        string selectHD = "select * from HoaDon";
        string selectCTHD = "select * from ChiTietHoaDon";
        string sqlSP = "select * from SanPham, LoaiSP, NhaSX where SanPham.MaLoaiSP = LoaiSP.MaLoaiSP and NhaSX.MaNSX = SanPham.MaNSX";
        string sqlNV = "select * from NhanVien, ChucVu where NhanVien.MaChucVu = ChucVu.MaChucVu";
        //int count = 1;
        #endregion
        public frm_Main()
        {
            InitializeComponent();

            dtSanPham = db.getDataTable(selectSP);
            DataColumn[] keySP = new DataColumn[1];
            keySP[0] = dtSanPham.Columns[0];
            dtSanPham.PrimaryKey = keySP;
            //sqlCTPN = "Select * from ChiTietPhieuNhap ct, SanPham sp where ct.MaSP = sp.MaSP and MaPhieuNhap = '" + cboMaPN.Text + "'";
            //if (frm_DangNhap.UserTxt.Equals("Admin"))
            //{
            dtNhanVien = db.getDataTable(selectNV);
            DataColumn[] keyNV = new DataColumn[1];
            keyNV[0] = dtNhanVien.Columns[0];
            dtNhanVien.PrimaryKey = keyNV;

            dtTaiKhoan = db.getDataTable(selectTK);
            DataColumn[] keyTK = new DataColumn[1];
            keyTK[0] = dtTaiKhoan.Columns[0];
            dtTaiKhoan.PrimaryKey = keyTK;
                
            dtPhieuNhap = db.getDataTable(selectPN);
            DataColumn[] keyPN = new DataColumn[1];
            keyPN[0] = dtPhieuNhap.Columns[0];
            dtPhieuNhap.PrimaryKey = keyPN;
                
            dtCTPN = db.getDataTable(selectCTPN);
            DataColumn[] keyCTPN = new DataColumn[2];
            keyCTPN[0] = dtCTPN.Columns[0];
            keyCTPN[1] = dtCTPN.Columns[1];
            dtCTPN.PrimaryKey = keyCTPN;

            dtHoaDon = db.getDataTable(selectHD);
            DataColumn[] keyHD = new DataColumn[1];
            keyHD[0] = dtHoaDon.Columns[0];
            dtHoaDon.PrimaryKey = keyHD;

            dtCTHD = db.getDataTable(selectCTHD);
            DataColumn[] keyCTHD = new DataColumn[2];
            keyCTHD[0] = dtCTHD.Columns[0];
            keyCTHD[1] = dtCTHD.Columns[1];
            dtCTHD.PrimaryKey = keyCTHD;
            //}
        }
        #region Kiem_tra_trung_and_main_desgin and Seleted Index change
        bool ValiDateEmail(string email)
        {
            try
            {
                MailAddress check = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
        bool IsEmpty(string str)
        {
            return str.Length <= 0;
        }
        public bool TrungThongTin(string selectStr)
        {
            int kq = (int)db.GetData(selectStr);
            if (kq == 1)
                return true;
            return false;
        }
        bool TrungMa(string ma, string colMa)
        {
            foreach (DataRow row in ldrIns)
                if (row[colMa].ToString().Equals(ma))
                    return true;
            return false;
        }
        private void tabMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabMain.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabMain.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Blue);
                g.FillRectangle(Brushes.Cyan, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Arial", 12.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            ldrDel.Clear();
            ldrIns.Clear();
            dtSanPham = db.getDataTable(selectSP);
            DataColumn[] keySP = new DataColumn[1];
            keySP[0] = dtSanPham.Columns[0];
            dtSanPham.PrimaryKey = keySP;
            //sqlCTPN = "Select * from ChiTietPhieuNhap ct, SanPham sp where ct.MaSP = sp.MaSP and MaPhieuNhap = '" + cboMaPN.Text + "'";
            //if (frm_DangNhap.UserTxt.Equals("Admin"))
            //{
            dtNhanVien = db.getDataTable(selectNV);
            DataColumn[] keyNV = new DataColumn[1];
            keyNV[0] = dtNhanVien.Columns[0];
            dtNhanVien.PrimaryKey = keyNV;

            dtTaiKhoan = db.getDataTable(selectTK);
            DataColumn[] keyTK = new DataColumn[1];
            keyTK[0] = dtTaiKhoan.Columns[0];
            dtTaiKhoan.PrimaryKey = keyTK;

            dtPhieuNhap = db.getDataTable(selectPN);
            DataColumn[] keyPN = new DataColumn[1];
            keyPN[0] = dtPhieuNhap.Columns[0];
            dtPhieuNhap.PrimaryKey = keyPN;

            dtCTPN = db.getDataTable(selectCTPN);
            DataColumn[] keyCTPN = new DataColumn[2];
            keyCTPN[0] = dtCTPN.Columns[0];
            keyCTPN[1] = dtCTPN.Columns[1];
            dtCTPN.PrimaryKey = keyCTPN;

            dtHoaDon = db.getDataTable(selectHD);
            DataColumn[] keyHD = new DataColumn[1];
            keyHD[0] = dtHoaDon.Columns[0];
            dtHoaDon.PrimaryKey = keyHD;

            dtCTHD = db.getDataTable(selectCTHD);
            DataColumn[] keyCTHD = new DataColumn[2];
            keyCTHD[0] = dtCTHD.Columns[0];
            keyCTHD[1] = dtCTHD.Columns[1];
            dtCTHD.PrimaryKey = keyCTHD;
        }
        private void cboMaPN_Hide_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboMaPN.SelectedIndex = cboMaPN_Hide.SelectedIndex;
            }
            catch
            {
                return;
            }
        }
        private void cboMaPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectPN = "select * from PhieuNhapKho where MaPhieuNhap = '" + cboMaPN.Text + "'";
            DataTable dt = db.getDataTable(selectPN);
            DataBindPN(dt);
            Load_DgvCTPN();
        }
        private void cboMaHD_Hide_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cboMaHD.SelectedIndex = cboMaHD_Hide.SelectedIndex;
            }
            catch
            {
                return;
            }
        }
        private void cboMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectHD = "select * from HoaDon where MaHD = '" + cboMaHD.Text + "'";
            DataTable dt = db.getDataTable(selectHD);
            DataBindHD(dt);
            Load_DgvCTHD();
        }
        private void cboTenSP_HD_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectDonGia = "select GiaBan from SanPham where MaSP = '" + cboTenSP_HD.SelectedValue.ToString() + "'";
                txtDonGiaHD.Text = ((Decimal)db.GetData(selectDonGia)).ToString();
            }
            catch
            {
                return;
            }
        }
        #endregion

        #region Trang_chu_and_form_main_load
        private void frm_Main_Load(object sender, EventArgs e)
        {
            Load_ComboLoaiSP();
            Load_ComboNSX();
            Load_ComboKH();
            //phieuNhap: Ql nhập hàng
            Load_ComboNCC();
            Load_ComboTenNVPN();
            Load_ComboTenSP();
            Load_ComboMaPN();
            Load_DgvCTPN();
            Load_DgvSanPham();
            //hoaDon
            Load_ComboKH();
            Load_ComboMaHD();
            Load_ComboTenNVHD();
            Load_ComboTenSPHD();
            Load_DgvCTHD();
            dtp_NgayNhap.Format = dtp_NgaySinhNV.Format = dtpNgayLap_HD.Format = DateTimePickerFormat.Custom;
            dtp_NgayNhap.CustomFormat = dtp_NgaySinhNV.CustomFormat = dtpNgayLap_HD.CustomFormat = "dd/MM/yyyy";
            if (frm_DangNhap.UserTxt.Equals("Admin"))
            {
                lblUser.Text = "Xin chào, Admin";
                lblChucVu.Text = "Chức vụ: Admin";
                Load_ComboChucVu();
                Load_DgvNhanVien();
                btnQLTK.Enabled = true;
            }
            else
            {
                if (frm_DangNhap.MaChucVuTxt.Equals("QLNH"))
                {
                    tabMain.TabPages.Remove(tabHoaDon);
                    tabMain.TabPages.Remove(tabProduct);
                    tabMain.TabPages.Remove(tabNhanVien);
                }
                else if(frm_DangNhap.MaChucVuTxt.Equals("NV"))
                {
                    tabMain.TabPages.Remove(tabKho);
                    tabMain.TabPages.Remove(tabHoaDon);
                    tabMain.TabPages.Remove(tabNhanVien);
                }
                else
                {
                    tabMain.TabPages.Remove(tabKho);
                    tabMain.TabPages.Remove(tabProduct);
                    tabMain.TabPages.Remove(tabNhanVien);
                }
                lblUser.Text = "Xin chào, " + frm_DangNhap.NameTxt;
                lblChucVu.Text = "Chức vụ: " + db.GetData("select TenChucVu from ChucVu where MaChucVu = '" + frm_DangNhap.MaChucVuTxt + "'").ToString();
                tabMain.TabPages.Remove(tabNhanVien);
                btnAddLoaiSP.Visible = false;
                btnAddNSX.Visible = false;
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
        #endregion

        #region keyPress and leave event
        //SanPham
        private void txtMaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsUpper(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        //NhanVien
        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }
        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            int intValue;
            Decimal DValue;
            if (int.TryParse(txtSoLuong.Text, out intValue) && Decimal.TryParse(txtDonGiaPN.Text, out DValue))
            {
                txtThanhTienPN.Text = ((Decimal)int.Parse(txtSoLuong.Text) * Decimal.Parse(txtDonGiaPN.Text)).ToString();
                //txtThanhTienPN
            }
        }
        private void txtGiamGia_Leave(object sender, EventArgs e)
        {
            int intValue;
            Decimal DValue;
            if (int.TryParse(txtSoLuongHD.Text, out intValue) && Decimal.TryParse(txtDonGiaHD.Text, out DValue) && int.TryParse(txtGiamGia.Text, out intValue))
            {
                Decimal sl = (Decimal) int.Parse(txtSoLuongHD.Text);
                Decimal dg = Decimal.Parse(txtDonGiaHD.Text);
                Decimal gg = (Decimal) int.Parse(txtGiamGia.Text);
                txtThanhTienHD.Text = ((int)(sl * dg - gg / 100 * sl * dg)).ToString();
            }
        }
        #endregion

        #region loadCbo
        //SanPham
        public void Load_ComboLoaiSP()
        {
            string selectStr = "select * from LoaiSP";
            DataTable dtLoaiSP = db.getDataTable(selectStr);
            cboLoaiSP.DataSource = dtLoaiSP;
            cboLoaiSP.DisplayMember = "TenLoaiSP";
            cboLoaiSP.ValueMember = "MaLoaiSP";
        }
        public void Load_ComboNSX()
        {
            string selectStr = "select * from NhaSX";
            DataTable dtNSX = db.getDataTable(selectStr);
            cboNSX.DataSource = dtNSX;
            cboNSX.DisplayMember = "TenNSX";
            cboNSX.ValueMember = "MaNSX";
        }
        
        //NhanVien
        public void Load_ComboChucVu()
        {
            string selectStr = "select * from ChucVu";
            DataTable dtChucVu = db.getDataTable(selectStr);
            cboChucVu.DataSource = dtChucVu;
            cboChucVu.DisplayMember = "TenChucVu";
            cboChucVu.ValueMember = "MaChucVu";
        }
        
        //PhieuNhap
        public void Load_ComboNCC()
        {
            string selectStr = "select * from NhaCC";
            DataTable dt = db.getDataTable(selectStr);
            cboNCC.DataSource = dt;
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
        }
        public void Load_ComboTenNVPN()
        {
            string selectStr = "select * from NhanVien where MaChucVu = 'QLNH'";
            DataTable dt = db.getDataTable(selectStr);
            cboTenNV.DataSource = dt;
            cboTenNV.DisplayMember = "TenNV";
            cboTenNV.ValueMember = "MaNV";
        }
        public void Load_ComboTenSP()
        {
            string selectStr = "select * from SanPham";
            DataTable dt = db.getDataTable(selectStr);
            cboTenSP.DataSource = dt;
            cboTenSP.DisplayMember = "TenSP";
            cboTenSP.ValueMember = "MaSP";
        }
        public void Load_ComboMaPN()
        {
            string selectStr = "select * from PhieuNhapKho";
            DataTable dt = db.getDataTable(selectStr);
            
            cboMaPN.DataSource = dt;
            cboMaPN.DisplayMember = "MaPhieuNhap";
            cboMaPN.ValueMember = "MaPhieuNhap";
            cboMaPN_Hide.Items.Clear();
            for (int i = 0; i < cboMaPN.Items.Count; i++)
            {
                string value = cboMaPN.GetItemText(cboMaPN.Items[i]);
                cboMaPN_Hide.DisplayMember = "Text";
                cboMaPN_Hide.ValueMember = "Value";
                cboMaPN_Hide.Items.Add(new { Text = value, Value = i.ToString() });
                cboMaPN_Hide.SelectedIndex = 0;
            }
            cboMaPN_Hide.SelectedIndex = 0;
        }
        
        //HoaDon
        public void Load_ComboKH()
        {
            //string selectStr = "select MaKH, (MaKH + ' ' + TenKH) as kh from KhachHang";
            string selectStr = "select * from KhachHang";            
            DataTable dt = db.getDataTable(selectStr);
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
        }
        public void Load_ComboTenNVHD()
        {
            string selectStr = "select * from NhanVien where MaChucVu = 'TN'";
            DataTable dt = db.getDataTable(selectStr);
            cboNhanVien_HD.DataSource = dt;
            cboNhanVien_HD.DisplayMember = "TenNV";
            cboNhanVien_HD.ValueMember = "MaNV";
        }
        public void Load_ComboMaHD()
        {
            string selectStr = "select * from HoaDon";
            DataTable dt = db.getDataTable(selectStr);

            cboMaHD.DataSource = dt;
            cboMaHD.DisplayMember = "MaHD";
            cboMaHD.ValueMember = "MaHD";
            cboMaHD_Hide.Items.Clear();
            for (int i = 0; i < cboMaHD.Items.Count; i++)
            {
                string value = cboMaHD.GetItemText(cboMaHD.Items[i]);
                cboMaHD_Hide.DisplayMember = "Text";
                cboMaHD_Hide.ValueMember = "Value";
                cboMaHD_Hide.Items.Add(new { Text = value, Value = i.ToString() });
                cboMaHD_Hide.SelectedIndex = 0;
            }
            cboMaHD_Hide.SelectedIndex = 0;
        }
        public void Load_ComboTenSPHD()
        {
            string selectStr = "select * from SanPham";
            DataTable dt = db.getDataTable(selectStr);
            cboTenSP_HD.DataSource = dt;
            cboTenSP_HD.DisplayMember = "TenSP";
            cboTenSP_HD.ValueMember = "MaSP";
        }
        #endregion

        #region DataBinding
        void DataBindSP(DataTable dt)
        {
            txtMaSP.DataBindings.Clear();
            cboLoaiSP.DataBindings.Clear();
            txtTenSP.DataBindings.Clear();
            cboNSX.DataBindings.Clear();
            txtXuatXu.DataBindings.Clear();
            txtGiaBan.DataBindings.Clear();

            txtMaSP.DataBindings.Add("Text", dt, "MaSP");
            cboLoaiSP.DataBindings.Add("SelectedValue", dt, "MaLoaiSP");
            txtTenSP.DataBindings.Add("Text", dt, "TenSP");
            cboNSX.DataBindings.Add("SelectedValue", dt, "MaNSX");
            txtXuatXu.DataBindings.Add("Text", dt, "XuatXu");
            txtGiaBan.DataBindings.Add("Text", dt, "GiaBan");
        }
        void DataBindNV(DataTable dt)
        {
            txtMaNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            cboChucVu.DataBindings.Clear();
            cboGender.DataBindings.Clear();
            dtp_NgaySinhNV.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtLuong.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dt, "MaNV");
            txtTenNV.DataBindings.Add("Text", dt, "TenNV");
            cboChucVu.DataBindings.Add("SelectedValue", dt, "MaChucVu");
            cboGender.DataBindings.Add("SelectedItem", dt, "GioiTinh");
            dtp_NgaySinhNV.DataBindings.Add("Text", dt, "NgaySinh");
            txtSDT.DataBindings.Add("Text", dt, "SoDT");
            txtEmail.DataBindings.Add("Text", dt, "Email");
            txtLuong.DataBindings.Add("Text", dt, "Luong");
        }
        void DataBindPN(DataTable dt)
        {
            cboMaPN.DataBindings.Clear();
            cboTenNV.DataBindings.Clear();
            cboNCC.DataBindings.Clear();
            dtp_NgayNhap.DataBindings.Clear();

            cboMaPN.DataBindings.Add("Text", dt, "MaPhieuNhap");
            cboTenNV.DataBindings.Add("SelectedValue", dt, "MaNV");
            cboNCC.DataBindings.Add("SelectedValue", dt, "MaNCC");
            dtp_NgayNhap.DataBindings.Add("text", dt, "NgayNhap");
        }
        void DataBindCTPN(DataTable dt)
        {
            cboMaPN.DataBindings.Clear();
            cboTenSP.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDonGiaPN.DataBindings.Clear();
            txtThanhTienPN.DataBindings.Clear();

            cboMaPN.DataBindings.Add("text", dt, "MaPhieuNhap");
            cboTenSP.DataBindings.Add("SelectedValue", dt, "MaSP");
            txtSoLuong.DataBindings.Add("text", dt, "SoLuongNhap");
            txtDonGiaPN.DataBindings.Add("text", dt, "DonGia");
            txtThanhTienPN.DataBindings.Add("text", dt, "ThanhTien");
        }
        void DataBindHD(DataTable dt)
        {
            cboMaHD.DataBindings.Clear();
            cboTenNV.DataBindings.Clear();
            cboKhachHang.DataBindings.Clear();
            dtpNgayLap_HD.DataBindings.Clear();

            cboMaHD.DataBindings.Add("Text", dt, "MaHD");
            cboTenNV.DataBindings.Add("SelectedValue", dt, "MaNV");
            cboKhachHang.DataBindings.Add("SelectedValue", dt, "MaKH");
            dtpNgayLap_HD.DataBindings.Add("text", dt, "NgayLap");
        }
        void DataBindCTHD(DataTable dt)
        {
            cboMaHD.DataBindings.Clear();
            cboTenSP_HD.DataBindings.Clear();
            txtSoLuongHD.DataBindings.Clear();
            txtDonGiaHD.DataBindings.Clear();
            txtThanhTienHD.DataBindings.Clear();
            txtGiamGia.DataBindings.Clear();

            cboMaHD.DataBindings.Add("text", dt, "MaHD");
            cboTenSP_HD.DataBindings.Add("SelectedValue", dt, "MaSP");
            txtSoLuongHD.DataBindings.Add("text", dt, "SoLuong");
            txtDonGiaHD.DataBindings.Add("text", dt, "DonGia");
            txtThanhTienHD.DataBindings.Add("text", dt, "ThanhTien");
            txtGiamGia.DataBindings.Add("text", dt, "GiamGia");
        }
        #endregion

        #region CellClick
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvSanPham.CurrentRow;
            txtMaSP.Text = Convert.ToString(row.Cells["colMaSP"].Value);
            txtTenSP.Text = Convert.ToString(row.Cells["colTenSP"].Value);
            cboLoaiSP.Text = Convert.ToString(row.Cells["colLoaiSP"].Value);
            cboNSX.Text = Convert.ToString(row.Cells["colHangSP"].Value);
            txtXuatXu.Text = Convert.ToString(row.Cells["colXuatXu"].Value);
            txtGiaBan.Text = Convert.ToString(row.Cells["colGiaBan"].Value);
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvNhanVien.CurrentRow;
            txtMaNV.Text = Convert.ToString(row.Cells["colMaNV"].Value);
            txtTenNV.Text = Convert.ToString(row.Cells["colTenNV"].Value);
            cboChucVu.Text = Convert.ToString(row.Cells["colChucVu"].Value);
            cboGender.Text = Convert.ToString(row.Cells["colGender"].Value);
            dtp_NgaySinhNV.Text = Convert.ToString(row.Cells["colNgaySinh"].Value);
            txtSDT.Text = Convert.ToString(row.Cells["colSoDT"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["colEmail"].Value);
            txtLuong.Text = Convert.ToString(row.Cells["colLuong"].Value);
        }
        private void dgv_cthd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgv_cthd.CurrentRow;
            cboMaHD.Text = Convert.ToString(row.Cells["MaHD"].Value);
            cboTenSP_HD.Text = Convert.ToString(row.Cells["TenSPHD"].Value);
            txtSoLuongHD.Text = Convert.ToString(row.Cells["SoLuongHD"].Value);
            txtDonGiaHD.Text = Convert.ToString(row.Cells["DonGiaHD"].Value);
            txtThanhTienHD.Text = Convert.ToString(row.Cells["ThanhTienHD"].Value);
            txtGiamGia.Text = Convert.ToString(row.Cells["GiamGia"].Value);
        }
        private void dgv_ctpn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgv_ctpn.CurrentRow;
            cboMaPN.Text = Convert.ToString(row.Cells["MaPN"].Value);
            cboTenSP.Text = Convert.ToString(row.Cells["TenSP"].Value);
            txtSoLuong.Text = Convert.ToString(row.Cells["SoLuong"].Value);
            txtDonGiaPN.Text = Convert.ToString(row.Cells["DonGia"].Value);
            txtThanhTienPN.Text = Convert.ToString(row.Cells["ThanhTien"].Value);
        }
        #endregion
        
        #region loadDgv
        public void Load_DgvSanPham()
        {
            dtgvSP = new DataTable();
            dtgvSP = db.getDataTable(sqlSP);
            DataColumn[] keySP = new DataColumn[1];
            keySP[0] = dtgvSP.Columns[0];
            dtgvSP.PrimaryKey = keySP;
            dgvSanPham.AutoGenerateColumns = false;
            dgvSanPham.DataSource = dtgvSP;
            //DataBindSP(dtgvSP);
        }
        public void Load_DgvNhanVien()
        {
            dtgvNV = new DataTable();
            dtgvNV = db.getDataTable(sqlNV);
            DataColumn[] keyNV = new DataColumn[1];
            keyNV[0] = dtgvNV.Columns[0];
            dtgvNV.PrimaryKey = keyNV;
            dgvNhanVien.AutoGenerateColumns = false;
            dgvNhanVien.DataSource = dtgvNV;
            //DataBindNV(dtgvNV);
        }
        public void Load_DgvCTPN()
        {
            dtgvCTPN = new DataTable();
            string ma = cboMaPN.GetItemText(cboMaPN.SelectedItem);
            dtgvCTPN = db.getDataTable("Select * from ChiTietPhieuNhap ct, SanPham sp where ct.MaSP = sp.MaSP and MaPhieuNhap = '" + ma + "'");
            dgv_ctpn.AutoGenerateColumns = false;
            dgv_ctpn.DataSource = dtgvCTPN;
            DataColumn[] keyCTPN = new DataColumn[2];
            keyCTPN[0] = dtgvCTPN.Columns[0];
            keyCTPN[1] = dtgvCTPN.Columns[1];
            dtgvCTPN.PrimaryKey = keyCTPN;
            //DataBindCTPN(dtgvCTPN);
        }
        public void Load_DgvCTHD()
        {
            dtgvCTHD = new DataTable();
            dtgvCTHD = db.getDataTable("Select * from ChiTietHoaDon ct, SanPham sp where ct.MaSP = sp.MaSP and MaHD = '" + cboMaHD.GetItemText(cboMaHD.SelectedItem) + "'");
            dgv_cthd.AutoGenerateColumns = false;
            DataColumn[] keyCTHD = new DataColumn[2];
            keyCTHD[0] = dtgvCTHD.Columns[0];
            keyCTHD[1] = dtgvCTHD.Columns[1];
            dtgvCTHD.PrimaryKey = keyCTHD;
            dgv_cthd.DataSource = dtgvCTHD;
            //DataBindCTHD(dtgvCTHD);
        }
        
        #endregion

        #region btnAdd
        //SanPham
        void taoMaSP()
        {
            txtMaSP.Text = "sp";
            string sqlCount = "select count(*) from SanPham";
            int count = (int)db.GetData(sqlCount);
            while (true)
            {
                count++;
                if (count < 10)
                    txtMaSP.Text += "00" + count.ToString();
                else if (count < 100)
                    txtMaSP.Text += "0" + count.ToString();
                else
                    txtMaSP.Text += count.ToString();
                if (TrungThongTin("Select count(*) from SanPham where MaSP = '" + txtMaSP.Text + "'") == false && TrungMa(txtMaSP.Text, "MaSP") == false)
                    break;
                else
                    txtMaSP.Text = "sp";
            }
        }
        private void btnStartAddSP_Click(object sender, EventArgs e)
        {
            taoMaSP();
            txtTenSP.Text = txtXuatXu.Text = txtGiaBan.Text = "";
            txtTenSP.Focus();
            btnAddLoaiSP.Enabled = false;
            btnAddNSX.Enabled = false;
            btnStartDelSP.Enabled = false;
            btnStartEditSP.Enabled = false;
            btnStartAddSP.Visible = false;
            btnAddSP.Visible = true;
            btnCancelSP_Ins.Visible = true;
        }
        private void btnAddSP_Click(object sender, EventArgs e)
        {

            string selectMaSP = "select count(*) from SanPham where MaSP = '" + txtMaSP.Text + "'";
            if (IsEmpty(txtMaSP.Text) || IsEmpty(txtTenSP.Text) || IsEmpty(txtXuatXu.Text) || IsEmpty(txtGiaBan.Text))
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TrungThongTin(selectMaSP) || TrungMa(txtMaSP.Text, "MaSP"))
                MessageBox.Show("Mã SP bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //DataRow row = dtSanPham.NewRow();
                DataRow row = dtgvSP.NewRow();
                DataRow dtr = dtSanPham.NewRow();
                dtr["MaSP"] = row["MaSP"] = txtMaSP.Text;
                dtr["MaLoaiSP"] = row["MaLoaiSP"] = cboLoaiSP.SelectedValue.ToString();
                row["TenLoaiSP"] = cboLoaiSP.Text;
                dtr["TenSP"] = row["TenSP"] = txtTenSP.Text;
                dtr["MaNSX"] = row["MaNSX"] = cboNSX.SelectedValue.ToString();
                row["TenNSX"] = cboNSX.Text;
                dtr["XuatXu"] = row["XuatXu"] = txtXuatXu.Text;
                dtr["GiaBan"] = row["GiaBan"] = txtGiaBan.Text;
                ldrIns.Add(row);
                dtgvSP.Rows.Add(row);
                dtSanPham.Rows.Add(dtr);

                KhoiPhucBtnSP();
            }
        }
        //NhanVien
        void taoMaNV()
        {
            txtMaNV.Text = "NV";
            string sqlCount = "select count(*) from NhanVien";
            int count = (int)db.GetData(sqlCount);
            while (true)
            {
                count++;
                if (count < 10)
                    txtMaNV.Text += "000" + count.ToString();
                else if (count < 100)
                    txtMaNV.Text += "0" + count.ToString();
                else
                    txtMaNV.Text += count.ToString();
                if ((int)db.GetData(sqlCount + " where MaNV = '" + txtMaNV.Text + "'") == 0 && TrungMa(txtMaNV.Text, "MaNV") == false)
                    break;
                else
                    txtMaNV.Text = "NV";
            }
        }
        private void btnStartAddNV_Click(object sender, EventArgs e)
        {
            taoMaNV();
            txtTenNV.Focus();
            txtTenNV.Text = txtSDT.Text = txtEmail.Text = txtLuong.Text = "";
            btnChucVu.Enabled = false;
            btnQLTK.Enabled = false;
            btnStartDelNV.Enabled = false;
            btnStartEditNV.Enabled = false;
            btnStartAddNV.Visible = false;
            btnAddNV.Visible = true;
            btnCancelNV_Ins.Visible = true;
        }
        private void btnAddNV_Click(object sender, EventArgs e)
        {
            string selectMaNV = "select count(*) from NhanVien where MaNV = '" + txtMaNV.Text + "'";
            string selectSDT = "select count(*) from NhanVien where SoDT = '" + txtSDT.Text + "'";
            string selectEmail = "select count(*) from NhanVien where Email = '" + txtEmail.Text + "'";
            if (IsEmpty(txtMaNV.Text) || IsEmpty(txtTenNV.Text) || IsEmpty(txtSDT.Text) || IsEmpty(txtLuong.Text))
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSDT.Text.Length != 10)
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TrungThongTin(selectSDT))
                MessageBox.Show("Số điện thoại bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!ValiDateEmail(txtEmail.Text))
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TrungThongTin(selectEmail))
                MessageBox.Show("Email bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataRow row = dtgvNV.NewRow();
                DataRow dtr = dtNhanVien.NewRow();
                dtr["MaNV"] = row["MaNV"] = txtMaNV.Text;
                dtr["TenNV"] = row["TenNV"] = txtTenNV.Text;
                dtr["MaChucVu"] = cboChucVu.SelectedValue.ToString();
                row["TenChucVu"] = cboChucVu.Text;
                dtr["GioiTinh"] = row["GioiTinh"] = cboGender.Text;
                dtr["NgaySinh"] = row["NgaySinh"] = dtp_NgaySinhNV.Value.ToString("yyyy-MM-dd"); ;
                dtr["SoDT"] = row["SoDT"] = txtSDT.Text;
                dtr["Email"] = row["Email"] = txtEmail.Text;
                dtr["Luong"] = row["Luong"] = txtLuong.Text;
                dtNhanVien.Rows.Add(dtr);
                dtgvNV.Rows.Add(row);
                ldrIns.Add(row);

                KhoiPhucBtnNV();
            }
        }
        //PhieuNhap
        void taoMaPN()
        {
            //string sql = "select count(*) from PHIEUNHAP where NGAYNHAP = '" + dtp_NgayNhap.Value.ToString("yyyy-MM-dd") + "'";
            string sqlCount = "select count(*) from PhieuNhapKho where NgayNhap = '" + dtp_NgayNhap.Value + "'";
            int count = (int)db.GetData(sqlCount);
            while(true)
            {
                txtMaPN.Text = "PN";
                count++;
                txtMaPN.Text += (dtp_NgayNhap.Value.Year % 100).ToString();
                if (dtp_NgayNhap.Value.Day < 10)
                    txtMaPN.Text += "0" + dtp_NgayNhap.Value.Day.ToString();
                else
                    txtMaPN.Text += dtp_NgayNhap.Value.Day.ToString();
                if (dtp_NgayNhap.Value.Month < 10)
                    txtMaPN.Text += "0" + dtp_NgayNhap.Value.Month.ToString();
                else
                    txtMaPN.Text += dtp_NgayNhap.Value.Month.ToString();
                if (count < 10)
                    txtMaPN.Text += "00";
                else if (count < 100)
                    txtMaPN.Text += "0";
                txtMaPN.Text += count.ToString();
                if ((int)db.GetData("select count(*) from PhieuNhapKho where MaPhieuNhap = '" + txtMaPN.Text + "'") == 0 && TrungMa(txtMaPN.Text, "MaPhieuNhap") == false)
                    break;
            }
        }
        private void dtp_NgayNhap_ValueChanged(object sender, EventArgs e)
        {
            taoMaPN();
        }
        private void btnStartAddPN_Click(object sender, EventArgs e)
        {
            cboMaPN_Hide.Visible = false;
            txtMaPN.Visible = true;
            taoMaPN();
            btnStartAddPN.Visible = false;
            btnAddPN.Visible = true;
            btnCancelPN_Ins.Visible = true;
            btnSavePN.Visible = false;
            cboTenNV.SelectedIndex = cboTenNV.FindString(frm_DangNhap.NameTxt);
            if (cboTenNV.Text == "")
                cboTenNV.Enabled = true;
            else
                cboTenNV.Enabled = false;
        }
        private void btnAddPN_Click(object sender, EventArgs e)
        {
            DataRow row = dtPhieuNhap.NewRow();
            
            row["MaPhieuNhap"] = txtMaPN.Text;
            row["MaNV"] = cboTenNV.SelectedValue.ToString();
            row["ManCC"] = cboNCC.SelectedValue.ToString();
            row["NgayNhap"] = dtpNgayLap_HD.Value.ToString("yyyy-MM-dd");
            ldrIns.Add(row);
            dtPhieuNhap.Rows.Add(row);
            cboMaPN_Hide.Items.Add(txtMaPN.Text);
            KhoiPhucBtnPN();
        }
        private void btnStartAddCTPN_Click(object sender, EventArgs e)
        {
            txtSoLuong.Focus();
            btnStartAddCTPN.Visible = false;
            btnAddCTPN.Visible = true;
            btnCancelCTPN_Ins.Visible = true;
            btnSaveCTPN.Visible = false;
            cboNhanVien_HD.SelectedIndex = cboNhanVien_HD.FindString(frm_DangNhap.NameTxt);
            if (cboNhanVien_HD.Text == "")
                cboNhanVien_HD.Enabled = true;
            else
                cboNhanVien_HD.Enabled = false;
        }
        private void btnAddCTPN_Click(object sender, EventArgs e)
        {
            if (TrungThongTin("select count(*) from ChiTietPhieuNhap where MaPhieuNhap = '" + cboMaPN.Text + "' and MaSP = '" + cboTenSP.SelectedValue.ToString() + "'") || TrungMa(cboTenSP.SelectedValue.ToString(), "MaSP"))
            {
                MessageBox.Show("Đã có sản phẩm trong phiếu nhập này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DataRow dtr = dtCTPN.NewRow();
                DataRow row = dtgvCTPN.NewRow();

                dtr["MaPhieuNhap"] = row["MaPhieuNhap"] = cboMaPN.Text;
                dtr["MaSP"] = row["MaSP"] = cboTenSP.SelectedValue.ToString();
                row["TenSP"] = cboTenSP.Text;
                dtr["SoLuongNhap"] = row["SoLuongNhap"] = txtSoLuong.Text;
                dtr["DonGia"] = row["DonGia"] = txtDonGiaPN.Text;
                dtr["ThanhTien"] = row["ThanhTien"] = txtThanhTienPN.Text;
                dtgvCTPN.Rows.Add(row);
                dtCTPN.Rows.Add(dtr);
                ldrIns.Add(dtr);
                
                KhoiPhucBtnCTPN();
            }        
        }
        //HoaDon
        void taoMaHD()
        {
            string sqlCount = "select count(*) from HoaDon where NgayLap = '" + dtpNgayLap_HD.Value + "'";
            int count = (int)db.GetData(sqlCount);
            while (true)
            {
                txtMaHD.Text = "HD";
                count++;
                txtMaHD.Text += (dtpNgayLap_HD.Value.Year % 100).ToString();
                if (dtpNgayLap_HD.Value.Day < 10)
                    txtMaHD.Text += "0" + dtpNgayLap_HD.Value.Day.ToString();
                else
                    txtMaHD.Text += dtpNgayLap_HD.Value.Day.ToString();
                if (dtpNgayLap_HD.Value.Month < 10)
                    txtMaHD.Text += "0" + dtpNgayLap_HD.Value.Month.ToString();
                else
                    txtMaHD.Text += dtpNgayLap_HD.Value.Month.ToString();
                if (count < 10)
                    txtMaHD.Text += "00";
                else if (count < 100)
                    txtMaHD.Text += "0";
                txtMaHD.Text += count.ToString();
                if ((int)db.GetData("select count(*) from HoaDon where MaHD = '" + txtMaHD.Text + "'") == 0 && TrungMa(txtMaHD.Text, "MaHD") == false)
                    break;
            }
        }
        private void dtp_NgayLap_HD_ValueChanged(object sender, EventArgs e)
        {
            taoMaHD();
        }
        private void btnStartAddHD_Click(object sender, EventArgs e)
        {
            cboMaHD_Hide.Visible = false;
            txtMaHD.Visible = true;
            taoMaHD();
            btnStartAddHD.Visible = false;
            btnAddHD.Visible = true;
            btnCancelHD_Ins.Visible = true;
            btnSaveHD.Visible = false;
        }
        private void btnAddHD_Click(object sender, EventArgs e)
        {
            DataRow row = dtHoaDon.NewRow();

            row["MaHD"] = txtMaHD.Text;
            row["MaNV"] = cboNhanVien_HD.SelectedValue.ToString();
            row["MaKH"] = cboKhachHang.SelectedValue.ToString();
            row["NgayLap"] = dtpNgayLap_HD.Value.ToString("yyyy-MM-dd");
            ldrIns.Add(row);
            dtHoaDon.Rows.Add(row);
            cboMaHD_Hide.Items.Add(txtMaHD.Text);
            KhoiPhucBtnHD();
        }
        private void btnStartAddCTHD_Click(object sender, EventArgs e)
        {
            string selectDonGia = "select GiaBan from SanPham where MaSP = '" + cboTenSP_HD.SelectedValue.ToString() + "'";
            txtGiamGia.Focus();
            txtSoLuongHD.Text = txtDonGiaHD.Text = txtThanhTienHD.Text = txtGiamGia.Text = "";
            txtDonGiaHD.Text = ((Decimal)db.GetData(selectDonGia)).ToString();
            btnStartAddCTHD.Visible = false;
            btnAddCTHD.Visible = true;
            btnCancelCTHD_Ins.Visible = true;
            btnSaveCTHD.Visible = false;
        }
        private void btnAddCTHD_Click(object sender, EventArgs e)
        {
            if (TrungThongTin("select count(*) from ChiTietHoaDon where MaHD = '" + cboMaHD.Text + "' and MaSP = N'" + cboTenSP_HD.SelectedValue.ToString() + "'") || TrungMa(cboTenSP_HD.SelectedValue.ToString(), "MaSP"))
            {
                MessageBox.Show("Đã có sản phẩm trong hóa đơn này này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(IsEmpty(txtSoLuongHD.Text) || IsEmpty(txtGiamGia.Text))
            {
                MessageBox.Show("Không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DataRow dtr = dtCTHD.NewRow();
                DataRow row = dtgvCTHD.NewRow();
                dtr["MaHD"] = row["MaHD"] = cboMaHD.Text;
                dtr["MaSP"] = row["MaSP"] = cboTenSP_HD.SelectedValue.ToString();
                row["TenSP"] = cboTenSP_HD.Text;
                dtr["SoLuong"] = row["SoLuong"] = txtSoLuongHD.Text;
                dtr["DonGia"] = row["DonGia"] = txtDonGiaHD.Text;
                dtr["GiamGia"] = row["GiamGia"] = txtGiamGia.Text;
                dtr["ThanhTien"] = row["ThanhTien"] = txtThanhTienHD.Text;
                
                dtCTHD.Rows.Add(dtr);
                dtgvCTHD.Rows.Add(row);
                ldrIns.Add(row);
                KhoiPhucBtnCTHD();
            } 
        }        
        #endregion

        #region btnDel
        //SanPham
        private void btnStartDelSP_Click(object sender, EventArgs e)
        {
            btnAddLoaiSP.Enabled = false;
            btnAddNSX.Enabled = false;
            btnStartAddSP.Enabled = false;
            btnStartEditSP.Enabled = false;
            btnStartDelSP.Visible = false;
            btnDelSP.Visible = true;
            btnCancelSP_Del.Visible = true;
        }
        private void btnDelSP_Click(object sender, EventArgs e)
        {
            DialogResult del;
            del = MessageBox.Show("Bạn muốn xóa mặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (del == DialogResult.Yes)
            {
                DataRow row = dtgvSP.Rows.Find(txtMaSP.Text);
                DataRow dtr = dtSanPham.Rows.Find(txtMaSP.Text);
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy mặt hàng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    row.Delete();
                    dtr.Delete();
                    if (ldrIns.Contains(row))
                        ldrIns.Remove(row);
                    else
                        ldrDel.Add(row);
                }
            }
            KhoiPhucBtnSP();
        }
        //NhanVien
        private void btnStartDelNV_Click(object sender, EventArgs e)
        {
            btnChucVu.Enabled = false;
            btnQLTK.Enabled = false;
            btnStartAddNV.Enabled = false;
            btnStartEditNV.Enabled = false;
            btnStartDelNV.Visible = false;
            btnDelNV.Visible = true;
            btnCancelNV_Del.Visible = true;
        }
        private void btnDelNV_Click(object sender, EventArgs e)
        {
            DialogResult del;
            del = MessageBox.Show("Bạn muốn xóa nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (del == DialogResult.Yes)
            {
                DataRow row = dtgvNV.Rows.Find(txtMaNV.Text);
                DataRow dtr = dtNhanVien.Rows.Find(txtMaNV.Text);
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy mặt hàng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    row.Delete();
                    dtr.Delete();
                    if (ldrIns.Contains(row))
                        ldrIns.Remove(row);
                    else
                        ldrDel.Add(row);
                }
            }
            KhoiPhucBtnNV();
        }
        //PhieuNhap
        private void btnStartDelPN_Click(object sender, EventArgs e)
        {
            btnStartDelPN.Visible = false;
            btnDelPN.Visible = true;
            btnResetPN.Visible = false;
            btnCancelPN_Del.Visible = true;
            btnQLTK.Enabled = false;
        }
        private void btnDelPN_Click(object sender, EventArgs e)
        {
            DialogResult del;
            del = MessageBox.Show("Bạn muốn xóa hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (del == DialogResult.Yes)
            {
                DataRow rowPN = dtPhieuNhap.Rows.Find(cboMaPN.Text);
                if (rowPN == null)
                {
                    MessageBox.Show("Không tìm thấy mặt hàng cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cboMaPN_Hide.Items.RemoveAt(cboMaPN_Hide.SelectedIndex);
                    cboMaPN.DataSource = dtPhieuNhap;
                    cboMaPN_Hide.SelectedIndex = 0;
                    //int kq = db.updateDatabase("select * from ChiTietPhieuNhap where MaPhieuNhap = '" + cboMaPN.Text + "'", dt);
                    DataRow r = rowPN;
                    if (ldrIns.Contains(r))
                        ldrIns.Remove(r);
                    else
                        ldrDel.Add(r);
                    //rowPN.Delete();
                }
            }
            KhoiPhucBtnPN();
        }
        private void btnDelCTPN_Click(object sender, EventArgs e)
        {
            DialogResult del;
            del = MessageBox.Show("Bạn muốn chi tiết phiếu nhập này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (del == DialogResult.Yes)
            {
                DataRow row = null;
                DataRow dtr = null;
                DataRow[] fRows = dtgvCTPN.Select("MaPhieuNhap = '" + cboMaPN.Text + "'");
                foreach(DataRow r in fRows)
                {
                    string value = r["TenSP"] as string;
                    if (value == cboTenSP.Text)
                    {
                        row = r;
                        break;
                    }
                }
                fRows = dtCTPN.Select("MaPhieuNhap = '" + cboMaPN.Text + "'");
                foreach (DataRow r in fRows)
                {
                    string value = r["MaSP"] as string;
                    if (value == cboTenSP.SelectedValue.ToString())
                    {
                        dtr = r;
                        break;
                    }
                }
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiêt cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    row.Delete();
                    dtr.Delete();
                    if (ldrIns.Contains(row))
                        ldrIns.Remove(row);
                    else
                        ldrDel.Add(row);
                }
            }
            KhoiPhucBtnCTPN();
        }
        private void btnStartDelCTPN_Click(object sender, EventArgs e)
        {
            btnStartDelCTPN.Visible = false;
            btnDelCTPN.Visible = true;
            btnResetCTPN.Visible = false;
            btnCancelCTPN_Del.Visible = true;
        }
        //HoaDon
        private void btnStartDelCTHD_Click(object sender, EventArgs e)
        {
            btnStartDelCTHD.Visible = false;
            btnDelCTHD.Visible = true;
            btnResetCTHD.Visible = false;
            btnCancelCTHD_Del.Visible = true;
        }
        private void btnDelCTHD_Click(object sender, EventArgs e)
        {
            DialogResult del;
            del = MessageBox.Show("Bạn muốn chi tiết hóa đơn này này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (del == DialogResult.Yes)
            {
                DataRow row = null;
                DataRow dtr = null;
                DataRow[] fRows = dtgvCTHD.Select("MaHD = '" + cboMaHD.Text + "'");
                foreach (DataRow r in fRows)
                {
                    string value = r["TenSP"] as string;
                    if (value == cboTenSP_HD.Text)
                    {
                        row = r;
                        break;
                    }
                }
                fRows = dtCTHD.Select("MaHD = '" + cboMaHD.Text + "'");
                foreach (DataRow r in fRows)
                {
                    string value = r["MaSP"] as string;
                    if (value == cboTenSP_HD.SelectedValue.ToString())
                    {
                        dtr = r;
                        break;
                    }
                }
                if (row == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    row.Delete();
                    dtr.Delete();
                    if (ldrIns.Contains(row))
                        ldrIns.Remove(row);
                    else
                        ldrDel.Add(row);
                }
            }
            KhoiPhucBtnCTHD();
        }
        #endregion

        #region btnEdit
        //SanPham
        private void btnStartEditSP_Click(object sender, EventArgs e)
        {
            txtTenSP.Focus();
            btnAddLoaiSP.Enabled = false;
            btnAddNSX.Enabled = false;
            btnStartAddSP.Enabled = false;
            btnStartDelSP.Enabled = false;
            btnStartEditSP.Visible = false;
            btnEditSP.Visible = true;
            btnCancelSP_Edit.Visible = true;
        }
        private void btnEditSP_Click(object sender, EventArgs e)
        {
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn sửa mặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                DataRow dtr = dtSanPham.Rows.Find(txtMaSP.Text);
                DataRow row = dtgvSP.Rows.Find(txtMaSP.Text);

                if (row == null)
                    MessageBox.Show("Không tìm thấy mặt hàng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    dtr["MaSP"] = row["MaSP"] = txtMaSP.Text;
                    dtr["MaLoaiSP"] = row["MaLoaiSP"] = cboLoaiSP.SelectedValue.ToString();
                    row["TenLoaiSP"] = cboLoaiSP.Text;
                    dtr["TenSP"] = row["TenSP"] = txtTenSP.Text;
                    dtr["MaNSX"] = row["MaNSX"] = cboNSX.SelectedValue.ToString();
                    row["TenNSX"] = cboNSX.Text;
                    dtr["XuatXu"] = row["XuatXu"] = txtXuatXu.Text;
                    dtr["GiaBan"] = row["GiaBan"] = txtGiaBan.Text;

                    int kq = db.updateDatabase(selectSP, dtSanPham);
                    if (kq > 0)
                        MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_DgvSanPham();
                }
            }
            KhoiPhucBtnSP();
        }
        //NhanVien
        private void btnStartEditNV_Click(object sender, EventArgs e)
        {
            txtTenNV.Focus();
            btnChucVu.Enabled = false;
            btnQLTK.Enabled = false;
            btnStartAddNV.Enabled = false;
            btnStartDelNV.Enabled = false;
            btnStartEditNV.Visible = false;
            btnEditNV.Visible = true;
            btnCancelNV_Edit.Visible = true;
        }
        private void btnEditNV_Click(object sender, EventArgs e)
        {
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn sửa thông tin nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                string sdt = (string)db.GetData("select SoDT from NhanVien where MaNV = '" + txtMaNV.Text + "'");
                string email = (string)db.GetData("select Email from NhanVien where MaNV = '" + txtMaNV.Text + "'");

                string selectSDT = "select count(MaNV) from NhanVien where SoDT = '" + txtSDT.Text + "'";
                string selectEmail = "select count(MaNV) from NhanVien where Email = '" + txtEmail.Text + "'";
                if (IsEmpty(txtMaNV.Text) || IsEmpty(txtTenNV.Text) || IsEmpty(txtSDT.Text) || IsEmpty(txtLuong.Text))
                    MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtSDT.Text.Length != 10)
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (TrungThongTin(selectSDT) && sdt != txtSDT.Text)
                    MessageBox.Show("Số điện thoại bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!ValiDateEmail(txtEmail.Text))
                    MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (TrungThongTin(selectEmail) && email != txtEmail.Text)
                    MessageBox.Show("Email bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    DataRow dtr = dtNhanVien.Rows.Find(txtMaNV.Text);
                    DataRow row = dtgvNV.Rows.Find(txtMaNV.Text);
                    if (row != null)
                    {
                        dtr["TenNV"] = row["TenNV"] = txtTenNV.Text;
                        dtr["MaChucVu"] = row["MaChucVu"] = cboChucVu.SelectedValue.ToString();
                        row["TenChucVu"] = cboChucVu.Text;
                        dtr["GioiTinh"] = row["GioiTinh"] = cboGender.Text;
                        dtr["NgaySinh"] = row["NgaySinh"] = dtp_NgaySinhNV.Value;
                        dtr["SoDT"] = row["SoDT"] = txtSDT.Text;
                        dtr["Email"] = row["Email"] = txtEmail.Text;
                        dtr["Luong"] = row["Luong"] = txtLuong.Text;
                    }
                    int kq = db.updateDatabase(selectNV, dtNhanVien);
                    if (kq > 0)
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Load_DgvNhanVien();
            }
            KhoiPhucBtnNV();
        }
        #endregion

        #region btnSave, btnReset, btnCancel
        //SanPham
        void KhoiPhucBtnSP()
        {
            if (frm_DangNhap.UserTxt.Equals("Admin"))
            {
                btnAddLoaiSP.Enabled = true;
                btnAddNSX.Enabled = true;
            }
            btnAddSP.Visible = false;
            btnDelSP.Visible = false;
            btnEditSP.Visible = false;

            btnStartAddSP.Enabled = true;
            btnStartDelSP.Enabled = true;
            btnStartEditSP.Enabled = true;

            btnCancelSP_Ins.Visible = false;
            btnCancelSP_Del.Visible = false;
            btnCancelSP_Edit.Visible = false;

            btnStartAddSP.Visible = true;
            btnStartDelSP.Visible = true;
            btnStartEditSP.Visible = true;
        }
        private void btnSaveSP_Click(object sender, EventArgs e)
        {
            if (ldrDel.Count == 0 && ldrIns.Count == 0)
            {
                MessageBox.Show("Không thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn lưu thông tin bảng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                int kq = db.updateDatabase(selectSP, dtSanPham);
                if (kq > 0)
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DgvSanPham();
                ldrDel.Clear();
                ldrIns.Clear();
            }
        }
        private void btnResetSP_Click(object sender, EventArgs e)
        {
            Load_DgvSanPham();
            dtSanPham = db.getDataTable(selectSP);
            DataColumn[] keySP = new DataColumn[1];
            keySP[0] = dtSanPham.Columns[0];
            dtSanPham.PrimaryKey = keySP;
            ldrDel.Clear();
            ldrIns.Clear();
        }
        private void btnCancelSP_Click(object sender, EventArgs e)
        {
            KhoiPhucBtnSP();
            Load_DgvSanPham();
        }
        //NhanVien
        void KhoiPhucBtnNV()
        {
            if (frm_DangNhap.UserTxt.Equals("Admin"))
            {
                btnQLTK.Enabled = true;
                btnChucVu.Enabled = true;
            }
            btnAddNV.Visible = false;
            btnDelNV.Visible = false;
            btnEditNV.Visible = false;

            btnCancelNV_Ins.Visible = false;
            btnCancelNV_Del.Visible = false;
            btnCancelNV_Edit.Visible = false;

            btnStartAddNV.Visible = btnStartAddNV.Enabled = true;
            btnStartDelNV.Visible = btnStartDelNV.Enabled = true;
            btnStartEditNV.Visible = btnStartEditNV.Enabled = true;
        }
        private void btnSaveNV_Click(object sender, EventArgs e)
        {
            if (ldrDel.Count == 0 && ldrIns.Count == 0)
            {
                MessageBox.Show("Không thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn lưu thông tin bảng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                int kq = db.updateDatabase(selectNV, dtNhanVien);
                if (kq > 0)
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DgvNhanVien();
                ldrDel.Clear();
                ldrIns.Clear();
            }
        }
        private void btnCancelNV_Click(object sender, EventArgs e)
        {
            KhoiPhucBtnNV();
            Load_DgvNhanVien();
        }
        private void btnResetNV_Click(object sender, EventArgs e)
        {
            Load_DgvNhanVien();
            dtNhanVien = db.getDataTable(selectNV);
            DataColumn[] key = new DataColumn[1];
            key[0] = dtNhanVien.Columns[0];
            dtNhanVien.PrimaryKey = key;
            ldrDel.Clear();
            ldrIns.Clear();
        }
        //PhieuNhap
        void KhoiPhucBtnPN()
        {
            if (frm_DangNhap.UserTxt.Equals("Admin"))
            {
                btnAddNCC.Enabled = true;
            }
            btnStartDelPN.Visible = true;
            btnDelPN.Visible = false;
            btnResetPN.Visible = true;
            btnSavePN.Visible = true;
            cboMaPN_Hide.Visible = true;
            txtMaPN.Visible = false;
            btnStartAddPN.Visible = true;
            btnAddPN.Visible = false;
            btnCancelPN_Ins.Visible = false;
            btnCancelPN_Del.Visible = false;
            cboTenNV.Enabled = true;
        }
        private void btnResetPN_Click(object sender, EventArgs e)
        {
            dtPhieuNhap = db.getDataTable(selectPN);
            Load_ComboMaPN();
            ldrDel.Clear();
            ldrIns.Clear();
        }
        private void btnCancelPN_Ins_Click(object sender, EventArgs e)
        {
            KhoiPhucBtnPN();
            Load_ComboMaPN();
        }
        private void btnSavePN_Click(object sender, EventArgs e)
        {
            if (ldrDel.Count == 0 && ldrIns.Count == 0)
            {
                MessageBox.Show("Không thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn lưu thông tin bảng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                foreach(var row in ldrDel)
                {
                    var value = row["MaPhieuNhap"] as string;
                    DataTable dt = db.getDataTable("select * from ChiTietPhieuNhap where MaPhieuNhap = '" + value + "'");
                    DataRow rowPN = dtPhieuNhap.Rows.Find(row["MaPhieuNhap"] as string);
                    foreach (DataRow r in dt.Rows)
                    {
                        r.Delete();
                    }
                    int kq0 = db.updateDatabase("select * from ChiTietPhieuNhap where MaPhieuNhap = '" + value + "'", dt);
                    rowPN.Delete();
                }
                                
                int kq = db.updateDatabase(selectPN, dtPhieuNhap);
                if (kq > 0)
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_ComboMaPN();
                ldrDel.Clear();
                ldrIns.Clear();
            }
        }
        void KhoiPhucBtnCTPN()
        {
            if (frm_DangNhap.UserTxt.Equals("Admin"))
            {
                btnAddNCC.Enabled = true;
            }
            btnStartDelCTPN.Visible = true;
            btnDelCTPN.Visible = false;
            btnResetCTPN.Visible = true;
            btnSaveCTPN.Visible = true;
            btnStartAddCTPN.Visible = true;
            btnAddCTPN.Visible = false;
            btnCancelCTPN_Ins.Visible = false;
            btnCancelCTPN_Del.Visible = false;
        }
        private void btnSaveCTPN_Click(object sender, EventArgs e)
        {
            if (ldrDel.Count == 0 && ldrIns.Count == 0)
            {
                MessageBox.Show("Không thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn lưu thông tin bảng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                int kq = db.updateDatabase(selectCTPN, dtCTPN);
                if (kq > 0)
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_ComboMaPN();
                Load_DgvCTPN();
                ldrDel.Clear();
                ldrIns.Clear();
            }
        }
        private void btnResetCTPN_Click(object sender, EventArgs e)
        {
            Load_DgvCTPN();
            ldrDel.Clear();
            ldrIns.Clear();
        }
        private void btnCancelCTPN_Ins_Click(object sender, EventArgs e)
        {
            KhoiPhucBtnCTPN();
            Load_DgvCTPN();
        }
        //HoaDon
        void KhoiPhucBtnHD()
        {
            btnResetHD.Visible = true;
            btnSaveHD.Visible = true;
            cboMaHD_Hide.Visible = true;
            txtMaHD.Visible = false;
            btnStartAddHD.Visible = true;
            btnAddHD.Visible = false;
            btnCancelHD_Ins.Visible = false;
            cboNhanVien_HD.Enabled = true;
        }
        private void btnCancelHD_Ins_Click(object sender, EventArgs e)
        {
            KhoiPhucBtnHD();
            Load_ComboMaHD();
        }
        private void btnResetHD_Click(object sender, EventArgs e)
        {
            dtHoaDon = db.getDataTable(selectHD);
            Load_ComboMaHD();
            ldrDel.Clear();
            ldrIns.Clear();
        }
        private void btnSaveHD_Click(object sender, EventArgs e)
        {
            if (ldrDel.Count == 0 && ldrIns.Count == 0)
            {
                MessageBox.Show("Không thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn lưu thông tin bảng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                int kq = db.updateDatabase(selectHD, dtHoaDon);
                if (kq > 0)
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_ComboMaHD();
                ldrDel.Clear();
                ldrIns.Clear();
            }
        }
        void KhoiPhucBtnCTHD()
        {
            btnStartDelCTHD.Visible = true;
            btnDelCTHD.Visible = false;
            btnResetCTHD.Visible = true;
            btnSaveCTHD.Visible = true;
            btnStartAddCTHD.Visible = true;
            btnAddCTHD.Visible = false;
            btnCancelCTHD_Ins.Visible = false;
            btnCancelCTHD_Del.Visible = false;
        }
        private void btnSaveCTHD_Click(object sender, EventArgs e)
        {
            if (ldrDel.Count == 0 && ldrIns.Count == 0)
            {
                MessageBox.Show("Không thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn lưu thông tin bảng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                int kq = db.updateDatabase(selectCTHD, dtCTHD);
                if (kq > 0)
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_ComboMaHD();
                Load_DgvCTHD();
                ldrDel.Clear();
                ldrIns.Clear();
            }
        }
        private void btnResetCTHD_Click(object sender, EventArgs e)
        {
            Load_DgvCTHD();
            ldrDel.Clear();
            ldrIns.Clear();
        }
        private void btnCancelCTHD_Ins_Click(object sender, EventArgs e)
        {
            KhoiPhucBtnCTHD();
            Load_DgvCTHD();
        }
        #endregion

        #region btnSearch and btnOpenForm
        //SanPham
        private void btnAddLoaiSP_Click(object sender, EventArgs e)
        {
            frm_LoaiSP frmLSP = new frm_LoaiSP(this);
            frmLSP.ShowDialog();
        }
        private void btnAddNSX_Click(object sender, EventArgs e)
        {
            frm_NSX frmNSX = new frm_NSX(this);
            frmNSX.ShowDialog();
        }
        private void btnSearchSP_Click(object sender, EventArgs e)
        {
            Load_DgvSanPham();
            string search = txtSearchSP.Text;
            string col = "";
            for (int i = 0; i < dtgvSP.Columns.Count; i++)
            {
                if (cboSearchSP.Text.Equals(dgvSanPham.Columns[i].HeaderText.ToString()))
                {
                    col = dgvSanPham.Columns[i].DataPropertyName.ToString();
                    break;
                }
            }

            try
            {
                string str = "select * from SanPham, LoaiSP, NhaSX where " + col + " like N'%" + search + "%' and SanPham.MaLoaiSP = LoaiSP.MaLoaiSP and SanPham.MaNSX = NhaSX.MaNSX";
                dtgvSP = db.getDataTable(str);
                dgvSanPham.AutoGenerateColumns = false;
                dgvSanPham.DataSource = dtgvSP;
                DataBindSP(dtgvSP);
            }
            catch
            {
                MessageBox.Show("Không tìm thấy", "Thông báo");
            }
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            frm_KhachHang frmKH = new frm_KhachHang();
            frmKH.ShowDialog();
        }
        //NhanVien
        private void btnQLTK_Click(object sender, EventArgs e)
        {
            frm_TaiKhoan frmTK = new frm_TaiKhoan(this);
            frmTK.ShowDialog();
        }
        //HoaDon
        private void txtSearchMaHD_Enter(object sender, EventArgs e)
        {
            txtSearchMaHD.ForeColor = Color.Black;
            txtSearchMaHD.Text = "";
        }
        private void txtSearchMaHD_Leave(object sender, EventArgs e)
        {
            if(txtSearchMaHD.Text == "")
            {
                txtSearchMaHD.Text = "Nhập mã hóa đơn";
                txtSearchMaHD.ForeColor = Color.DarkGray;
            }
        }
        private void btnSearchHD_Click(object sender, EventArgs e)
        {
            int count = (int)db.GetData("Select count(*) from HoaDon where MaHD = '" + txtSearchMaHD.Text + "'");
            if(count == 0)
            {
                MessageBox.Show("Không có hóa đơn này", "Thông báo");
                txtSearchMaHD.Text = "Nhập mã hóa đơn";
                txtSearchMaHD.ForeColor = Color.DarkGray;
            }
            else
            {
                for(int i = 0; i<cboMaHD_Hide.Items.Count; i++)
                {
                    if(cboMaHD_Hide.GetItemText(cboMaHD_Hide.Items[i]) == txtSearchMaHD.Text)
                    {
                        cboMaHD_Hide.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
