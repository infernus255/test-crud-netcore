using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_crud.core.Entities;

namespace test_crud.infrastructure.Data.Configurations
{
    public class GenreFilmConfiguration : IEntityTypeConfiguration<GenreFilm>
    {
        public void Configure(EntityTypeBuilder<GenreFilm> builder)
        {
            builder.HasKey(e => new { e.FilmCode, e.GenreCode })
                .HasName("PK__tGeneroP__6285A5958BFD1A0B");

            builder.ToTable("tGeneroPelicula");

            builder.Property(e => e.FilmCode).HasColumnName("cod_pelicula");

            builder.Property(e => e.GenreCode).HasColumnName("cod_genero");

            builder.HasOne(d => d.Genre)
                .WithMany(p => p.GenreFilms)
                .HasForeignKey(d => d.GenreCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pelicula_genero");

            builder.HasOne(d => d.Film)
                .WithMany(p => p.GenreFilms)
                .HasForeignKey(d => d.FilmCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_genero_pelicula");
        }
    }
}
