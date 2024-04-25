using ModelLibrary.Models;
using System.Collections.Generic;
using System;
using ControllerLibrary;

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
        public void requestFilms(int offset, int count, Action cb)
        {
            controller.requestFilms(offset, count, (films) =>
            {
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
    }
}