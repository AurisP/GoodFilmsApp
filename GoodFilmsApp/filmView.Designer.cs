﻿namespace GoodFilmsApp
{
    partial class filmView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(filmView));
            this.lblFilmName = new System.Windows.Forms.Label();
            this.pbPoster = new System.Windows.Forms.PictureBox();
            this.imgStar = new System.Windows.Forms.ImageList(this.components);
            this.pbStar1 = new System.Windows.Forms.PictureBox();
            this.pbStar2 = new System.Windows.Forms.PictureBox();
            this.pbStar3 = new System.Windows.Forms.PictureBox();
            this.pbStar4 = new System.Windows.Forms.PictureBox();
            this.pbStar5 = new System.Windows.Forms.PictureBox();
            this.lblUserRating = new System.Windows.Forms.Label();
            this.txtMovieInfo = new System.Windows.Forms.TextBox();
            this.txtUserComment = new System.Windows.Forms.TextBox();
            this.lblUserComments = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSaveComment = new System.Windows.Forms.Button();
            this.dtpScheduleTime = new System.Windows.Forms.DateTimePicker();
            this.lblScheduleFilm = new System.Windows.Forms.Label();
            this.btnAddToSchedule = new System.Windows.Forms.Button();
            this.cbFilmWatched = new System.Windows.Forms.CheckBox();
            this.btnSaveAs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFilmName
            // 
            this.lblFilmName.AutoSize = true;
            this.lblFilmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilmName.Location = new System.Drawing.Point(27, 37);
            this.lblFilmName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilmName.Name = "lblFilmName";
            this.lblFilmName.Size = new System.Drawing.Size(191, 39);
            this.lblFilmName.TabIndex = 0;
            this.lblFilmName.Text = "Film Name";
            // 
            // pbPoster
            // 
            this.pbPoster.Location = new System.Drawing.Point(27, 98);
            this.pbPoster.Margin = new System.Windows.Forms.Padding(4);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(400, 554);
            this.pbPoster.TabIndex = 1;
            this.pbPoster.TabStop = false;
            // 
            // imgStar
            // 
            this.imgStar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgStar.ImageStream")));
            this.imgStar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgStar.Images.SetKeyName(0, "star_off.png");
            this.imgStar.Images.SetKeyName(1, "star_on.png");
            // 
            // pbStar1
            // 
            this.pbStar1.Location = new System.Drawing.Point(453, 116);
            this.pbStar1.Margin = new System.Windows.Forms.Padding(4);
            this.pbStar1.Name = "pbStar1";
            this.pbStar1.Size = new System.Drawing.Size(67, 62);
            this.pbStar1.TabIndex = 2;
            this.pbStar1.TabStop = false;
            // 
            // pbStar2
            // 
            this.pbStar2.Location = new System.Drawing.Point(453, 185);
            this.pbStar2.Margin = new System.Windows.Forms.Padding(4);
            this.pbStar2.Name = "pbStar2";
            this.pbStar2.Size = new System.Drawing.Size(67, 62);
            this.pbStar2.TabIndex = 3;
            this.pbStar2.TabStop = false;
            // 
            // pbStar3
            // 
            this.pbStar3.Location = new System.Drawing.Point(453, 254);
            this.pbStar3.Margin = new System.Windows.Forms.Padding(4);
            this.pbStar3.Name = "pbStar3";
            this.pbStar3.Size = new System.Drawing.Size(67, 62);
            this.pbStar3.TabIndex = 4;
            this.pbStar3.TabStop = false;
            // 
            // pbStar4
            // 
            this.pbStar4.Location = new System.Drawing.Point(453, 322);
            this.pbStar4.Margin = new System.Windows.Forms.Padding(4);
            this.pbStar4.Name = "pbStar4";
            this.pbStar4.Size = new System.Drawing.Size(67, 62);
            this.pbStar4.TabIndex = 5;
            this.pbStar4.TabStop = false;
            // 
            // pbStar5
            // 
            this.pbStar5.Location = new System.Drawing.Point(453, 391);
            this.pbStar5.Margin = new System.Windows.Forms.Padding(4);
            this.pbStar5.Name = "pbStar5";
            this.pbStar5.Size = new System.Drawing.Size(67, 62);
            this.pbStar5.TabIndex = 6;
            this.pbStar5.TabStop = false;
            // 
            // lblUserRating
            // 
            this.lblUserRating.AutoSize = true;
            this.lblUserRating.Location = new System.Drawing.Point(449, 96);
            this.lblUserRating.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserRating.Name = "lblUserRating";
            this.lblUserRating.Size = new System.Drawing.Size(72, 16);
            this.lblUserRating.TabIndex = 7;
            this.lblUserRating.Text = "User rating";
            // 
            // txtMovieInfo
            // 
            this.txtMovieInfo.Location = new System.Drawing.Point(547, 98);
            this.txtMovieInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMovieInfo.Multiline = true;
            this.txtMovieInfo.Name = "txtMovieInfo";
            this.txtMovieInfo.ReadOnly = true;
            this.txtMovieInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMovieInfo.Size = new System.Drawing.Size(399, 282);
            this.txtMovieInfo.TabIndex = 8;
            this.txtMovieInfo.TabStop = false;
            // 
            // txtUserComment
            // 
            this.txtUserComment.Location = new System.Drawing.Point(547, 405);
            this.txtUserComment.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUserComment.Multiline = true;
            this.txtUserComment.Name = "txtUserComment";
            this.txtUserComment.Size = new System.Drawing.Size(399, 176);
            this.txtUserComment.TabIndex = 9;
            this.txtUserComment.TextChanged += new System.EventHandler(this.txtUserComments_TextChanged);
            // 
            // lblUserComments
            // 
            this.lblUserComments.AutoSize = true;
            this.lblUserComments.Location = new System.Drawing.Point(543, 385);
            this.lblUserComments.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserComments.Name = "lblUserComments";
            this.lblUserComments.Size = new System.Drawing.Size(94, 16);
            this.lblUserComments.TabIndex = 10;
            this.lblUserComments.Text = "User comment";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnSaveComment
            // 
            this.btnSaveComment.Location = new System.Drawing.Point(780, 589);
            this.btnSaveComment.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveComment.Name = "btnSaveComment";
            this.btnSaveComment.Size = new System.Drawing.Size(167, 28);
            this.btnSaveComment.TabIndex = 11;
            this.btnSaveComment.Text = "Save comment";
            this.btnSaveComment.UseVisualStyleBackColor = true;
            this.btnSaveComment.Click += new System.EventHandler(this.btnSaveComment_Click);
            // 
            // dtpScheduleTime
            // 
            this.dtpScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduleTime.Location = new System.Drawing.Point(547, 628);
            this.dtpScheduleTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtpScheduleTime.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dtpScheduleTime.Name = "dtpScheduleTime";
            this.dtpScheduleTime.Size = new System.Drawing.Size(227, 22);
            this.dtpScheduleTime.TabIndex = 12;
            // 
            // lblScheduleFilm
            // 
            this.lblScheduleFilm.AutoSize = true;
            this.lblScheduleFilm.Location = new System.Drawing.Point(543, 608);
            this.lblScheduleFilm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScheduleFilm.Name = "lblScheduleFilm";
            this.lblScheduleFilm.Size = new System.Drawing.Size(127, 16);
            this.lblScheduleFilm.TabIndex = 13;
            this.lblScheduleFilm.Text = "Add film to schedule";
            // 
            // btnAddToSchedule
            // 
            this.btnAddToSchedule.Location = new System.Drawing.Point(780, 625);
            this.btnAddToSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddToSchedule.Name = "btnAddToSchedule";
            this.btnAddToSchedule.Size = new System.Drawing.Size(167, 28);
            this.btnAddToSchedule.TabIndex = 14;
            this.btnAddToSchedule.Text = "Add";
            this.btnAddToSchedule.UseVisualStyleBackColor = true;
            this.btnAddToSchedule.Click += new System.EventHandler(this.btnAddToSchedule_Click);
            // 
            // cbFilmWatched
            // 
            this.cbFilmWatched.AutoSize = true;
            this.cbFilmWatched.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbFilmWatched.Location = new System.Drawing.Point(829, 54);
            this.cbFilmWatched.Margin = new System.Windows.Forms.Padding(4);
            this.cbFilmWatched.Name = "cbFilmWatched";
            this.cbFilmWatched.Size = new System.Drawing.Size(107, 20);
            this.cbFilmWatched.TabIndex = 15;
            this.cbFilmWatched.Text = "Film watched";
            this.cbFilmWatched.UseVisualStyleBackColor = true;
            this.cbFilmWatched.CheckedChanged += new System.EventHandler(this.cbFilmWatched_CheckedChanged);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(700, 49);
            this.btnSaveAs.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(121, 28);
            this.btnSaveAs.TabIndex = 25;
            this.btnSaveAs.Text = "Export As CSV";
            this.btnSaveAs.UseVisualStyleBackColor = true;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click_1);
            // 
            // filmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 674);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.cbFilmWatched);
            this.Controls.Add(this.btnAddToSchedule);
            this.Controls.Add(this.lblScheduleFilm);
            this.Controls.Add(this.dtpScheduleTime);
            this.Controls.Add(this.btnSaveComment);
            this.Controls.Add(this.lblUserComments);
            this.Controls.Add(this.txtUserComment);
            this.Controls.Add(this.txtMovieInfo);
            this.Controls.Add(this.lblUserRating);
            this.Controls.Add(this.pbStar5);
            this.Controls.Add(this.pbStar4);
            this.Controls.Add(this.pbStar3);
            this.Controls.Add(this.pbStar2);
            this.Controls.Add(this.pbStar1);
            this.Controls.Add(this.pbPoster);
            this.Controls.Add(this.lblFilmName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "filmView";
            this.Text = "Movie name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.filmView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.filmView_Closed);
            this.Load += new System.EventHandler(this.filmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFilmName;
        private System.Windows.Forms.PictureBox pbPoster;
        private System.Windows.Forms.ImageList imgStar;
        private System.Windows.Forms.PictureBox pbStar1;
        private System.Windows.Forms.PictureBox pbStar2;
        private System.Windows.Forms.PictureBox pbStar3;
        private System.Windows.Forms.PictureBox pbStar4;
        private System.Windows.Forms.PictureBox pbStar5;
        private System.Windows.Forms.Label lblUserRating;
        private System.Windows.Forms.TextBox txtMovieInfo;
        private System.Windows.Forms.TextBox txtUserComment;
        private System.Windows.Forms.Label lblUserComments;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnSaveComment;
        private System.Windows.Forms.DateTimePicker dtpScheduleTime;
        private System.Windows.Forms.Label lblScheduleFilm;
        private System.Windows.Forms.Button btnAddToSchedule;
        private System.Windows.Forms.CheckBox cbFilmWatched;
        private System.Windows.Forms.Button btnSaveAs;
    }
}