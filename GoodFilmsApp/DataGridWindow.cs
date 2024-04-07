using ModelLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GoodFilmsApp
{
    public partial class DataGridWindow : Form
    {
        //// Lists to store different models
        List<StudioModel> _studioModels;
        List<GenreModel> _genreModel;
        List<DirectorModel> _directorModel;
        List<AgeRatingModel> _ageRatingModel;
        public DataGridWindow()
        {
            InitializeComponent(); // Form components
        }

        // Constructors to populate the data grid with a list of ...
        public DataGridWindow(List<StudioModel> studioModels)
        {
            InitializeComponent();
            _studioModels = studioModels;

            dgwMain.DataSource = _studioModels;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }

        public DataGridWindow(List<GenreModel> genreModel)
        {
            InitializeComponent();
            _genreModel = genreModel;

            dgwMain.DataSource = _genreModel;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }

        public DataGridWindow(List<DirectorModel> directorModel)
        {
            InitializeComponent();
            _directorModel = directorModel;

            dgwMain.DataSource = _directorModel;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }


        public DataGridWindow(List<AgeRatingModel> ageRatingModel)
        {
            InitializeComponent();
            _ageRatingModel = ageRatingModel;

            dgwMain.DataSource = _ageRatingModel;
            dgwMain.Columns["Id"].Visible = false;
            dgwMain.Columns["Chosen"].HeaderText = "";
        }
        //---

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // Check which list is being displayed in the data grid and update the corresponding list in the QueryModel
            if (_studioModels != null)
            {
                List<StudioModel> studios = dgwMain.DataSource as List<StudioModel>;

                Helpers.QueryModel.Studios = studios.Where(x => x.Chosen == true).ToList();
            }
            else if (_genreModel != null)
            {
                List<GenreModel> genres = dgwMain.DataSource as List<GenreModel>;

                Helpers.QueryModel.Genres = genres.Where(x => x.Chosen == true).ToList();
            }
            else if (_directorModel != null)
            {
                List<DirectorModel> directors = dgwMain.DataSource as List<DirectorModel>;

                Helpers.QueryModel.Directors = directors.Where(x => x.Chosen == true).ToList();
            }
            else if (_ageRatingModel != null)
            {
                List<AgeRatingModel> directors = dgwMain.DataSource as List<AgeRatingModel>;

                Helpers.QueryModel.AgeRatings = directors.Where(x => x.Chosen == true).ToList();
            }


            this.Close(); // Close the form
        }



    }
}
