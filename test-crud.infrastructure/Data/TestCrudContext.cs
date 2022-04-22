using Microsoft.EntityFrameworkCore;
using System.Reflection;
using test_crud.core.Entities;

namespace test_crud.infrastructure.Data
{
    public partial class TestCrudContext : DbContext
    {
        public TestCrudContext()
        {
        }

        public TestCrudContext(DbContextOptions<TestCrudContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<GenreFilm> GenreFilms { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
