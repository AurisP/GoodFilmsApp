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
using ViewHandler;
using ControllerLibrary;
using System.Xml.Linq;
using CSVExporterDNF;

namespace GoodFilmsApp
{
    // Represents the main view of the application.
    public partial class mainView : Form
    {
        IExporter exporter;         // Interface for exporting data.
        CFilter searchFilter;       // Filter for searching films.
        IController controller;     // Interface for controlling application logic.
        PosterHandler postersSearch;    // Handler for displaying search results.
        PosterHandler postersRecommend; // Handler for displaying recommended films.
        PosterHandler postersScheduled; // Handler for displaying scheduled films.
        internal bool _isFirstLoad = true; // Flag to track if it's the first load of the application.
        Ref<string> path;           // Reference to a string representing a file path.

        // Initializes a new instance of the mainView class.
        public mainView()
        {
            InitializeComponent();
            searchFilter = new CFilter(); // Initializes the search filter.
            controller = new CController(); // Initializes the controller.
            string myValue = null;
            path = new Ref<string>(() => myValue, value => myValue = value); // Initializes the path reference.
            exporter = new CExporter(); // Initializes the exporter.
            postersSearch = new PosterHandler(controller, this,
                7, new PosterBoxSettings(),
                gbSearchResults,
                btnSearchLeft,
                btnSearchRight,
                lblSearchPage,
                exporter,
                path); // Initializes the poster handler for search results.
            postersRecommend = new PosterHandler(controller, this,
                7, new PosterBoxSettings(),
                gbRecommendedFilms,
                btnRecommendLeft,
                btnRecommenRight,
                lblRecommendPage,
                exporter,
                path); // Initializes the poster handler for recommended films.
            postersScheduled = new PosterHandler(controller, this,
                7, new PosterBoxSettings(),
                gbScheduledFilms,
                btnScheduleLeft,
                btnScheduleRight,
                lblScheduledPage,
                exporter,
                path); // Initializes the poster handler for scheduled films.
            updateRecommend(); // Updates the recommended films.
            updateSearch(); // Updates the search results.
            updateScheduled(); // Updates the scheduled films.
        }

        // Updates the search results.
        public void updateSearch()
        {
            postersSearch.setFilter(searchFilter);
        }

        // Updates the recommended films.
        public void updateRecommend()
        {
            CFilter filter = new CFilter();
            filter.boolRandom = true;
            postersRecommend.setFilter(filter);
        }

        // Updates the scheduled films based on a filter.
        public void updateScheduled()
        {
            CFilter filter = new CFilter();
            filter.boolOnlyScheduled = true;
            postersScheduled.setFilter(filter);
        }

        // Event handler for the click event of the "Query" button.
        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            // Opens a query sub-window for filtering films.
            QuerySubWindow querySubWindow = new QuerySubWindow(controller, searchFilter, (filter) =>
            {
                searchFilter = filter;  // Updates the search filter.
                updateSearch();         // Updates the search results based on the new filter.
            }, this);
            querySubWindow.StartPosition = FormStartPosition.CenterParent; // Centers the query sub-window.
            querySubWindow.ShowDialog(this); // Displays the query sub-window.
        }

        // Event handler for the text changed event of the search textbox.
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchFilter.strSearch = txtSearch.Text; // Updates the search filter with the text from the search textbox.
            updateSearch(); // Updates the search results based on the updated filter.
        }

    }
}
