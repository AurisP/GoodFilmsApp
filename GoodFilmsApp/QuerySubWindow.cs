using ModelLibrary;
using ModelLibrary.Models;
using ControllerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GoodFilmsApp
{
    // Partial class for the QuerySubWindow form
    public partial class QuerySubWindow : Form
    {

        private List<StudioModel> _studios;
        private List<GenreModel> _genres;
        private List<DirectorModel> _directors;
        private List<AgeRatingModel> _ageRatings;
        private List<LanguageModel> _languages;
        private mainView _mainView;
        // Lists to store data fetched from the database
        private ConstRef<CFilmsMetadataCache> _data;
        private List<int> _hoursMax = new List<int>() { 1, 2, 3, 4, 5 };
        private List<int> _hoursMin = new List<int>() { 1, 2, 3, 4, 5 };

        // Constructor
        public QuerySubWindow(ConstRef<CFilmsMetadataCache> data, bool isCleared, mainView mainView)
        {
            InitializeComponent();  // Initialize form components
            //Helpers.QueryModel = new QueryModel(); // Instantiate QueryModel
            _mainView = mainView;
            this._data = data;

            // Load data from database
            _studios = CDataAccess.LoadStudios();
            _genres = CDataAccess.LoadGenres();
            _directors = CDataAccess.LoadDirectors();
            _ageRatings = CDataAccess.LoadAgeRatings();
            _languages = CDataAccess.LoadLanguages();

            // Initialize combo boxes for duration selection
            cBoxMaxDuration.DataSource = _hoursMax;
            cBoxMinDuration.DataSource = _hoursMin;
            cBoxMaxDuration.SelectedItem = null;
            cBoxMinDuration.SelectedItem = null;

            // Set DropDownStyle to DropDownList for read-only behavior
            cBoxMinDuration.DropDownStyle = ComboBoxStyle.DropDownList;
            cBoxMaxDuration.DropDownStyle = ComboBoxStyle.DropDownList;


            // Populate combo boxes for duration selection
            cBoxMaxDuration.DataSource = _hoursMax;
            cBoxMaxDuration.SelectedItem = null;
            cBoxMinDuration.DataSource = _hoursMin;
            cBoxMinDuration.SelectedItem = null;


            // Check if filters need to be cleared
            if (!isCleared)
            {
                // Populate filters with previous selections
                var temp = Helpers.QueryModel;

                if (Helpers.QueryModel.MinDuration != 0)
                    cBoxMinDuration.SelectedItem = Helpers.QueryModel.MinDuration;
                if (Helpers.QueryModel.MaxDuration != 0)
                    cBoxMaxDuration.SelectedItem = Helpers.QueryModel.MaxDuration;
                if (Helpers.QueryModel.ReleaseYear != 0)
                    tBoxReleaseYear.Text = Helpers.QueryModel.ReleaseYear.ToString();

            }
        }


        // Method to handle minimum duration selection
        private void HandleMinTime()
        {
            try
            {
                if (cBoxMinDuration.SelectedItem != null)
                    Helpers.QueryModel.MinDuration = Convert.ToInt32(cBoxMinDuration.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose min duration.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle maximum duration selection
        private void HandleMaxTime()
        {
            try
            {
                if (cBoxMaxDuration.SelectedItem != null)
                    Helpers.QueryModel.MaxDuration = Convert.ToInt32(cBoxMaxDuration.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Please choose max duration.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle release year selection
        private void HandleReleaseYear()
        {
            try
            {
                if (!string.IsNullOrEmpty(tBoxReleaseYear.Text))
                {
                    int releaseYear = Convert.ToInt32(tBoxReleaseYear.Text);
                    if (releaseYear == 0)
                    {
                        MessageBox.Show("Release year cannot be 0.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Exit the method without further processing
                    }
                    Helpers.QueryModel.ReleaseYear = releaseYear;
                }
                else
                {
                    // If the input is empty, set release year to 0 or handle it as needed
                    Helpers.QueryModel.ReleaseYear = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid release year format.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle query parameters
        private void HandleQuery()
        {
            HandleMinTime();
            HandleMaxTime();
            HandleReleaseYear();

            // Check if min duration is greater than max duration
            if (Helpers.QueryModel.MinDuration > Helpers.QueryModel.MaxDuration && Helpers.QueryModel.MaxDuration > 0) // can also leave blank
            {
                MessageBox.Show("Minimum duration cannot be greater than maximum duration.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Helpers.QueryModel.MinDuration = 0; // Reset min duration
                Helpers.QueryModel.MaxDuration = 0; // Reset max duration
            }



        }

        // Method to handle studio selection
        private void HandleStudio()
        {
            try
            {
                DataGridWindow dataGridWindow;
                if (Helpers.QueryModel.Studios.Count != 0)
                {

                    var studiosTemp = Helpers.QueryModel.Studios;
                    var existingStudioIds = studiosTemp.Select(x => x.Id).ToList();

                    studiosTemp.AddRange(_studios.Where(x => !existingStudioIds.Contains(x.Id)));
                    dataGridWindow = new DataGridWindow(studiosTemp.OrderByDescending(x => x.Chosen).Distinct().ToList());
                }
                else
                    dataGridWindow = new DataGridWindow(_studios);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something gone wrong on studio.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle genre selection
        private void HandleGenres()
        {
            try
            {
                DataGridWindow dataGridWindow;
                if (Helpers.QueryModel.Genres.Count != 0)
                {
                    var genresTemp = Helpers.QueryModel.Genres;
                    var existingGenresIds = genresTemp.Select(x => x.Id).ToList();

                    genresTemp.AddRange(_genres.Where(x => !existingGenresIds.Contains(x.Id)));
                    dataGridWindow = new DataGridWindow(genresTemp.OrderByDescending(x => x.Chosen).Distinct().ToList());
                }
                else
                    dataGridWindow = new DataGridWindow(_genres);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something gone wrong on genres.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle director selection
        private void HandleDirectors()
        {
            try
            {
                DataGridWindow dataGridWindow;
                if (Helpers.QueryModel.Directors.Count != 0)
                {
                    var directorsTemp = Helpers.QueryModel.Directors;
                    var existingDirectorId = directorsTemp.Select(x => x.Id).ToList();

                    directorsTemp.AddRange(_directors.Where(x => !existingDirectorId.Contains(x.Id)));
                    dataGridWindow = new DataGridWindow(directorsTemp.OrderByDescending(x => x.Chosen).Distinct().ToList());

                }
                else
                    dataGridWindow = new DataGridWindow(_directors.ToList());
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something gone wrong on directors.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle age rating selection
        private void HandleAgeRatings()
        {
            try
            {
                DataGridWindow dataGridWindow;
                if (Helpers.QueryModel.AgeRatings.Count != 0)
                {
                    var ageRatingTemp = Helpers.QueryModel.AgeRatings;
                    var existingAgeIds = ageRatingTemp.Select(x => x.Id).ToList();

                    ageRatingTemp.AddRange(_ageRatings.Where(x => !existingAgeIds.Contains(x.Id)));
                    dataGridWindow = new DataGridWindow(ageRatingTemp.OrderByDescending(x => x.Chosen).Distinct().ToList());
                }
                else
                    dataGridWindow = new DataGridWindow(_ageRatings);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something gone wrong on age rating.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void HandleLanguages()
        {
            try
            {
                DataGridWindow dataGridWindow;
                if (Helpers.QueryModel.Languages.Count != 0)
                {
                    var languageTemp = Helpers.QueryModel.Languages;
                    var existingLanguageIds = languageTemp.Select(x => x.Id).ToList();

                    languageTemp.AddRange(_languages.Where(x => !existingLanguageIds.Contains(x.Id)));
                    dataGridWindow = new DataGridWindow(languageTemp.OrderByDescending(x => x.Chosen).Distinct().ToList());
                }
                else
                    dataGridWindow = new DataGridWindow(_languages);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something gone wrong on language part.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Buttons:
        private void btnAddNewStudio_Click(object sender, EventArgs e)
        {
            HandleStudio();
        }

        private void btnChooseLanguage_Click(object sender, EventArgs e)
        {
            HandleLanguages();
        }

        private void btnAddNewGenre_Click(object sender, EventArgs e)
        {
            HandleGenres();
        }

        private void btnChooseDirector_Click(object sender, EventArgs e)
        {
            HandleDirectors();
        }

        private void btnAgeRating_Click(object sender, EventArgs e)
        {
            HandleAgeRatings();
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            HandleQuery();
            var query = Helpers.QueryModel;
            this.Close();
            _mainView.updateSearch(true);
            //MessageBox.Show("Searched");

        }


        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            QuerySubWindow querySubWindow = new QuerySubWindow(_data, true, _mainView);
            Helpers.QueryModel = new QueryModel(); // Instantiate QueryModel
            querySubWindow.StartPosition = FormStartPosition.CenterParent;
            querySubWindow.ShowDialog();
            this.Close();
        }
    }
}
