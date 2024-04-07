using ModelLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GoodFilmsApp
{
    // Partial class for the QuerySubWindow form
    public partial class QuerySubWindow : Form
    {
        // Lists to store data fetched from the database
        private List<StudioModel> _studios;
        private List<GenreModel> _genres;
        private List<DirectorModel> _directors;
        private List<AgeRatingModel> _ageRatings;
        private List<int> _hoursMax = new List<int>() { 1, 2, 3, 4, 5 };
        private List<int> _hoursMin = new List<int>() { 1, 2, 3, 4, 5 };

        // Constructor
        public QuerySubWindow()
        {
            InitializeComponent();  // Initialize form components
            Helpers.QueryModel = new QueryModel(); // Instantiate QueryModel

            // Load data from SQLite database into lists
            _studios = CDataAccess.LoadStudios();
            _genres = CDataAccess.LoadGenres();
            _directors = CDataAccess.LoadDirectors();
            _ageRatings = CDataAccess.LoadAgeRatings();


            // Populate combo boxes for duration selection
            cBoxMaxDuration.DataSource = _hoursMax;
            cBoxMaxDuration.SelectedItem = null;
            cBoxMinDuration.DataSource = _hoursMin;
            cBoxMinDuration.SelectedItem = null;

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
                    Helpers.QueryModel.ReleaseYear = Convert.ToInt32(tBoxReleaseYear.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something gone wrong on Release Year.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    studiosTemp.AddRange(_studios);
                    dataGridWindow = new DataGridWindow(studiosTemp.Distinct().ToList());
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
                    genresTemp.AddRange(_genres);
                    dataGridWindow = new DataGridWindow(genresTemp.Distinct().ToList());

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
                    directorsTemp.AddRange(_directors);
                    dataGridWindow = new DataGridWindow(directorsTemp.Distinct().ToList());

                }
                else
                    dataGridWindow = new DataGridWindow(_directors);
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
                    ageRatingTemp.AddRange(_ageRatings);
                    dataGridWindow = new DataGridWindow(ageRatingTemp.Distinct().ToList());

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

        // Method to handle query parameters
        private void HandleQuery()
        {
            HandleMinTime();
            HandleMaxTime();
            HandleReleaseYear();

        }

        //Buttons:
        private void btnAddNewStudio_Click(object sender, EventArgs e)
        {
            HandleStudio();
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
            MessageBox.Show("Searched");

        }


    }
}
