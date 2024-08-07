//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Net.Mail;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace QuanLyPhuKienDienThoai1
//{
//    public partial class frm_Main : Form
//    {
//        //Khai báo biến toàn cục
//        #region variable
//        DBConnect db = new DBConnect();
//        DataTable dtgvSP = new DataTable();
//        DataTable dtSanPham = new DataTable();
//        DataTable dtgvNV = new DataTable();
//        DataTable dtNhanVien = new DataTable();
//        DataTable dtTaiKhoan = new DataTable();
//        List<DataRow> ldrIns = new List<DataRow>();
//        List<DataRow> ldrDel = new List<DataRow>();
//        //DataTable dt_kho = new DataTable();
//        string selectSP = "select * from SanPham";
//        string selectNV = "Select * from NhanVien";
//        string selectTK = "Select * from TaiKhoan";
//        string sqlSP = "select * from SanPham, LoaiSP, NhaSX where SanPham.MaLoaiSP = LoaiSP.MaLoaiSP and NhaSX.MaNSX = SanPham.MaNSX";
//        string sqlNV = "";
//        int count = 1;
//        #endregion
//        public frm_Main()
//        {
//            InitializeComponent();
//            dtSanPham = db.getDataTable(selectSP);
//            DataColumn[] keySP = new DataColumn[1];
//            keySP[0] = dtSanPham.Columns[0];
//            dtSanPham.PrimaryKey = keySP;
//            if (frm_DangNhap.UserTxt.Equals("Admin"))
//            {
//                dtNhanVien = db.getDataTable(selectNV);
//                dtTaiKhoan = db.getDataTable(selectTK);
//                DataColumn[] keyNV = new DataColumn[1];
//                DataColumn[] keyTK = new DataColumn[1];
//                keyNV[0] = dtNhanVien.Columns[0];
//                keyTK[0] = dtTaiKhoan.Columns[0];
//                dtNhanVien.PrimaryKey = keyNV;
//                dtTaiKhoan.PrimaryKey = keyTK;
//            }
//        }
//        //Kiểm tra trùng và thiết kế main
//        #region Kiem_tra_trung_and_main_desgin
//        bool ValiDateEmail(string email)
//        {
//            try
//            {
//                MailAddress check = new MailAddress(email);
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//        bool IsEmpty(string str)
//        {
//            return str.Length <= 0;
//        }
//        public bool TrungThongTin(string selectStr)
//        {
//            int kq = (int)db.GetData(selectStr);
//            if (kq == 1)
//                return true;
//            return false;
//        }
//        bool TrungMaSP(string ma)
//        {
//            foreach (DataRow row in ldrIns)
//                if (row["MaSP"].ToString().Equals(ma))
//                    return true;
//            return false;
//        }
//        bool TrungMaNV(string ma)
//        {
//            foreach (DataRow row in ldrIns)
//                if (row["MaNV"].ToString().Equals(ma))
//                    return true;
//            return false;
//        }
//        private void tabMain_DrawItem(object sender, DrawItemEventArgs e)
//        {
//            Graphics g = e.Graphics;
//            Brush _textBrush;

//            // Get the item from the collection.
//            TabPage _tabPage = tabMain.TabPages[e.Index];

//            // Get the real bounds for the tab rectangle.
//            Rectangle _tabBounds = tabMain.GetTabRect(e.Index);

//            if (e.State == DrawItemState.Selected)
//            {

//                // Draw a different background color, and don't paint a focus rectangle.
//                _textBrush = new SolidBrush(Color.Blue);
//                g.FillRectangle(Brushes.Cyan, e.Bounds);
//            }
//            else
//            {
//                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
//                e.DrawBackground();
//            }

//            // Use our own font.
//            Font _tabFont = new Font("Arial", 12.0f, FontStyle.Bold, GraphicsUnit.Pixel);

//            // Draw string. Center the text.
//            StringFormat _stringFlags = new StringFormat();
//            _stringFlags.Alignment = StringAlignment.Center;
//            _stringFlags.LineAlignment = StringAlignment.Center;
//            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
//        }
//        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            ldrDel.Clear();
//            ldrIns.Clear();
//        }
//        #endregion

