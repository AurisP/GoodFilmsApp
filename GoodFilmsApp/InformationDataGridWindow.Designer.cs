namespace GoodFilmsApp
{
    partial class InformationDataGridWindow
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
            this.dgwMain = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMain)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwMain
            // 
            this.dgwMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMain.Location = new System.Drawing.Point(0, 56);
            this.dgwMain.Name = "dgwMain";
            this.dgwMain.ReadOnly = true;
            this.dgwMain.RowHeadersVisible = false;
            this.dgwMain.Size = new System.Drawing.Size(300, 244);
            this.dgwMain.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(230, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(58, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Okay";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // InformationDataGridWİndow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgwMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InformationDataGridWİndow";
            this.Text = "InformationDataGridWİndow";
            this.Load += new System.EventHandler(this.InformationDataGridWİndow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwMain;
        private System.Windows.Forms.Button btnSave;
    }
}