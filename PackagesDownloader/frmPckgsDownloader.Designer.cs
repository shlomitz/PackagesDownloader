namespace PackagesDownloader
{
    partial class frmPckgsDownloader
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblCurrentNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalNo = new System.Windows.Forms.Label();
            this.cmbxDownloadType = new System.Windows.Forms.ComboBox();
            this.rdbDownloadPckgs = new System.Windows.Forms.RadioButton();
            this.rdbDownloadHash = new System.Windows.Forms.RadioButton();
            this.dpDownloadFDate = new System.Windows.Forms.DateTimePicker();
            this.txtSourceUrl = new System.Windows.Forms.TextBox();
            this.fbDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnFolderDlg = new System.Windows.Forms.Label();
            this.numTopX = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numTopX)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(134, 387);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(254, 84);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lblCurrentNo
            // 
            this.lblCurrentNo.AutoSize = true;
            this.lblCurrentNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentNo.Location = new System.Drawing.Point(157, 488);
            this.lblCurrentNo.Name = "lblCurrentNo";
            this.lblCurrentNo.Size = new System.Drawing.Size(83, 29);
            this.lblCurrentNo.TabIndex = 1;
            this.lblCurrentNo.Text = "00000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "/";
            // 
            // lblTotalNo
            // 
            this.lblTotalNo.AutoSize = true;
            this.lblTotalNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNo.Location = new System.Drawing.Point(249, 488);
            this.lblTotalNo.Name = "lblTotalNo";
            this.lblTotalNo.Size = new System.Drawing.Size(83, 29);
            this.lblTotalNo.TabIndex = 3;
            this.lblTotalNo.Text = "00000";
            // 
            // cmbxDownloadType
            // 
            this.cmbxDownloadType.FormattingEnabled = true;
            this.cmbxDownloadType.Items.AddRange(new object[] {
            "ALL",
            "TOP X",
            "TOP X FROM DATE"});
            this.cmbxDownloadType.Location = new System.Drawing.Point(192, 41);
            this.cmbxDownloadType.Name = "cmbxDownloadType";
            this.cmbxDownloadType.Size = new System.Drawing.Size(278, 24);
            this.cmbxDownloadType.TabIndex = 4;
            this.cmbxDownloadType.SelectedIndexChanged += new System.EventHandler(this.cmbxDownloadType_SelectedIndexChanged);
            // 
            // rdbDownloadPckgs
            // 
            this.rdbDownloadPckgs.AutoSize = true;
            this.rdbDownloadPckgs.Checked = true;
            this.rdbDownloadPckgs.Location = new System.Drawing.Point(191, 191);
            this.rdbDownloadPckgs.Name = "rdbDownloadPckgs";
            this.rdbDownloadPckgs.Size = new System.Drawing.Size(162, 21);
            this.rdbDownloadPckgs.TabIndex = 5;
            this.rdbDownloadPckgs.TabStop = true;
            this.rdbDownloadPckgs.Text = "DOWNLOAD PCKGS";
            this.rdbDownloadPckgs.UseVisualStyleBackColor = true;
            // 
            // rdbDownloadHash
            // 
            this.rdbDownloadHash.AutoSize = true;
            this.rdbDownloadHash.Location = new System.Drawing.Point(191, 226);
            this.rdbDownloadHash.Name = "rdbDownloadHash";
            this.rdbDownloadHash.Size = new System.Drawing.Size(153, 21);
            this.rdbDownloadHash.TabIndex = 6;
            this.rdbDownloadHash.TabStop = true;
            this.rdbDownloadHash.Text = "DOWNLOAD HASH";
            this.rdbDownloadHash.UseVisualStyleBackColor = true;
            // 
            // dpDownloadFDate
            // 
            this.dpDownloadFDate.CustomFormat = "";
            this.dpDownloadFDate.Enabled = false;
            this.dpDownloadFDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDownloadFDate.Location = new System.Drawing.Point(192, 141);
            this.dpDownloadFDate.Name = "dpDownloadFDate";
            this.dpDownloadFDate.Size = new System.Drawing.Size(278, 22);
            this.dpDownloadFDate.TabIndex = 7;
            // 
            // txtSourceUrl
            // 
            this.txtSourceUrl.Location = new System.Drawing.Point(191, 271);
            this.txtSourceUrl.Name = "txtSourceUrl";
            this.txtSourceUrl.Size = new System.Drawing.Size(279, 22);
            this.txtSourceUrl.TabIndex = 8;
            this.txtSourceUrl.Text = "http:\\\\";
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Enabled = false;
            this.txtDestinationFolder.Location = new System.Drawing.Point(190, 325);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.Size = new System.Drawing.Size(280, 22);
            this.txtDestinationFolder.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "DOWNLOAD TYPE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "FROM DATE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "DOWNLOAD METHOD";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "SOURCE URL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "SAVE TO";
            // 
            // btnFolderDlg
            // 
            this.btnFolderDlg.AutoSize = true;
            this.btnFolderDlg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderDlg.Location = new System.Drawing.Point(471, 330);
            this.btnFolderDlg.Name = "btnFolderDlg";
            this.btnFolderDlg.Size = new System.Drawing.Size(24, 20);
            this.btnFolderDlg.TabIndex = 16;
            this.btnFolderDlg.Text = "...";
            this.btnFolderDlg.Click += new System.EventHandler(this.btnFolderDlg_Click);
            // 
            // numTopX
            // 
            this.numTopX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTopX.Location = new System.Drawing.Point(192, 93);
            this.numTopX.Name = "numTopX";
            this.numTopX.Size = new System.Drawing.Size(217, 24);
            this.numTopX.TabIndex = 17;
            this.numTopX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numTopX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "TOP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(415, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 19;
            this.label8.Text = "PCKGS";
            // 
            // frmPckgsDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 541);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numTopX);
            this.Controls.Add(this.btnFolderDlg);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDestinationFolder);
            this.Controls.Add(this.txtSourceUrl);
            this.Controls.Add(this.dpDownloadFDate);
            this.Controls.Add(this.rdbDownloadHash);
            this.Controls.Add(this.rdbDownloadPckgs);
            this.Controls.Add(this.cmbxDownloadType);
            this.Controls.Add(this.lblTotalNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCurrentNo);
            this.Controls.Add(this.btnDownload);
            this.Name = "frmPckgsDownloader";
            this.Text = "Packages Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPckgsDownloader_FormClosing);
            this.Load += new System.EventHandler(this.frmPckgsDownloader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTopX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblCurrentNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalNo;
        private System.Windows.Forms.ComboBox cmbxDownloadType;
        private System.Windows.Forms.RadioButton rdbDownloadPckgs;
        private System.Windows.Forms.RadioButton rdbDownloadHash;
        private System.Windows.Forms.DateTimePicker dpDownloadFDate;
        private System.Windows.Forms.TextBox txtSourceUrl;
        private System.Windows.Forms.FolderBrowserDialog fbDialog;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label btnFolderDlg;
        private System.Windows.Forms.NumericUpDown numTopX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

