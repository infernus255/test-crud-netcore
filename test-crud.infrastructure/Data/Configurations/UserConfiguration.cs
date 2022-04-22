using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using test_crud.core.Entities;

namespace test_crud.infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("PK__tUsers__EA3C9B1AFD98216D");

            builder.ToTable("tUsers");

            builder.Property(e => e.Id).HasColumnName("cod_usuario");

            builder.Property(e => e.RoleCode)
                .HasColumnName("cod_rol");
            //.HasConversion(
            //x => x.ToString(),
            //x => (RoleType)Enum.Parse(typeof(RoleType), x));

            builder.Property(e => e.IdentityCardNum)
                .HasColumnName("nro_doc")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.IsActive).HasColumnName("sn_activo");

            builder.Property(e => e.TxtLastName)
                .HasColumnName("txt_apellido")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.TxtName)
                .HasColumnName("txt_nombre")
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.TxtPassword)
                .HasColumnName("txt_password")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.TxtUser)
                .HasColumnName("txt_user")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleCode)
                .HasConstraintName("fk_user_rol");
        }
    }
}
