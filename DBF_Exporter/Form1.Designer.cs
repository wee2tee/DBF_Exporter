namespace DBF_Exporter
{
    partial class Form1
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnStartExport = new System.Windows.Forms.Button();
            this.lblCounter = new System.Windows.Forms.Label();
            this.btnCancelExport = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioDealer = new System.Windows.Forms.RadioButton();
            this.radioProblem = new System.Windows.Forms.RadioButton();
            this.radioSerial = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Enabled = false;
            this.txtPath.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPath.Location = new System.Drawing.Point(104, 15);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(280, 23);
            this.txtPath.TabIndex = 0;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "เลือกโฟลเดอร์";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnBrowse.Location = new System.Drawing.Point(388, 15);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(67, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnStartExport
            // 
            this.btnStartExport.Enabled = false;
            this.btnStartExport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnStartExport.Location = new System.Drawing.Point(140, 148);
            this.btnStartExport.Name = "btnStartExport";
            this.btnStartExport.Size = new System.Drawing.Size(107, 26);
            this.btnStartExport.TabIndex = 4;
            this.btnStartExport.Text = "เริ่ม Exportข้อมูล";
            this.btnStartExport.UseVisualStyleBackColor = true;
            this.btnStartExport.Click += new System.EventHandler(this.btnStartExport_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.Location = new System.Drawing.Point(20, 104);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(459, 13);
            this.lblCounter.TabIndex = 7;
            this.lblCounter.Text = "0/0";
            this.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancelExport
            // 
            this.btnCancelExport.Enabled = false;
            this.btnCancelExport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancelExport.Location = new System.Drawing.Point(253, 148);
            this.btnCancelExport.Name = "btnCancelExport";
            this.btnCancelExport.Size = new System.Drawing.Size(107, 26);
            this.btnCancelExport.TabIndex = 8;
            this.btnCancelExport.Text = "หยุดการทำงาน";
            this.btnCancelExport.UseVisualStyleBackColor = true;
            this.btnCancelExport.Click += new System.EventHandler(this.btnCancelExport_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(16, 122);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(472, 10);
            this.progressBar1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioSerial);
            this.groupBox1.Controls.Add(this.radioProblem);
            this.groupBox1.Controls.Add(this.radioDealer);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Location = new System.Drawing.Point(16, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 82);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // radioDealer
            // 
            this.radioDealer.AutoSize = true;
            this.radioDealer.Enabled = false;
            this.radioDealer.Location = new System.Drawing.Point(122, 51);
            this.radioDealer.Name = "radioDealer";
            this.radioDealer.Size = new System.Drawing.Size(56, 17);
            this.radioDealer.TabIndex = 3;
            this.radioDealer.TabStop = true;
            this.radioDealer.Text = "Dealer";
            this.radioDealer.UseVisualStyleBackColor = true;
            // 
            // radioProblem
            // 
            this.radioProblem.AutoSize = true;
            this.radioProblem.Enabled = false;
            this.radioProblem.Location = new System.Drawing.Point(205, 51);
            this.radioProblem.Name = "radioProblem";
            this.radioProblem.Size = new System.Drawing.Size(63, 17);
            this.radioProblem.TabIndex = 4;
            this.radioProblem.TabStop = true;
            this.radioProblem.Text = "Problem";
            this.radioProblem.UseVisualStyleBackColor = true;
            // 
            // radioSerial
            // 
            this.radioSerial.AutoSize = true;
            this.radioSerial.Enabled = false;
            this.radioSerial.Location = new System.Drawing.Point(290, 51);
            this.radioSerial.Name = "radioSerial";
            this.radioSerial.Size = new System.Drawing.Size(51, 17);
            this.radioSerial.TabIndex = 5;
            this.radioSerial.TabStop = true;
            this.radioSerial.Text = "Serial";
            this.radioSerial.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 191);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCancelExport);
            this.Controls.Add(this.lblCounter);
            this.Controls.Add(this.btnStartExport);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S/N Exporter";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnStartExport;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Button btnCancelExport;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioSerial;
        private System.Windows.Forms.RadioButton radioProblem;
        private System.Windows.Forms.RadioButton radioDealer;
    }
}

