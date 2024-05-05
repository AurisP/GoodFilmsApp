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

namespace GoodFilmsApp
{
    public partial class mainView : Form
    {
        CFilter searchFilter;
        IController controller;
        PosterHandler postersSearch;
        PosterHandler postersRecommend;
        PosterHandler postersScheduled;
        internal bool _isFirstLoad = true;
        public mainView()
        {
            InitializeComponent();
            searchFilter = new CFilter();
            controller = new CController();
            postersSearch = new PosterHandler(controller, this,
                7, new PosterBoxSettings(), 
                gbSearchResults,
                btnSearchLeft,
                btnSearchRight,
                lblSearchPage);
            postersRecommend = new PosterHandler(controller, this,
                7, new PosterBoxSettings(),
                gbRecommendedFilms,
                btnRecommendLeft,
                btnRecommenRight,
                lblRecommendPage);
            postersScheduled = new PosterHandler(controller, this,
                7, new PosterBoxSettings(),
                gbScheduledFilms,
                btnScheduleLeft,
                btnScheduleRight,
                lblScheduledPage);
            updateRecommend();
            updateSearch();
        }
        public void updateSearch()
        {
            postersSearch.setFilter(searchFilter);
        }
        public void updateRecommend()
        {
            CFilter filter = new CFilter();
            filter.boolRandom = true;
            postersRecommend.setFilter(filter);
        }
        public void updateScheduled()
        {
            CFilter filter = new CFilter();
            filter.boolOnlyScheduled = true;
            postersScheduled.setFilter(filter);
        }
        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            QuerySubWindow querySubWindow = new QuerySubWindow(controller, searchFilter, (filter) => {
                searchFilter = filter;
                updateSearch();
            }, this);
            querySubWindow.StartPosition = FormStartPosition.CenterParent;
            querySubWindow.ShowDialog(this);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchFilter.strSearch = txtSearch.Text;
            updateSearch();
        }
    }
}
