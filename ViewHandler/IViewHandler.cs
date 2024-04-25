using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewHandler
{
    using FilmModel = ModelLibrary.Models.FilmModel;
    public interface IViewHandler
    {
        void requestFilms(int offset, int count, Action cb);
        List<FilmModel> getFilms(int offset, int count);
        int getMaxOffset();
    }
}
