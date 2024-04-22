using ControllerLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodFilmsApp
{
    public partial class filmView : Form
    {
        private FilmModel film;
        private IController controller;
        private Action onCloseCb;
        private FilmModel film;
        IController controller;
        IDataAccess access;
        public filmView(FilmModel film, Action onCloseCb, ref IController controller)
        {
            this.film = film;
            // this.controller = rController;
            this.onCloseCb = onCloseCb;
            this.controller = controller;
            this.access = new CDataAccess();
            InitializeComponent();
        }

        private void updateStars()
        {
            pbStar1.Image = imgStar.Images[(film.User_Rating >= 1) ? 1 : 0];
            pbStar2.Image = imgStar.Images[(film.User_Rating >= 2) ? 1 : 0];
            pbStar3.Image = imgStar.Images[(film.User_Rating >= 3) ? 1 : 0];
            pbStar4.Image = imgStar.Images[(film.User_Rating >= 4) ? 1 : 0];
            pbStar5.Image = imgStar.Images[(film.User_Rating >= 5) ? 1 : 0];
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

            CommentModel comment;
            comment = access.requestComments(film.Id);
            if (comment != null)
                txtUserComments.Text = comment.Comment_Text.ToString();
            //var data = controller.requestComments(film);
        }

        private void addComment()
        {
            if ((txtUserComments).Tag != null)
            {
               int Id = controller.addComment(film, txtUserComments.Text);
                //access.updateComment(film.Id,txtUserComments.Text, )
            }        
        //TODO implement correctly`
        }

        private void txtUserComments_TextChanged(object sender, EventArgs e)
        {
            ((txtUserComments).Tag) = true;
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
            // controller.addComment(film, film.Title, txtUserComment.Text);
        }

        private void btnAddToSchedule_Click(object sender, EventArgs e)
        {
            // controller.setFilmScheduled(film, dtpScheduleTime.Value);
        }

        private void cbFilmWatched_CheckedChanged(object sender, EventArgs e)
        {
            // controller.setFilmWatched(film, cbFilmWatched.Checked);
        }
    }
}
