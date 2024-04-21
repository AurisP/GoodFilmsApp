using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ViewHandler;
using ModelLibrary.Models;

namespace GoodFilmsApp
{
    internal class PosterHandler : CViewHandler
    {
        static bool detailOpen = false;
        List<FilmModel> films;
        List<PictureBox> pb = new List<PictureBox>();
        List<MouseEventHandler> events = new List<MouseEventHandler>();

        public PosterHandler(int numOfPictures, PosterBoxSettings s, ref GroupBox gb)
        {
            setOnChangeCb((films) => {
                int j = 0;
                int i = 0;
                this.films = films;
                for (; j < pb.Count && i < films.Count; i++)
                {
                    if (this.films[i].Poster_Url == "" || this.films[i].Poster_Url == null) continue;
                    pb[j].ImageLocation = "../../" + this.films[i].Poster_Url;
                    pb[j].MouseClick -= events[j];
                    int iCopy = i;
                    MouseEventHandler ev;
                    ev = new MouseEventHandler((_, __) =>
                    {
                        if (detailOpen) return;
                        detailOpen = true;
                        var filmWindow = new filmView(this.films[iCopy], () => { detailOpen = false; });
                        filmWindow.Show();
                    });
                    pb[j].MouseClick += ev;
                    events[j] = ev;
                    j++;
                }
                for (; j < pb.Count; j++)
                {
                    pb[j].ImageLocation = "";
                    if (events[j] != null)
                    {
                        pb[j].MouseClick -= events[j];
                    }
                    events[j] = null;
                }
            });
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
    }
}
