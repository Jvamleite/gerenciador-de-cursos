using GerenciadorDeCursos.Border.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCursos.Repositories.Data
{
    public class DataContext :  DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext (DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
