namespace KütüphaneOtomasyonuBerke
{
    partial class frmUpdateMembers
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
            this.chkSuperAdmin = new System.Windows.Forms.CheckBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.chkMember = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMan
            // 
            this.rbMan.AutoSize = true;
            this.rbMan.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbMan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbMan.Location = new System.Drawing.Point(762, 218);
            this.rbMan.Name = "rbMan";
            this.rbMan.Size = new System.Drawing.Size(105, 41);
            this.rbMan.TabIndex = 16;
            this.rbMan.TabStop = true;
            this.rbMan.Text = "Erkek";
            this.rbMan.UseVisualStyleBackColor = true;
            // 
            // rbWoman
            // 
            this.rbWoman.AutoSize = true;
            this.rbWoman.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbWoman.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rbWoman.Location = new System.Drawing.Point(640, 218);
            this.rbWoman.Name = "rbWoman";
            this.rbWoman.Size = new System.Drawing.Size(109, 41);
            this.rbWoman.TabIndex = 17;
            this.rbWoman.TabStop = true;
            this.rbWoman.Text = "Kadın";
            this.rbWoman.UseVisualStyleBackColor = true;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtpBirthDate.Location = new System.Drawing.Point(636, 174);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(259, 31);
            this.dtpBirthDate.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(420, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 40);
            this.label4.TabIndex = 4;
            this.label4.Text = "Doğum Tarihi: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxPassword.Location = new System.Drawing.Point(636, 317);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(259, 31);
            this.tbxPassword.TabIndex = 10;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxLastName.Location = new System.Drawing.Point(636, 82);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(259, 31);
            this.tbxLastName.TabIndex = 11;
            // 
            // tbxIdentityNumber
            // 
            this.tbxIdentityNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxIdentityNumber.Location = new System.Drawing.Point(636, 128);
            this.tbxIdentityNumber.Name = "tbxIdentityNumber";
            this.tbxIdentityNumber.Size = new System.Drawing.Size(259, 31);
            this.tbxIdentityNumber.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(534, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 40);
            this.label6.TabIndex = 5;
            this.label6.Text = "Şifre: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(513, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = "Soyad: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(520, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 40);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tc No: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tbxUserName
            // 
            this.tbxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxUserName.Location = new System.Drawing.Point(636, 268);
            this.tbxUserName.Name = "tbxUserName";
            this.tbxUserName.Size = new System.Drawing.Size(259, 31);
            this.tbxUserName.TabIndex = 13;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxFirstName.Location = new System.Drawing.Point(636, 37);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(259, 31);
            this.tbxFirstName.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(426, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 40);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kullanıcı Adı: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(559, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ad: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // chkSuperAdmin
            // 
            this.chkSuperAdmin.AutoSize = true;
            this.chkSuperAdmin.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkSuperAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkSuperAdmin.Location = new System.Drawing.Point(587, 420);
            this.chkSuperAdmin.Name = "chkSuperAdmin";
            this.chkSuperAdmin.Size = new System.Drawing.Size(124, 36);
            this.chkSuperAdmin.TabIndex = 18;
            this.chkSuperAdmin.Text = "Yönetici";
            this.chkSuperAdmin.UseVisualStyleBackColor = true;
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkAdmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkAdmin.Location = new System.Drawing.Point(587, 387);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(156, 36);
            this.chkAdmin.TabIndex = 19;
            this.chkAdmin.Text = "Moderatör";
            this.chkAdmin.UseVisualStyleBackColor = true;
            // 
            // chkMember
            // 
            this.chkMember.AutoSize = true;
            this.chkMember.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.chkMember.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkMember.Location = new System.Drawing.Point(587, 355);
            this.chkMember.Name = "chkMember";
            this.chkMember.Size = new System.Drawing.Size(169, 36);
            this.chkMember.TabIndex = 20;
            this.chkMember.Text = "Normal Üye";
            this.chkMember.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpdate.Location = new System.Drawing.Point(762, 355);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(137, 55);
            this.btnUpdate.TabIndex = 21;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.Location = new System.Drawing.Point(762, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(137, 55);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "İptal Et";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 540);
            this.panel1.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.label8.Location = new System.Drawing.Point(25, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(278, 39);
            this.label8.TabIndex = 24;
            this.label8.Text = "Kütüphanemize eklenen üyeleri bu sayfadan güncelleyebilirsiniz";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.label7.Location = new System.Drawing.Point(4, 184);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(328, 37);
            this.label7.TabIndex = 23;
            this.label7.Text = "Kütüphane Otomasyonu";
            // 
            // frmUpdateMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(1050, 540);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.chkSuperAdmin);
            this.Controls.Add(this.chkAdmin);
            this.Controls.Add(this.chkMember);
            this.Controls.Add(this.rbMan);
            this.Controls.Add(this.rbWoman);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxLastName);
            this.Controls.Add(this.tbxIdentityNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxUserName);
            this.Controls.Add(this.tbxFirstName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "frmUpdateMembers";
            this.Text = "Üye Güncelle";
            this.Load += new System.EventHandler(this.frmUpdateMembers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbMan;
        private System.Windows.Forms.RadioButton rbWoman;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.TextBox tbxIdentityNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxUserName;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSuperAdmin;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.CheckBox chkMember;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}