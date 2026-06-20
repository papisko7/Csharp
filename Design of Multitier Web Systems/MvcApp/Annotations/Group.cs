using System.ComponentModel.DataAnnotations;

namespace MvcApp.Annotations;

public class Group
{
	public int GroupId { get; set; }

	[Required(ErrorMessage = "Group name is required")]
	[StringLength(100, ErrorMessage = "Group name cannot exceed 100 characters")]
	[Display(Name = "Group name")]
	public string Name { get; set; }

	public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
}