namespace QuanLyPhuKienDienThoai
{
    partial class frm_NSX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_NSX));
            this.dgvNSX = new System.Windows.Forms.DataGridView();
            this.colMaLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.grpUse = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTenNSX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaNSX = new System.Windows.Forms.TextBox();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNSX)).BeginInit();
            this.grpUse.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNSX
            // 
            this.dgvNSX.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNSX.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLoaiSP,
            this.colLoaiSP,
            this.Column1});
            this.dgvNSX.Location = new System.Drawing.Point(204, 28);
            this.dgvNSX.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNSX.Name = "dgvNSX";
            this.dgvNSX.RowHeadersWidth = 51;
            this.dgvNSX.Size = new System.Drawing.Size(324, 340);
            this.dgvNSX.TabIndex = 41;
            // 
            // colMaLoaiSP
            // 
            this.colMaLoaiSP.DataPropertyName = "MaNSX";
            this.colMaLoaiSP.HeaderText = "Mã NSX";
            this.colMaLoaiSP.MinimumWidth = 6;
            this.colMaLoaiSP.Name = "colMaLoaiSP";
            this.colMaLoaiSP.Width = 90;
            // 
            // colLoaiSP
            // 
            this.colLoaiSP.DataPropertyName = "TenNSX";
            this.colLoaiSP.HeaderText = "Tên NSX";
            this.colLoaiSP.MinimumWidth = 6;
            this.colLoaiSP.Name = "colLoaiSP";
            this.colLoaiSP.Width = 110;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SoDT";
            this.Column1.HeaderText = "Số điện thoại";
            this.Column1.Name = "Column1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(27, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "Mã NSX";
            // 
            // grpUse
            // 
            this.grpUse.Controls.Add(this.btnStartAdd);
            this.grpUse.Controls.Add(this.btnAdd);
            this.grpUse.Controls.Add(this.btnDel);
            this.grpUse.Controls.Add(this.btnCancel);
            this.grpUse.Location = new System.Drawing.Point(31, 390);
            this.grpUse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpUse.Name = "grpUse";
            this.grpUse.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpUse.Size = new System.Drawing.Size(381, 90);
            this.grpUse.TabIndex = 45;
            this.grpUse.TabStop = false;
            this.grpUse.Text = "Thao tác";
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
            this.btnAdd.Visible = false;
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
            this.btnDel.TabIndex = 3;
            this.btnDel.Text = "   Xóa";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(248, 22);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 44);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "   Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTenNSX
            // 
            this.txtTenNSX.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenNSX.Location = new System.Drawing.Point(31, 214);
            this.txtTenNSX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenNSX.Name = "txtTenNSX";
            this.txtTenNSX.Size = new System.Drawing.Size(160, 27);
            this.txtTenNSX.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(27, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 43;
            this.label1.Text = "Tên NSX";
            // 
            // txtMaNSX
            // 
            this.txtMaNSX.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaNSX.Location = new System.Drawing.Point(31, 126);
            this.txtMaNSX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaNSX.Name = "txtMaNSX";
            this.txtMaNSX.ReadOnly = true;
            this.txtMaNSX.Size = new System.Drawing.Size(160, 27);
            this.txtMaNSX.TabIndex = 42;
            // 
            // txtSoDienThoai
            // 
            this.txtSoDienThoai.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSoDienThoai.Location = new System.Drawing.Point(31, 296);
            this.txtSoDienThoai.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSoDienThoai.Name = "txtSoDienThoai";
            this.txtSoDienThoai.Size = new System.Drawing.Size(160, 27);
            this.txtSoDienThoai.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(27, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 19);
            this.label2.TabIndex = 46;
            this.label2.Text = "Số điện thoại";
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
            this.btnStartAdd.TabIndex = 3;
            this.btnStartAdd.Text = "     Thêm";
            this.btnStartAdd.UseVisualStyleBackColor = true;
            this.btnStartAdd.Click += new System.EventHandler(this.btnStartAdd_Click);
            // 
            // frm_NSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 494);
            this.Controls.Add(this.txtSoDienThoai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvNSX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpUse);
            this.Controls.Add(this.txtTenNSX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaNSX);
            this.MaximizeBox = false;
            this.Name = "frm_NSX";
            this.Text = "Nhà sản xuất";
            this.Load += new System.EventHandler(this.frm_NSX_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNSX)).EndInit();
            this.grpUse.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNSX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpUse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTenNSX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaNSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartAdd;

    }
}