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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
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
                (id, films) =>
                {
                    postersSearch.filmsRx(id, films);
                    postersRecommend.filmsRx(id, films);
                    postersScheduled.filmsRx(id, films);
                },
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
            postersSearch = new PosterHandler(7, new PosterBoxSettings(), ref gbSearchResults, new ConstRef<IController>(()=>controller));
            postersRecommend = new PosterHandler(7, new PosterBoxSettings(), ref gbRecommendedFilms, new ConstRef<IController>(() => controller));
            postersScheduled = new PosterHandler(7, new PosterBoxSettings(), ref gbScheduledFilms, new ConstRef<IController>(() => controller));
            btnSearch_Click(null, null);
            updateRecommend();
            updateSearch(false);

        }
        internal void updateSearch(bool fromFilter)
        {
            controller.clearFilters();
            if (txtSearch.Text != "" && fromFilter == false)
            {
                CFilter filter = new CFilter();
                filter.strSearch = txtSearch.Text;
                controller.addFilter(filter);
            }
            postersSearch.request(controller.requestFilms(0, 7, Helpers.QueryModel, Helpers.IsFirstLoad));
            var quey = Helpers.QueryModel;
        }
        private void updateRecommend()
        {
            controller.clearFilters();
            CFilter filter = new CFilter();
            filter.boolRandom = true;
            controller.addFilter(filter);
            postersRecommend.request(controller.requestFilms(0, 7, Helpers.QueryModel, Helpers.IsFirstLoad));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            updateSearch(false);
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

            updateSearch(false);
        }


    }
}
