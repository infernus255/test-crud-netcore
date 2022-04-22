using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_crud.core.Entities;

namespace test_crud.infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK__tSegurid__8A7E100F2AF1D512");

            builder.ToTable("tSeguridad");

            builder.Property(e => e.Id).HasColumnName("cod_seguridad");

            builder.Property(e => e.RoleCode)
                .HasColumnName("cod_rol")
                .IsRequired();
            //.HasConversion(
            //x => x.ToString(),
            //x => (RoleType)Enum.Parse(typeof(RoleType), x));

            builder.Property(e => e.TxtLastName)
                .HasColumnName("txt_apellido")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.TxtName)
                .HasColumnName("txt_nombre")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.TxtPassword)
                .HasColumnName("txt_password")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TxtUser)
                .HasColumnName("txt_user")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.Role)
                .WithMany(p => p.Securities)
                .HasForeignKey(d => d.RoleCode)
                .HasConstraintName("fk_security_rol");
        }
    }
}
