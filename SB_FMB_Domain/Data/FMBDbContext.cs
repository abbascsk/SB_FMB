using Microsoft.EntityFrameworkCore;
using SB_FMB_Domain.Commons.Entity;
using SB_FMB_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB_FMB_Domain.Data
{
    public class FMBDbContext: DbContext
    {
        public FMBDbContext(DbContextOptions<FMBDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Mumin> Mumins { get; set; }
        public DbSet<Thali> Thalis { get; set; }
        public DbSet<ThaliItem> ThaliItems { get; set; }
        public DbSet<ThaliStopRequest> ThaliStopRequests { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

		public override int SaveChanges()
		{
			AddTimestamps();
			return base.SaveChanges();
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			AddTimestamps();
			return base.SaveChangesAsync(cancellationToken);
		}

		private void AddTimestamps()
		{
			//var UserId = User.Identity.GetUserID();

			var entities = ChangeTracker.Entries()
				.Where(x => x.Entity is EntityBase && (x.State == EntityState.Added || x.State == EntityState.Modified));

			foreach (var entity in entities)
			{
				var now = DateTime.Now;

				if (entity.State == EntityState.Added && ((EntityBase)entity.Entity).CreatedAt == DateTime.MinValue)
					((EntityBase)entity.Entity).CreatedAt = now;

				else if (entity.State == EntityState.Modified && ((EntityBase)entity.Entity).UpdatedAt == DateTime.MinValue)
					((EntityBase)entity.Entity).UpdatedAt = now;
			}
		}
	}
}
