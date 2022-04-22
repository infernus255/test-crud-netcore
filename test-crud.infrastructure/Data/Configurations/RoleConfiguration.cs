using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_crud.core.Entities;

namespace test_crud.infrastructure.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK__tRol__F13B1211B18B797A");

            builder.ToTable("tRol");

            builder.Property(e => e.Id).HasColumnName("cod_rol");

            builder.Property(e => e.IsActive).HasColumnName("sn_activo");

            builder.Property(e => e.TxtDesc)
                .HasColumnName("txt_desc")
                .HasMaxLength(500)
                .IsUnicode(false);
        }
    }
}
