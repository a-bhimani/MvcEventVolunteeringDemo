using System.Data.Entity;

namespace MvcEventVolunteeringDemo.Models
{
	public class SrvContext : DbContext
	{
		public SrvContext()
							: base("ConnEventVolunteeringPrimary")
		{
			Database.SetInitializer(new DbInitializer());
		}

		public virtual DbSet<Volunteer> Volunteers { get; set; }

		public virtual DbSet<Event> Events { get; set; }

		public virtual DbSet<Volunteering> Volunteerings { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			#region Volunteers
			modelBuilder.Entity<Volunteer>()
					.HasMany(el => el.Volunteerings)
					.WithRequired(el => el.Volunteer)
					.HasForeignKey(el => el.VolunteerID)
					.WillCascadeOnDelete(true);

			modelBuilder.Entity<Volunteer>()
					.Property(el => el.FirstName)
					.IsUnicode(false);

			modelBuilder.Entity<Volunteer>()
					.Property(el => el.LastName)
					.IsUnicode(false);

			modelBuilder.Entity<Volunteer>()
					.Property(el => el.Username)
					.IsUnicode(false);

			modelBuilder.Entity<Volunteer>()
					.Property(el => el.Username)
					.IsUnicode(false);

			modelBuilder.Entity<Volunteer>()
					.Property(el => el.Phone)
					.HasPrecision(10, 0);

			modelBuilder.Entity<Volunteer>()
					.Property(el => el.Address)
					.IsUnicode(false);

			modelBuilder.Entity<Volunteer>()
					.Property(el => el.City)
					.IsUnicode(false);

			modelBuilder.Entity<Volunteer>()
					.Property(el => el.State)
					.IsUnicode(false);
			#endregion

			#region Events
			modelBuilder.Entity<Event>()
					.HasMany(el => el.Volunteerings)
					.WithRequired(el => el.Event)
					.HasForeignKey(el => el.EventID)
					.WillCascadeOnDelete(true);

			modelBuilder.Entity<Event>()
					.Property(el => el.Title)
					.IsUnicode(false);

			modelBuilder.Entity<Event>()
					.Property(el => el.VenueAddress)
					.IsUnicode(false);

			modelBuilder.Entity<Event>()
					.Property(el => el.VenueCity)
					.IsUnicode(false);

			modelBuilder.Entity<Event>()
					.Property(el => el.VenueState)
					.IsUnicode(false);
			#endregion

			#region Volunteerings
			//
			#endregion
		}
	}
}
