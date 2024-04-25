using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ViewHandler;
using ModelLibrary.Models;
using ControllerLibrary;
using System.Xml.Linq;
using System.Threading.Tasks;

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
        mainView mv; // Have to keep track of this to update buttons in the same thread as they were created, god I love C#
        int size;    // Amount of PictureBoxes
        int page;    // Current page we're on
        public PosterHandler(
            IController controller,
            mainView mv,
            int numOfPictures, 
            PosterBoxSettings s,
            GroupBox gb, 
            Button btnLeft,
            Button btnRight,
            Label lblStatus) : base(controller)
        {
            this.size = numOfPictures;
            page = 0;
            this.btnLeft = btnLeft;
            this.btnRight = btnRight;
            this.lblStatus = lblStatus;
            this.mv = mv;
            this.controller = controller;
            btnLeft.Enabled = true;
            btnRight.Enabled = true;
            lblStatus.Text = "";
            btnLeft.Click += (_, __) => setPage(this.page - 1);
            btnRight.Click += (_, __) => setPage(this.page + 1);
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

        private void updateControls(List<FilmModel> films)
        {
            mv.Invoke(new Action(() => {
                btnLeft.Enabled = page > 0;
                btnRight.Enabled = btnRight.Enabled = films.Count >= size;
                if (films.Count < size)
                {
                    lblStatus.Text = "page " + page.ToString() + " / " + (getMaxOffset() / size).ToString();
                }
                else
                {
                    lblStatus.Text = "page " + page.ToString() + " / " + (getMaxOffset() / size).ToString() + "...";
                }
            }));
        }

        private void updateView(List<FilmModel> films)
        {
            for (var i = 0; i < pb.Count; i++)
            {
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
                    detailView = new filmView(films[iCopy], () => { detailView = null; }, controller);
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

        public void request()
        {
            controller.clearFilters();
            controller.addFilter(filter);
            requestFilms(page * size, 64, () => // TODO: Change 64 into reasonable parameter
            {
                var films = getFilms(page * size, size);
                updateView(films);
                updateControls(films);
            });
        }

        public void setFilter(CFilter filter)
        {
            clearView();
            this.filter = filter;
            request();
        }

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

        public static void rxComment(CommentModel comment, int id)
        {
            detailView?.rxComment(comment, id);
        }
    }
}
