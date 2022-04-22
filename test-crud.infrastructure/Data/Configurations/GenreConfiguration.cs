using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_crud.core.Entities;

namespace test_crud.infrastructure.Data.Configurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK__tGenero__0DACB9D545DFF69F");

            builder.ToTable("tGenero");

            builder.Property(e => e.Id).HasColumnName("cod_genero");

            builder.Property(e => e.TxtDesc)
                .HasColumnName("txt_desc")
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
