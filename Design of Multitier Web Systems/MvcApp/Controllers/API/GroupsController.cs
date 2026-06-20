using MvcApp.Annotations;
using MvcApp.DTOs.Group_DTOs;
using MvcApp.DTOs.Student_DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MvcApp.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class GroupsController(StudentDbContext context) : ControllerBase
{
	private readonly StudentDbContext _context = context;

	[HttpGet]
	public async Task<ActionResult<IEnumerable<GroupDto>>> GetGroups()
	{
		return await _context.Groups
			.Select(g => new GroupDto { GroupId = g.GroupId, Name = g.Name })
			.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<GroupDto>> GetGroup(int id)
	{
		var group = await _context.Groups.FindAsync(id);

		if (group == null) return NotFound();

		return new GroupDto { GroupId = group.GroupId, Name = group.Name };
	}

	[HttpGet("{id}/students")]
	public async Task<ActionResult<GroupWithStudentsDto>> GetGroupWithStudents(int id)
	{
		var group = await _context.Groups.FindAsync(id);

		if (group == null) return NotFound();

		return new GroupWithStudentsDto
		{
			GroupId = group.GroupId,
			Name = group.Name,
			Students = group.Students.Select(s => new StudentDto
			{
				StudentId = s.StudentId,
				FirstName = s.FirstName,
				LastName = s.LastName,
				Age = s.Age,
				GroupId = s.GroupId
			}).ToList()
		};
	}

	[HttpPost]
	public async Task<ActionResult<GroupDto>> PostGroup(GroupDto groupDto)
	{
		var group = new Group { Name = groupDto.Name };
		_context.Groups.Add(group);
		await _context.SaveChangesAsync();

		groupDto.GroupId = group.GroupId;
		return CreatedAtAction(nameof(GetGroup), new { id = group.GroupId }, groupDto);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutGroup(int id, GroupDto groupDto)
	{
		if (id != groupDto.GroupId) return BadRequest();

		var group = await _context.Groups.FindAsync(id);
		if (group == null) return NotFound();

		group.Name = groupDto.Name;
		await _context.SaveChangesAsync();

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteGroup(int id)
	{
		var group = await _context.Groups.FindAsync(id);
		if (group == null) return NotFound();

		_context.Groups.Remove(group);
		await _context.SaveChangesAsync();

		return NoContent();
	}
}