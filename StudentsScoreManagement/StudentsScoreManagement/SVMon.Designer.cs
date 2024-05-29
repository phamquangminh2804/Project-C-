
namespace StudentsScoreManagement
{
    partial class SVMon
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
            this.lblWel = new System.Windows.Forms.Label();
            this.dataSV = new System.Windows.Forms.DataGridView();
            this.rdPDF = new System.Windows.Forms.RadioButton();
            this.rdExcel = new System.Windows.Forms.RadioButton();
            this.btnSave = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataSV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWel
            // 
            this.lblWel.AutoSize = true;
            this.lblWel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWel.Location = new System.Drawing.Point(515, 33);
            this.lblWel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWel.Name = "lblWel";
            this.lblWel.Size = new System.Drawing.Size(0, 31);
            this.lblWel.TabIndex = 0;
            // 
            // dataSV
            // 
            this.dataSV.AllowUserToAddRows = false;
            this.dataSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSV.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataSV.Location = new System.Drawing.Point(0, 185);
            this.dataSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataSV.Name = "dataSV";
            this.dataSV.RowHeadersWidth = 51;
            this.dataSV.Size = new System.Drawing.Size(1472, 623);
            this.dataSV.TabIndex = 1;
            this.dataSV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataSV_CellClick);
            // 
            // rdPDF
            // 
            this.rdPDF.AutoSize = true;
            this.rdPDF.Location = new System.Drawing.Point(215, 106);
            this.rdPDF.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdPDF.Name = "rdPDF";
            this.rdPDF.Size = new System.Drawing.Size(56, 21);
            this.rdPDF.TabIndex = 10;
            this.rdPDF.TabStop = true;
            this.rdPDF.Text = "PDF";
            this.rdPDF.UseVisualStyleBackColor = true;
            // 
            // rdExcel
            // 
            this.rdExcel.AutoSize = true;
            this.rdExcel.Location = new System.Drawing.Point(215, 135);
            this.rdExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdExcel.Name = "rdExcel";
            this.rdExcel.Size = new System.Drawing.Size(62, 21);
            this.rdExcel.TabIndex = 11;
            this.rdExcel.TabStop = true;
            this.rdExcel.Text = "Excel";
            this.rdExcel.UseVisualStyleBackColor = true;
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
            this.btnSave.Location = new System.Drawing.Point(13, 98);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(173, 62);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Lưu File";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(110)))), ((int)(((byte)(242)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(1280, 98);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(173, 62);
            this.iconButton1.TabIndex = 12;
            this.iconButton1.Text = "&Thêm";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Visible = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.lblWel);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.rdPDF);
            this.panel1.Controls.Add(this.rdExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1472, 185);
            this.panel1.TabIndex = 13;
            // 
            // SVMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 796);
            this.Controls.Add(this.dataSV);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SVMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách môn";
            this.Load += new System.EventHandler(this.SVMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblWel;
        private System.Windows.Forms.DataGridView dataSV;
        private FontAwesome.Sharp.IconButton btnSave;
        private System.Windows.Forms.RadioButton rdPDF;
        private System.Windows.Forms.RadioButton rdExcel;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel1;
    }
}