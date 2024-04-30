using ModelLibrary.Models;
using System.Collections.Generic;
using System;
using ControllerLibrary;
using System.Windows.Forms;

namespace ViewHandler
{
    public class CViewHandler : IViewHandler
    {
        private Dictionary<int, FilmModel> offsetsToFilms;
        private int maxOffset;
        private IController controller;
        public CViewHandler(IController controller)
        {
            offsetsToFilms = new Dictionary<int, FilmModel>();
            maxOffset = 0;
            this.controller = controller;
        }
        public void requestFilms(CFilter filter, int offset, int count, Action cb)
        {
            controller.requestFilms(filter, offset, count, (films) =>
            {
                maxOffset = maxOffset > offset + films.Count ? maxOffset : offset + films.Count;
                for (var i = 0; i < films.Count; i++)
                {
                    if (offsetsToFilms.ContainsKey(offset + i))
                    {
                        offsetsToFilms[offset + i] = films[i];
                    }
                    else
                    {
                        offsetsToFilms.Add(offset + i, films[i]);
                    }
                }
                cb?.Invoke();
            }, 
            (error) =>
            {
                MessageBox.Show(error);
            });
        }
        public List<FilmModel> getFilms(int offset, int count)
        {
            List<FilmModel> result = new List<FilmModel>();
            for (var i = 0; i < count; i++)
            {
                if (!offsetsToFilms.ContainsKey(offset + i)) continue;
                result.Add(offsetsToFilms[offset + i]);
            }
            return result;
        }
        public int getMaxOffset()
        {
            return maxOffset;
        }
        public void clearView()
        {
            maxOffset = 0;
            offsetsToFilms = new Dictionary<int, FilmModel>();
        }
    }
}