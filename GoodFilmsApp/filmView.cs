using ControllerLibrary;
using CSVExporterDNF;
using ModelLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GoodFilmsApp
{
    public partial class filmView : Form
    {
        private FilmModel film;
        private IController controller;
        private IExporter exporter;
        private Action onCloseCb;
        private int commentId;
        private Ref<string> path;
        private bool ignoreCheck;
        private mainView parent;

        public filmView(mainView parent, FilmModel film, Action onCloseCb, IController controller, IExporter exporter, Ref<string> path)
        {
            this.parent = parent;
            this.film = film;
            this.onCloseCb = onCloseCb;
            this.controller = controller;
            this.exporter = exporter;
            this.path = path;
            InitializeComponent();

        }

        private void updateStars()
        {
            // Updates the star images based on the film's user rating and sends the updated rating to the controller
            pbStar1.Image = imgStar.Images[(film.User_Rating >= 1) ? 1 : 0];
            pbStar2.Image = imgStar.Images[(film.User_Rating >= 2) ? 1 : 0];
            pbStar3.Image = imgStar.Images[(film.User_Rating >= 3) ? 1 : 0];
            pbStar4.Image = imgStar.Images[(film.User_Rating >= 4) ? 1 : 0];
            pbStar5.Image = imgStar.Images[(film.User_Rating >= 5) ? 1 : 0];
            controller.setFilmRating(film, film.User_Rating, null, (error) => { MessageBox.Show(error); });
        }

        private void filmView_Load(object sender, EventArgs e)
        {
            // Sets the film name and poster image location
            lblFilmName.Text = film.Title;
            pbPoster.ImageLocation = "../../" + film.Poster_Url;
            // Updates the star images
            updateStars();

            // Event handlers for updating the film's user rating
            pbStar1.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = film.User_Rating != 1 ? 1 : 0; updateStars(); });
            pbStar2.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = 2; updateStars(); });
            pbStar3.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = 3; updateStars(); });
            pbStar4.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = 4; updateStars(); });
            pbStar5.MouseClick += new MouseEventHandler((a, b) => { film.User_Rating = 5; updateStars(); });

            // Displays the movie description and duration
            txtMovieInfo.Text = film.Description;
            TimeSpan duration = TimeSpan.FromSeconds(film.Duration_Sec);
            txtMovieInfo.Text += $"Duration: {duration.Hours}h, {duration.Minutes}min";

            // Requests and displays the user comment for the film
            controller.requestComment(film, (comment) =>
            {
                if (comment == null) return;
                this.Invoke(new Action(() =>
                {
                    txtUserComment.Text = comment.Comment_Text.ToString();
                }));
            },
            (error) => { MessageBox.Show(error); });

            // Sets the checkbox state for whether the film is watched
            ignoreCheck = true;
            cbFilmWatched.Checked = film.Watched;
            ignoreCheck = false;
        }



        private void addComment()
        {
            // Adds the user comment for the film
            if (txtUserComment.Text == null) return;
            controller.addComment(film, txtUserComment.Text, null, (error) => { MessageBox.Show(error); });
        }

        private void txtUserComments_TextChanged(object sender, EventArgs e)
        {
            txtUserComment.Tag = true;
        }

        private void filmView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Adds the comment when the form is closing
            addComment();
        }

        private void filmView_Closed(object sender, FormClosedEventArgs e)
        {
            // Invokes the onCloseCb action when the form is closed
            onCloseCb();
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            // Saves the comment when the Save button is clicked
            addComment();
        }

        private void btnAddToSchedule_Click(object sender, EventArgs e)
        {
            // Adds the film to the schedule when the Add to Schedule button is clicked
            controller.setFilmScheduled(film, dtpScheduleTime.Value, () => { this.parent.updateScheduled(); }, (error) => { MessageBox.Show(error); });
        }

        private void cbFilmWatched_CheckedChanged(object sender, EventArgs e)
        {
            // Sets the film watched status when the checkbox state changes
            if (ignoreCheck) return;
            controller.setFilmWatched(film, cbFilmWatched.Checked, null, (error) => { MessageBox.Show(error); });
            film.Watched = cbFilmWatched.Checked;
        }

        //private void lblLanguageResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    InformationDataGridWindow informationDataGridWİndow = new InformationDataGridWindow(_languages);
        //    informationDataGridWİndow.StartPosition = FormStartPosition.CenterParent;
        //    informationDataGridWİndow.ShowDialog(this);
        //}

        //private void lblStudioResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    InformationDataGridWindow informationDataGridWİndow = new InformationDataGridWindow(_studios);
        //    informationDataGridWİndow.StartPosition = FormStartPosition.CenterParent;
        //    informationDataGridWİndow.ShowDialog(this);
        //}

        //private void lblGenreResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    InformationDataGridWindow informationDataGridWindow = new InformationDataGridWindow(_genres);
        //    informationDataGridWindow.StartPosition = FormStartPosition.CenterParent;
        //    informationDataGridWindow.ShowDialog(this);
        //}

        private void btnSaveAs_Click_1(object sender, EventArgs e)
        {
            // Opens the CSView form to save the film details
            CSView csview = new CSView(film, exporter, path);
            csview.StartPosition = FormStartPosition.CenterParent;
            csview.ShowDialog(this);
        }

    }
}
