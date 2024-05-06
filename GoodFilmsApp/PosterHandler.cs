using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ViewHandler;
using ControllerLibrary;
using ModelLibrary.Models;
using System.Xml.Linq;
using System.Threading.Tasks;
using CSVExporterDNF;

namespace GoodFilmsApp
{
    internal class PosterHandler : CViewHandler
    {
        static filmView detailView = null;
        CFilter filter;
        List<PictureBox> pb = new List<PictureBox>();
        List<MouseEventHandler> events = new List<MouseEventHandler>();
        Button btnLeft;
        Button btnRight;
        Label lblStatus;
        IController controller;
        IExporter exporter;
        private Ref<string> path;
        mainView mv; // Reference to the mainView instance
        int size;    // Number of PictureBoxes
        int page;    // Current page index

        // Constructor
        public PosterHandler(
            IController controller,
            mainView mv,
            int numOfPictures,
            PosterBoxSettings s,
            GroupBox gb,
            Button btnLeft,
            Button btnRight,
            Label lblStatus,
            IExporter exporter,
            Ref<string> path) : base(controller)
        {
            this.size = numOfPictures;
            this.page = 0;
            this.btnLeft = btnLeft;
            this.btnRight = btnRight;
            this.lblStatus = lblStatus;
            this.mv = mv;
            this.controller = controller;
            btnLeft.Enabled = false;
            btnRight.Enabled = false;
            lblStatus.Text = "";
            this.exporter = exporter;
            this.path = path;

            // Subscribe to button click events for navigation
            btnLeft.Click += (_, __) => setPage(this.page - 1);
            btnRight.Click += (_, __) => setPage(this.page + 1);

            // Create PictureBoxes
            for (int i = 0; i < numOfPictures; i++)
            {
                PictureBox pb = new PictureBox();
                pb.ImageLocation = "";
                pb.Location = new Point(
                    s.margin + ((i % s.nPerRow) * (s.width + s.margin)),
                    s.margin + ((i / s.nPerRow) * (s.height + s.margin)));
                pb.Size = new Size(s.width, s.height);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                events.Add(null);
                this.pb.Add(pb);
                gb.Controls.Add(pb);
            }
        }

        // Update controls based on the films received
        private void updateControls(List<FilmModel> films)
        {
            mv.Invoke(new Action(() => {
                btnLeft.Enabled = page > 0;
                btnRight.Enabled = page != (getMaxOffset() - 1) / size;
                if (getAbsoluteEndKnown())
                {
                    lblStatus.Text = "page " + (page + 1).ToString() + " / " + ((getMaxOffset() - 1) / size + 1).ToString();
                }
                else
                {
                    lblStatus.Text = "page " + (page + 1).ToString() + " / " + ((getMaxOffset() - 1) / size + 1).ToString() + "...";
                }
            }));
        }

        // Update the PictureBoxes with the films received
        private void updateView(List<FilmModel> films)
        {
            for (var i = 0; i < pb.Count; i++)
            {
                pb[i].MouseClick -= events[i];
                if (i >= films.Count)
                {
                    pb[i].ImageLocation = "";
                    continue;
                }
                var iCopy = i;
                pb[i].MouseClick -= events[i];
                var ev = new MouseEventHandler((_, __) =>
                {
                    if (detailView != null) return;
                    detailView = new filmView(mv, films[iCopy], () => { detailView = null; }, controller, exporter, path);
                    detailView.Show();
                });
                pb[i].MouseClick += ev;
                events[i] = ev;
                if (films[i].Poster_Url == "" || films[i].Poster_Url == null)
                {
                    pb[i].ImageLocation = "";
                }
                else
                {
                    pb[i].ImageLocation = "../../" + films[i].Poster_Url;
                }
            }
        }

        // Request films based on the current filter and page index
        public void request()
        {
            requestFilms(filter, page * size, 64, () => // TODO: Change 64 into a meaningful parameter
            {
                var films = getFilms(page * size, size);
                updateView(films);
                updateControls(films);
            });
        }

        // Set the filter for the PosterHandler and request films based on the new filter
        public void setFilter(CFilter filter)
        {
            clearView();
            this.page = 0;
            this.filter = filter;
            request();
        }

        // Set the page index for the PosterHandler and request films for the new page
        public void setPage(int page)
        {
            if (page < 0) page = 0;
            this.page = page;
            var films = getFilms(this.page * size, size);
            updateView(films);
            updateControls(films);
            if (films.Count != size)
            {
                request();
            }
        }
    }
}
