namespace KütüphaneOtomasyonuBerke
{
    partial class frmBooks
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
            this.dgwBooks = new System.Windows.Forms.DataGridView();
            this.tbxSearchBook = new System.Windows.Forms.TextBox();
            this.lblSearchBook = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gbxInsertBook = new System.Windows.Forms.GroupBox();
            this.btnInsertBook = new System.Windows.Forms.Button();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.numPageCount = new System.Windows.Forms.NumericUpDown();
            this.dtpReleasedDate = new System.Windows.Forms.DateTimePicker();
            this.cbxAuthorName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPublisher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxBookName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKitapGeri = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBooks)).BeginInit();
            this.gbxInsertBook.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwBooks
            // 
            this.dgwBooks.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgwBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwBooks.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgwBooks.Location = new System.Drawing.Point(0, 362);
            this.dgwBooks.Name = "dgwBooks";
            this.dgwBooks.Size = new System.Drawing.Size(1050, 178);
            this.dgwBooks.TabIndex = 0;
            this.dgwBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwBooks_CellClick);
            // 
            // tbxSearchBook
            // 
            this.tbxSearchBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxSearchBook.Location = new System.Drawing.Point(353, 130);
            this.tbxSearchBook.Name = "tbxSearchBook";
            this.tbxSearchBook.Size = new System.Drawing.Size(218, 29);
            this.tbxSearchBook.TabIndex = 1;
            this.tbxSearchBook.TextChanged += new System.EventHandler(this.tbxSearchBook_TextChanged);
            // 
            // lblSearchBook
            // 
            this.lblSearchBook.AutoSize = true;
            this.lblSearchBook.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSearchBook.ForeColor = System.Drawing.Color.White;
            this.lblSearchBook.Location = new System.Drawing.Point(402, 78);
            this.lblSearchBook.Name = "lblSearchBook";
            this.lblSearchBook.Size = new System.Drawing.Size(111, 30);
            this.lblSearchBook.TabIndex = 2;
            this.lblSearchBook.Text = "Kitap Ara ";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.Location = new System.Drawing.Point(305, 275);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 49);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Location = new System.Drawing.Point(412, 275);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 49);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gbxInsertBook
            // 
            this.gbxInsertBook.Controls.Add(this.btnInsertBook);
            this.gbxInsertBook.Controls.Add(this.numStock);
            this.gbxInsertBook.Controls.Add(this.numPageCount);
            this.gbxInsertBook.Controls.Add(this.dtpReleasedDate);
            this.gbxInsertBook.Controls.Add(this.cbxAuthorName);
            this.gbxInsertBook.Controls.Add(this.label4);
            this.gbxInsertBook.Controls.Add(this.label7);
            this.gbxInsertBook.Controls.Add(this.tbxPublisher);
            this.gbxInsertBook.Controls.Add(this.label2);
            this.gbxInsertBook.Controls.Add(this.label3);
            this.gbxInsertBook.Controls.Add(this.label5);
            this.gbxInsertBook.Controls.Add(this.tbxBookName);
            this.gbxInsertBook.Controls.Add(this.label1);
            this.gbxInsertBook.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxInsertBook.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxInsertBook.Location = new System.Drawing.Point(626, 12);
            this.gbxInsertBook.Name = "gbxInsertBook";
            this.gbxInsertBook.Size = new System.Drawing.Size(412, 312);
            this.gbxInsertBook.TabIndex = 4;
            this.gbxInsertBook.TabStop = false;
            this.gbxInsertBook.Text = "Yeni Kitap Kaydı";
            // 
            // btnInsertBook
            // 
            this.btnInsertBook.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInsertBook.Location = new System.Drawing.Point(146, 252);
            this.btnInsertBook.Name = "btnInsertBook";
            this.btnInsertBook.Size = new System.Drawing.Size(259, 36);
            this.btnInsertBook.TabIndex = 20;
            this.btnInsertBook.Text = "Kaydı Ekle";
            this.btnInsertBook.UseVisualStyleBackColor = true;
            this.btnInsertBook.Click += new System.EventHandler(this.btnInsertBook_Click);
            // 
            // numStock
            // 
            this.numStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numStock.Location = new System.Drawing.Point(146, 215);
            this.numStock.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(259, 30);
            this.numStock.TabIndex = 18;
            // 
            // numPageCount
            // 
            this.numPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numPageCount.Location = new System.Drawing.Point(146, 179);
            this.numPageCount.Maximum = new decimal(new int[] {
            -1530494976,
            232830,
            0,
            0});
            this.numPageCount.Name = "numPageCount";
            this.numPageCount.Size = new System.Drawing.Size(259, 30);
            this.numPageCount.TabIndex = 19;
            // 
            // dtpReleasedDate
            // 
            this.dtpReleasedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpReleasedDate.Location = new System.Drawing.Point(146, 139);
            this.dtpReleasedDate.Name = "dtpReleasedDate";
            this.dtpReleasedDate.Size = new System.Drawing.Size(259, 30);
            this.dtpReleasedDate.TabIndex = 17;
            // 
            // cbxAuthorName
            // 
            this.cbxAuthorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cbxAuthorName.FormattingEnabled = true;
            this.cbxAuthorName.Location = new System.Drawing.Point(146, 62);
            this.cbxAuthorName.Name = "cbxAuthorName";
            this.cbxAuthorName.Size = new System.Drawing.Size(259, 33);
            this.cbxAuthorName.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(20, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Yayın Tarihi: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(83, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 28);
            this.label7.TabIndex = 9;
            this.label7.Text = "Stok: ";
            // 
            // tbxPublisher
            // 
            this.tbxPublisher.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxPublisher.Location = new System.Drawing.Point(146, 100);
            this.tbxPublisher.Name = "tbxPublisher";
            this.tbxPublisher.Size = new System.Drawing.Size(259, 30);
            this.tbxPublisher.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(72, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Yazar: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(49, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Yayınevi: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(14, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "Sayfa Sayısı: ";
            // 
            // tbxBookName
            // 
            this.tbxBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxBookName.Location = new System.Drawing.Point(146, 25);
            this.tbxBookName.Name = "tbxBookName";
            this.tbxBookName.Size = new System.Drawing.Size(259, 30);
            this.tbxBookName.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(78, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 28);
            this.label1.TabIndex = 13;
            this.label1.Text = "Kitap: ";
            // 
            // btnKitapGeri
            // 
            this.btnKitapGeri.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKitapGeri.Location = new System.Drawing.Point(519, 275);
            this.btnKitapGeri.Name = "btnKitapGeri";
            this.btnKitapGeri.Size = new System.Drawing.Size(101, 49);
            this.btnKitapGeri.TabIndex = 5;
            this.btnKitapGeri.Text = "Geri Dön";
            this.btnKitapGeri.UseVisualStyleBackColor = true;
            this.btnKitapGeri.Click += new System.EventHandler(this.btnKitapGeri_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 362);
            this.panel1.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.label9.Location = new System.Drawing.Point(13, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(259, 72);
            this.label9.TabIndex = 14;
            this.label9.Text = "Kitap bilgilerini kolayca güncelleyerek en güncel ve doğru arşive sahip olun.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.label8.Location = new System.Drawing.Point(16, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(254, 30);
            this.label8.TabIndex = 13;
            this.label8.Text = "Kütüphane Otomasyonu";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(350, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 45);
            this.label6.TabIndex = 7;
            this.label6.Text = "Koleksiyonumuzda hızlıca keşfedin, aradığınızı anında bulun.";
            // 
            // frmBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1050, 540);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblSearchBook);
            this.Controls.Add(this.tbxSearchBook);
            this.Controls.Add(this.btnKitapGeri);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxInsertBook);
            this.Controls.Add(this.dgwBooks);
            this.Controls.Add(this.btnUpdate);
            this.Name = "frmBooks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitaplar";
            this.Load += new System.EventHandler(this.frmBooks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwBooks)).EndInit();
            this.gbxInsertBook.ResumeLayout(false);
            this.gbxInsertBook.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPageCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwBooks;
        private System.Windows.Forms.TextBox tbxSearchBook;
        private System.Windows.Forms.Label lblSearchBook;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbxInsertBook;
        private System.Windows.Forms.Button btnInsertBook;
        private System.Windows.Forms.NumericUpDown numStock;
        private System.Windows.Forms.NumericUpDown numPageCount;
        private System.Windows.Forms.DateTimePicker dtpReleasedDate;
        private System.Windows.Forms.ComboBox cbxAuthorName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxPublisher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbxBookName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKitapGeri;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}