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
        void request(int id);
        void setOnChangeCb(Action<List<FilmModel>> cb);
        void filmsRx(int id, List<FilmModel> films);
        List<int> getVisibleIDs();
    }
}
