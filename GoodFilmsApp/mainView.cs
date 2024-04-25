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
        IController controller;
        int metadataId;
        CFilmsMetadataCache metadataCache;
        PosterHandler postersSearch;
        PosterHandler postersRecommend;
        PosterHandler postersScheduled;
        internal bool _isFirstLoad = true;
        public mainView()
        {
            InitializeComponent();
            controller = new CController(
                (id, films) => { },
                (id, cache) =>
                {
                    if (id != metadataId)
                    {
                        Console.WriteLine("Controller Error: Incorrect ID ", id, " in metadata rx, expected ", metadataId);
                        return;
                    }
                    metadataCache = cache;
                },
                (id, _) => { },
                (id, comment) => { PosterHandler.rxComment(comment, id); },
                (id, err) => Console.WriteLine("Controller Error: " + err));
            metadataId = controller.requestMeta();
            metadataCache = null;
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
        internal void updateSearch()
        {
            CFilter filter = new CFilter();
            filter.strSearch = txtSearch.Text;
            postersSearch.setFilter(filter);
        }
        private void updateRecommend()
        {
            CFilter filter = new CFilter();
            filter.boolRandom = true;
            postersRecommend.setFilter(filter);
        }

        //##
        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            if (metadataCache == null) return; // TODO: Delay window instead of rejecting perhaps?
            QuerySubWindow querySubWindow = new QuerySubWindow(new ConstRef<CFilmsMetadataCache>(() => metadataCache), false, this);

            querySubWindow.StartPosition = FormStartPosition.CenterParent;
            querySubWindow.ShowDialog(this);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                Helpers.QueryModel.Query = null;
            else
                Helpers.QueryModel.Query = txtSearch.Text;

            updateSearch();
        }


    }
}
