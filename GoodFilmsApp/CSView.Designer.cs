namespace GoodFilmsApp
{
    partial class CSView
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
            this.checkBoxNewFile = new System.Windows.Forms.CheckBox();
            this.checkBoxAppend = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTextQualifier = new System.Windows.Forms.TextBox();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.lblPathAndName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxNewFile
            // 
            this.checkBoxNewFile.AutoSize = true;
            this.checkBoxNewFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxNewFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBoxNewFile.Location = new System.Drawing.Point(-1, 70);
            this.checkBoxNewFile.Name = "checkBoxNewFile";
            this.checkBoxNewFile.Size = new System.Drawing.Size(92, 17);
            this.checkBoxNewFile.TabIndex = 30;
            this.checkBoxNewFile.Text = "Pick New FIle";
            this.checkBoxNewFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxNewFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxAppend
            // 
            this.checkBoxAppend.AutoSize = true;
            this.checkBoxAppend.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAppend.Location = new System.Drawing.Point(28, 93);
            this.checkBoxAppend.Name = "checkBoxAppend";
            this.checkBoxAppend.Size = new System.Drawing.Size(63, 17);
            this.checkBoxAppend.TabIndex = 29;
            this.checkBoxAppend.Text = "Append";
            this.checkBoxAppend.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Text Qualifier:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Delimiter:";
            // 
            // txtTextQualifier
            // 
            this.txtTextQualifier.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTextQualifier.Location = new System.Drawing.Point(107, 35);
            this.txtTextQualifier.Name = "txtTextQualifier";
            this.txtTextQualifier.Size = new System.Drawing.Size(69, 20);
            this.txtTextQualifier.TabIndex = 26;
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Location = new System.Drawing.Point(24, 35);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(67, 20);
            this.txtDelimiter.TabIndex = 25;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(12, 168);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAs.TabIndex = 24;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // lblPathAndName
            // 
            this.lblPathAndName.AutoSize = true;
            this.lblPathAndName.Location = new System.Drawing.Point(9, 130);
            this.lblPathAndName.Name = "lblPathAndName";
            this.lblPathAndName.Size = new System.Drawing.Size(0, 13);
            this.lblPathAndName.TabIndex = 31;
            // 
            // CSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 203);
            this.Controls.Add(this.lblPathAndName);
            this.Controls.Add(this.checkBoxNewFile);
            this.Controls.Add(this.checkBoxAppend);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTextQualifier);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.btnSaveAs);
            this.Name = "CSView";
            this.Text = "Saving FIle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxNewFile;
        private System.Windows.Forms.CheckBox checkBoxAppend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTextQualifier;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Label lblPathAndName;
    }
}