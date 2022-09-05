using CityData.Domain.Models;
using CityData.Infrastructure.Context.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CityData.Infrastructure.Context
{
    public class CityDataContext : DbContext
    {
        public CityDataContext(DbContextOptions<CityDataContext> options)
        : base(options)
        {
        }

        public DbSet<City> Citys { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            var AddedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Added)
                .ToList();

            AddedEntities.ForEach(E =>
            {
                E.Property("CreatedDate").CurrentValue = DateTime.Now;
                E.Property("IsDeleted").CurrentValue = false;
            });

            var EditedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Modified)
                .ToList();

            EditedEntities.ForEach(E =>
            {
                E.Property("ModifiedDate").CurrentValue = DateTime.Now;
            });

            var DeletedEntities = ChangeTracker.Entries()
                .Where(E => E.State == EntityState.Deleted)
                .ToList();

            DeletedEntities.ForEach(E =>
            {
                E.Property("DeletedDate").CurrentValue = DateTime.Now;
                E.Property("IsDeleted").CurrentValue = true;
            });

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}
