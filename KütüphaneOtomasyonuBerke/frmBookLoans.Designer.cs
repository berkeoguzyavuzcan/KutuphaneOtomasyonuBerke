namespace KütüphaneOtomasyonuBerke
{
    partial class frmBookLoans
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
            this.dgwMember = new System.Windows.Forms.DataGridView();
            this.dgwBooks = new System.Windows.Forms.DataGridView();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.gbxMembers = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxBirthDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxIdentityNumber = new System.Windows.Forms.TextBox();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.gbxBooks = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbxAuthorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxBookName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxStocks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPageCount = new System.Windows.Forms.TextBox();
            this.tbxPublisherName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxSearchBook = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxSearchMembers = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbxInformation = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnProcesDone = new System.Windows.Forms.Button();
            this.btnStateOfDue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBooks)).BeginInit();
            this.gbxMembers.SuspendLayout();
            this.gbxBooks.SuspendLayout();
            this.gbxInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwMember
            // 
            this.dgwMember.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgwMember.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMember.Location = new System.Drawing.Point(518, 367);
            this.dgwMember.Name = "dgwMember";
            this.dgwMember.Size = new System.Drawing.Size(520, 180);
            this.dgwMember.TabIndex = 0;
            this.dgwMember.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwMember_CellClick);
            // 
            // dgwBooks
            // 
            this.dgwBooks.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgwBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwBooks.Location = new System.Drawing.Point(12, 367);
            this.dgwBooks.Name = "dgwBooks";
            this.dgwBooks.Size = new System.Drawing.Size(500, 177);
            this.dgwBooks.TabIndex = 0;
            this.dgwBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwBooks_CellClick);
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpDueDate.Location = new System.Drawing.Point(118, 288);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(271, 29);
            this.dtpDueDate.TabIndex = 1;
            // 
            // gbxMembers
            // 
            this.gbxMembers.Controls.Add(this.label7);
            this.gbxMembers.Controls.Add(this.tbxFirstName);
            this.gbxMembers.Controls.Add(this.label10);
            this.gbxMembers.Controls.Add(this.label8);
            this.gbxMembers.Controls.Add(this.tbxBirthDate);
            this.gbxMembers.Controls.Add(this.label9);
            this.gbxMembers.Controls.Add(this.tbxIdentityNumber);
            this.gbxMembers.Controls.Add(this.tbxLastName);
            this.gbxMembers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxMembers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxMembers.Location = new System.Drawing.Point(397, 12);
            this.gbxMembers.Name = "gbxMembers";
            this.gbxMembers.Size = new System.Drawing.Size(380, 227);
            this.gbxMembers.TabIndex = 6;
            this.gbxMembers.TabStop = false;
            this.gbxMembers.Text = "Üye Bilgileri";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCancel.Location = new System.Drawing.Point(596, 273);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(181, 50);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "GERİ DÖN";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(98, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ad: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxFirstName.Location = new System.Drawing.Point(148, 21);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(214, 29);
            this.tbxFirstName.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(8, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 25);
            this.label10.TabIndex = 6;
            this.label10.Text = "Doğum Tarihi: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(70, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tc No: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxBirthDate
            // 
            this.tbxBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxBirthDate.Location = new System.Drawing.Point(148, 156);
            this.tbxBirthDate.Name = "tbxBirthDate";
            this.tbxBirthDate.Size = new System.Drawing.Size(214, 29);
            this.tbxBirthDate.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(69, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Soyad: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxIdentityNumber
            // 
            this.tbxIdentityNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxIdentityNumber.Location = new System.Drawing.Point(148, 109);
            this.tbxIdentityNumber.Name = "tbxIdentityNumber";
            this.tbxIdentityNumber.Size = new System.Drawing.Size(214, 29);
            this.tbxIdentityNumber.TabIndex = 11;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxLastName.Location = new System.Drawing.Point(148, 62);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(214, 29);
            this.tbxLastName.TabIndex = 12;
            // 
            // gbxBooks
            // 
            this.gbxBooks.Controls.Add(this.label20);
            this.gbxBooks.Controls.Add(this.tbxAuthorName);
            this.gbxBooks.Controls.Add(this.label1);
            this.gbxBooks.Controls.Add(this.tbxBookName);
            this.gbxBooks.Controls.Add(this.label2);
            this.gbxBooks.Controls.Add(this.label3);
            this.gbxBooks.Controls.Add(this.tbxStocks);
            this.gbxBooks.Controls.Add(this.label4);
            this.gbxBooks.Controls.Add(this.tbxPageCount);
            this.gbxBooks.Controls.Add(this.tbxPublisherName);
            this.gbxBooks.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxBooks.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxBooks.Location = new System.Drawing.Point(12, 12);
            this.gbxBooks.Name = "gbxBooks";
            this.gbxBooks.Size = new System.Drawing.Size(362, 227);
            this.gbxBooks.TabIndex = 6;
            this.gbxBooks.TabStop = false;
            this.gbxBooks.Text = "Kitap Bilgileri";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label20.Location = new System.Drawing.Point(58, 60);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(70, 25);
            this.label20.TabIndex = 5;
            this.label20.Text = "Yazar: ";
            this.label20.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxAuthorName
            // 
            this.tbxAuthorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxAuthorName.Location = new System.Drawing.Point(139, 58);
            this.tbxAuthorName.Name = "tbxAuthorName";
            this.tbxAuthorName.Size = new System.Drawing.Size(204, 29);
            this.tbxAuthorName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(58, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kitap: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxBookName
            // 
            this.tbxBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxBookName.Location = new System.Drawing.Point(139, 17);
            this.tbxBookName.Name = "tbxBookName";
            this.tbxBookName.Size = new System.Drawing.Size(204, 29);
            this.tbxBookName.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(72, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Stok: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(10, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sayfa Sayısı: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxStocks
            // 
            this.tbxStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxStocks.Location = new System.Drawing.Point(141, 186);
            this.tbxStocks.Name = "tbxStocks";
            this.tbxStocks.Size = new System.Drawing.Size(204, 29);
            this.tbxStocks.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(33, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Yayınevi:  ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxPageCount
            // 
            this.tbxPageCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxPageCount.Location = new System.Drawing.Point(139, 138);
            this.tbxPageCount.Name = "tbxPageCount";
            this.tbxPageCount.Size = new System.Drawing.Size(204, 29);
            this.tbxPageCount.TabIndex = 11;
            // 
            // tbxPublisherName
            // 
            this.tbxPublisherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxPublisherName.Location = new System.Drawing.Point(139, 96);
            this.tbxPublisherName.Name = "tbxPublisherName";
            this.tbxPublisherName.Size = new System.Drawing.Size(204, 29);
            this.tbxPublisherName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(21, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "İade Tarihi: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(12, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "KİTAP BİLGİLERİ";
            // 
            // tbxSearchBook
            // 
            this.tbxSearchBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxSearchBook.Location = new System.Drawing.Point(252, 340);
            this.tbxSearchBook.Name = "tbxSearchBook";
            this.tbxSearchBook.Size = new System.Drawing.Size(159, 24);
            this.tbxSearchBook.TabIndex = 10;
            this.tbxSearchBook.TextChanged += new System.EventHandler(this.tbxSearchBook_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(171, 344);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 6;
            this.label11.Text = "Kitap Ara: ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxSearchMembers
            // 
            this.tbxSearchMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxSearchMembers.Location = new System.Drawing.Point(715, 337);
            this.tbxSearchMembers.Name = "tbxSearchMembers";
            this.tbxSearchMembers.Size = new System.Drawing.Size(159, 24);
            this.tbxSearchMembers.TabIndex = 10;
            this.tbxSearchMembers.TextChanged += new System.EventHandler(this.tbxSearchMembers_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(641, 342);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 6;
            this.label12.Text = "Üye Ara: ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(495, 341);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 20);
            this.label13.TabIndex = 7;
            this.label13.Text = "ÜYE BİLGİLERİ";
            // 
            // gbxInformation
            // 
            this.gbxInformation.Controls.Add(this.label18);
            this.gbxInformation.Controls.Add(this.label17);
            this.gbxInformation.Controls.Add(this.label19);
            this.gbxInformation.Controls.Add(this.label15);
            this.gbxInformation.Controls.Add(this.label14);
            this.gbxInformation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbxInformation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxInformation.Location = new System.Drawing.Point(833, 13);
            this.gbxInformation.Name = "gbxInformation";
            this.gbxInformation.Size = new System.Drawing.Size(205, 226);
            this.gbxInformation.TabIndex = 11;
            this.gbxInformation.TabStop = false;
            this.gbxInformation.Text = "Bilgi Kutusu";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Location = new System.Drawing.Point(6, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(113, 40);
            this.label18.TabIndex = 0;
            this.label18.Text = "Bugüne Kadar \r\nKiralanan Adet";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(6, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(174, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Anlık Kiralanan Kitaplar";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Location = new System.Drawing.Point(6, 181);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(135, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "Toplam Üye Sayısı";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(6, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 20);
            this.label15.TabIndex = 0;
            this.label15.Text = "Saat";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(6, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 20);
            this.label14.TabIndex = 0;
            this.label14.Text = "Tarih";
            // 
            // btnProcesDone
            // 
            this.btnProcesDone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProcesDone.Location = new System.Drawing.Point(397, 274);
            this.btnProcesDone.Name = "btnProcesDone";
            this.btnProcesDone.Size = new System.Drawing.Size(175, 51);
            this.btnProcesDone.TabIndex = 12;
            this.btnProcesDone.Text = "Tamamla";
            this.btnProcesDone.UseVisualStyleBackColor = true;
            this.btnProcesDone.Click += new System.EventHandler(this.btnProcesDone_Click);
            // 
            // btnStateOfDue
            // 
            this.btnStateOfDue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStateOfDue.Location = new System.Drawing.Point(833, 274);
            this.btnStateOfDue.Name = "btnStateOfDue";
            this.btnStateOfDue.Size = new System.Drawing.Size(205, 51);
            this.btnStateOfDue.TabIndex = 13;
            this.btnStateOfDue.Text = "İade Durumu";
            this.btnStateOfDue.UseVisualStyleBackColor = true;
            this.btnStateOfDue.Click += new System.EventHandler(this.btnStateOfDue_Click);
            // 
            // frmBookLoans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1050, 540);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStateOfDue);
            this.Controls.Add(this.btnProcesDone);
            this.Controls.Add(this.gbxInformation);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbxSearchMembers);
            this.Controls.Add(this.gbxBooks);
            this.Controls.Add(this.tbxSearchBook);
            this.Controls.Add(this.gbxMembers);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.dgwBooks);
            this.Controls.Add(this.dgwMember);
            this.Name = "frmBookLoans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitap Kirala";
            this.Load += new System.EventHandler(this.frmBookLoans_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwBooks)).EndInit();
            this.gbxMembers.ResumeLayout(false);
            this.gbxMembers.PerformLayout();
            this.gbxBooks.ResumeLayout(false);
            this.gbxBooks.PerformLayout();
            this.gbxInformation.ResumeLayout(false);
            this.gbxInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwMember;
        private System.Windows.Forms.DataGridView dgwBooks;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.GroupBox gbxMembers;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxBirthDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxIdentityNumber;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.GroupBox gbxBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxBookName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxStocks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPageCount;
        private System.Windows.Forms.TextBox tbxPublisherName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxSearchBook;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxSearchMembers;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbxInformation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbxAuthorName;
        private System.Windows.Forms.Button btnProcesDone;
        private System.Windows.Forms.Button btnStateOfDue;
    }
}