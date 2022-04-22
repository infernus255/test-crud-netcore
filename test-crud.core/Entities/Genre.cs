using System.Collections.Generic;

namespace test_crud.core.Entities
{
    public partial class Genre : BaseEntity
    {
        public Genre()
        {
            GenreFilms = new HashSet<GenreFilm>();
        }

        public string TxtDesc { get; set; }

        public virtual ICollection<GenreFilm> GenreFilms { get; set; }
    }
}