//        //Trang chủ và form main load
//        #region Trang_chu_and_form_main_load
//        private void frm_Main_Load(object sender, EventArgs e)
//        {
//            Load_ComboLoaiSP();
//            Load_ComboLoaiSP_HD();
//            Load_ComboNSX();
//            Load_ComboNSX_HD();
//            load_ComboKho();
//            Load_ComboTenSP();
//            Load_ComboKH();
//            Load_DgvSanPhamHD();
//            //Load_ComboSearch();
//            Load_DgvSanPham();
//            lblDate.Text = DateTime.Now.ToString("dddd, dd/MM/yyyy");
//            dtpNgayLap_HD.Format = DateTimePickerFormat.Custom;
//            dtpNgayLap_HD.CustomFormat = "dd/MM/yyyy";
//            if (frm_DangNhap.UserTxt.Equals("Admin"))
//            {
//                lblUser.Text = "Xin chào, Admin";
//                lblChucVu.Text = "Chức vụ: Admin";
//                Load_ComboChucVu();
//                Load_DgvNhanVien();
//                Load_dgvCTKho();
//                //Load_ComboLoaiSP2();
//                //Load_DgvKho();
//            }
//            else
//            {
//                if (frm_DangNhap.MaChucVuTxt.Equals("QLK"))
//                {
//                    tabMain.TabPages.Remove(tabProduct);
//                    //Load_ComboLoaiSP2();
//                    //Load_DgvKho();
//                    Load_dgvCTKho();
//                }
//                else
//                    tabMain.TabPages.Remove(tabKho);
//                lblUser.Text = "Xin chào, " + frm_DangNhap.NameTxt;
//                lblChucVu.Text = "Chức vụ: " + db.GetData("select TenChucVu from ChucVu where MaChucVu = '" + frm_DangNhap.MaChucVuTxt + "'").ToString();
//                tabMain.TabPages.Remove(tabNhanVien);
//                btnAddLoaiSP.Visible = false;
//                btnAddNSX.Visible = false;
//            }
//        }
//        private void btnLogout_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//        #endregion

//        //Page sản phẩm
//        #region SanPham
//        //Key press sp
//        private void txtMaSP_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (char.IsUpper(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back)
//                e.Handled = false;
//            else
//                e.Handled = true;
//        }
//        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
//                e.Handled = true;
//        }
//        //load combo page san pham
//        public void Load_ComboLoaiSP()
//        {
//            string selectStr = "select * from LoaiSP";
//            DataTable dtLoaiSP = db.getDataTable(selectStr);
//            cboLoaiSP.DataSource = dtLoaiSP;
//            cboLoaiSP.DisplayMember = "TenLoaiSP";
//            cboLoaiSP.ValueMember = "MaLoaiSP";
//        }
//        public void Load_ComboNSX()
//        {
//            string selectStr = "select * from NhaSX";
//            DataTable dtNSX = db.getDataTable(selectStr);
//            cboNSX.DataSource = dtNSX;
//            cboNSX.DisplayMember = "TenNSX";
//            cboNSX.ValueMember = "MaNSX";
//        }
//        //load dgv san pham
//        public void Load_DgvSanPham()
//        {
//            dtgvSP = new DataTable();
//            dtgvSP = db.getDataTable(sqlSP);
//            DataColumn[] keySP = new DataColumn[1];
//            keySP[0] = dtgvSP.Columns[0];
//            dtgvSP.PrimaryKey = keySP;
//            dgvSanPham.AutoGenerateColumns = false;
//            dgvSanPham.DataSource = dtgvSP;
//            DataBindSP(dtgvSP);
//        }
//        //Databinding san pham
//        void DataBindSP(DataTable dt)
//        {
//            txtMaSP.DataBindings.Clear();
//            cboLoaiSP.DataBindings.Clear();
//            txtTenSP.DataBindings.Clear();
//            cboNSX.DataBindings.Clear();
//            txtXuatXu.DataBindings.Clear();
//            txtGiaBan.DataBindings.Clear();

