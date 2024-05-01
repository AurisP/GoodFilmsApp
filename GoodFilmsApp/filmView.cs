using ControllerLibrary;
using ModelLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GoodFilmsApp
{
    public partial class filmView : Form
    {
        private Action onCloseCb;
        private FilmModel film;
        IController controller;
        IDataAccess access;

        List<LanguageModel> _languages;
        List<StudioModel> _studios;
        List<GenreModel> _genres;
        string _director;
        int _releaseYear;
        double _durationHour;
        string _ageRating;
 
        private bool ignoreCheck;
        private mainView parent;
        public filmView(mainView parent, FilmModel film, Action onCloseCb, IController controller)
        {
            this.parent = parent;
            this.film = film;
            this.onCloseCb = onCloseCb;
            this.controller = controller;
            InitializeComponent();


            _languages = CDataAccess.LoadLanguages()
                .Where(
                d => CDataAccess.LoadLanguagesFilms()
                .Where(x => x.film_id == film.Id)
                .Select(s => (int)s.language_id)
                .Contains(d.Id)).ToList();
            _studios = CDataAccess.LoadStudios()
                .Where(
                d => CDataAccess.LoadStudioFilms()
                .Where(x => x.film_id == film.Id)
                .Select(s => (int)s.studio_id)
                .Contains(d.Id)).ToList();
            _genres = CDataAccess.LoadGenres()
                .Where(
                d => CDataAccess.LoadGenresFilms()
                .Where(x => x.film_id == film.Id)
                .Select(s => (int)s.genre_id)
                .Contains(d.Id)).ToList();

            _director = CDataAccess.LoadDirectors().Where(d => d.Id == CDataAccess.LoadDirectorFilms().Where(x => x.Id == film.Id).FirstOrDefault().director_id).FirstOrDefault().Name;
            _releaseYear = film.Release_Year;
            // Convert the duration in seconds to a TimeSpan object
            TimeSpan duration = TimeSpan.FromSeconds(film.Duration_Sec);
            // Calculate hours and minutes separately
            int hours = duration.Hours;
            int minutes = duration.Minutes;
            // Display the duration in hours and minutes
            lblDurationResult.Text = $"{hours}h {minutes}min";
            _ageRating = CDataAccess.LoadAgeRatings().Where(x => x.Id == film.age_rating_id).FirstOrDefault().Rating.ToString();

            lblDirectorResult.Text = _director;
            lblReleaseYearResult.Text = _releaseYear.ToString();
            lblAgeRatingResult.Text = _ageRating;


        }

        private void updateStars()
        {
            pbStar1.Image = imgStar.Images[(film.User_Rating >= 1) ? 1 : 0];
            pbStar2.Image = imgStar.Images[(film.User_Rating >= 2) ? 1 : 0];
            pbStar3.Image = imgStar.Images[(film.User_Rating >= 3) ? 1 : 0];
            pbStar4.Image = imgStar.Images[(film.User_Rating >= 4) ? 1 : 0];
            pbStar5.Image = imgStar.Images[(film.User_Rating >= 5) ? 1 : 0];
            controller.setFilmRating(film, film.User_Rating, null, (error) => { MessageBox.Show(error); });
        }

        private void filmView_Load(object sender, EventArgs e)
        {
            lblFilmName.Text = film.Title;
            pbPoster.ImageLocation = "../../" + film.Poster_Url;
            updateStars();
            pbStar1.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = film.User_Rating != 1 ? 1 : 0; updateStars(); }); // TOOD: Update database
            pbStar2.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = 2; updateStars(); });
            pbStar3.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = 3; updateStars(); });
            pbStar4.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = 4; updateStars(); });
            pbStar5.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = 5; updateStars(); });
            txtMovieInfo.Text = film.Description;
            // Convert the duration in seconds to a TimeSpan object
            TimeSpan duration = TimeSpan.FromSeconds(film.Duration_Sec);
            // Display the duration in hours, minutes, and seconds
            txtMovieInfo.Text += $"Duration: {duration.Hours}h, {duration.Minutes}min";

            controller.requestComment(film, (comment) =>
            {
                if (comment == null) return;
                this.Invoke(new Action(() => {
                    txtUserComment.Text = comment.Comment_Text.ToString();
                }));
            }, 
            (error) => { MessageBox.Show(error); });
            ignoreCheck = true;
            cbFilmWatched.Checked = film.Watched;
            ignoreCheck = false;
        }

        private void addComment()
        {
            if (txtUserComment.Text == null) return;
            controller.addComment(film, txtUserComment.Text, null, (error) => { MessageBox.Show(error); });
        }

        private void txtUserComments_TextChanged(object sender, EventArgs e)
        {
            txtUserComment.Tag = true;
        }

        private void filmView_FormClosing(object sender, FormClosingEventArgs e)
        {
            addComment();
        }

        private void filmView_Closed(object sender, FormClosedEventArgs e)
        {
            onCloseCb();
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            addComment();
        }

        private void btnAddToSchedule_Click(object sender, EventArgs e)
        {
            controller.setFilmScheduled(film, dtpScheduleTime.Value, () => { this.parent.updateScheduled(); }, (error) => { MessageBox.Show(error); });
        }

        private void cbFilmWatched_CheckedChanged(object sender, EventArgs e)
        {
            if (ignoreCheck) return;
            controller.setFilmWatched(film, cbFilmWatched.Checked, null, (error) => { MessageBox.Show(error); });
            film.Watched = cbFilmWatched.Checked;
        }

        private void lblLanguageResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InformationDataGridWindow informationDataGridWİndow = new InformationDataGridWindow(_languages);
            informationDataGridWİndow.StartPosition = FormStartPosition.CenterParent;
            informationDataGridWİndow.ShowDialog(this);
        }

        private void lblStudioResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InformationDataGridWindow informationDataGridWİndow = new InformationDataGridWindow(_studios);
            informationDataGridWİndow.StartPosition = FormStartPosition.CenterParent;
            informationDataGridWİndow.ShowDialog(this);
        }

        private void lblGenreResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InformationDataGridWindow informationDataGridWindow = new InformationDataGridWindow(_genres);
            informationDataGridWindow.StartPosition = FormStartPosition.CenterParent;
            informationDataGridWindow.ShowDialog(this);
        }

       
    }
}
