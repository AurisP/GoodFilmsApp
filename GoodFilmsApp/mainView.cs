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

namespace GoodFilmsApp
{
    public partial class mainView : Form
    {
        List<FilmModel> film = new List<FilmModel>();
        public mainView()
        {
            InitializeComponent();
            LoadFilmList();
        }

        public void LoadFilmList()
        {
            film = CDataAccess.loadFilm(1, 4);
            testBox.DataSource = film;
            testBox.DisplayMember = "title";
        }
    }
}
