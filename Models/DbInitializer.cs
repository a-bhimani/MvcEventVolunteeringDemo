using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MvcEventVolunteeringDemo.Models
{
	public class DbInitializer : CreateDatabaseIfNotExists<SrvContext>
	{
		protected override void Seed(SrvContext context)
		{
			GetVolunteers().ForEach(v => context.Volunteers.Add(v));
			GetEvents().ForEach(e => context.Events.Add(e));
			GetVolunteerings().ForEach(ve => context.Volunteerings.Add(ve));
		}

		private static List<Volunteer> GetVolunteers()
		{
			return new List<Volunteer> {
																new Volunteer
																{
																	VolunteerID = 1,
																	FirstName = "Ankit",
																	LastName = "Bhimani",
																	Username = "abhimani@hawk.iit.edu",
																	Phone = 3125365229,
																	DateOfBirth = new DateTime(1989, 4, 8),
																	IsFemale = false,
																	Address = "2851 S. King Dr., #714",
																	City = "Chicago",
																	State = "Illinois",
																	Zip = 60616,
																	IsActive = true
																},
																new Volunteer
																{
																	VolunteerID = 2,
																	FirstName = "Puneet",
																	LastName = "Kolathaya",
																	Username = "pkolatha@hawk.iit.edu",
																	Phone = 3129374083,
																	IsFemale = false,
																	DateOfBirth = new DateTime(1990, 10, 8),
																	Address = "2851 S. King Dr., #714",
																	City = "Chicago",
																	State = "Illinois",
																	Zip = 60616,
																	IsActive = true
																}
														};
		}

		private static List<Event> GetEvents()
		{
			return new List<Event> {
														new Event
														{
															EventID = 1,
															StartDate = new DateTime(2017, 10, 31),
															StartTime = (new DateTime(1999, 12, 31, 19, 0, 0)).ToLocalTime(),
															EndDate = new DateTime(2017, 11, 1, 4, 30, 0),
															EndTime = (new DateTime(1999, 12, 31, 4, 30, 0)).ToLocalTime(),
															Title = "Halloween Night 2017",
															Description = "-",
															Capacity = 300,
															VolunteersRequired = 100,
															VenueAddress = "IIT Bog",
															VenueCity = "Chicago",
															VenueState = "Illinois",
															VenueZip = 60616,
															VenuePhone = 3125365229,
															IsActive = true
														},
														new Event
														{
															EventID = 2,
															StartDate = new DateTime(2017, 10, 31, 21, 0, 0),
															StartTime = (new DateTime(1999, 12, 31, 21, 0, 0)).ToLocalTime(),
															EndDate = new DateTime(2017, 11, 1, 2, 0, 0),
															EndTime = (new DateTime(1999, 12, 31, 2, 0, 0)).ToLocalTime(),
															Title = "Diwali 2017",
															Description = "-",
															Capacity = 20,
															VolunteersRequired = 2,
															VenueAddress = "IIT Keating Ground",
															VenueCity = "Chicago",
															VenueState = "Illinois",
															VenueZip = 60616,
															VenuePhone = 3125365224,
															IsActive = true
														},
														new Event
														{
															EventID = 3,
															StartDate = new DateTime(2015, 12, 31, 23, 30, 0),
															StartTime = (new DateTime(1999, 12, 31, 23, 30, 0)).ToLocalTime(),
															EndDate = new DateTime(2016, 1, 1, 1, 30, 0),
															EndTime = (new DateTime(1999, 12, 31, 1, 30, 0)).ToLocalTime(),
															Title = "New Year 2016",
															Description = "-",
															Capacity = 20,
															VolunteersRequired = 2,
															VenueAddress = "Navy Pier",
															VenueCity = "Chicago",
															VenueState = "Illinois",
															VenueZip = 60611,
															VenuePhone = 3125365220,
															IsActive = true
														}
												};
		}

		private static List<Volunteering> GetVolunteerings()
		{
			return new List<Volunteering>
			{

			};
		}
	}
}