//            txtMaSP.DataBindings.Add("Text", dt, "MaSP");
//            cboLoaiSP.DataBindings.Add("SelectedValue", dt, "MaLoaiSP");
//            txtTenSP.DataBindings.Add("Text", dt, "TenSP");
//            cboNSX.DataBindings.Add("SelectedValue", dt, "MaNSX");
//            txtXuatXu.DataBindings.Add("Text", dt, "XuatXu");
//            txtGiaBan.DataBindings.Add("Text", dt, "GiaBan");
//        }
//        //button san pham
//        #region button
//        void taoMaSP()
//        {
//            txtMaSP.Text = "sp";
//            string sqlCount = "select count(*) from SanPham";
//            int count = (int)db.GetData(sqlCount);
//            while (true)
//            {
//                count++;
//                if (count < 10)
//                    txtMaSP.Text += "00" + count.ToString();
//                else if (count < 100)
//                    txtMaSP.Text += "0" + count.ToString();
//                else
//                    txtMaSP.Text += count.ToString();
//                if (TrungThongTin("Select count(*) from SanPham where MaSP = '" + txtMaSP.Text + "'") && TrungMaSP(txtMaSP.Text) == false)
//                    break;
//                else
//                    txtMaSP.Text = "sp";
//            }
//        }
//        private void btnStartAddSP_Click(object sender, EventArgs e)
//        {
//            taoMaSP();
//            txtTenSP.Text = txtXuatXu.Text = txtGiaBan.Text = "";
//            txtTenSP.Focus();
//            btnAddLoaiSP.Enabled = false;
//            btnAddNSX.Enabled = false;
//            btnStartDelSP.Enabled = false;
//            btnStartEditSP.Enabled = false;
//            btnStartAddSP.Visible = false;
//            btnAddSP.Visible = true;
//            btnCancelSP_Ins.Visible = true;
//        }
//        private void btnAddSP_Click(object sender, EventArgs e)
//        {

//            string selectMaSP = "select count(*) from SanPham where MaSP = '" + txtMaSP.Text + "'";
//            if (IsEmpty(txtMaSP.Text) || IsEmpty(txtTenSP.Text) || IsEmpty(txtXuatXu.Text) || IsEmpty(txtGiaBan.Text))
//                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            else if (TrungThongTin(selectMaSP) || TrungMaSP(txtMaSP.Text))
//                MessageBox.Show("Mã SP bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            else
//            {
//                //DataRow row = dtSanPham.NewRow();
//                DataRow row = dtgvSP.NewRow();
//                DataRow dtr = dtSanPham.NewRow();
//                dtr["MaSP"] = row["MaSP"] = txtMaSP.Text;
//                dtr["MaLoaiSP"] = row["MaLoaiSP"] = cboLoaiSP.SelectedValue.ToString();
//                row["TenLoaiSP"] = cboLoaiSP.Text;
//                dtr["TenSP"] = row["TenSP"] = txtTenSP.Text;
//                dtr["MaNSX"] = row["MaNSX"] = cboNSX.SelectedValue.ToString();
//                row["TenNSX"] = cboNSX.Text;
//                dtr["XuatXu"] = row["XuatXu"] = txtXuatXu.Text;
//                dtr["GiaBan"] = row["GiaBan"] = txtGiaBan.Text;
//                ldrIns.Add(row);
//                dtgvSP.Rows.Add(row);
//                dtSanPham.Rows.Add(dtr);

//                KhoiPhucBtnSP();
//            }
//        }
//        private void btnStartDelSP_Click(object sender, EventArgs e)
//        {
//            btnAddLoaiSP.Enabled = false;
//            btnAddNSX.Enabled = false;
//            btnStartAddSP.Enabled = false;
//            btnStartEditSP.Enabled = false;
//            btnStartDelSP.Visible = false;
//            btnDelSP.Visible = true;
//            btnCancelSP_Del.Visible = true;
//        }
//        private void btnDelSP_Click(object sender, EventArgs e)
//        {
//            DialogResult del;
//            del = MessageBox.Show("Bạn muốn xóa mặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
//            if (del == DialogResult.Yes)
//            {
//                DataRow row = dtgvSP.Rows.Find(txtMaSP.Text);
//                DataRow dtr = dtSanPham.Rows.Find(txtMaSP.Text);
//                if (row == null)
//                {
//                    MessageBox.Show("Không tìm thấy mặt hàng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                else
//                {
//                    row.Delete();
//                    dtr.Delete();
//                    if (ldrIns.Contains(row))
//                        ldrIns.Remove(row);
//                    else
//                        ldrDel.Add(row);
//                }
//            }
//            KhoiPhucBtnSP();
//        }
//        private void btnStartEditSP_Click(object sender, EventArgs e)
//        {
//            txtTenSP.Focus();
//            btnAddLoaiSP.Enabled = false;
//            btnAddNSX.Enabled = false;
//            btnStartAddSP.Enabled = false;
//            btnStartDelSP.Enabled = false;
//            btnStartEditSP.Visible = false;
//            btnEditSP.Visible = true;
//            btnCancelSP_Edit.Visible = true;
//        }
//        private void btnEditSP_Click(object sender, EventArgs e)
//        {
//            DialogResult edit;
//            edit = MessageBox.Show("Bạn muốn sửa mặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
//            if (edit == DialogResult.Yes)
//            {
//                DataRow dtr = dtSanPham.Rows.Find(txtMaSP.Text);
//                DataRow row = dtgvSP.Rows.Find(txtMaSP.Text);

