using System.ComponentModel.DataAnnotations;

namespace MvcApp.DTOs.Group_DTOs;

public class GroupDto
{
	public int GroupId { get; set; }

	[Required(ErrorMessage = "Group name is required.")]
	public string Name { get; set; }
}