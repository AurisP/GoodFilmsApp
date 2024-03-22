namespace GoodFilmsApp
{
    partial class mainView
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
            this.testBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // testBox
            // 
            this.testBox.FormattingEnabled = true;
            this.testBox.ItemHeight = 16;
            this.testBox.Location = new System.Drawing.Point(100, 73);
            this.testBox.Name = "testBox";
            this.testBox.Size = new System.Drawing.Size(231, 212);
            this.testBox.TabIndex = 0;
            
            // 
            // mainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testBox);
            this.Name = "mainView";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox testBox;
    }
}

