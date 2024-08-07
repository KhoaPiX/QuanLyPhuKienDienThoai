namespace QuanLyPhuKienDienThoai
{
    partial class frm_LoaiSP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_LoaiSP));
            this.dgvLoaiSP = new System.Windows.Forms.DataGridView();
            this.colMaLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLoaiSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.grpUse = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTenLoaiSP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaLoaiSP = new System.Windows.Forms.TextBox();
            this.btnStartAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiSP)).BeginInit();
            this.grpUse.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLoaiSP
            // 
            this.dgvLoaiSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaLoaiSP,
            this.colLoaiSP});
            this.dgvLoaiSP.Location = new System.Drawing.Point(200, 26);
            this.dgvLoaiSP.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLoaiSP.Name = "dgvLoaiSP";
            this.dgvLoaiSP.RowHeadersWidth = 51;
            this.dgvLoaiSP.Size = new System.Drawing.Size(324, 340);
            this.dgvLoaiSP.TabIndex = 35;
            // 
            // colMaLoaiSP
            // 
            this.colMaLoaiSP.DataPropertyName = "MaLoaiSP";
            this.colMaLoaiSP.HeaderText = "Mã loại SP";
            this.colMaLoaiSP.MinimumWidth = 6;
            this.colMaLoaiSP.Name = "colMaLoaiSP";
            this.colMaLoaiSP.Width = 90;
            // 
            // colLoaiSP
            // 
            this.colLoaiSP.DataPropertyName = "TenLoaiSP";
            this.colLoaiSP.HeaderText = "Tên Loại SP";
            this.colLoaiSP.MinimumWidth = 6;
            this.colLoaiSP.Name = "colLoaiSP";
            this.colLoaiSP.Width = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(23, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 19);
            this.label3.TabIndex = 34;
            this.label3.Text = "Mã loại SP";
            // 
            // grpUse
            // 
            this.grpUse.Controls.Add(this.btnStartAdd);
            this.grpUse.Controls.Add(this.btnAdd);
            this.grpUse.Controls.Add(this.btnDel);
            this.grpUse.Controls.Add(this.btnCancel);
            this.grpUse.Location = new System.Drawing.Point(27, 388);
            this.grpUse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpUse.Name = "grpUse";
            this.grpUse.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpUse.Size = new System.Drawing.Size(381, 90);
            this.grpUse.TabIndex = 39;
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
            this.btnAdd.Text = "  OK";
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
            this.btnCancel.Location = new System.Drawing.Point(248, 22);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 44);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "   Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTenLoaiSP
            // 
            this.txtTenLoaiSP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenLoaiSP.Location = new System.Drawing.Point(27, 212);
            this.txtTenLoaiSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenLoaiSP.Name = "txtTenLoaiSP";
            this.txtTenLoaiSP.Size = new System.Drawing.Size(160, 27);
            this.txtTenLoaiSP.TabIndex = 38;
            this.txtTenLoaiSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenLoaiSP_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(23, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 37;
            this.label1.Text = "Tên loại SP";
            // 
            // txtMaLoaiSP
            // 
            this.txtMaLoaiSP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMaLoaiSP.Location = new System.Drawing.Point(27, 124);
            this.txtMaLoaiSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaLoaiSP.Name = "txtMaLoaiSP";
            this.txtMaLoaiSP.ReadOnly = true;
            this.txtMaLoaiSP.Size = new System.Drawing.Size(160, 27);
            this.txtMaLoaiSP.TabIndex = 36;
            this.txtMaLoaiSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaLoaiSP_KeyPress);
            // 
            // btnStartAdd
            // 
            this.btnStartAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStartAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnStartAdd.Image")));
            this.btnStartAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartAdd.Location = new System.Drawing.Point(18, 22);
            this.btnStartAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartAdd.Name = "btnStartAdd";
            this.btnStartAdd.Size = new System.Drawing.Size(109, 44);
            this.btnStartAdd.TabIndex = 40;
            this.btnStartAdd.Text = "     Thêm";
            this.btnStartAdd.UseVisualStyleBackColor = true;
            this.btnStartAdd.Click += new System.EventHandler(this.btnStartAdd_Click);
            // 
            // frm_LoaiSP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 484);
            this.Controls.Add(this.dgvLoaiSP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grpUse);
            this.Controls.Add(this.txtTenLoaiSP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaLoaiSP);
            this.MaximizeBox = false;
            this.Name = "frm_LoaiSP";
            this.Text = "Loại sản phẩm";
            this.Load += new System.EventHandler(this.frm_LoaiSP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiSP)).EndInit();
            this.grpUse.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLoaiSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLoaiSP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpUse;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTenLoaiSP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaLoaiSP;
        private System.Windows.Forms.Button btnStartAdd;

    }
}