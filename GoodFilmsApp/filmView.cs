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
            pbStar1.Image = imgStar.Images[(film.UserRating >= 1) ? 1 : 0];
            pbStar2.Image = imgStar.Images[(film.UserRating >= 2) ? 1 : 0];
            pbStar3.Image = imgStar.Images[(film.UserRating >= 3) ? 1 : 0];
            pbStar4.Image = imgStar.Images[(film.UserRating >= 4) ? 1 : 0];
            pbStar5.Image = imgStar.Images[(film.UserRating >= 5) ? 1 : 0];
            txtMovieInfo.Text = film.Description;
            // txtUserComments.Text = film.Comments[0].CommentText;
            pbStar1.MouseClick += new MouseEventHandler(starClickHandler);

        }

        private void starClickHandler(object sender, EventArgs e)
        {

        }
    }
}
