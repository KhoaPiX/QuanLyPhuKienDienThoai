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
    public partial class frm_NSX : Form
    {
        DBConnect db = new DBConnect();
        private frm_Main mainForm = null;
        DataTable dtNSX = new DataTable();
        string selectNSX = "Select * from NhaSX";
        public frm_NSX(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as frm_Main;
            dtNSX = db.getDataTable(selectNSX);

            DataColumn[] key = new DataColumn[1];
            key[0] = dtNSX.Columns[0];
            dtNSX.PrimaryKey = key;
        }
        public void Load_DgvNSX()
        {
            DataTable dt = db.getDataTable("select * from NhaSX");
            dgvNSX.DataSource = dt;
            DataBind(dt);
        }
        void DataBind(DataTable dt)
        {
            txtMaNSX.DataBindings.Clear();
            txtTenNSX.DataBindings.Clear();
            txtSoDienThoai.DataBindings.Clear();

            txtMaNSX.DataBindings.Add("text", dt, "MaNSX");
            txtTenNSX.DataBindings.Add("text", dt, "TenNSX");
            txtSoDienThoai.DataBindings.Add("text", dt, "SoDT");
        }
        private void frm_NSX_Load(object sender, EventArgs e)
        {
            Load_DgvNSX();
        }
        bool IsEmpty(string str)
        {
            return str.Length <= 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selectMaNSX = "select count(*) from NhaSX where MaNSX = '" + txtMaNSX.Text + "'";
            if (IsEmpty(txtMaNSX.Text) || IsEmpty(txtTenNSX.Text))
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (mainForm.TrungThongTin(selectMaNSX))
                MessageBox.Show("Mã loại SP bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataRow row = dtNSX.NewRow();
                row["MaNSX"] = txtMaNSX.Text;
                row["TenNSX"] = txtTenNSX.Text;
                row["SoDT"] = txtSoDienThoai.Text;
                dtNSX.Rows.Add(row);
                int kq = db.updateDatabase(selectNSX, dtNSX);
                if (kq > 0)
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DgvNSX();
                btnStartAdd.Visible = true;
                btnAdd.Visible = false;
                mainForm.Load_ComboNSX();
                //mainForm.Load_ComboLoaiSP2();

            }
        }
        private void txtMaLoaiSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'A' && e.KeyChar <= 'Z' || char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtTenLoaiSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult del;
            int kq;
            del = MessageBox.Show("Bạn muốn xóa mặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (del == DialogResult.Yes)
            {
                DataRow row = dtNSX.Rows.Find(txtMaNSX.Text);
                DataTable dtSanPham = db.getDataTable("Select * from SanPham");
                int count = (int)db.GetData("select count(*) from SanPham where MaNSX = '" + txtMaNSX.Text + "'");
                if (row != null)
                {
                    if (count == 0)
                    {
                        row.Delete();
                        kq = db.updateDatabase(selectNSX, dtNSX);
                        if (kq > 0)
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Xóa không thành công vì còn tồn tại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Load_DgvNSX();
                mainForm.Load_ComboNSX();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMaNSX.Clear();
            txtTenNSX.Clear();
            txtTenNSX.Focus();
            txtSoDienThoai.Clear();
            btnStartAdd.Visible = true;
            btnAdd.Visible = false;
        }

        private void btnStartAdd_Click(object sender, EventArgs e)
        {
            btnStartAdd.Visible = false;
            btnAdd.Visible = true;
            int count = (int)db.GetData("select count(*) from NhaSX");
            txtTenNSX.Text = txtSoDienThoai.Text = "";
            txtTenNSX.Focus();
            while (true)
            {
                txtMaNSX.Text = "NSX";
                count++;
                if (count < 10)
                    txtMaNSX.Text += "0" + count.ToString();
                else
                    txtMaNSX.Text +=  count.ToString();
                if ((int)db.GetData("select count(*) from NhaSX where MaNSX = '" + txtMaNSX.Text + "'") == 0)
                    break;
            }
        }

    }
}
