﻿namespace GoodFilmsApp
{
    partial class DataGridWindow
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
            this.btnSave = new System.Windows.Forms.Button();
            this.dgwMain = new System.Windows.Forms.DataGridView();
            this.tBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgwMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(382, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 20);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Okay";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgwMain
            // 
            this.dgwMain.AllowUserToAddRows = false;
            this.dgwMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwMain.Location = new System.Drawing.Point(12, 58);
            this.dgwMain.Name = "dgwMain";
            this.dgwMain.RowHeadersVisible = false;
            this.dgwMain.Size = new System.Drawing.Size(441, 345);
            this.dgwMain.TabIndex = 1;
            // 
            // tBox
            // 
            this.tBox.Location = new System.Drawing.Point(12, 22);
            this.tBox.Name = "tBox";
            this.tBox.Size = new System.Drawing.Size(349, 20);
            this.tBox.TabIndex = 2;
            this.tBox.TextChanged += new System.EventHandler(this.tBox_TextChanged);
            // 
            // DataGridWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(465, 415);
            this.Controls.Add(this.tBox);
            this.Controls.Add(this.dgwMain);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DataGridWindow";
            this.Text = "DataGridWindow";
            ((System.ComponentModel.ISupportInitialize)(this.dgwMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgwMain;
        private System.Windows.Forms.TextBox tBox;
    }
}