using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEventVolunteeringDemo.Models
{
	public class Event
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Event()
		{
			Volunteerings = new HashSet<Volunteering>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int EventID { get; set; }

		[Required(ErrorMessage = "Start Date is required.")]
		[DataType(DataType.Date)]
		[Display(Name = "Start Date")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime StartDate { get; set; }

		[Required(ErrorMessage = "Start Time is required.")]
		[DataType(DataType.Time)]
		[Display(Name = "Start Time")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime StartTime { get; set; }

		[Required(ErrorMessage = "End Date is required.")]
		[DataType(DataType.Date)]
		[Display(Name = "End Date")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime EndDate { get; set; }

		[Required(ErrorMessage = "End Time is required.")]
		[DataType(DataType.Time)]
		[Display(Name = "End Time")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
		public DateTime EndTime { get; set; }

		[Required(ErrorMessage = "Title is required.")]
		[StringLength(30, ErrorMessage = "Title should not exceed 30 characters.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Description is required.")]
		[StringLength(180, ErrorMessage = "Description should not exceed 180 characters.")]
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }

		[Required(ErrorMessage = "Capacity is required.")]
		[Range(1, 9999, ErrorMessage = "Enter only numbers for the Event Capacity.")]
		public int Capacity { get; set; }

		[Required(ErrorMessage = "Volunteers required is required.")]
		[Range(1, 9999, ErrorMessage = "Enter only numbers for the Volunteers Required.")]
		[Display(Name = "Volunteers")]
		public int VolunteersRequired { get; set; }

		[Required(ErrorMessage = "Address is required.")]
		[StringLength(180, ErrorMessage = "Address should not exceed 180 characters.")]
		[DataType(DataType.MultilineText)]
		[Display(Name = "Address")]
		public string VenueAddress { get; set; }

		[Required(ErrorMessage = "City is required.")]
		[StringLength(60, ErrorMessage = "City should not exceed 60 characters.")]
		[Display(Name = "City")]
		public string VenueCity { get; set; }

		[Required(ErrorMessage = "State is required.")]
		[StringLength(60, ErrorMessage = "State should not exceed 60 characters.")]
		[Display(Name = "State")]
		public string VenueState { get; set; }

		[Required(ErrorMessage = "Zip is required.")]
		[Range(10000, 99999, ErrorMessage = "Enter only numbers for Zip.")]
		[Display(Name = "Zip")]
		public int VenueZip { get; set; }

		[Required(ErrorMessage = "Phone Number is required.")]
		[Column(TypeName = "numeric")]
		[Range(1000000000, 9999999999, ErrorMessage = "Enter only numbers for your Phone Number.")]
		[DisplayFormat(DataFormatString = "{0:###-###-####}")]
		[Display(Name = "Phone")]
		public decimal VenuePhone { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; }

		public virtual ICollection<Volunteering> Volunteerings { get; set; }
	}
}
