using System.Collections.Generic;

namespace test_crud.core.Entities
{
    public partial class Film : BaseEntity
    {
        public Film()
        {
            GenreFilms = new HashSet<GenreFilm>();
        }

        public string TxtDesc { get; set; }
        public int? AvailableQtyRental { get; set; }
        public int? AvailableQtyForSale { get; set; }
        public decimal? RentalPrice { get; set; }
        public decimal? ForSalePrice { get; set; }

        public virtual ICollection<GenreFilm> GenreFilms { get; set; }
    }
}