//                if (row == null)
//                    MessageBox.Show("Không tìm thấy mặt hàng cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                else
//                {
//                    dtr["MaSP"] = row["MaSP"] = txtMaSP.Text;
//                    dtr["MaLoaiSP"] = row["MaLoaiSP"] = cboLoaiSP.SelectedValue.ToString();
//                    row["TenLoaiSP"] = cboLoaiSP.Text;
//                    dtr["TenSP"] = row["TenSP"] = txtTenSP.Text;
//                    dtr["MaNSX"] = row["MaNSX"] = cboNSX.SelectedValue.ToString();
//                    row["TenNSX"] = cboNSX.Text;
//                    dtr["XuatXu"] = row["XuatXu"] = txtXuatXu.Text;
//                    dtr["GiaBan"] = row["GiaBan"] = txtGiaBan.Text;

//                    int kq = db.updateDatabase(selectSP, dtSanPham);
//                    if (kq > 0)
//                        MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    else
//                        MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    Load_DgvSanPham();
//                }
//            }
//            KhoiPhucBtnSP();
//        }
//        private void btnSaveSP_Click(object sender, EventArgs e)
//        {
//            if (ldrDel.Count == 0 && ldrIns.Count == 0)
//            {
//                MessageBox.Show("Không thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }
//            DialogResult edit;
//            edit = MessageBox.Show("Bạn muốn lưu thông tin bảng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
//            if (edit == DialogResult.Yes)
//            {
//                int kq = db.updateDatabase(selectSP, dtSanPham);
//                if (kq > 0)
//                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                else
//                    MessageBox.Show("Lưu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                Load_DgvSanPham();
//                ldrDel.Clear();
//                ldrIns.Clear();
//            }
//        }
//        private void btnResetSP_Click(object sender, EventArgs e)
//        {
//            Load_DgvSanPham();
//            dtSanPham = db.getDataTable(selectSP);
//            DataColumn[] keySP = new DataColumn[1];
//            keySP[0] = dtSanPham.Columns[0];
//            dtSanPham.PrimaryKey = keySP;
//            txtSearchSP.Clear();
//            cboSearchSP.SelectedValue = cboSearchSP.Items[0];
//        }
//        void KhoiPhucBtnSP()
//        {
//            if (frm_DangNhap.UserTxt.Equals("Admin"))
//            {
//                btnAddLoaiSP.Enabled = true;
//                btnAddNSX.Enabled = true;
//            }
//            btnAddSP.Visible = false;
//            btnDelSP.Visible = false;
//            btnEditSP.Visible = false;

//            btnStartAddSP.Enabled = true;
//            btnStartDelSP.Enabled = true;
//            btnStartEditSP.Enabled = true;

//            btnCancelSP_Ins.Visible = false;
//            btnCancelSP_Del.Visible = false;
//            btnCancelSP_Edit.Visible = false;

//            btnStartAddSP.Visible = true;
//            btnStartDelSP.Visible = true;
//            btnStartEditSP.Visible = true;
//        }
//        private void btnCancelSP_Click(object sender, EventArgs e)
//        {
//            KhoiPhucBtnSP();
//            Load_DgvSanPham();
//        }
//        private void btnAddLoaiSP_Click(object sender, EventArgs e)
//        {
//            frm_LoaiSP frmLSP = new frm_LoaiSP(this);
//            frmLSP.ShowDialog();
//        }
//        private void btnAddNSX_Click(object sender, EventArgs e)
//        {
//            frm_NSX frmNSX = new frm_NSX(this);
//            frmNSX.ShowDialog();
//        }
//        private void btnSearchSP_Click(object sender, EventArgs e)
//        {
//            Load_DgvSanPham();
//            string col = "";
//            for (int i = 0; i < dtSanPham.Columns.Count; i++)
//            {
//                if (cboSearchSP.Text.Equals(dgvSanPham.Columns[i].HeaderText.ToString()))
//                    col = dgvSanPham.Columns[i].DataPropertyName.ToString();
//            }

