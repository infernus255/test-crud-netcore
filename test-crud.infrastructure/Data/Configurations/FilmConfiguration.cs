using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_crud.core.Entities;

namespace test_crud.infrastructure.Data.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK__tPelicul__225F6E08FAF2532F");

            builder.ToTable("tPelicula");

            builder.Property(e => e.Id).HasColumnName("cod_pelicula");

            builder.Property(e => e.AvailableQtyRental).HasColumnName("cant_disponibles_alquiler");

            builder.Property(e => e.AvailableQtyForSale).HasColumnName("cant_disponibles_venta");

            builder.Property(e => e.RentalPrice)
                .HasColumnName("precio_alquiler")
                .HasColumnType("numeric(18, 2)");

            builder.Property(e => e.ForSalePrice)
                .HasColumnName("precio_venta")
                .HasColumnType("numeric(18, 2)");

            builder.Property(e => e.TxtDesc)
                .HasColumnName("txt_desc")
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
