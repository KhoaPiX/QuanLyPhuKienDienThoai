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
    public partial class frm_LoaiSP : Form
    {
        DBConnect db = new DBConnect();
        private frm_Main mainForm = null;
        DataTable dtLoaiSP = new DataTable();
        string selectLSP = "Select * from LoaiSP";
        public frm_LoaiSP(Form callingForm)
        {
            InitializeComponent();
            mainForm = callingForm as frm_Main;
            dtLoaiSP = db.getDataTable(selectLSP);
            DataColumn[] key = new DataColumn[1];
            key[0] = dtLoaiSP.Columns[0];
            dtLoaiSP.PrimaryKey = key;
        }
        public void Load_DgvLoaiSP()
        {
            DataTable dt = db.getDataTable("select * from LoaiSP");
            dgvLoaiSP.DataSource = dt;
            DataBind(dt);
        }
        void DataBind(DataTable dt)
        {
            txtMaLoaiSP.DataBindings.Clear();
            txtTenLoaiSP.DataBindings.Clear();
            txtMaLoaiSP.DataBindings.Add("Text", dt, "MaLoaiSP");
            txtTenLoaiSP.DataBindings.Add("Text", dt, "TenLoaiSP");
        }
        private void frm_LoaiSP_Load(object sender, EventArgs e)
        {
            Load_DgvLoaiSP();
        }
        bool IsEmpty(string str)
        {
            return str.Length <= 0;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selectMaLoaiSP = "select count(*) from LoaiSP where MaLoaiSP = '" + txtMaLoaiSP.Text + "'";
            if (IsEmpty(txtMaLoaiSP.Text) || IsEmpty(txtTenLoaiSP.Text))
                MessageBox.Show("Thông tin không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (mainForm.TrungThongTin(selectMaLoaiSP))
                MessageBox.Show("Mã loại SP bị trùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DataRow row = dtLoaiSP.NewRow();
                row["MaLoaiSP"] = txtMaLoaiSP.Text;
                row["TenLoaiSP"] = txtTenLoaiSP.Text;
                dtLoaiSP.Rows.Add(row);
                int kq = db.updateDatabase(selectLSP, dtLoaiSP);
                if (kq > 0)
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_DgvLoaiSP();
                mainForm.Load_ComboLoaiSP();
                //mainForm.Load_ComboLoaiSP2();
            }
            btnAdd.Visible = true;
            btnStartAdd.Visible = false;
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
            del = MessageBox.Show("Bạn muốn xóa mặt hàng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (del == DialogResult.Yes)
            {
                DataRow row = dtLoaiSP.Rows.Find(txtMaLoaiSP.Text);
                int count = (int) db.GetData("select count(*) from SanPham where MaLoaiSP = '" + txtMaLoaiSP.Text + "'");
                if (row != null)
                {
                    if (count == 0)
                    {
                        row.Delete();
                        int kq = db.updateDatabase(selectLSP, dtLoaiSP);
                        if (kq > 0)
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Xóa không thành công vì còn tồn tại sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Load_DgvLoaiSP();
                mainForm.Load_ComboLoaiSP();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMaLoaiSP.Clear();
            txtTenLoaiSP.Clear();
            txtTenLoaiSP.Focus();
            btnStartAdd.Visible = true;
            btnAdd.Visible = false;
        }

        private void btnStartAdd_Click(object sender, EventArgs e)
        {
            btnStartAdd.Visible = false;
            btnAdd.Visible = true;
            int count = (int)db.GetData("select count(*) from LoaiSP");
            txtTenLoaiSP.Text = "";
            txtTenLoaiSP.Focus();
            while(true)
            {
                txtMaLoaiSP.Text = "L";
                count++;
                if (count < 10)
                    txtMaLoaiSP.Text += "00" + count.ToString();
                else if (count < 100)
                    txtMaLoaiSP.Text += "0" + count.ToString();
                else
                    txtMaLoaiSP.Text += count.ToString();
                if ((int)db.GetData("select count(*) from LoaiSP where MaLoaiSP = '" + txtMaLoaiSP.Text + "'") == 0)
                    break;
            }
        }
    }
}
