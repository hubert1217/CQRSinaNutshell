using CQRS.Domain.Common;
using CQRS.Domain.Entities;
using CQRS.InfrastructureEF.DummyData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.InfrastructureEF
{
    public class CQRSAppContext : DbContext
    {
        public CQRSAppContext(DbContextOptions<CQRSAppContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get;set;}
        public DbSet<Webinar> Webinars { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) 
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>()) 
            {
                switch (entry.State) 
                { 
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CQRSAppContext).Assembly);

            foreach (var item in DummyCategories.Get()) 
            {
                modelBuilder.Entity<Category>().HasData(item);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
