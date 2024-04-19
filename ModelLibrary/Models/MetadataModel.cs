using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibrary.Models
{
    public class MetadataModel
    {
        public List<DirectorModel> directors;
        public List<GenreModel> genres;
        public List<StudioModel> studios;
        public List<LanguageModel> languages;
        public List<AgeRatingModel> ageRatings;
        public MetadataModel(List<DirectorModel> directors, List<GenreModel> genres, List<StudioModel> studios, List<LanguageModel> languages, List<AgeRatingModel> ageRatings)
        {
            this.directors = directors;
            this.genres = genres;
            this.studios = studios;
            this.languages = languages;
            this.ageRatings = ageRatings;
        }
    }
}