//            try
//            {
//                string str = "select * from SanPham, LoaiSP, NhaSX where " + col + " like '%" + txtSearchSP.Text + "%' and SanPham.MaLoaiSP = LoaiSP.MaLoaiSP and SanPham.MaNSX = NhaSX.MaNSX";
//                DataTable dtKho = db.getDataTable(str);
//                dgvSanPham.AutoGenerateColumns = false;
//                dgvSanPham.DataSource = dtKho;
//                DataBindSP(dtKho);
//            }
//            catch
//            {
//                MessageBox.Show("Không tìm thấy", "Thông báo");
//            }
//        }
//        #endregion
//        #endregion

//        //Page Quản lý nhân viên
//        #region NhanVien
//        //key press nhan vien
//        private void txtTenNV_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (char.IsNumber(e.KeyChar))
//                e.Handled = true;
//        }
//        //Load combo NhanVien
//        public void Load_ComboChucVu()
//        {
//            string selectStr = "select * from ChucVu";
//            DataTable dtChucVu = db.getDataTable(selectStr);
//            cboChucVu.DataSource = dtChucVu;
//            cboChucVu.DisplayMember = "TenChucVu";
//            cboChucVu.ValueMember = "MaChucVu";
//        }
//        public void Load_DgvNhanVien()
//        {
//            DataTable dtNV = db.getDataTable("select * from NhanVien, ChucVu where NhanVien.MaChucVu = ChucVu.MaChucVu");
//            dgvNhanVien.AutoGenerateColumns = false;
//            dgvNhanVien.DataSource = dtNV;
//            DataBindNV(dtNV);
//        }
//        void DataBindNV(DataTable dt)
//        {
//            txtMaNV.DataBindings.Clear();
//            txtTenNV.DataBindings.Clear();
//            cboChucVu.DataBindings.Clear();
//            cboGender.DataBindings.Clear();
//            dtp_NgaySinhNV.DataBindings.Clear();
//            txtSDT.DataBindings.Clear();
//            txtEmail.DataBindings.Clear();
//            txtLuong.DataBindings.Clear();
//            txtMaNV.DataBindings.Add("Text", dt, "MaNV");
//            txtTenNV.DataBindings.Add("Text", dt, "TenNV");
//            cboChucVu.DataBindings.Add("SelectedValue", dt, "MaChucVu");
//            cboGender.DataBindings.Add("SelectedItem", dt, "GioiTinh");
//            dtp_NgaySinhNV.DataBindings.Add("Text", dt, "NgaySinh");
//            txtSDT.DataBindings.Add("Text", dt, "SoDT");
//            txtEmail.DataBindings.Add("Text", dt, "Email");
//            txtLuong.DataBindings.Add("Text", dt, "Luong");
//        }

//        #region button
//        void taoMaNV()
//        {
//            txtMaSP.Text = "NV";
//            string sqlCount = "select count(*) from NhanVien";
//            int count = (int)db.GetData(sqlCount);
//            while (true)
//            {
//                count++;
//                if (count < 10)
//                    txtMaSP.Text += "000" + count.ToString();
//                else if (count < 100)
//                    txtMaSP.Text += "0" + count.ToString();
//                else
//                    txtMaSP.Text += count.ToString();
//                if ((int)db.GetData(sqlCount + " where MaNV = '" + txtMaNV.Text + "'") == 0 && TrungMaNV(txtMaNV.Text) == false)
//                    break;
//                else
//                    txtMaSP.Text = "NV";
//            }
//        }
//        void KhoiPhucButtonNV()
//        {
//            if (frm_DangNhap.UserTxt.Equals("Admin"))
//            {
//                btnQLTK.Enabled = true;
//                btnChucVu.Enabled = true;
//            }
//            btnAddNV.Visible = false;
//            btnDelNV.Visible = false;
//            btnEditNV.Visible = false;

