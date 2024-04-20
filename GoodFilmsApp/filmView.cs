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
        IController controller;
        FilmModel film;

        public filmView()
        {
            InitializeComponent();
        }

        public filmView(FilmModel filmModel)
        {
            film = filmModel;
            InitializeComponent();
        }

        private void filmView_Load(object sender, EventArgs e)
        {
            lblFilmName.Text = film.Title;
            pbPoster.ImageLocation = "../../" + film.Poster_Url;
            pbStar1.Image = imgStar.Images[(film.User_Rating >= 1) ? 1 : 0];
            pbStar2.Image = imgStar.Images[(film.User_Rating >= 2) ? 1 : 0];
            pbStar3.Image = imgStar.Images[(film.User_Rating >= 3) ? 1 : 0];
            pbStar4.Image = imgStar.Images[(film.User_Rating >= 4) ? 1 : 0];
            pbStar5.Image = imgStar.Images[(film.User_Rating >= 5) ? 1 : 0];
            txtMovieInfo.Text = film.Description;
            // Convert the duration in seconds to a TimeSpan object
            TimeSpan duration = TimeSpan.FromSeconds(film.Duration_Sec);
            // Display the duration in hours, minutes, and seconds
            txtMovieInfo.Text += $"Duration: {duration.Hours}h, {duration.Minutes}min";

            //txtUserComments.Text = controller.requestComments(film);

        }

        private void updateComment()
        {
            if ((txtUserComments).Tag != null)
                controller.addComment(film, txtUserComments.Text);
        }

        private void txtUserComments_TextChanged(object sender, EventArgs e)
        {
            ((txtUserComments).Tag) = true;
        }

        private void filmView_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateComment();
        }

        private void starClickHandler(object sender, EventArgs e)
        {

        }
    }
}
