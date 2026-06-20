using System.ComponentModel.DataAnnotations;

namespace MvcApp.DTOs.Student_DTOs;

public class StudentDto
{
	public int StudentId { get; set; }

	[Required(ErrorMessage = "Last name is required.")]
	public string LastName { get; set; }

	[Required(ErrorMessage = "Name is required.")]
	public string FirstName { get; set; }

	public int Age { get; set; }

	public int GroupId { get; set; }
}