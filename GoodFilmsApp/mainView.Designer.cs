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
            this.gbFilters = new System.Windows.Forms.GroupBox();
            this.Language = new System.Windows.Forms.ListBox();
            this.Year = new System.Windows.Forms.ListBox();
            this.Director = new System.Windows.Forms.ListBox();
            this.Genre = new System.Windows.Forms.ListBox();
            this.Studio = new System.Windows.Forms.ListBox();
            this.Duration = new System.Windows.Forms.ListBox();

            this.btnQuery = new System.Windows.Forms.Button();

            this.gbFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // testBox
            // 
            this.testBox.FormattingEnabled = true;
            this.testBox.Location = new System.Drawing.Point(693, 661);
            this.testBox.Margin = new System.Windows.Forms.Padding(2);
            this.testBox.Name = "testBox";
            this.testBox.Size = new System.Drawing.Size(174, 186);
            this.testBox.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(23, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(455, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(506, 23);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbSearchResults
            // 
            this.gbSearchResults.Location = new System.Drawing.Point(23, 74);
            this.gbSearchResults.Name = "gbSearchResults";
            this.gbSearchResults.Size = new System.Drawing.Size(620, 360);
            this.gbSearchResults.TabIndex = 4;
            this.gbSearchResults.TabStop = false;
            this.gbSearchResults.Text = "Search Results";
            // 
            // gbRecommendedFilms
            // 
            this.gbRecommendedFilms.Location = new System.Drawing.Point(23, 454);
            this.gbRecommendedFilms.Name = "gbRecommendedFilms";
            this.gbRecommendedFilms.Size = new System.Drawing.Size(620, 190);
            this.gbRecommendedFilms.TabIndex = 13;
            this.gbRecommendedFilms.TabStop = false;
            this.gbRecommendedFilms.Text = "Recommended Films";
            // 
            // gbScheduledFilms
            // 
            this.gbScheduledFilms.Location = new System.Drawing.Point(23, 661);
            this.gbScheduledFilms.Name = "gbScheduledFilms";
            this.gbScheduledFilms.Size = new System.Drawing.Size(620, 190);
            this.gbScheduledFilms.TabIndex = 14;
            this.gbScheduledFilms.TabStop = false;
            this.gbScheduledFilms.Text = "Scheduled Films";
            // 
            // gbFilters
            // 
            this.gbFilters.Controls.Add(this.Language);
            this.gbFilters.Controls.Add(this.Year);
            this.gbFilters.Controls.Add(this.Director);
            this.gbFilters.Controls.Add(this.Genre);
            this.gbFilters.Controls.Add(this.Studio);
            this.gbFilters.Controls.Add(this.Duration);
            this.gbFilters.Location = new System.Drawing.Point(678, 23);
            this.gbFilters.Name = "gbFilters";
            this.gbFilters.Size = new System.Drawing.Size(174, 181);
            this.gbFilters.TabIndex = 15;
            this.gbFilters.TabStop = false;
            this.gbFilters.Text = "Filters";
            // 
            // Language

            // 
            this.Language.FormattingEnabled = true;
            this.Language.Location = new System.Drawing.Point(15, 145);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(141, 17);
            this.Language.TabIndex = 5;
            // 
            // Year
            // 
            this.Year.FormattingEnabled = true;
            this.Year.Location = new System.Drawing.Point(15, 122);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(141, 17);
            this.Year.TabIndex = 4;
            // 
            // Director
            // 
            this.Director.FormattingEnabled = true;
            this.Director.Location = new System.Drawing.Point(15, 98);
            this.Director.Name = "Director";
            this.Director.Size = new System.Drawing.Size(141, 17);
            this.Director.TabIndex = 3;

            // 
            this.Language.FormattingEnabled = true;
            this.Language.Location = new System.Drawing.Point(15, 145);
            this.Language.Name = "Language";
            this.Language.Size = new System.Drawing.Size(141, 17);
            this.Language.TabIndex = 5;

            // 
            // Year
            // 
            this.Year.FormattingEnabled = true;
            this.Year.Location = new System.Drawing.Point(15, 122);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(141, 17);
            this.Year.TabIndex = 4;
            // 
            this.Year.FormattingEnabled = true;
            this.Year.Location = new System.Drawing.Point(15, 122);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(141, 17);
            this.Year.TabIndex = 4;
            // 
            // Studio
            // 
            this.Studio.FormattingEnabled = true;
            this.Studio.Location = new System.Drawing.Point(15, 52);
            this.Studio.Name = "Studio";
            this.Studio.Size = new System.Drawing.Size(141, 17);
            this.Studio.TabIndex = 1;
            // 

            // Duration
            // 
            this.Duration.FormattingEnabled = true;
            this.Duration.Location = new System.Drawing.Point(15, 29);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(141, 17);
            this.Duration.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(678, 210);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(118, 31);
            this.btnQuery.TabIndex = 17;
            this.btnQuery.Text = "Filter";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click_1);

            // Genre
            // 
            this.Genre.FormattingEnabled = true;
            this.Genre.Location = new System.Drawing.Point(15, 75);
            this.Genre.Name = "Genre";
            this.Genre.Size = new System.Drawing.Size(141, 17);
            this.Genre.TabIndex = 2;
            // 
            // Studio
            // 
            this.Studio.FormattingEnabled = true;
            this.Studio.Location = new System.Drawing.Point(15, 52);
            this.Studio.Name = "Studio";
            this.Studio.Size = new System.Drawing.Size(141, 17);
            this.Studio.TabIndex = 1;
            // 
            // Duration
            // 
            this.Duration.FormattingEnabled = true;
            this.Duration.Location = new System.Drawing.Point(15, 29);
            this.Duration.Name = "Duration";
            this.Duration.Size = new System.Drawing.Size(141, 17);
            this.Duration.TabIndex = 0;

            // 
            // mainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(873, 739);
            this.Controls.Add(this.btnQuery);

            this.ClientSize = new System.Drawing.Size(897, 880);

            this.Controls.Add(this.gbFilters);
            this.Controls.Add(this.gbScheduledFilms);
            this.Controls.Add(this.gbRecommendedFilms);
            this.Controls.Add(this.gbSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.testBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainView";
            this.Text = "GoodFilms App";
            this.Load += new System.EventHandler(this.mainView_Load);
            this.gbFilters.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbFilters;
        private System.Windows.Forms.ListBox Language;
        private System.Windows.Forms.ListBox Year;
        private System.Windows.Forms.ListBox Director;
        private System.Windows.Forms.ListBox Genre;
        private System.Windows.Forms.ListBox Studio;
        private System.Windows.Forms.ListBox Duration;
        private System.Windows.Forms.Button btnQuery;
    }
}

