namespace KütüphaneOtomasyonuBerke
{
    partial class frmMembers
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
            this.gbxInsertMember = new System.Windows.Forms.GroupBox();
            this.btnÜyeGeri = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.chkSuperAdmin = new System.Windows.Forms.CheckBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.chkMember = new System.Windows.Forms.CheckBox();
            this.rbMan = new System.Windows.Forms.RadioButton();
            this.rbWoman = new System.Windows.Forms.RadioButton();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.tbxIdentityNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxUserName = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgwMembers = new System.Windows.Forms.DataGridView();
            this.tbxMember = new System.Windows.Forms.TextBox();
            this.gbxUpdate = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxUpdateName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxUpdateRoles = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxUpdateIdentity = new System.Windows.Forms.TextBox();
            this.tbxUpdateLastName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbxInsertMember.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMembers)).BeginInit();
            this.gbxUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxInsertMember
            // 
            this.gbxInsertMember.Controls.Add(this.btnÜyeGeri);
            this.gbxInsertMember.Controls.Add(this.btnInsert);
            this.gbxInsertMember.Controls.Add(this.chkSuperAdmin);
            this.gbxInsertMember.Controls.Add(this.chkAdmin);
            this.gbxInsertMember.Controls.Add(this.chkMember);
            this.gbxInsertMember.Controls.Add(this.rbMan);
            this.gbxInsertMember.Controls.Add(this.rbWoman);
            this.gbxInsertMember.Controls.Add(this.dtpBirthDate);
            this.gbxInsertMember.Controls.Add(this.label4);
            this.gbxInsertMember.Controls.Add(this.tbxPassword);
            this.gbxInsertMember.Controls.Add(this.tbxLastName);
            this.gbxInsertMember.Controls.Add(this.tbxIdentityNumber);
            this.gbxInsertMember.Controls.Add(this.label6);
            this.gbxInsertMember.Controls.Add(this.label2);
            this.gbxInsertMember.Controls.Add(this.label3);
            this.gbxInsertMember.Controls.Add(this.tbxUserName);
            this.gbxInsertMember.Controls.Add(this.tbxFirstName);
            this.gbxInsertMember.Controls.Add(this.label5);
            this.gbxInsertMember.Controls.Add(this.label1);
            this.gbxInsertMember.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxInsertMember.Location = new System.Drawing.Point(430, 12);
            this.gbxInsertMember.Name = "gbxInsertMember";
            this.gbxInsertMember.Size = new System.Drawing.Size(608, 326);
            this.gbxInsertMember.TabIndex = 0;
            this.gbxInsertMember.TabStop = false;
            this.gbxInsertMember.Text = "Üye Ekle";
            // 
            // btnÜyeGeri
            // 
            this.btnÜyeGeri.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnÜyeGeri.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnÜyeGeri.Location = new System.Drawing.Point(416, 253);
            this.btnÜyeGeri.Name = "btnÜyeGeri";
            this.btnÜyeGeri.Size = new System.Drawing.Size(156, 54);
            this.btnÜyeGeri.TabIndex = 6;
            this.btnÜyeGeri.Text = "Geri Dön";
            this.btnÜyeGeri.UseVisualStyleBackColor = true;
            this.btnÜyeGeri.Click += new System.EventHandler(this.btnÜyeGeri_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnInsert.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnInsert.Location = new System.Drawing.Point(416, 191);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(156, 54);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Kaydet";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // chkSuperAdmin
            // 
            this.chkSuperAdmin.AutoSize = true;
            this.chkSuperAdmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkSuperAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkSuperAdmin.Location = new System.Drawing.Point(462, 93);
            this.chkSuperAdmin.Name = "chkSuperAdmin";
            this.chkSuperAdmin.Size = new System.Drawing.Size(91, 25);
            this.chkSuperAdmin.TabIndex = 4;
            this.chkSuperAdmin.Text = "Yönetici";
            this.chkSuperAdmin.UseVisualStyleBackColor = true;
            this.chkSuperAdmin.CheckedChanged += new System.EventHandler(this.chkSuperAdmin_CheckedChanged);
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkAdmin.Location = new System.Drawing.Point(462, 63);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(110, 25);
            this.chkAdmin.TabIndex = 4;
            this.chkAdmin.Text = "Moderatör";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // chkMember
            // 
            this.chkMember.AutoSize = true;
            this.chkMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkMember.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkMember.Location = new System.Drawing.Point(462, 33);
            this.chkMember.Name = "chkMember";
            this.chkMember.Size = new System.Drawing.Size(121, 25);
            this.chkMember.TabIndex = 4;
            this.chkMember.Text = "Normal Üye";
            this.chkMember.UseVisualStyleBackColor = true;
            // 
            // rbMan
            // 
            this.rbMan.AutoSize = true;
            this.rbMan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbMan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbMan.Location = new System.Drawing.Point(266, 191);
            this.rbMan.Name = "rbMan";
            this.rbMan.Size = new System.Drawing.Size(66, 25);
            this.rbMan.TabIndex = 3;
            this.rbMan.TabStop = true;
            this.rbMan.Text = "Erkek";
            this.rbMan.UseVisualStyleBackColor = true;
            // 
            // rbWoman
            // 
            this.rbWoman.AutoSize = true;
            this.rbWoman.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbWoman.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbWoman.Location = new System.Drawing.Point(144, 191);
            this.rbWoman.Name = "rbWoman";
            this.rbWoman.Size = new System.Drawing.Size(67, 25);
            this.rbWoman.TabIndex = 3;
            this.rbWoman.TabStop = true;
            this.rbWoman.Text = "Kadın";
            this.rbWoman.UseVisualStyleBackColor = true;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpBirthDate.Location = new System.Drawing.Point(144, 139);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(259, 29);
            this.dtpBirthDate.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(16, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Doğum Tarihi: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxPassword.Location = new System.Drawing.Point(144, 264);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(259, 29);
            this.tbxPassword.TabIndex = 1;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxLastName.Location = new System.Drawing.Point(144, 61);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(259, 29);
            this.tbxLastName.TabIndex = 1;
            // 
            // tbxIdentityNumber
            // 
            this.tbxIdentityNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxIdentityNumber.Location = new System.Drawing.Point(144, 101);
            this.tbxIdentityNumber.Name = "tbxIdentityNumber";
            this.tbxIdentityNumber.Size = new System.Drawing.Size(259, 29);
            this.tbxIdentityNumber.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(82, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Şifre: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(77, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyad: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(78, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tc No: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxUserName
            // 
            this.tbxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxUserName.Location = new System.Drawing.Point(144, 224);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(259, 29);
            this.tbxUserName.TabIndex = 1;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxFirstName.Location = new System.Drawing.Point(144, 26);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(259, 29);
            this.tbxFirstName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(16, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Kullanıcı Adı: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(106, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dgwMembers
            // 
            this.dgwMembers.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgwMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMembers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgwMembers.Location = new System.Drawing.Point(0, 335);
            this.dgwMembers.Name = "dgwMembers";
            this.dgwMembers.Size = new System.Drawing.Size(1050, 205);
            this.dgwMembers.TabIndex = 1;
            this.dgwMembers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwMembers_CellClick);
            // 
            // tbxMember
            // 
            this.tbxMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxMember.Location = new System.Drawing.Point(96, 299);
            this.tbxMember.Name = "tbxMember";
            this.tbxMember.Size = new System.Drawing.Size(188, 22);
            this.tbxMember.TabIndex = 2;
            this.tbxMember.TextChanged += new System.EventHandler(this.tbxMember_TextChanged);
            // 
            // gbxUpdate
            // 
            this.gbxUpdate.Controls.Add(this.btnDelete);
            this.gbxUpdate.Controls.Add(this.btnUpdate);
            this.gbxUpdate.Controls.Add(this.label7);
            this.gbxUpdate.Controls.Add(this.tbxUpdateName);
            this.gbxUpdate.Controls.Add(this.label10);
            this.gbxUpdate.Controls.Add(this.label8);
            this.gbxUpdate.Controls.Add(this.tbxUpdateRoles);
            this.gbxUpdate.Controls.Add(this.label9);
            this.gbxUpdate.Controls.Add(this.tbxUpdateIdentity);
            this.gbxUpdate.Controls.Add(this.tbxUpdateLastName);
            this.gbxUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxUpdate.Location = new System.Drawing.Point(12, 12);
            this.gbxUpdate.Name = "gbxUpdate";
            this.gbxUpdate.Size = new System.Drawing.Size(349, 271);
            this.gbxUpdate.TabIndex = 5;
            this.gbxUpdate.TabStop = false;
            this.gbxUpdate.Text = "Güncelle";
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDelete.Location = new System.Drawing.Point(214, 203);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 52);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUpdate.Location = new System.Drawing.Point(84, 203);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(108, 52);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(22, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Ad: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxUpdateName
            // 
            this.tbxUpdateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxUpdateName.Location = new System.Drawing.Point(84, 16);
            this.tbxUpdateName.Name = "tbxUpdateName";
            this.tbxUpdateName.Size = new System.Drawing.Size(259, 29);
            this.tbxUpdateName.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(9, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 25);
            this.label10.TabIndex = 6;
            this.label10.Text = "Roles: ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(6, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tc No: ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxUpdateRoles
            // 
            this.tbxUpdateRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxUpdateRoles.Location = new System.Drawing.Point(84, 151);
            this.tbxUpdateRoles.Name = "tbxUpdateRoles";
            this.tbxUpdateRoles.Size = new System.Drawing.Size(259, 29);
            this.tbxUpdateRoles.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(5, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Soyad: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxUpdateIdentity
            // 
            this.tbxUpdateIdentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxUpdateIdentity.Location = new System.Drawing.Point(84, 104);
            this.tbxUpdateIdentity.Name = "tbxUpdateIdentity";
            this.tbxUpdateIdentity.Size = new System.Drawing.Size(259, 29);
            this.tbxUpdateIdentity.TabIndex = 11;
            // 
            // tbxUpdateLastName
            // 
            this.tbxUpdateLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxUpdateLastName.Location = new System.Drawing.Point(84, 59);
            this.tbxUpdateLastName.Name = "tbxUpdateLastName";
            this.tbxUpdateLastName.Size = new System.Drawing.Size(259, 29);
            this.tbxUpdateLastName.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(12, 295);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 24);
            this.label11.TabIndex = 5;
            this.label11.Text = "Üye Ara: ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // frmMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1050, 540);
            this.Controls.Add(this.gbxUpdate);
            this.Controls.Add(this.tbxMember);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgwMembers);
            this.Controls.Add(this.gbxInsertMember);
            this.Name = "frmMembers";
            this.Text = "frmMembers";
            this.Load += new System.EventHandler(this.frmMembers_Load);
            this.gbxInsertMember.ResumeLayout(false);
            this.gbxInsertMember.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMembers)).EndInit();
            this.gbxUpdate.ResumeLayout(false);
            this.gbxUpdate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxInsertMember;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.TextBox tbxIdentityNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.CheckBox chkSuperAdmin;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.CheckBox chkMember;
        private System.Windows.Forms.RadioButton rbMan;
        private System.Windows.Forms.RadioButton rbWoman;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgwMembers;
        private System.Windows.Forms.Button btnÜyeGeri;
        private System.Windows.Forms.TextBox tbxMember;
        private System.Windows.Forms.GroupBox gbxUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxUpdateName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxUpdateRoles;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxUpdateIdentity;
        private System.Windows.Forms.TextBox tbxUpdateLastName;
        private System.Windows.Forms.Label label11;
    }
}