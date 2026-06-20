using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MvcApp.Annotations;

public class Student
{
	public int StudentId { get; set; }

	[Required(ErrorMessage = "Last name is  required")]
	[StringLength(50, MinimumLength = 2, ErrorMessage = "Last name has to be between 2 to 50 characters long.")]
	[Display(Name = "Last name")]
	public string LastName { get; set; }

	[Required(ErrorMessage = "Name is  required")]
	[StringLength(50, MinimumLength = 2, ErrorMessage = "Name has to be between 2 to 50 characters long.")]
	[Display(Name = "Name")]
	public string FirstName { get; set; }

	[Required(ErrorMessage = "Age  is required")]
	[Range(18, 100, ErrorMessage = "Age has  to be between 18 and 100")]
	[Display(Name = "Age")]
	public int Age { get; set; }

	[Required(ErrorMessage = "Group  ID is required")]
	[Display(Name = "Group Id")]
	public int GroupId { get; set; }

	[ValidateNever]
	public virtual Group? Group { get; set; }
}