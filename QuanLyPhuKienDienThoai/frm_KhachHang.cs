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
    public partial class frm_KhachHang : Form
    {
        DBConnect db = new DBConnect();
        DataTable dtKhachHang = new DataTable();
        string sql = "select * from KhachHang";
        int count = 1;
        public frm_KhachHang()
        {
            InitializeComponent();
            dtKhachHang = db.getDataTable(sql);
            DataColumn[] key = new DataColumn[1];
            key[0] = dtKhachHang.Columns[0];
            dtKhachHang.PrimaryKey = key;
        }

        void Load_DgvKhachHang()
        {
            DataTable dt = db.getDataTable("select * from KhachHang");
            dgvKhachHang.DataSource = dt;
            dataBinDing(dt);
        }
        void dataBinDing(DataTable pDT)
        {
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtMaKH.DataBindings.Add("text", pDT, "MaKH");
            txtTenKH.DataBindings.Add("text", pDT, "TenKH");
            txtEmail.DataBindings.Add("text", pDT, "Email");
            txtSDT.DataBindings.Add("text", pDT, "SDT");
            txtDiaChi.DataBindings.Add("text", pDT, "DiaChi");
        }

        private void frm_KhachHang_Load(object sender, EventArgs e)
        {
            Load_DgvKhachHang();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            string selectMaKH = "select count(*) from KhachHang where MaKH = '" + txtMaKH.Text + "'";
            if (IsEmpty(txtMaKH.Text) || IsEmpty(txtTenKH.Text) || IsEmpty(txtSDT.Text) || IsEmpty(txtDiaChi.Text) || IsEmpty(txtEmail.Text))
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (TrungThongTin(selectMaKH))
                MessageBox.Show("Khách hàng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (txtSDT.Text.Length != 10)
                MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!ValiDateEmail(txtEmail.Text))
                MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string GioiTinh = "";
                if (rdoNam.Checked)
                {
                    GioiTinh = "Nam";
                }
                else if (rdoNu.Checked)
                {
                    GioiTinh = "Nữ";
                }
                else
                {
                    GioiTinh = "Khác";
                }    
                DataRow row = dtKhachHang.NewRow();
                row["MaKH"] = txtMaKH.Text;
                row["TenKH"] = txtTenKH.Text;
                row["GioiTinh"] = GioiTinh;
                row["Email"] = txtEmail.Text;
                row["SDT"] = txtSDT.Text;
                row["DiaChi"] = txtDiaChi.Text;
                dtKhachHang.Rows.Add(row);
                int kq = db.updateDatabase(sql, dtKhachHang);
                if (kq > 0)
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DgvKhachHang();
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn sửa thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                if (IsEmpty(txtMaKH.Text) || IsEmpty(txtTenKH.Text) || IsEmpty(txtSDT.Text) || IsEmpty(txtDiaChi.Text) || IsEmpty(txtEmail.Text))
                    MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (txtSDT.Text.Length != 10)
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (!ValiDateEmail(txtEmail.Text))
                    MessageBox.Show("Email không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string GioiTinh = "";
                    if (rdoNam.Checked)
                    {
                        GioiTinh = "Nam";
                    }
                    else if (rdoNu.Checked)
                    {
                        GioiTinh = "Nữ";
                    }
                    else
                    {
                        GioiTinh = "Khác";
                    }
                    DataRow row = dtKhachHang.Rows.Find(txtMaKH.Text);
                    if(row != null)
                    {
                        row["TenKH"] = txtTenKH.Text;
                        row["GioiTinh"] = GioiTinh;
                        row["Email"] = txtEmail.Text;
                        row["SDT"] = txtSDT.Text;
                        row["DiaChi"] = txtDiaChi.Text;
                    }    
                    int kq = db.updateDatabase(sql, dtKhachHang);
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_DgvKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Load_DgvKhachHang();
                    }

                }
            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Today;
            txtMaKH.Text = "KH" + now.Day.ToString("00") + now.Month.ToString("00") + (now.Year - 2000) + count.ToString("000");
            string selectMaKH = "select count(*) from KhachHang where MaKH = '" + txtMaKH.Text + "'";
            while (TrungThongTin(selectMaKH))
            {
                count++;
                txtMaKH.Text = "KH" + now.Day.ToString("00") + now.Month.ToString("00") + (now.Year - 2000) + count.ToString("000");
                selectMaKH = "select count(*) from KhachHang where MaKH = '" + txtMaKH.Text + "'";
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult edit;
            edit = MessageBox.Show("Bạn muốn xóa thông tin khách hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (edit == DialogResult.Yes)
            {
                DataRow row = dtKhachHang.Rows.Find(txtMaKH.Text);
                if (row != null)
                {
                    row.Delete();
                }
                int kq = db.updateDatabase(sql, dtKhachHang);
                if (kq > 0)
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DgvKhachHang();
            }
        }

        private void txtTenKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string gender = dgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            if (gender == "Nam")
                rdoNam.Checked = true;
            else if(gender == "Nữ")
                rdoNu.Checked = true;
            else
                rdoKhac.Checked = true;
        }
    }
}
