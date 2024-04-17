using System;

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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbSearchResults = new System.Windows.Forms.GroupBox();
            this.gbRecommendedFilms = new System.Windows.Forms.GroupBox();
            this.gbScheduledFilms = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testBox
            // 
            this.testBox.FormattingEnabled = true;
            this.testBox.ItemHeight = 16;
            this.testBox.Location = new System.Drawing.Point(924, 814);
            this.testBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.testBox.Name = "testBox";
            this.testBox.Size = new System.Drawing.Size(231, 228);
            this.testBox.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(31, 32);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(605, 22);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(675, 28);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(152, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbSearchResults
            // 
            this.gbSearchResults.Location = new System.Drawing.Point(31, 91);
            this.gbSearchResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSearchResults.Name = "gbSearchResults";
            this.gbSearchResults.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbSearchResults.Size = new System.Drawing.Size(827, 443);
            this.gbSearchResults.TabIndex = 4;
            this.gbSearchResults.TabStop = false;
            this.gbSearchResults.Text = "Search Results";
            // 
            // gbRecommendedFilms
            // 
            this.gbRecommendedFilms.Location = new System.Drawing.Point(31, 559);
            this.gbRecommendedFilms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbRecommendedFilms.Name = "gbRecommendedFilms";
            this.gbRecommendedFilms.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbRecommendedFilms.Size = new System.Drawing.Size(827, 234);
            this.gbRecommendedFilms.TabIndex = 13;
            this.gbRecommendedFilms.TabStop = false;
            this.gbRecommendedFilms.Text = "Recommended Films";
            // 
            // gbScheduledFilms
            // 
            this.gbScheduledFilms.Location = new System.Drawing.Point(31, 814);
            this.gbScheduledFilms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbScheduledFilms.Name = "gbScheduledFilms";
            this.gbScheduledFilms.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gbScheduledFilms.Size = new System.Drawing.Size(827, 234);
            this.gbScheduledFilms.TabIndex = 14;
            this.gbScheduledFilms.TabStop = false;
            this.gbScheduledFilms.Text = "Scheduled Films";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(904, 258);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(157, 38);
            this.btnQuery.TabIndex = 17;
            this.btnQuery.Text = "Filter";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click_1);
            // 
            // mainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 1055);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.gbScheduledFilms);
            this.Controls.Add(this.gbRecommendedFilms);
            this.Controls.Add(this.gbSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.testBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainView";
            this.Text = "GoodFilms App";
            this.Load += new System.EventHandler(this.mainView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox testBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbSearchResults;
        private System.Windows.Forms.GroupBox gbRecommendedFilms;
        private System.Windows.Forms.GroupBox gbScheduledFilms;
        private System.Windows.Forms.Button btnQuery;
    }
}

