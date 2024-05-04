using ControllerLibrary;
using ModelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewHandler
{
    public interface IViewHandler
    {
        void requestFilms(CFilter filter, int offset, int count, Action cb);
        List<FilmModel> getFilms(int offset, int count);
        bool getAbsoluteEndKnown();
        int getMaxOffset();
        void clearView();
    }
}
