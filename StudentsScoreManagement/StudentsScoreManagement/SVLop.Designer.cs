
namespace StudentsScoreManagement
{
    partial class SVLop
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
            this.rdExcel = new System.Windows.Forms.RadioButton();
            this.rdPDF = new System.Windows.Forms.RadioButton();
            this.dataSV = new System.Windows.Forms.DataGridView();
            this.lblWel = new System.Windows.Forms.Label();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataSV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdExcel
            // 
            this.rdExcel.AutoSize = true;
            this.rdExcel.Location = new System.Drawing.Point(162, 110);
            this.rdExcel.Name = "rdExcel";
            this.rdExcel.Size = new System.Drawing.Size(51, 17);
            this.rdExcel.TabIndex = 16;
            this.rdExcel.TabStop = true;
            this.rdExcel.Text = "Excel";
            this.rdExcel.UseVisualStyleBackColor = true;
            // 
            // rdPDF
            // 
            this.rdPDF.AutoSize = true;
            this.rdPDF.Location = new System.Drawing.Point(162, 87);
            this.rdPDF.Name = "rdPDF";
            this.rdPDF.Size = new System.Drawing.Size(46, 17);
            this.rdPDF.TabIndex = 15;
            this.rdPDF.TabStop = true;
            this.rdPDF.Text = "PDF";
            this.rdPDF.UseVisualStyleBackColor = true;
            // 
            // dataSV
            // 
            this.dataSV.AllowUserToAddRows = false;
            this.dataSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataSV.Location = new System.Drawing.Point(0, 150);
            this.dataSV.Name = "dataSV";
            this.dataSV.RowHeadersWidth = 51;
            this.dataSV.Size = new System.Drawing.Size(1104, 506);
            this.dataSV.TabIndex = 13;
            this.dataSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSV_CellClick);
            // 
            // lblWel
            // 
            this.lblWel.AutoSize = true;
            this.lblWel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWel.Location = new System.Drawing.Point(386, 27);
            this.lblWel.Name = "lblWel";
            this.lblWel.Size = new System.Drawing.Size(0, 25);
            this.lblWel.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnSave.IconColor = System.Drawing.Color.White;
            this.btnSave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSave.IconSize = 40;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(10, 80);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Lưu File";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.lblWel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.rdExcel);
            this.panel1.Controls.Add(this.rdPDF);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1104, 150);
            this.panel1.TabIndex = 17;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnThem.IconColor = System.Drawing.Color.White;
            this.btnThem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThem.IconSize = 40;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(960, 80);
            this.btnThem.Margin = new System.Windows.Forms.Padding(0);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(130, 50);
            this.btnThem.TabIndex = 17;
            this.btnThem.Text = "&Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Visible = false;
            this.btnThem.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // SVLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 647);
            this.Controls.Add(this.dataSV);
            this.Controls.Add(this.panel1);
            this.Name = "SVLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách lớp";
            this.Load += new System.EventHandler(this.SVLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdExcel;
        private System.Windows.Forms.RadioButton rdPDF;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.DataGridView dataSV;
        private System.Windows.Forms.Label lblWel;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnThem;
    }
}