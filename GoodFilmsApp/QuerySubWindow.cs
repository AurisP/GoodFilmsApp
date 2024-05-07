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
        IController controller;
        Action<CFilter> onUpdate;
        CFilter filter;
        mainView _mainView;

        // Constructor
        public QuerySubWindow(IController controller, CFilter filter, Action<CFilter> onUpdate, mainView mainView)
        {
            InitializeComponent();  // Initialize form components
            _mainView = mainView;
            this.controller = controller;
            this.onUpdate = onUpdate;
            this.filter = filter;

            // Populate combo boxes for duration selection

            // Initialize text boxes with filter values
            if (filter.intMinLenSec != null) txtMinDuration.Text = (filter.intMinLenSec / 60).ToString();
            if (filter.intMaxLenSec != null) txtMaxDuration.Text = (filter.intMaxLenSec / 60).ToString();
            if (filter.intReleaseYear != null) txtReleaseYear.Text = filter.intReleaseYear.ToString();
        }

        // Clear all filters
        private void clearFilters()
        {
            // Reset all filter properties
            filter.listAgeRatings = new List<int>();
            filter.listDirectors = new List<int>();
            filter.listGenres = new List<int>();
            filter.listLanguages = new List<int>();
            filter.listStudios = new List<int>();
            filter.intMinLenSec = null;
            filter.intMaxLenSec = null;
            filter.intReleaseYear = null;

            // Clear text boxes
            txtMinDuration.Text = "";
            txtMaxDuration.Text = "";
            txtReleaseYear.Text = "";

            // Invoke onUpdate action to apply changes
            this.onUpdate(filter);
        }

        // Method to handle studio selection
        private void HandleStudio()
        {
            try
            {
                // Open data grid window for studio selection
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForStudios(onUpdate);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Something gone wrong on studio. " + ex.ToString(), "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        // Method to handle genre selection
        private void HandleGenres()
        {
            try
            {
                // Open data grid window for genre selection
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForGenres(onUpdate);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Something gone wrong on genres.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle director selection
        private void HandleDirectors()
        {
            try
            {
                // Open data grid window for director selection
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForDirectors(onUpdate);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Something gone wrong on directors.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle age rating selection
        private void HandleAgeRatings()
        {
            try
            {
                // Open data grid window for age rating selection
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForAgeRatings(onUpdate);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                // Show error message if something goes wrong
                MessageBox.Show("Something gone wrong on age rating.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle language selection
        private void HandleLanguages()
        {
            try
            {
                // Open a data grid window for selecting languages
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForLanguages(onUpdate);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                // Display a warning message if an exception occurs during language selection
                MessageBox.Show("Something went wrong while selecting languages.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.onUpdate(filter);
            this.Close();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            clearFilters();
        }

        private void lblMaxDuration_Click(object sender, EventArgs e)
        {

        }

        // Event handler for changes in the minimum duration text box
        private void txtMinDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Parse the text in the minimum duration text box to an integer and convert to seconds
                filter.intMinLenSec = Int32.Parse(txtMinDuration.Text) * 60;
            }
            catch
            {
                // If parsing fails, set the minimum duration to null
                filter.intMinLenSec = null;
            }
            // Call the onUpdate action with the updated filter
            this.onUpdate(filter);
        }

        // Event handler for changes in the maximum duration text box
        private void txtMaxDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Parse the text in the maximum duration text box to an integer and convert to seconds
                filter.intMaxLenSec = Int32.Parse(txtMaxDuration.Text) * 60;
            }
            catch
            {
                // If parsing fails, set the maximum duration to null
                filter.intMaxLenSec = null;
            }
            // Call the onUpdate action with the updated filter
            this.onUpdate(filter);
        }

        // Event handler for changes in the release year text box
        private void txtReleaseYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Parse the text in the release year text box to an integer
                filter.intReleaseYear = Int32.Parse(txtReleaseYear.Text);
            }
            catch
            {
                // If parsing fails, set the release year to null
                filter.intReleaseYear = null;
            }
            // Call the onUpdate action with the updated filter
            this.onUpdate(filter);
        }

    }
}
