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

            if (filter.intMinLenSec != null) txtMinDuration.Text = (filter.intMinLenSec/60).ToString();
            if (filter.intMaxLenSec != null) txtMaxDuration.Text = (filter.intMaxLenSec/60).ToString();
            if (filter.intReleaseYear != null) txtReleaseYear.Text = filter.intReleaseYear.ToString();
        }
        private void clearFilters()
        {
            filter.listAgeRatings = new List<int>();
            filter.listDirectors = new List<int>();
            filter.listGenres = new List<int>();
            filter.listLanguages = new List<int>();
            filter.listStudios = new List<int>();
            filter.intMinLenSec = null;
            filter.intMaxLenSec = null;
            filter.intReleaseYear = null;
            txtMinDuration.Text = "";
            txtMaxDuration.Text = "";
            txtReleaseYear.Text = "";
            this.onUpdate(filter);
        }

        // Method to handle studio selection
        private void HandleStudio()
        {
            try
            {
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

        private void txtMinDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filter.intMinLenSec = Int32.Parse(txtMinDuration.Text) * 60;
            }
            catch
            {
                filter.intMinLenSec = null;
            }
            this.onUpdate(filter);
        }

        private void txtMaxDuration_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filter.intMaxLenSec = Int32.Parse(txtMaxDuration.Text) * 60;
            }
            catch
            {
                filter.intMaxLenSec = null;
            }
            this.onUpdate(filter);
        }

        private void txtReleaseYear_TextChanged(object sender, EventArgs e)
        {
            try
            {
                filter.intReleaseYear = Int32.Parse(txtReleaseYear.Text);
            }
            catch
            {
                filter.intReleaseYear = null;
            }
            this.onUpdate(filter);
        }
    }
}
