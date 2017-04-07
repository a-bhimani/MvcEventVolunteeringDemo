using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEventVolunteeringDemo.Models
{
	public class Volunteer
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public Volunteer()
		{
			Volunteerings = new HashSet<Volunteering>();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int VolunteerID { get; set; }

		[Required(ErrorMessage = "First Name is required.")]
		[StringLength(30, ErrorMessage = "First Name should not exceed 30 characters.")]
		[MinLength(3, ErrorMessage = "Please enter a valid First Name")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required.")]
		[StringLength(30, ErrorMessage = "Last Name should not exceed 30 characters.")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter a valid Email Address for the Username.")]
		[Index(IsUnique = true)]
		[StringLength(155)]
		[EmailAddress(ErrorMessage = "Please enter a valid Email Address for the Username.")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Phone Number is required.")]
		[Index(IsUnique = true)]
		[Column(TypeName = "numeric")]
		[Range(1000000000, 9999999999, ErrorMessage = "Enter only numbers for your Phone Number.")]
		[DisplayFormat(DataFormatString = "{0:###-###-####}")]
		public decimal Phone { get; set; }

		[Required(ErrorMessage = "Date of Birth is required.")]
		[DataType(DataType.Date)]
		[Display(Name = "Birth Date")]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
		public DateTime DateOfBirth { get; set; }

		[Display(Name = "Gender")]
		public bool IsFemale { get; set; }

		[Required(ErrorMessage = "Address is required.")]
		[StringLength(180, ErrorMessage = "Address should not exceed 180 characters.")]
		[DataType(DataType.MultilineText)]
		public string Address { get; set; }

		[Required(ErrorMessage = "City is required.")]
		[StringLength(60, ErrorMessage = "City should not exceed 60 characters.")]
		public string City { get; set; }

		[Required(ErrorMessage = "State is required.")]
		[StringLength(60, ErrorMessage = "State should not exceed 60 characters.")]
		public string State { get; set; }

		[Required(ErrorMessage = "Zip is required.")]
		[Range(10000, 99999, ErrorMessage = "Enter only numbers for your Zip Code.")]
		public int Zip { get; set; }

		[Display(Name = "Active")]
		public bool IsActive { get; set; }

		public virtual ICollection<Volunteering> Volunteerings { get; set; }
	}
}
