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
    public partial class frm_DangNhap : Form
    {
        DBConnect db = new DBConnect();
        DataTable dtDN = new DataTable();
        public static string UserTxt;
        public static string NameTxt;
        public static string MaChucVuTxt;
        public frm_DangNhap()
        {
            InitializeComponent();
            dtDN = db.getDataTable("Select * from TaiKhoan");
            DataColumn[] key = new DataColumn[1];
            key[0] = dtDN.Columns[1];
            dtDN.PrimaryKey = key;
        }
        void CloseForm()
        {
            frm_Main main = new frm_Main();
            this.Hide();
            main.ShowDialog();
            txtUser.Text = txtPassword.Text = "";
            txtUser.Select();
            this.Show();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserTxt = txtUser.Text;
            if (txtUser.Text.Equals("Admin"))
            {
                if (txtPassword.Text.Equals("admin"))
                {
                    MessageBox.Show("Admin Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NameTxt = "Admin";
                    MaChucVuTxt = "Admin";
                    CloseForm();
                }
                else
                    MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataRow row = dtDN.Rows.Find(txtUser.Text);
                if (row == null)
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (row["MatKhau"].ToString().Equals(txtPassword.Text))
                    {
                        MessageBox.Show(UserTxt + " Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NameTxt = db.GetData("select TenNV from NhanVien,TaiKhoan where NhanVien.MaNV = TaiKhoan.MaNV and TenTaiKhoan = '" + UserTxt + "'").ToString();
                        MaChucVuTxt = db.GetData("select MaChucVu from NhanVien,TaiKhoan where NhanVien.MaNV = TaiKhoan.MaNV and TenTaiKhoan = '" + UserTxt + "'").ToString();
                        CloseForm();
                    }
                    else
                        MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq;
            kq = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }

        private void btnVisible_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '*';
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
