namespace KütüphaneOtomasyonuBerke
{
    partial class frmStateOfDue
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
            this.dgwCompletedReturns = new System.Windows.Forms.DataGridView();
            this.dgwNotCompletedReturns = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxSearchInCompleted = new System.Windows.Forms.TextBox();
            this.tbxSearchInNotCompleted = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxInformation = new System.Windows.Forms.GroupBox();
            this.btnReturnProccessDone = new System.Windows.Forms.Button();
            this.tbxDueDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxLoanDate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxBookName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgwCompletedReturns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNotCompletedReturns)).BeginInit();
            this.gbxInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwCompletedReturns
            // 
            this.dgwCompletedReturns.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgwCompletedReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwCompletedReturns.GridColor = System.Drawing.Color.LightSlateGray;
            this.dgwCompletedReturns.Location = new System.Drawing.Point(12, 288);
            this.dgwCompletedReturns.Name = "dgwCompletedReturns";
            this.dgwCompletedReturns.Size = new System.Drawing.Size(509, 240);
            this.dgwCompletedReturns.TabIndex = 0;
            // 
            // dgwNotCompletedReturns
            // 
            this.dgwNotCompletedReturns.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgwNotCompletedReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwNotCompletedReturns.Location = new System.Drawing.Point(527, 288);
            this.dgwNotCompletedReturns.Name = "dgwNotCompletedReturns";
            this.dgwNotCompletedReturns.Size = new System.Drawing.Size(511, 240);
            this.dgwNotCompletedReturns.TabIndex = 0;
            this.dgwNotCompletedReturns.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwNotCompletedReturns_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(21, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "İADE EDİLENLER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(259, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ara: ";
            // 
            // tbxSearchInCompleted
            // 
            this.tbxSearchInCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxSearchInCompleted.Location = new System.Drawing.Point(315, 248);
            this.tbxSearchInCompleted.Name = "tbxSearchInCompleted";
            this.tbxSearchInCompleted.Size = new System.Drawing.Size(141, 27);
            this.tbxSearchInCompleted.TabIndex = 3;
            this.tbxSearchInCompleted.TextChanged += new System.EventHandler(this.tbxSearchInCompleted_TextChanged);
            // 
            // tbxSearchInNotCompleted
            // 
            this.tbxSearchInNotCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxSearchInNotCompleted.Location = new System.Drawing.Point(894, 255);
            this.tbxSearchInNotCompleted.Name = "tbxSearchInNotCompleted";
            this.tbxSearchInNotCompleted.Size = new System.Drawing.Size(141, 27);
            this.tbxSearchInNotCompleted.TabIndex = 6;
            this.tbxSearchInNotCompleted.TextChanged += new System.EventHandler(this.tbxSearchInNotCompleted_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(838, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ara: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(554, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "İADE EDİLMEYENLER";
            // 
            // gbxInformation
            // 
            this.gbxInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.gbxInformation.Controls.Add(this.btnReturnProccessDone);
            this.gbxInformation.Controls.Add(this.tbxDueDate);
            this.gbxInformation.Controls.Add(this.label9);
            this.gbxInformation.Controls.Add(this.tbxLoanDate);
            this.gbxInformation.Controls.Add(this.label8);
            this.gbxInformation.Controls.Add(this.tbxBookName);
            this.gbxInformation.Controls.Add(this.label7);
            this.gbxInformation.Controls.Add(this.tbxLastName);
            this.gbxInformation.Controls.Add(this.label6);
            this.gbxInformation.Controls.Add(this.tbxFirstName);
            this.gbxInformation.Controls.Add(this.label5);
            this.gbxInformation.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gbxInformation.Location = new System.Drawing.Point(447, 12);
            this.gbxInformation.Name = "gbxInformation";
            this.gbxInformation.Size = new System.Drawing.Size(591, 220);
            this.gbxInformation.TabIndex = 7;
            this.gbxInformation.TabStop = false;
            this.gbxInformation.Text = "Bilgi Kutusu";
            // 
            // btnReturnProccessDone
            // 
            this.btnReturnProccessDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.btnReturnProccessDone.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReturnProccessDone.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReturnProccessDone.Location = new System.Drawing.Point(148, 157);
            this.btnReturnProccessDone.Name = "btnReturnProccessDone";
            this.btnReturnProccessDone.Size = new System.Drawing.Size(308, 43);
            this.btnReturnProccessDone.TabIndex = 10;
            this.btnReturnProccessDone.Text = "İade Edildi";
            this.btnReturnProccessDone.UseVisualStyleBackColor = false;
            this.btnReturnProccessDone.Click += new System.EventHandler(this.btnReturnProccessDone_Click);
            // 
            // tbxDueDate
            // 
            this.tbxDueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxDueDate.Location = new System.Drawing.Point(381, 74);
            this.tbxDueDate.Name = "tbxDueDate";
            this.tbxDueDate.Size = new System.Drawing.Size(195, 22);
            this.tbxDueDate.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(247, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 21);
            this.label9.TabIndex = 8;
            this.label9.Text = "Verilecek Tarih: ";
            // 
            // tbxLoanDate
            // 
            this.tbxLoanDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxLoanDate.Location = new System.Drawing.Point(381, 26);
            this.tbxLoanDate.Name = "tbxLoanDate";
            this.tbxLoanDate.Size = new System.Drawing.Size(195, 22);
            this.tbxLoanDate.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(257, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Verildiği Tarih: ";
            // 
            // tbxBookName
            // 
            this.tbxBookName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxBookName.Location = new System.Drawing.Point(89, 118);
            this.tbxBookName.Name = "tbxBookName";
            this.tbxBookName.Size = new System.Drawing.Size(152, 22);
            this.tbxBookName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(23, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 21);
            this.label7.TabIndex = 4;
            this.label7.Text = "Kitap: ";
            // 
            // tbxLastName
            // 
            this.tbxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxLastName.Location = new System.Drawing.Point(89, 74);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(152, 22);
            this.tbxLastName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(14, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Soyad: ";
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxFirstName.Location = new System.Drawing.Point(89, 28);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(152, 22);
            this.tbxFirstName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(42, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ad: ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(70)))), ((int)(((byte)(229)))));
            this.label10.Location = new System.Drawing.Point(39, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(353, 40);
            this.label10.TabIndex = 12;
            this.label10.Text = "Kütüphane Otomasyonu";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(243)))), ((int)(((byte)(246)))));
            this.label11.Location = new System.Drawing.Point(68, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(297, 91);
            this.label11.TabIndex = 13;
            this.label11.Text = "Kiralanan kitapları hangi üyelerimiz kiraladı hangileri iade etti ve hangileri ia" +
    "de etmedi burdan çok net bir şekilde görebilirsiniz";
            // 
            // frmStateOfDue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(24)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1050, 540);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gbxInformation);
            this.Controls.Add(this.tbxSearchInNotCompleted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbxSearchInCompleted);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgwNotCompletedReturns);
            this.Controls.Add(this.dgwCompletedReturns);
            this.Name = "frmStateOfDue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İade Durumları";
            this.Load += new System.EventHandler(this.frmStateOfDue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwCompletedReturns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgwNotCompletedReturns)).EndInit();
            this.gbxInformation.ResumeLayout(false);
            this.gbxInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwCompletedReturns;
        private System.Windows.Forms.DataGridView dgwNotCompletedReturns;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxSearchInCompleted;
        private System.Windows.Forms.TextBox tbxSearchInNotCompleted;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbxInformation;
        private System.Windows.Forms.Button btnReturnProccessDone;
        private System.Windows.Forms.TextBox tbxDueDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxLoanDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxBookName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}