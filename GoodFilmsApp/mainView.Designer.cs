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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.gbSearchResults = new System.Windows.Forms.GroupBox();
            this.gbRecommendedFilms = new System.Windows.Forms.GroupBox();
            this.gbScheduledFilms = new System.Windows.Forms.GroupBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnSearchLeft = new System.Windows.Forms.Button();
            this.btnSearchRight = new System.Windows.Forms.Button();
            this.lblSearchPage = new System.Windows.Forms.Label();
            this.lblRecommendPage = new System.Windows.Forms.Label();
            this.btnRecommenRight = new System.Windows.Forms.Button();
            this.btnRecommendLeft = new System.Windows.Forms.Button();
            this.lblScheduledPage = new System.Windows.Forms.Label();
            this.btnScheduleRight = new System.Windows.Forms.Button();
            this.btnScheduleLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(35, 40);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(680, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(758, 36);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(171, 35);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // gbSearchResults
            // 
            this.gbSearchResults.Location = new System.Drawing.Point(35, 114);
            this.gbSearchResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSearchResults.Name = "gbSearchResults";
            this.gbSearchResults.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSearchResults.Size = new System.Drawing.Size(1277, 270);
            this.gbSearchResults.TabIndex = 4;
            this.gbSearchResults.TabStop = false;
            this.gbSearchResults.Text = "Search Results";
            // 
            // gbRecommendedFilms
            // 
            this.gbRecommendedFilms.Location = new System.Drawing.Point(35, 424);
            this.gbRecommendedFilms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRecommendedFilms.Name = "gbRecommendedFilms";
            this.gbRecommendedFilms.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbRecommendedFilms.Size = new System.Drawing.Size(1277, 270);
            this.gbRecommendedFilms.TabIndex = 13;
            this.gbRecommendedFilms.TabStop = false;
            this.gbRecommendedFilms.Text = "Recommended Films";
            // 
            // gbScheduledFilms
            // 
            this.gbScheduledFilms.Location = new System.Drawing.Point(35, 734);
            this.gbScheduledFilms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbScheduledFilms.Name = "gbScheduledFilms";
            this.gbScheduledFilms.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbScheduledFilms.Size = new System.Drawing.Size(1277, 270);
            this.gbScheduledFilms.TabIndex = 14;
            this.gbScheduledFilms.TabStop = false;
            this.gbScheduledFilms.Text = "Scheduled Films";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(962, 36);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(140, 35);
            this.btnQuery.TabIndex = 17;
            this.btnQuery.Text = "Filter";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click_1);
            // 
            // btnSearchLeft
            // 
            this.btnSearchLeft.Location = new System.Drawing.Point(579, 384);
            this.btnSearchLeft.Name = "btnSearchLeft";
            this.btnSearchLeft.Size = new System.Drawing.Size(32, 32);
            this.btnSearchLeft.TabIndex = 0;
            this.btnSearchLeft.Text = "<";
            this.btnSearchLeft.UseVisualStyleBackColor = true;
            // 
            // btnSearchRight
            // 
            this.btnSearchRight.Location = new System.Drawing.Point(737, 384);
            this.btnSearchRight.Name = "btnSearchRight";
            this.btnSearchRight.Size = new System.Drawing.Size(32, 32);
            this.btnSearchRight.TabIndex = 18;
            this.btnSearchRight.Text = ">";
            this.btnSearchRight.UseVisualStyleBackColor = true;
            // 
            // lblSearchPage
            // 
            this.lblSearchPage.AutoSize = true;
            this.lblSearchPage.Location = new System.Drawing.Point(617, 390);
            this.lblSearchPage.Name = "lblSearchPage";
            this.lblSearchPage.Size = new System.Drawing.Size(92, 20);
            this.lblSearchPage.TabIndex = 19;
            this.lblSearchPage.Text = "page 1 of ...";
            // 
            // lblRecommendPage
            // 
            this.lblRecommendPage.AutoSize = true;
            this.lblRecommendPage.Location = new System.Drawing.Point(617, 708);
            this.lblRecommendPage.Name = "lblRecommendPage";
            this.lblRecommendPage.Size = new System.Drawing.Size(92, 20);
            this.lblRecommendPage.TabIndex = 22;
            this.lblRecommendPage.Text = "page 1 of ...";
            // 
            // btnRecommenRight
            // 
            this.btnRecommenRight.Location = new System.Drawing.Point(737, 702);
            this.btnRecommenRight.Name = "btnRecommenRight";
            this.btnRecommenRight.Size = new System.Drawing.Size(32, 32);
            this.btnRecommenRight.TabIndex = 21;
            this.btnRecommenRight.Text = ">";
            this.btnRecommenRight.UseVisualStyleBackColor = true;
            // 
            // btnRecommendLeft
            // 
            this.btnRecommendLeft.Location = new System.Drawing.Point(579, 702);
            this.btnRecommendLeft.Name = "btnRecommendLeft";
            this.btnRecommendLeft.Size = new System.Drawing.Size(32, 32);
            this.btnRecommendLeft.TabIndex = 20;
            this.btnRecommendLeft.Text = "<";
            this.btnRecommendLeft.UseVisualStyleBackColor = true;
            // 
            // lblScheduledPage
            // 
            this.lblScheduledPage.AutoSize = true;
            this.lblScheduledPage.Location = new System.Drawing.Point(617, 1023);
            this.lblScheduledPage.Name = "lblScheduledPage";
            this.lblScheduledPage.Size = new System.Drawing.Size(92, 20);
            this.lblScheduledPage.TabIndex = 25;
            this.lblScheduledPage.Text = "page 1 of ...";
            // 
            // btnScheduleRight
            // 
            this.btnScheduleRight.Location = new System.Drawing.Point(737, 1017);
            this.btnScheduleRight.Name = "btnScheduleRight";
            this.btnScheduleRight.Size = new System.Drawing.Size(32, 32);
            this.btnScheduleRight.TabIndex = 24;
            this.btnScheduleRight.Text = ">";
            this.btnScheduleRight.UseVisualStyleBackColor = true;
            // 
            // btnScheduleLeft
            // 
            this.btnScheduleLeft.Location = new System.Drawing.Point(579, 1017);
            this.btnScheduleLeft.Name = "btnScheduleLeft";
            this.btnScheduleLeft.Size = new System.Drawing.Size(32, 32);
            this.btnScheduleLeft.TabIndex = 23;
            this.btnScheduleLeft.Text = "<";
            this.btnScheduleLeft.UseVisualStyleBackColor = true;
            // 
            // mainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 1061);
            this.Controls.Add(this.lblScheduledPage);
            this.Controls.Add(this.btnScheduleRight);
            this.Controls.Add(this.btnScheduleLeft);
            this.Controls.Add(this.lblRecommendPage);
            this.Controls.Add(this.btnRecommenRight);
            this.Controls.Add(this.btnRecommendLeft);
            this.Controls.Add(this.lblSearchPage);
            this.Controls.Add(this.btnSearchRight);
            this.Controls.Add(this.btnSearchLeft);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.gbScheduledFilms);
            this.Controls.Add(this.gbRecommendedFilms);
            this.Controls.Add(this.gbSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainView";
            this.Text = "GoodFilms App";
            this.Load += new System.EventHandler(this.mainView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbSearchResults;
        private System.Windows.Forms.GroupBox gbRecommendedFilms;
        private System.Windows.Forms.GroupBox gbScheduledFilms;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnSearchLeft;
        private System.Windows.Forms.Button btnSearchRight;
        private System.Windows.Forms.Label lblSearchPage;
        private System.Windows.Forms.Label lblRecommendPage;
        private System.Windows.Forms.Button btnRecommenRight;
        private System.Windows.Forms.Button btnRecommendLeft;
        private System.Windows.Forms.Label lblScheduledPage;
        private System.Windows.Forms.Button btnScheduleRight;
        private System.Windows.Forms.Button btnScheduleLeft;
    }
}

