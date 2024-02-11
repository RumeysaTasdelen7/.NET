using System.Collections.Generic;
using System.Reflection.Emit;
using Entities.Models;
using Repositories.EFCore.Config;

namespace Repositories.EFCore
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) :
            base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModuleBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }


        internal object Set<T>()
        {
            throw new NotImplementedException();
        }

    }
}