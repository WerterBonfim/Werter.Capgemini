using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Werter.Capgemini.WebApi.Core.Data;

namespace Werter.Capgemini.WebApi.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            
            var todasAsPropriedades = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x =>
                    x.GetProperties().Where(p => p.ClrType == typeof(string)));

            foreach (var property in todasAsPropriedades)
                property.SetColumnType("varchar(100)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}