using ModelLibrary;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace GoodFilmsApp
{
    public partial class mainView : Form
    {
        List<FilmModel> films = new List<FilmModel>();
        const int noOfFilmsPerRow = 5;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        int noOfSearchResults = 0;

        public mainView()
        {
            InitializeComponent();
            LoadFilmList();
        }

        public void LoadFilmList()
        {
            films = SqliteDataAccess.LoadFilms();
            testBox.DataSource = films;
            testBox.DisplayMember = "title";
        }

        private void mainView_Load(object sender, EventArgs e)
        {
            films = SqliteDataAccess.LoadFilms();
            int noOfSearchResults = 10;
            int filmNumber = 0;
            FilmModel film = null;

            if (pictureBoxes.Count > 0) {  pictureBoxes.Clear(); }

            int noOfRows = (int)(noOfSearchResults + noOfFilmsPerRow - 1) / noOfFilmsPerRow;

            for (int i = 0; i < noOfRows + 1; i++)
            {
                for (int j = 0; j < noOfFilmsPerRow; j++)
                {
                    if (filmNumber < noOfSearchResults)
                    {
                        film = films[filmNumber];
                        PictureBox pbPoster = new PictureBox();
                        Console.WriteLine("url: ");
                        Console.WriteLine(film.Poster_Url);
                        //pbPoster.Image = Image.FromFile(film.Poster_Url);
                        pbPoster.ImageLocation = "../../"+film.Poster_Url;
                        pbPoster.Location = new Point(20 + (j * 120), 20 + (i * 170));
                        pbPoster.Size = new Size(100, 150);
                        pbPoster.SizeMode = PictureBoxSizeMode.StretchImage;
                        pbPoster.MouseClick += new MouseEventHandler(posterClickHandler);
                        
                        pictureBoxes.Add(pbPoster);
                        gbSearchResults.Controls.Add(pbPoster);

                        filmNumber++;
                    }
                }
            }
        }

        private void posterClickHandler(object sender, EventArgs e)
        {
            // calculate i, j
            int i = (((PictureBox)sender).Location.X - 20) / 120;
            int j = (((PictureBox)sender).Location.Y - 20) / 170;
            int filmNumber = j * noOfFilmsPerRow + i;
            Console.WriteLine("filmNumber: " + filmNumber);

            var filmWindow = new filmView(films[filmNumber]);
            filmWindow.Show();
        }

        private void gbSearchResults_Enter(object sender, EventArgs e)
        {

        }
    }
}
