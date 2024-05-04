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
        // Lists to store data fetched from the database
        private CFilmsMetadataCache data;
        private List<int> _hoursMax = new List<int>() { 1, 2, 3, 4, 5 };
        private List<int> _hoursMin = new List<int>() { 1, 2, 3, 4, 5 };

        // Constructor
        public QuerySubWindow(IController controller, CFilmsMetadataCache data, CFilter filter, Action<CFilter> onUpdate, mainView mainView)
        {
            InitializeComponent();  // Initialize form components
            _mainView = mainView;
            this.controller = controller;
            this.data = data;
            this.onUpdate = onUpdate;
            this.filter = filter;

            cBoxMaxDuration.DataSource = _hoursMax;
            cBoxMinDuration.DataSource = _hoursMin;
            cBoxMaxDuration.SelectedItem = null;
            cBoxMinDuration.SelectedItem = null;

            // Populate combo boxes for duration selection
            cBoxMaxDuration.DataSource = _hoursMax;
            cBoxMaxDuration.SelectedItem = null;
            cBoxMinDuration.DataSource = _hoursMin;
            cBoxMinDuration.SelectedItem = null;

            if (filter.intMinLenSec != null) cBoxMinDuration.SelectedItem = filter.intMinLenSec;
            if (filter.intMaxLenSec != null) cBoxMaxDuration.SelectedItem = filter.intMaxLenSec;
            if (filter.intReleaseYear != null) tBoxReleaseYear.Text = filter.intReleaseYear.ToString();
        }
        
        // Method to handle minimum duration selection
        private void HandleMinTime()
        {
            try
            {
                if (cBoxMinDuration.SelectedItem != null) filter.intMinLenSec = Convert.ToInt32(cBoxMinDuration.SelectedItem.ToString());
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
                if (cBoxMaxDuration.SelectedItem != null) filter.intMaxLenSec = Convert.ToInt32(cBoxMaxDuration.SelectedItem.ToString());
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
                if (tBoxReleaseYear.Text != null && tBoxReleaseYear.Text != "") filter.intReleaseYear = Convert.ToInt32(tBoxReleaseYear.Text);
            }
            catch
            {
                filter.intReleaseYear = null;
            }
        }

        // Method to handle studio selection
        private void HandleStudio()
        {
            try
            {
                // var dataGridWindow = new DataGridWindow(filter, onUpdate, data.studios.OrderByDescending(x => filter.listStudios.Contains(x.Id)).ToList());
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForStudios(onUpdate);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something gone wrong on studio. " + ex.ToString(), "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to handle genre selection
        private void HandleGenres()
        {
            try
            {
                //var dataGridWindow = new DataGridWindow(filter, onUpdate, data.genres.OrderByDescending(x => filter.listGenres.Contains(x.Id)).ToList());
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForGenres(onUpdate);
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
                //var dataGridWindow = new DataGridWindow(filter, onUpdate, data.directors.OrderByDescending(x => filter.listDirectors.Contains(x.Id)).ToList());
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForDirectors(onUpdate);
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
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForAgeRatings(onUpdate);
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
                var dataGridWindow = new DataGridWindow(controller, filter);
                dataGridWindow.initForLanguages(onUpdate);
                dataGridWindow.StartPosition = FormStartPosition.CenterParent;
                dataGridWindow.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something gone wrong on language part.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.onUpdate(filter);
            Console.WriteLine("AGE " + filter.listAgeRatings.Count.ToString());
            this.Close();
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            /*QuerySubWindow querySubWindow = new QuerySubWindow(data, true, _mainView);
            Helpers.QueryModel = new QueryModel(); // Instantiate QueryModel
            querySubWindow.StartPosition = FormStartPosition.CenterParent;
            querySubWindow.ShowDialog();
            this.Close();*/
        }
    }
}
