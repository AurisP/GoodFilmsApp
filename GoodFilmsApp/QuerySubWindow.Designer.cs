namespace GoodFilmsApp
{
    partial class QuerySubWindow
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblMinDuration = new System.Windows.Forms.Label();
            this.lblMaxDuration = new System.Windows.Forms.Label();
            this.lblStudios = new System.Windows.Forms.Label();
            this.lblAddedStudios = new System.Windows.Forms.Label();
            this.btnAddNewStudio = new System.Windows.Forms.Button();
            this.lblAddedGenres = new System.Windows.Forms.Label();
            this.lblGenres = new System.Windows.Forms.Label();
            this.btnAddNewGenre = new System.Windows.Forms.Button();
            this.btnChooseDirector = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDirectors = new System.Windows.Forms.Label();
            this.lblReleaseYear = new System.Windows.Forms.Label();
            this.txtReleaseYear = new System.Windows.Forms.TextBox();
            this.btnAgeRating = new System.Windows.Forms.Button();
            this.lblAgeRating = new System.Windows.Forms.Label();
            this.btnChooseLanguage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.txtMinDuration = new System.Windows.Forms.TextBox();
            this.txtMaxDuration = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(20, 181);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 40);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Close";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblMinDuration
            // 
            this.lblMinDuration.AutoSize = true;
            this.lblMinDuration.Location = new System.Drawing.Point(17, 35);
            this.lblMinDuration.Name = "lblMinDuration";
            this.lblMinDuration.Size = new System.Drawing.Size(115, 13);
            this.lblMinDuration.TabIndex = 2;
            this.lblMinDuration.Text = "Min Duration (minutes):";
            // 
            // lblMaxDuration
            // 
            this.lblMaxDuration.AutoSize = true;
            this.lblMaxDuration.Location = new System.Drawing.Point(17, 78);
            this.lblMaxDuration.Name = "lblMaxDuration";
            this.lblMaxDuration.Size = new System.Drawing.Size(118, 13);
            this.lblMaxDuration.TabIndex = 4;
            this.lblMaxDuration.Text = "Max Duration (minutes):";
            this.lblMaxDuration.Click += new System.EventHandler(this.lblMaxDuration_Click);
            // 
            // lblStudios
            // 
            this.lblStudios.AutoSize = true;
            this.lblStudios.Location = new System.Drawing.Point(248, 75);
            this.lblStudios.Name = "lblStudios";
            this.lblStudios.Size = new System.Drawing.Size(37, 13);
            this.lblStudios.TabIndex = 6;
            this.lblStudios.Text = "Studio";
            // 
            // lblAddedStudios
            // 
            this.lblAddedStudios.AutoSize = true;
            this.lblAddedStudios.Location = new System.Drawing.Point(386, 87);
            this.lblAddedStudios.Name = "lblAddedStudios";
            this.lblAddedStudios.Size = new System.Drawing.Size(0, 13);
            this.lblAddedStudios.TabIndex = 9;
            // 
            // btnAddNewStudio
            // 
            this.btnAddNewStudio.Location = new System.Drawing.Point(323, 67);
            this.btnAddNewStudio.Name = "btnAddNewStudio";
            this.btnAddNewStudio.Size = new System.Drawing.Size(94, 21);
            this.btnAddNewStudio.TabIndex = 10;
            this.btnAddNewStudio.Text = "Choose studio";
            this.btnAddNewStudio.UseVisualStyleBackColor = true;
            this.btnAddNewStudio.Click += new System.EventHandler(this.btnAddNewStudio_Click);
            // 
            // lblAddedGenres
            // 
            this.lblAddedGenres.AutoSize = true;
            this.lblAddedGenres.Location = new System.Drawing.Point(387, 125);
            this.lblAddedGenres.Name = "lblAddedGenres";
            this.lblAddedGenres.Size = new System.Drawing.Size(0, 13);
            this.lblAddedGenres.TabIndex = 13;
            // 
            // lblGenres
            // 
            this.lblGenres.AutoSize = true;
            this.lblGenres.Location = new System.Drawing.Point(248, 109);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(41, 13);
            this.lblGenres.TabIndex = 12;
            this.lblGenres.Text = "Genres";
            // 
            // btnAddNewGenre
            // 
            this.btnAddNewGenre.Location = new System.Drawing.Point(323, 101);
            this.btnAddNewGenre.Name = "btnAddNewGenre";
            this.btnAddNewGenre.Size = new System.Drawing.Size(94, 21);
            this.btnAddNewGenre.TabIndex = 14;
            this.btnAddNewGenre.Text = "Choose genre";
            this.btnAddNewGenre.UseVisualStyleBackColor = true;
            this.btnAddNewGenre.Click += new System.EventHandler(this.btnAddNewGenre_Click);
            // 
            // btnChooseDirector
            // 
            this.btnChooseDirector.Location = new System.Drawing.Point(323, 137);
            this.btnChooseDirector.Name = "btnChooseDirector";
            this.btnChooseDirector.Size = new System.Drawing.Size(94, 21);
            this.btnChooseDirector.TabIndex = 17;
            this.btnChooseDirector.Text = "Choose director";
            this.btnChooseDirector.UseVisualStyleBackColor = true;
            this.btnChooseDirector.Click += new System.EventHandler(this.btnChooseDirector_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(428, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 16;
            // 
            // lblDirectors
            // 
            this.lblDirectors.AutoSize = true;
            this.lblDirectors.Location = new System.Drawing.Point(248, 145);
            this.lblDirectors.Name = "lblDirectors";
            this.lblDirectors.Size = new System.Drawing.Size(49, 13);
            this.lblDirectors.TabIndex = 15;
            this.lblDirectors.Text = "Directors";
            // 
            // lblReleaseYear
            // 
            this.lblReleaseYear.AutoSize = true;
            this.lblReleaseYear.Location = new System.Drawing.Point(17, 126);
            this.lblReleaseYear.Name = "lblReleaseYear";
            this.lblReleaseYear.Size = new System.Drawing.Size(74, 13);
            this.lblReleaseYear.TabIndex = 18;
            this.lblReleaseYear.Text = "Release Year:";
            // 
            // txtReleaseYear
            // 
            this.txtReleaseYear.Location = new System.Drawing.Point(86, 138);
            this.txtReleaseYear.Name = "txtReleaseYear";
            this.txtReleaseYear.Size = new System.Drawing.Size(135, 20);
            this.txtReleaseYear.TabIndex = 19;
            this.txtReleaseYear.TextChanged += new System.EventHandler(this.txtReleaseYear_TextChanged);
            // 
            // btnAgeRating
            // 
            this.btnAgeRating.Location = new System.Drawing.Point(324, 181);
            this.btnAgeRating.Name = "btnAgeRating";
            this.btnAgeRating.Size = new System.Drawing.Size(93, 40);
            this.btnAgeRating.TabIndex = 21;
            this.btnAgeRating.Text = "Choose age rating";
            this.btnAgeRating.UseVisualStyleBackColor = true;
            this.btnAgeRating.Click += new System.EventHandler(this.btnAgeRating_Click);
            // 
            // lblAgeRating
            // 
            this.lblAgeRating.AutoSize = true;
            this.lblAgeRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAgeRating.Location = new System.Drawing.Point(248, 195);
            this.lblAgeRating.Name = "lblAgeRating";
            this.lblAgeRating.Size = new System.Drawing.Size(65, 13);
            this.lblAgeRating.TabIndex = 20;
            this.lblAgeRating.Text = "Age Ratings";
            // 
            // btnChooseLanguage
            // 
            this.btnChooseLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseLanguage.Location = new System.Drawing.Point(323, 32);
            this.btnChooseLanguage.Name = "btnChooseLanguage";
            this.btnChooseLanguage.Size = new System.Drawing.Size(94, 21);
            this.btnChooseLanguage.TabIndex = 23;
            this.btnChooseLanguage.Text = "Choose language";
            this.btnChooseLanguage.UseVisualStyleBackColor = true;
            this.btnChooseLanguage.Click += new System.EventHandler(this.btnChooseLanguage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Language";
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilters.Location = new System.Drawing.Point(131, 181);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(94, 40);
            this.btnClearFilters.TabIndex = 24;
            this.btnClearFilters.Text = "Clear filters";
            this.btnClearFilters.UseVisualStyleBackColor = true;
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // txtMinDuration
            // 
            this.txtMinDuration.Location = new System.Drawing.Point(134, 46);
            this.txtMinDuration.Name = "txtMinDuration";
            this.txtMinDuration.Size = new System.Drawing.Size(87, 20);
            this.txtMinDuration.TabIndex = 25;
            this.txtMinDuration.TextChanged += new System.EventHandler(this.txtMinDuration_TextChanged);
            // 
            // txtMaxDuration
            // 
            this.txtMaxDuration.Location = new System.Drawing.Point(134, 94);
            this.txtMaxDuration.Name = "txtMaxDuration";
            this.txtMaxDuration.Size = new System.Drawing.Size(87, 20);
            this.txtMaxDuration.TabIndex = 26;
            this.txtMaxDuration.TextChanged += new System.EventHandler(this.txtMaxDuration_TextChanged);
            // 
            // QuerySubWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(439, 246);
            this.Controls.Add(this.txtMaxDuration);
            this.Controls.Add(this.txtMinDuration);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.btnChooseLanguage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAgeRating);
            this.Controls.Add(this.lblAgeRating);
            this.Controls.Add(this.txtReleaseYear);
            this.Controls.Add(this.lblReleaseYear);
            this.Controls.Add(this.btnChooseDirector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDirectors);
            this.Controls.Add(this.btnAddNewGenre);
            this.Controls.Add(this.lblAddedGenres);
            this.Controls.Add(this.lblGenres);
            this.Controls.Add(this.btnAddNewStudio);
            this.Controls.Add(this.lblAddedStudios);
            this.Controls.Add(this.lblStudios);
            this.Controls.Add(this.lblMaxDuration);
            this.Controls.Add(this.lblMinDuration);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuerySubWindow";
            this.Text = "QuerySubWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblMinDuration;
        private System.Windows.Forms.Label lblMaxDuration;
        private System.Windows.Forms.Label lblStudios;
        private System.Windows.Forms.Label lblAddedStudios;
        private System.Windows.Forms.Button btnAddNewStudio;
        private System.Windows.Forms.Label lblAddedGenres;
        private System.Windows.Forms.Label lblGenres;
        private System.Windows.Forms.Button btnAddNewGenre;
        private System.Windows.Forms.Button btnChooseDirector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDirectors;
        private System.Windows.Forms.Label lblReleaseYear;
        private System.Windows.Forms.TextBox txtReleaseYear;
        private System.Windows.Forms.Button btnAgeRating;
        private System.Windows.Forms.Label lblAgeRating;
        private System.Windows.Forms.Button btnChooseLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClearFilters;
        private System.Windows.Forms.TextBox txtMinDuration;
        private System.Windows.Forms.TextBox txtMaxDuration;
    }
}