//            btnCancelNV_Ins.Visible = false;
//            btnCancelNV_Del.Visible = false;
//            btnCancelNV_Edit.Visible = false;

//            btnStartAddNV.Visible = btnStartAddNV.Enabled = true;
//            btnStartDelNV.Visible = btnStartDelNV.Enabled = true;
//            btnStartEditNV.Visible = btnStartEditNV.Enabled = true;
//        }
//        private void btnStartAddNV_Click(object sender, EventArgs e)
//        {
//            taoMaNV();
//            txtTenNV.Focus();
//            txtTenNV.Text = txtSDT.Text = txtEmail.Text = txtLuong.Text = "";
//            btnChucVu.Enabled = false;
//            btnQLTK.Enabled = false;
//            btnStartDelNV.Enabled = false;
//            btnStartEditNV.Enabled = false;
//            btnStartAddNV.Visible = false;
//            btnAddNV.Visible = true;
//            btnCancelNV_Ins.Visible = true;
//        }
//        private void btnAddNV_Click(object sender, EventArgs e)
//        {
//            string selectMaNV = "select count(*) from NhanVien where MaNV = '" + txtMaNV.Text + "'";
//            string selectSDT = "select count(*) from NhanVien where SoDT = '" + txtSDT.Text + "'";
//            string selectEmail = "select count(*) from NhanVien where Email = '" + txtEmail.Text + "'";
//            if (IsEmpty(txtMaNV.Text) || IsEmpty(txtTenNV.Text) || IsEmpty(txtSDT.Text) || IsEmpty(txtLuong.Text))
//                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            else if (TrungThongTin(selectMaNV))
//                MessageBox.Show("Mã NV bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            else if (TrungThongTin(selectSDT))
//                MessageBox.Show("Số điện thoại bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            else if (!ValiDateEmail(txtEmail.Text))
//                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            else if (TrungThongTin(selectEmail))
//                MessageBox.Show("Email bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            else
//            {
//                DataRow rowNV = dtNhanVien.NewRow();
//                rowNV["MaNV"] = txtMaNV.Text;
//                rowNV["TenNV"] = txtTenNV.Text;
//                rowNV["MaChucVu"] = cboChucVu.SelectedValue.ToString();
//                rowNV["GioiTinh"] = cboGender.SelectedItem.ToString();
//                rowNV["NgaySinh"] = dtp_NgaySinhNV.Text;
//                rowNV["SoDT"] = txtSDT.Text;
//                rowNV["Email"] = txtEmail.Text;
//                rowNV["Luong"] = txtLuong.Text;
//                dtNhanVien.Rows.Add(rowNV);
//                int kqNV = db.updateDatabase(selectNV, dtNhanVien);
//                if (kqNV > 0)
//                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                else
//                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                Load_DgvNhanVien();
//            }
//        }
//        private void btnDelNV_Click(object sender, EventArgs e)
//        {
//            DialogResult del;
//            del = MessageBox.Show("Bạn muốn xóa nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
//            if (del == DialogResult.Yes)
//            {
//                DataRow rowNV = dtNhanVien.Rows.Find(txtMaNV.Text);
//                if (rowNV != null)
//                    rowNV.Delete();
//                int kqNV = db.updateDatabase(selectNV, dtNhanVien);
//                if (kqNV > 0)
//                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                else
//                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                Load_DgvNhanVien();
//            }
//        }
//        private void btnEditNV_Click(object sender, EventArgs e)
//        {
//            DialogResult edit;
//            edit = MessageBox.Show("Bạn muốn sửa thông tin nhân viên này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
//            if (edit == DialogResult.Yes)
//            {
//                string selectMaNV = "select count(*) from NhanVien where MaNV = '" + txtMaNV.Text + "'";
//                string selectSDT = "select count(*) from NhanVien where SoDT = '" + txtSDT.Text + "'";
//                string selectEmail = "select count(*) from NhanVien where Email = '" + txtEmail.Text + "'";
//                if (IsEmpty(txtMaNV.Text) || IsEmpty(txtTenNV.Text) || IsEmpty(txtSDT.Text) || IsEmpty(txtLuong.Text))
//                    MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                else if (TrungThongTin(selectMaNV))
//                    MessageBox.Show("Mã NV bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                else if (txtSDT.Text.Length != 10)
//                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                else if (TrungThongTin(selectSDT))
//                    MessageBox.Show("Số điện thoại bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                else if (!ValiDateEmail(txtEmail.Text))
//                    MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                else if (TrungThongTin(selectEmail))
//                    MessageBox.Show("Email bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                else
//                {
//                    DataRow rowNV = dtNhanVien.Rows.Find(txtMaNV.Text);
//                    if (rowNV != null)
//                    {
//                        rowNV["TenNV"] = txtTenNV.Text;
//                        rowNV["MaChucVu"] = cboChucVu.SelectedValue.ToString();
//                        rowNV["GioiTinh"] = cboGender.SelectedItem.ToString();
//                        rowNV["NgaySinh"] = dtp_NgaySinhNV.Text;
//                        rowNV["SoDienThoai"] = txtSDT.Text;
//                        rowNV["Email"] = txtEmail.Text;
//                        rowNV["Luong"] = txtLuong.Text;
//                    }
//                    int kq = db.updateDatabase(selectNV, dtNhanVien);
//                    if (kq > 0)
//                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    else
//                        MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                Load_DgvNhanVien();
//            }
//        }
//        private void btnCancelNV_Click(object sender, EventArgs e)
//        {
//            KhoiPhucButtonNV();
//            Load_DgvNhanVien();
//        }
//        private void btnQLTK_Click(object sender, EventArgs e)
//        {
//            frm_TaiKhoan frmTK = new frm_TaiKhoan(this);
//            frmTK.ShowDialog();
//        }
//        private void btnChucVu_Click(object sender, EventArgs e)
//        {

