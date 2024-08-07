using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyPhuKienDienThoai
{
    public partial class frm_TaiKhoan : Form
    {
        DBConnect db = new DBConnect();
        private frm_Main mainForm = null;
        DataTable dtTK = new DataTable();
        string selectTK = "select * from TaiKhoan";
        public frm_TaiKhoan(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as frm_Main;
            dtTK = db.getDataTable(selectTK);
            DataColumn[] key = new DataColumn[1];
            key[0] = dtTK.Columns[0];
            dtTK.PrimaryKey = key;
        }
        public void Load_ComboMaNVChuaCoTK()
        {
            DataTable dt = db.getDataTable("Select MaNV from NhanVien where MaNV not in(select MANV from TaiKhoan)");
            cboMaNV.DataSource = dt;
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
        }
        public void Load_DgvTK()
        {
            DataTable dt = db.getDataTable("select * from TaiKhoan, NhanVien where TaiKhoan.MaNV = NhanVien.MaNV");
            dgvTK.AutoGenerateColumns = false;
            dgvTK.DataSource = dt;
            DataBind(dt);
        }
        private void DataBind(DataTable dt)
        {
            txtMaNV.DataBindings.Clear();
            txtUser.DataBindings.Clear();
            txtPassword.DataBindings.Clear();
            txtMaNV.DataBindings.Add("Text", dt, "MaNV");
            txtUser.DataBindings.Add("Text", dt, "TenTaiKhoan");
            txtPassword.DataBindings.Add("Text", dt, "MatKhau");
        }

        private void frm_TaiKhoan_Load(object sender, EventArgs e)
        {
            Load_DgvTK();
        }

        bool IsEmpty(string str)
        {
            return str.Length <= 0;
        }
        private void btnStartAdd_Click(object sender, EventArgs e)
        {
            btnStartAdd.Visible = false;
            btnAdd.Visible = true;
            cboMaNV.Visible = true;
            txtMaNV.Visible = false;
            Load_ComboMaNVChuaCoTK();
            lblMaNV.Text = "Mã NV chưa có TK";
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string selectMaNV = "select count(*) from NhanVien where MaNV = '" + txtMaNV.Text + "'";
            if (IsEmpty(txtMaNV.Text) || IsEmpty(txtUser.Text))
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //if (!mainForm.TrungThongTin(selectMaNV))
            //    MessageBox.Show("Nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //DataRow row = dtTK.Rows.Find(txtMaNV.Text);
                //if (row != null)
                //    MessageBox.Show("Nhân viên này đã có tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //else
                //{
                string selectTTK = "select count(*) from TaiKhoan where TenTaiKhoan = '" + txtUser.Text + "'";
                if (mainForm.TrungThongTin(selectTTK))
                {
                    MessageBox.Show("Đã có tên tài khoản này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //btnAdd.Visible = false;
                    //btnStartAdd.Visible = true;
                }
                else
                {
                    DataRow rowTK = dtTK.NewRow();
                    rowTK["TenTaiKhoan"] = txtUser.Text;
                    rowTK["MaNV"] = cboMaNV.Text;
                    rowTK["MatKhau"] = txtPassword.Text;
                    dtTK.Rows.Add(rowTK);
                    int kq = db.updateDatabase(selectTK, dtTK);
                    if (kq > 0)
                        MessageBox.Show("Tạo thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Tạo không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_DgvTK();
                    //}    
                }
                btnAdd.Visible = false;
                btnStartAdd.Visible = true;
                cboMaNV.Visible = false;
                txtMaNV.Visible = true;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult del;
            del = MessageBox.Show("Bạn muốn xóa tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (del == DialogResult.Yes)
            {
                DataRow row = dtTK.Rows.Find(txtMaNV.Text);
                if (row == null)
                    MessageBox.Show("Không tìm thấy tài khoản cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    row.Delete();
                    int kq = db.updateDatabase(selectTK, dtTK);
                    if (kq > 0)
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_DgvTK();
                }    
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string selectMaNV = "select count(*) from NhanVien where MaNV = '" + txtMaNV.Text + "'";
            if (IsEmpty(txtMaNV.Text) || IsEmpty(txtUser.Text))
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!mainForm.TrungThongTin(selectMaNV))
                MessageBox.Show("Nhân viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataRow row = dtTK.Rows.Find(txtMaNV.Text);
                if (row == null)
                    MessageBox.Show("Không tìm thấy tài khoản cần sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string selectTTK = "select count(*) from TaiKhoan where TenTaiKhoan = '" + txtUser.Text + "'";
                    if (mainForm.TrungThongTin(selectTTK) && !row["TenTaiKhoan"].ToString().Equals(txtUser.Text))
                        MessageBox.Show("Tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        row["TenTaiKhoan"] = txtUser.Text;
                        row["MatKhau"] = txtPassword.Text;
                        int kq = db.updateDatabase(selectTK, dtTK);
                        if (kq > 0)
                            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_DgvTK();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cboMaNV.Visible = false;
            txtMaNV.Visible = true;
            lblMaNV.Text = "Mã NV";
            txtMaNV.Clear();
            txtUser.Clear();
            txtPassword.Clear();
            Load_DgvTK();
            txtMaNV.Focus();
            btnAdd.Visible = false;
            btnStartAdd.Visible = true;
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsUpper(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsWhiteSpace(e.KeyChar) && (char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
                e.Handled = true;
        }
    }
}
