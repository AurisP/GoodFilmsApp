﻿using ModelLibrary;
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
    public partial class mainView : Form
    {
        IExporter exporter;
        CFilter searchFilter;
        IController controller;
        PosterHandler postersSearch;
        PosterHandler postersRecommend;
        PosterHandler postersScheduled;
        internal bool _isFirstLoad = true;
        Ref<string> path;
        public mainView()
        {
            InitializeComponent();
            searchFilter = new CFilter();
            controller = new CController();
            metadataCache = null;
            postersSearch = new PosterHandler(controller, this,
                7, new PosterBoxSettings(), 
                gbSearchResults,
                btnSearchLeft,
                btnSearchRight,
                lblSearchPage,
                exporter,
                path);
            postersRecommend = new PosterHandler(controller, this,
                7, new PosterBoxSettings(),
                gbRecommendedFilms,
                btnRecommendLeft,
                btnRecommenRight,
                lblRecommendPage,
                exporter,
                path);
            postersScheduled = new PosterHandler(controller, this,
                7, new PosterBoxSettings(),
                gbScheduledFilms,
                btnScheduleLeft,
                btnScheduleRight,
                lblScheduledPage,
                exporter,
                path); ; ;
            updateRecommend();
            updateSearch();
        }
        private void updateSearch()
        {
            postersSearch.setFilter(searchFilter);
        }
        private void updateRecommend()
        {
            CFilter filter = new CFilter();
            filter.boolRandom = true;
            postersRecommend.setFilter(filter);
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
