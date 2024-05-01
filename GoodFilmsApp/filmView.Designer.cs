namespace GoodFilmsApp
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
            this.dtpScheduleTime = new System.Windows.Forms.DateTimePicker();
            this.lblScheduleFilm = new System.Windows.Forms.Label();
            this.btnAddToSchedule = new System.Windows.Forms.Button();
            this.cbFilmWatched = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lblGenreResult = new System.Windows.Forms.LinkLabel();
            this.lblLanguageResult = new System.Windows.Forms.LinkLabel();
            this.lblStudioResult = new System.Windows.Forms.LinkLabel();
            this.lblDirectorResult = new System.Windows.Forms.Label();
            this.lblReleaseYearResult = new System.Windows.Forms.Label();
            this.lblDurationResult = new System.Windows.Forms.Label();
            this.lblAgeRatingResult = new System.Windows.Forms.Label();
            this.lblAgeRating = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblReleaseYear = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.lblStudio = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPoster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStar5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFilmName
            // 
            this.lblFilmName.AutoSize = true;
            this.lblFilmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilmName.Location = new System.Drawing.Point(20, 30);
            this.lblFilmName.Name = "lblFilmName";
            this.lblFilmName.Size = new System.Drawing.Size(153, 31);
            this.lblFilmName.TabIndex = 0;
            this.lblFilmName.Text = "Film Name";
            // 
            // pbPoster
            // 
            this.pbPoster.Location = new System.Drawing.Point(20, 80);
            this.pbPoster.Name = "pbPoster";
            this.pbPoster.Size = new System.Drawing.Size(300, 450);
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
            this.pbStar1.Location = new System.Drawing.Point(340, 94);
            this.pbStar1.Name = "pbStar1";
            this.pbStar1.Size = new System.Drawing.Size(50, 50);
            this.pbStar1.TabIndex = 2;
            this.pbStar1.TabStop = false;
            // 
            // pbStar2
            // 
            this.pbStar2.Location = new System.Drawing.Point(340, 150);
            this.pbStar2.Name = "pbStar2";
            this.pbStar2.Size = new System.Drawing.Size(50, 50);
            this.pbStar2.TabIndex = 3;
            this.pbStar2.TabStop = false;
            // 
            // pbStar3
            // 
            this.pbStar3.Location = new System.Drawing.Point(340, 206);
            this.pbStar3.Name = "pbStar3";
            this.pbStar3.Size = new System.Drawing.Size(50, 50);
            this.pbStar3.TabIndex = 4;
            this.pbStar3.TabStop = false;
            // 
            // pbStar4
            // 
            this.pbStar4.Location = new System.Drawing.Point(340, 262);
            this.pbStar4.Name = "pbStar4";
            this.pbStar4.Size = new System.Drawing.Size(50, 50);
            this.pbStar4.TabIndex = 5;
            this.pbStar4.TabStop = false;
            // 
            // pbStar5
            // 
            this.pbStar5.Location = new System.Drawing.Point(340, 318);
            this.pbStar5.Name = "pbStar5";
            this.pbStar5.Size = new System.Drawing.Size(50, 50);
            this.pbStar5.TabIndex = 6;
            this.pbStar5.TabStop = false;
            // 
            // lblUserRating
            // 
            this.lblUserRating.AutoSize = true;
            this.lblUserRating.Location = new System.Drawing.Point(337, 78);
            this.lblUserRating.Name = "lblUserRating";
            this.lblUserRating.Size = new System.Drawing.Size(58, 13);
            this.lblUserRating.TabIndex = 7;
            this.lblUserRating.Text = "User rating";
            // 
            // txtMovieInfo
            // 
            this.txtMovieInfo.Location = new System.Drawing.Point(410, 80);
            this.txtMovieInfo.Multiline = true;
            this.txtMovieInfo.Name = "txtMovieInfo";
            this.txtMovieInfo.ReadOnly = true;
            this.txtMovieInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMovieInfo.Size = new System.Drawing.Size(300, 384);
            this.txtMovieInfo.TabIndex = 8;
            this.txtMovieInfo.TabStop = false;
            // 
            // txtUserComment
            // 
            this.txtUserComment.Location = new System.Drawing.Point(410, 495);
            this.txtUserComment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUserComment.Multiline = true;
            this.txtUserComment.Name = "txtUserComment";
            this.txtUserComment.Size = new System.Drawing.Size(300, 180);
            this.txtUserComment.TabIndex = 9;
            this.txtUserComment.TextChanged += new System.EventHandler(this.txtUserComments_TextChanged);
            // 
            // lblUserComments
            // 
            this.lblUserComments.AutoSize = true;
            this.lblUserComments.Location = new System.Drawing.Point(407, 479);
            this.lblUserComments.Name = "lblUserComments";
            this.lblUserComments.Size = new System.Drawing.Size(75, 13);
            this.lblUserComments.TabIndex = 10;
            this.lblUserComments.Text = "User comment";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dtpScheduleTime
            // 
            this.dtpScheduleTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpScheduleTime.Location = new System.Drawing.Point(410, 707);
            this.dtpScheduleTime.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.dtpScheduleTime.Name = "dtpScheduleTime";
            this.dtpScheduleTime.Size = new System.Drawing.Size(171, 20);
            this.dtpScheduleTime.TabIndex = 12;
            // 
            // lblScheduleFilm
            // 
            this.lblScheduleFilm.AutoSize = true;
            this.lblScheduleFilm.Location = new System.Drawing.Point(407, 691);
            this.lblScheduleFilm.Name = "lblScheduleFilm";
            this.lblScheduleFilm.Size = new System.Drawing.Size(102, 13);
            this.lblScheduleFilm.TabIndex = 13;
            this.lblScheduleFilm.Text = "Add film to schedule";
            // 
            // btnAddToSchedule
            // 
            this.btnAddToSchedule.Location = new System.Drawing.Point(587, 704);
            this.btnAddToSchedule.Name = "btnAddToSchedule";
            this.btnAddToSchedule.Size = new System.Drawing.Size(125, 23);
            this.btnAddToSchedule.TabIndex = 14;
            this.btnAddToSchedule.Text = "Add";
            this.btnAddToSchedule.UseVisualStyleBackColor = true;
            this.btnAddToSchedule.Click += new System.EventHandler(this.btnAddToSchedule_Click);
            // 
            // cbFilmWatched
            // 
            this.cbFilmWatched.AutoSize = true;
            this.cbFilmWatched.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbFilmWatched.Location = new System.Drawing.Point(622, 44);
            this.cbFilmWatched.Name = "cbFilmWatched";
            this.cbFilmWatched.Size = new System.Drawing.Size(88, 17);
            this.cbFilmWatched.TabIndex = 15;
            this.cbFilmWatched.Text = "Film watched";
            this.cbFilmWatched.UseVisualStyleBackColor = true;
            this.cbFilmWatched.CheckedChanged += new System.EventHandler(this.cbFilmWatched_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblGenre);
            this.panel1.Controls.Add(this.lblGenreResult);
            this.panel1.Controls.Add(this.lblLanguageResult);
            this.panel1.Controls.Add(this.lblStudioResult);
            this.panel1.Controls.Add(this.lblDirectorResult);
            this.panel1.Controls.Add(this.lblReleaseYearResult);
            this.panel1.Controls.Add(this.lblDurationResult);
            this.panel1.Controls.Add(this.lblAgeRatingResult);
            this.panel1.Controls.Add(this.lblAgeRating);
            this.panel1.Controls.Add(this.lblDuration);
            this.panel1.Controls.Add(this.lblReleaseYear);
            this.panel1.Controls.Add(this.lblDirector);
            this.panel1.Controls.Add(this.lblStudio);
            this.panel1.Controls.Add(this.lblLanguage);
            this.panel1.Location = new System.Drawing.Point(20, 545);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 217);
            this.panel1.TabIndex = 16;
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(18, 14);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(39, 13);
            this.lblGenre.TabIndex = 13;
            this.lblGenre.Text = "Genre:";
            // 
            // lblGenreResult
            // 
            this.lblGenreResult.AutoSize = true;
            this.lblGenreResult.Location = new System.Drawing.Point(107, 14);
            this.lblGenreResult.Name = "lblGenreResult";
            this.lblGenreResult.Size = new System.Drawing.Size(41, 13);
            this.lblGenreResult.TabIndex = 12;
            this.lblGenreResult.TabStop = true;
            this.lblGenreResult.Text = "Genres";
            this.lblGenreResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGenreResult_LinkClicked);
            // 
            // lblLanguageResult
            // 
            this.lblLanguageResult.AutoSize = true;
            this.lblLanguageResult.Location = new System.Drawing.Point(106, 42);
            this.lblLanguageResult.Name = "lblLanguageResult";
            this.lblLanguageResult.Size = new System.Drawing.Size(60, 13);
            this.lblLanguageResult.TabIndex = 11;
            this.lblLanguageResult.TabStop = true;
            this.lblLanguageResult.Text = "Languages";
            this.lblLanguageResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLanguageResult_LinkClicked);
            // 
            // lblStudioResult
            // 
            this.lblStudioResult.AutoSize = true;
            this.lblStudioResult.Location = new System.Drawing.Point(106, 71);
            this.lblStudioResult.Name = "lblStudioResult";
            this.lblStudioResult.Size = new System.Drawing.Size(42, 13);
            this.lblStudioResult.TabIndex = 10;
            this.lblStudioResult.TabStop = true;
            this.lblStudioResult.Text = "Studios";
            this.lblStudioResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblStudioResult_LinkClicked);
            // 
            // lblDirectorResult
            // 
            this.lblDirectorResult.AutoSize = true;
            this.lblDirectorResult.Location = new System.Drawing.Point(106, 100);
            this.lblDirectorResult.Name = "lblDirectorResult";
            this.lblDirectorResult.Size = new System.Drawing.Size(13, 13);
            this.lblDirectorResult.TabIndex = 9;
            this.lblDirectorResult.Text = "a";
            // 
            // lblReleaseYearResult
            // 
            this.lblReleaseYearResult.AutoSize = true;
            this.lblReleaseYearResult.Location = new System.Drawing.Point(106, 129);
            this.lblReleaseYearResult.Name = "lblReleaseYearResult";
            this.lblReleaseYearResult.Size = new System.Drawing.Size(13, 13);
            this.lblReleaseYearResult.TabIndex = 8;
            this.lblReleaseYearResult.Text = "a";
            // 
            // lblDurationResult
            // 
            this.lblDurationResult.AutoSize = true;
            this.lblDurationResult.Location = new System.Drawing.Point(106, 158);
            this.lblDurationResult.Name = "lblDurationResult";
            this.lblDurationResult.Size = new System.Drawing.Size(13, 13);
            this.lblDurationResult.TabIndex = 7;
            this.lblDurationResult.Text = "a";
            // 
            // lblAgeRatingResult
            // 
            this.lblAgeRatingResult.AutoSize = true;
            this.lblAgeRatingResult.Location = new System.Drawing.Point(106, 187);
            this.lblAgeRatingResult.Name = "lblAgeRatingResult";
            this.lblAgeRatingResult.Size = new System.Drawing.Size(13, 13);
            this.lblAgeRatingResult.TabIndex = 6;
            this.lblAgeRatingResult.Text = "a";
            // 
            // lblAgeRating
            // 
            this.lblAgeRating.AutoSize = true;
            this.lblAgeRating.Location = new System.Drawing.Point(18, 187);
            this.lblAgeRating.Name = "lblAgeRating";
            this.lblAgeRating.Size = new System.Drawing.Size(58, 13);
            this.lblAgeRating.TabIndex = 5;
            this.lblAgeRating.Text = "Age rating:";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(18, 158);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(50, 13);
            this.lblDuration.TabIndex = 4;
            this.lblDuration.Text = "Duration:";
            // 
            // lblReleaseYear
            // 
            this.lblReleaseYear.AutoSize = true;
            this.lblReleaseYear.Location = new System.Drawing.Point(18, 129);
            this.lblReleaseYear.Name = "lblReleaseYear";
            this.lblReleaseYear.Size = new System.Drawing.Size(72, 13);
            this.lblReleaseYear.TabIndex = 3;
            this.lblReleaseYear.Text = "Release year:";
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(18, 100);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(47, 13);
            this.lblDirector.TabIndex = 2;
            this.lblDirector.Text = "Director:";
            // 
            // lblStudio
            // 
            this.lblStudio.AutoSize = true;
            this.lblStudio.Location = new System.Drawing.Point(18, 71);
            this.lblStudio.Name = "lblStudio";
            this.lblStudio.Size = new System.Drawing.Size(40, 13);
            this.lblStudio.TabIndex = 1;
            this.lblStudio.Text = "Studio:";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(18, 42);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(58, 13);
            this.lblLanguage.TabIndex = 0;
            this.lblLanguage.Text = "Language:";
            // 
            // filmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 774);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbFilmWatched);
            this.Controls.Add(this.btnAddToSchedule);
            this.Controls.Add(this.lblScheduleFilm);
            this.Controls.Add(this.dtpScheduleTime);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.DateTimePicker dtpScheduleTime;
        private System.Windows.Forms.Label lblScheduleFilm;
        private System.Windows.Forms.Button btnAddToSchedule;
        private System.Windows.Forms.CheckBox cbFilmWatched;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblStudio;
        private System.Windows.Forms.Label lblReleaseYear;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.Label lblAgeRating;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblAgeRatingResult;
        private System.Windows.Forms.Label lblDirectorResult;
        private System.Windows.Forms.Label lblReleaseYearResult;
        private System.Windows.Forms.Label lblDurationResult;
        private System.Windows.Forms.LinkLabel lblStudioResult;
        private System.Windows.Forms.LinkLabel lblLanguageResult;
        private System.Windows.Forms.LinkLabel lblGenreResult;
        private System.Windows.Forms.Label lblGenre;
    }
}