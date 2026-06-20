using MvcApp.DTOs.Student_DTOs;
using System.ComponentModel.DataAnnotations;

namespace MvcApp.DTOs.Group_DTOs;

public class GroupWithStudentsDto
{
	public int GroupId { get; set; }

	[Required(ErrorMessage = "Group name is required.")]
	public string Name { get; set; }

	public List<StudentDto> Students { get; set; } = new List<StudentDto>();
}