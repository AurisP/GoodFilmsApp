﻿using ModelLibrary.Models;
using System.Collections.Generic;
using System;

namespace ViewHandler
{
    public class CViewHandler : IViewHandler
    {
        private List<FilmModel> films;
        private HashSet<int> expectedIds;
        private Action<List<FilmModel>> cb;
        public CViewHandler()
        {
            cb = (_) => {};
            films = new List<FilmModel>();
            expectedIds = new HashSet<int>();
        }
        public void request(int id)
        {
            expectedIds.Add(id);
        }
        public void setOnChangeCb(Action<List<FilmModel>> cb)
        {
            this.cb = cb;
        }
        public void filmsRx(int id, List<FilmModel> films)
        {
            if (!expectedIds.Contains(id)) return;
            this.films.AddRange(films);
            cb?.Invoke(films);
        }
        public List<int> getVisibleIDs()
        {
            List<int> ids = new List<int>();
            for (var i = 0; i < films.Count; i++)
            {
                ids.Add(films[i].Id);
            }
            return ids;
        }
    }
}