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

namespace GoodFilmsApp
{
    public partial class mainView : Form
    {
        bool detailOpen;
        IController controller;
        int metadataId;
        CFilmsMetadataCache metadataCache;
        PosterHandler postersSearch;
        PosterHandler postersRecommend;
        PosterHandler postersScheduled;
        public mainView()
        {
            InitializeComponent();
            controller = new CController(
                (id, films) => {
                    postersSearch.filmsRx(id, films);
                    postersRecommend.filmsRx(id, films);
                    postersScheduled.filmsRx(id, films);
                },
                (id, cache) => {
                    if (id != metadataId)
                    {
                        Console.WriteLine("Controller Error: Incorrect ID ", id, " in metadata rx, expected ", metadataId);
                        return;
                    }
                    metadataCache = cache;
                },
                (id, _) => { },
                (id, err) => Console.WriteLine("Controller Error: " + err));
            metadataId = controller.requestMeta();
            metadataCache = null;
            postersSearch = new PosterHandler(7, new PosterBoxSettings(), ref gbSearchResults);
            postersRecommend = new PosterHandler(7, new PosterBoxSettings(), ref gbRecommendedFilms);
            postersScheduled = new PosterHandler(7, new PosterBoxSettings(), ref gbScheduledFilms);
            detailOpen = false;
            btnSearch_Click(null, null);
            updateRecommend();
            updateSearch();
        }
        private void updateSearch()
        {
            controller.clearFilters();
            if (txtSearch.Text != "")
            {
                CFilter filter = new CFilter();
                filter.strSearch = txtSearch.Text;
                controller.addFilter(filter);
            }
            postersSearch.request(controller.requestFilms(0, 7));
        }
        private void updateRecommend()
        {
            controller.clearFilters();
            CFilter filter = new CFilter();
            filter.boolRandom = true;
            controller.addFilter(filter);
            postersRecommend.request(controller.requestFilms(0, 7));
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            updateSearch();
        }

        //##
        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            if (metadataCache == null) return; // TODO: Delay window instead of rejecting perhaps?
            QuerySubWindow querySubWindow = new QuerySubWindow(ref metadataCache);

            querySubWindow.StartPosition = FormStartPosition.CenterParent;
            querySubWindow.ShowDialog(this);
        }

        private void mainView_Load(object sender, EventArgs e)
        {
        }

    }
}
