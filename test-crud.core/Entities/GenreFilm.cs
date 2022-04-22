namespace test_crud.core.Entities
{
    public partial class GenreFilm
    {
        public int FilmCode { get; set; }
        public int GenreCode { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Film Film { get; set; }
    }
}
