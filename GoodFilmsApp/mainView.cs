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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using ViewHandler;
using ControllerLibrary;

namespace GoodFilmsApp
{
    public partial class mainView : Form
    {
        IController controller;
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
                (id, _) => { },
                (id, _) => { },
                (id, _) => { },
                (id, _) => { },
                (id, err) => Console.WriteLine("Controller Error: " + err));
            postersSearch = new PosterHandler(100, new PosterBoxSettings(), ref gbSearchResults);
            postersRecommend = new PosterHandler(100, new PosterBoxSettings(), ref gbRecommendedFilms);
            postersScheduled = new PosterHandler(100, new PosterBoxSettings(), ref gbScheduledFilms);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            postersSearch.request(controller.requestFilms(0, 40));
            //postersRecommend.request(controller.requestFilms(0, 10));
            //postersScheduled.request(controller.requestFilms(0, 10));
        }


        //##
        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            QuerySubWindow querySubWindow = new QuerySubWindow();

            querySubWindow.StartPosition = FormStartPosition.CenterParent;
            querySubWindow.ShowDialog(this);
        }


        private void mainView_Load(object sender, EventArgs e)
        {
        }

    }
}