//        }
//        #endregion
//        #endregion

//        //Page Kho
//        #region Kho
//        void load_ComboKho()
//        {
//            string selectStr = "select * from Kho";
//            DataTable dtKho = db.getDataTable(selectStr);
//            cboKho.DataSource = dtKho;
//            cboKho.DisplayMember = "TenKho";
//            cboKho.ValueMember = "MaKho";
//        }
//        public void Load_ComboTenSP()
//        {
//            string selectStr = "select * from SanPham";
//            DataTable dtTenSP = db.getDataTable(selectStr);
//            cboTenSP.DataSource = dtTenSP;
//            cboTenSP.DisplayMember = "TenSP";
//            cboTenSP.ValueMember = "MaSP";
//        }
//        private void cboKho_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            Load_dgvCTKho();
//        }
//        public void Load_dgvCTKho()
//        {
//            try
//            {
//                string cmd = "select * from ChiTietKho, Kho, SanPham where Kho.MaKho = ChiTietKho.MaKho and SanPham.MaSP = ChiTietKho.MaSP and ChiTietKho.MaKho = '" + cboKho.SelectedValue.ToString() + "'";
//                DataTable dtKho = db.getDataTable(cmd);
//                dgv_ctKho.AutoGenerateColumns = false;
//                dgv_ctKho.DataSource = dtKho;
//                DataBindingCTKho(dtKho);
//            }
//            catch
//            {
//                return;
//            }

//        }
//        void DataBindingCTKho(DataTable dt)
//        {
//            cboKho.DataBindings.Clear();
//            cboTenSP.DataBindings.Clear();
//            txtSoLuong.DataBindings.Clear();
//            txtGia.DataBindings.Clear();
//            txtXX.DataBindings.Clear();

//            cboKho.DataBindings.Add("SelectedValue", dt, "MaKho");
//            cboTenSP.DataBindings.Add("SelectedValue", dt, "MaSP");
//            txtSoLuong.DataBindings.Add("text", dt, "SoLuongSP");
//            txtGia.DataBindings.Add("text", dt, "GiaBan");
//            txtXX.DataBindings.Add("text", dt, "XuatXu");
//        }
//        #endregion

