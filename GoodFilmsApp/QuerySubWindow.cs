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
        // Lists to store data fetched from the database
        private ConstRef<CFilmsMetadataCache> data;
        private List<int> _hoursMax = new List<int>() { 1, 2, 3, 4, 5 };
        private List<int> _hoursMin = new List<int>() { 1, 2, 3, 4, 5 };

        // Constructor
        public QuerySubWindow(ConstRef<CFilmsMetadataCache> data)
        {
            InitializeComponent();  // Initialize form components
            Helpers.QueryModel = new QueryModel(); // Instantiate QueryModel

            this.data = data;

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
                    studiosTemp.AddRange(data.Value.studios);
                    dataGridWindow = new DataGridWindow(studiosTemp.Distinct().ToList());
                }
                else // TODO: Formatting, this looks cursed
                    dataGridWindow = new DataGridWindow(data.Value.studios);
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
                    genresTemp.AddRange(data.Value.genres);
                    dataGridWindow = new DataGridWindow(genresTemp.Distinct().ToList());

                }
                else
                    dataGridWindow = new DataGridWindow(data.Value.genres);
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
                    directorsTemp.AddRange(data.Value.directors);
                    dataGridWindow = new DataGridWindow(directorsTemp.Distinct().ToList());

                }
                else
                    dataGridWindow = new DataGridWindow(data.Value.directors);
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
                    ageRatingTemp.AddRange(data.Value.ageRatings);
                    dataGridWindow = new DataGridWindow(ageRatingTemp.Distinct().ToList());

                }
                else
                    dataGridWindow = new DataGridWindow(data.Value.ageRatings);
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
