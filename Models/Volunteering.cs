using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEventVolunteeringDemo.Models
{
	public class Volunteering
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int VolunteeringID { get; set; }

		[Required]
		[Display(Name = "Start Date")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		[DataType(DataType.Date)]
		public DateTime BeginDate { get; set; }

		[Required]
		[Display(Name = "Start Time")]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime BeginTime { get; set; }

		[Required]
		[Display(Name = "End Date")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		[DataType(DataType.Date)]
		public DateTime EndDate { get; set; }

		[Required]
		[Display(Name = "End Time")]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime EndTime { get; set; }

		[StringLength(180)]
		[DataType(DataType.MultilineText)]
		public string Remarks { get; set; }

		[Required]
		[ForeignKey("Event")]
		public int EventID { get; set; }

		[Required]
		[ForeignKey("Volunteer")]
		public int VolunteerID { get; set; }

		public virtual Event Event { get; set; }

		public virtual Volunteer Volunteer { get; set; }
	}
}