//        //Page Hóa đơn
//        #region HoaDon
//        public void Load_ComboLoaiSP_HD()
//        {
//            string selectStr = "select * from LoaiSP";
//            DataTable dtLoaiSP = db.getDataTable(selectStr);
//            cboLoaiSP_HD.DataSource = dtLoaiSP;
//            cboLoaiSP_HD.DisplayMember = "TenLoaiSP";
//            cboLoaiSP_HD.ValueMember = "MaLoaiSP";
//        }
//        public void Load_ComboNSX_HD()
//        {
//            string selectStr = "select * from NhaSX";
//            DataTable dtNSX = db.getDataTable(selectStr);
//            cboNSX_HD.DataSource = dtNSX;
//            cboNSX_HD.DisplayMember = "TenNSX";
//            cboNSX_HD.ValueMember = "MaNSX";
//        }
//        public void Load_ComboKH()
//        {
//            string selectStr = "select MaKH, (MaKH + ' ' + TenKH) as kh from KhachHang";
//            DataTable dt = db.getDataTable(selectStr);
//            cboKhachHang.DataSource = dt;
//            cboKhachHang.DisplayMember = "kh";
//            cboKhachHang.ValueMember = "MaKH";
//        }
//        public void Load_DgvSanPhamHD()
//        {
//            DataTable dt = db.getDataTable("select * from HoaDon hd, ChiTietHoaDon cthd, SanPham sp, NhaSX nsx, LoaiSP l where hd.MaHD = cthd.MaHD and cthd.MaSP = sp.MaSP and sp.MaNSX = nsx.MaNSX and sp.MaLoaiSP = l.MaLoaiSP");
//            DataTable dt1 = db.getDataTable("Select * from HoaDon");
//            dgvSPHD.AutoGenerateColumns = false;
//            dgvHD.AutoGenerateColumns = false;
//            dgvCTHD.AutoGenerateColumns = false;

//            dgvSPHD.DataSource = dt;
//            dgvHD.DataSource = dt1;
//            dgvCTHD.DataSource = dt;
//            DataBindSPHD(dt);
//        }
//        void DataBindSPHD(DataTable dt)
//        {
//            txtMaSP_HD.DataBindings.Clear();
//            cboLoaiSP_HD.DataBindings.Clear();
//            txtTenSP_HD.DataBindings.Clear();
//            cboNSX_HD.DataBindings.Clear();
//            txtXuatXu_HD.DataBindings.Clear();
//            txtGiaBan_HD.DataBindings.Clear();
//            txtMaHD.DataBindings.Clear();
//            dtpNgayLap_HD.DataBindings.Clear();
//            txtSoLuong_HD.DataBindings.Clear();
//            txtGiamGia_HD.DataBindings.Clear();

//            txtMaSP_HD.DataBindings.Add("Text", dt, "MaSP");
//            cboLoaiSP_HD.DataBindings.Add("SelectedValue", dt, "MaLoaiSP");
//            txtTenSP_HD.DataBindings.Add("Text", dt, "TenSP");
//            cboNSX_HD.DataBindings.Add("SelectedValue", dt, "MaNSX");
//            txtXuatXu_HD.DataBindings.Add("Text", dt, "XuatXu");
//            txtGiaBan_HD.DataBindings.Add("Text", dt, "GiaBan");
//            txtMaHD.DataBindings.Add("Text", dt, "MaHD");
//            dtpNgayLap_HD.DataBindings.Add("Text", dt, "NgayLap");
//            txtSoLuong_HD.DataBindings.Add("Text", dt, "SoLuong");
//            txtGiamGia_HD.DataBindings.Add("Text", dt, "GiamGia");
//        }
//        #region button
//        private void btnThemKH_Click(object sender, EventArgs e)
//        {
//            frm_KhachHang frmKH = new frm_KhachHang();
//            frmKH.ShowDialog();
//        }
//        private void btnTaoHD_Click(object sender, EventArgs e)
//        {
//            DateTime now = DateTime.Today;
//            txtMaHD.Text = "KH" + now.Day.ToString("00") + now.Month.ToString("00") + (now.Year - 2000) + count.ToString("000");
//            string selectMaKH = "select count(*) from HoaDon where MaHD = '" + txtMaHD.Text + "'";
//            while (TrungThongTin(selectMaKH))
//            {
//                count++;
//                txtMaHD.Text = "KH" + now.Day.ToString("00") + now.Month.ToString("00") + (now.Year - 2000) + count.ToString("000");
//                selectMaKH = "select count(*) from HoaDon where MaHD = '" + txtMaHD.Text + "'";
//            }
//        }
//        #endregion
//        #endregion
//    }
//}
