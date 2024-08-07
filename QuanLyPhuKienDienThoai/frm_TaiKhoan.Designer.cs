namespace QuanLyPhuKienDienThoai
{
    partial class frm_TaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_TaiKhoan));
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.dgvTK = new System.Windows.Forms.DataGridView();
            this.colMaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpUse = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnStartAdd = new System.Windows.Forms.Button();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).BeginInit();
            this.grpUse.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(23, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 39;
            this.label3.Text = "Tài khoản";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPassword.Location = new System.Drawing.Point(23, 247);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(201, 27);
            this.txtPassword.TabIndex = 42;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(23, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 41;
            this.label1.Text = "Mật khẩu";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtUser.Location = new System.Drawing.Point(23, 173);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(201, 27);
            this.txtUser.TabIndex = 40;
            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaNV.Location = new System.Drawing.Point(23, 78);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(58, 19);
            this.lblMaNV.TabIndex = 43;
            this.lblMaNV.Text = "Mã NV";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaNV.Location = new System.Drawing.Point(23, 99);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(201, 27);
            this.txtMaNV.TabIndex = 44;
            this.txtMaNV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaNV_KeyPress);
            // 
            // dgvTK
            // 
            this.dgvTK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaNV,
            this.colTenNV,
            this.colUser,
            this.colPassword});
            this.dgvTK.Location = new System.Drawing.Point(234, 34);
            this.dgvTK.Name = "dgvTK";
            this.dgvTK.RowHeadersWidth = 51;
            this.dgvTK.RowTemplate.Height = 24;
            this.dgvTK.Size = new System.Drawing.Size(659, 282);
            this.dgvTK.TabIndex = 45;
            // 
            // colMaNV
            // 
            this.colMaNV.DataPropertyName = "MaNV";
            this.colMaNV.HeaderText = "Mã NV";
            this.colMaNV.MinimumWidth = 6;
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.Width = 75;
            // 
            // colTenNV
            // 
            this.colTenNV.DataPropertyName = "TenNV";
            this.colTenNV.HeaderText = "Tên NV";
            this.colTenNV.MinimumWidth = 6;
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.Width = 125;
            // 
            // colUser
            // 
            this.colUser.DataPropertyName = "TenTaiKhoan";
            this.colUser.HeaderText = "Tài khoản";
            this.colUser.MinimumWidth = 6;
            this.colUser.Name = "colUser";
            this.colUser.Width = 125;
            // 
            // colPassword
            // 
            this.colPassword.DataPropertyName = "MatKhau";
            this.colPassword.HeaderText = "Mật khẩu";
            this.colPassword.MinimumWidth = 6;
            this.colPassword.Name = "colPassword";
            this.colPassword.Width = 125;
            // 
            // grpUse
            // 
            this.grpUse.Controls.Add(this.btnStartAdd);
            this.grpUse.Controls.Add(this.btnEdit);
            this.grpUse.Controls.Add(this.btnAdd);
            this.grpUse.Controls.Add(this.btnDel);
            this.grpUse.Controls.Add(this.btnCancel);
            this.grpUse.Location = new System.Drawing.Point(27, 338);
            this.grpUse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpUse.Name = "grpUse";
            this.grpUse.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpUse.Size = new System.Drawing.Size(490, 90);
            this.grpUse.TabIndex = 46;
            this.grpUse.TabStop = false;
            this.grpUse.Text = "Thao tác";
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(248, 22);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(109, 44);
            this.btnEdit.TabIndex = 47;
            this.btnEdit.Text = "   Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(19, 22);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 44);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "   OK";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(133, 22);
            this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(109, 44);
            this.btnDel.TabIndex = 9;
            this.btnDel.Text = "   Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(363, 22);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 44);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "   Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnStartAdd
            // 
            this.btnStartAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStartAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnStartAdd.Image")));
            this.btnStartAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartAdd.Location = new System.Drawing.Point(19, 22);
            this.btnStartAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartAdd.Name = "btnStartAdd";
            this.btnStartAdd.Size = new System.Drawing.Size(109, 44);
            this.btnStartAdd.TabIndex = 48;
            this.btnStartAdd.Text = "     Thêm";
            this.btnStartAdd.UseVisualStyleBackColor = true;
            this.btnStartAdd.Click += new System.EventHandler(this.btnStartAdd_Click);
            // 
            // cboMaNV
            // 
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(23, 99);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(201, 24);
            this.cboMaNV.TabIndex = 47;
            this.cboMaNV.Visible = false;
            // 
            // frm_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 476);
            this.Controls.Add(this.grpUse);
            this.Controls.Add(this.dgvTK);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.cboMaNV);
            this.MaximizeBox = false;
            this.Name = "frm_TaiKhoan";
            this.Text = "frm_TaiKhoan";
            this.Load += new System.EventHandler(this.frm_TaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTK)).EndInit();
            this.grpUse.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.DataGridView dgvTK;
        private System.Windows.Forms.GroupBox grpUse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPassword;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnStartAdd;
        private System.Windows.Forms.ComboBox cboMaNV;
    }
}