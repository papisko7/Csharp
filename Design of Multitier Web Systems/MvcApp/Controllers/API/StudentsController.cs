using MvcApp.Annotations;
using MvcApp.DTOs.Student_DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MvcApp.Controllers.API;

[Route("api/[controller]")]
[ApiController]
public class StudentsController(StudentDbContext context) : ControllerBase
{
	[HttpGet]
	public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
	{
		return await context.Students.Select(s => new StudentDto
		{
			StudentId = s.StudentId,
			FirstName = s.FirstName,
			LastName = s.LastName,
			Age = s.Age,
			GroupId = s.GroupId
		})
			.ToListAsync();
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<StudentDto>> GetStudent(int id)
	{
		var student = await context.Students.FindAsync(id);

		if (student == null) return NotFound();

		return new StudentDto
		{
			StudentId = student.StudentId,
			FirstName = student.FirstName,
			LastName = student.LastName,
			Age = student.Age,
			GroupId = student.GroupId
		};
	}

	[HttpPost]
	public async Task<ActionResult<StudentDto>> PostStudent(StudentDto studentDto)
	{
		var student = new Student
		{
			FirstName = studentDto.FirstName,
			LastName = studentDto.LastName,
			Age = studentDto.Age,
			GroupId = studentDto.GroupId
		};

		context.Students.Add(student);
		await context.SaveChangesAsync();

		studentDto.StudentId = student.StudentId;
		return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, studentDto);
	}

	[HttpPost("with-group")]
	public async Task<ActionResult<StudentDto>> PostStudentWithGroup(CreateStudentWithGroupDto dto)
	{
		var group = await context.Groups.FirstOrDefaultAsync(g => g.Name == dto.GroupName);

		if (group == null)
		{
			group = new Group { Name = dto.GroupName };
			context.Groups.Add(group);
			await context.SaveChangesAsync();
		}

		var student = new Student
		{
			FirstName = dto.FirstName,
			LastName = dto.LastName,
			Age = dto.Age,
			GroupId = group.GroupId
		};

		context.Students.Add(student);
		await context.SaveChangesAsync();

		var studentDto = new StudentDto
		{
			StudentId = student.StudentId,
			FirstName = student.FirstName,
			LastName = student.LastName,
			Age = student.Age,
			GroupId = student.GroupId
		};

		return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, studentDto);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> PutStudent(int id, StudentDto studentDto)
	{
		if (id != studentDto.StudentId) return BadRequest();

		var student = await context.Students.FindAsync(id);
		if (student == null) return NotFound();

		student.FirstName = studentDto.FirstName;
		student.LastName = studentDto.LastName;
		student.Age = studentDto.Age;
		student.GroupId = studentDto.GroupId;

		await context.SaveChangesAsync();

		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteStudent(int id)
	{
		var student = await context.Students.FindAsync(id);
		if (student == null) return NotFound();

		context.Students.Remove(student);
		await context.SaveChangesAsync();

		return NoContent();
	}
}