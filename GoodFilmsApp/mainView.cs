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
            films = CDataAccess.requestFilms(0 ,0);
            testBox.DataSource = films;
            testBox.DisplayMember = "title";
        }


        //##
        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            QuerySubWindow querySubWindow = new QuerySubWindow();

            querySubWindow.StartPosition = FormStartPosition.CenterParent;
            querySubWindow.ShowDialog(this);
        }


        private void mainView_Load(object sender, EventArgs e)
        {
            int noOfSearchResults = 10;
            int filmNumber = 0;
            films = CDataAccess.requestFilms(1, noOfSearchResults);
            if (pictureBoxes.Count > 0) pictureBoxes.Clear();
            int noOfRows = (int)(noOfSearchResults + noOfFilmsPerRow - 1) / noOfFilmsPerRow;
            for (int i = 0; i < noOfRows + 1; i++)
            {
                for (int j = 0; j < noOfFilmsPerRow; j++)
                {
                    if (filmNumber >= noOfSearchResults) continue;
                    int filmNumberCopy = filmNumber;

                    FilmModel film = films[filmNumber];
                    PictureBox pbPoster = new PictureBox();
                    Console.WriteLine("url: ");
                    Console.WriteLine(film.Poster_Url);
                    //pbPoster.Image = Image.FromFile(film.Poster_Url);
                    pbPoster.ImageLocation = "../../"+film.Poster_Url;
                    pbPoster.Location = new Point(20 + (j * 120), 20 + (i * 170));
                    pbPoster.Size = new Size(100, 150);
                    pbPoster.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbPoster.MouseClick += new MouseEventHandler((_, __) => posterClickHandler(filmNumberCopy));
                        
                    pictureBoxes.Add(pbPoster);
                    gbSearchResults.Controls.Add(pbPoster);

                    filmNumber++;
                }
            }
        }

        private void posterClickHandler(int filmNumber)
        {
            Console.WriteLine("filmNumber: " + filmNumber);
            var filmWindow = new filmView(films[filmNumber]);
            filmWindow.Show();
        }

        private void gbSearchResults_Enter(object sender, EventArgs e)
        {

        }

    }
}
