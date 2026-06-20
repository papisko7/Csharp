using MvcApp.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MvcApp.Controllers.MVC;

public class MvcStudentsController(StudentDbContext context, ILogger<MvcStudentsController> logger)
	: Controller
{
	public async Task<IActionResult> Index()
	{
		logger.LogInformation("Fetched students list.");
		var students = await context.Students.Include(s => s.Group).ToListAsync();
		return View(students);
	}

	public IActionResult Create()
	{
		ViewData["GroupId"] = new SelectList(context.Groups, "GroupId", "Name");
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(Student student)
	{
		if (ModelState.IsValid)
		{
			context.Add(student);
			await context.SaveChangesAsync();
			logger.LogInformation($"Added new student: {student.FirstName} {student.LastName}");
			return RedirectToAction(nameof(Index));
		}
		ViewData["GroupId"] = new SelectList(context.Groups, "GroupId", "Name", student.GroupId);
		return View(student);
	}

	// To jest metoda GET, która ładuje formularz edycji!
	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null)
		{
			return NotFound();
		}

		var student = await context.Students.FindAsync(id);
		if (student == null)
		{
			return NotFound();
		}

		// Generujemy listę grup (ComboBox) z zaznaczoną obecną grupą studenta
		ViewData["GroupId"] = new SelectList(context.Groups, "GroupId", "Name", student.GroupId);
		return View(student);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("StudentId,LastName,FirstName,Age,GroupId")] Student student)
	{
		if (id != student.StudentId)
		{
			return NotFound();
		}

		if (ModelState.IsValid)
		{
			try
			{
				var studentToUpdate = await context.Students.FindAsync(id);

				if (studentToUpdate == null)
				{
					return NotFound();
				}

				studentToUpdate.FirstName = student.FirstName;
				studentToUpdate.LastName = student.LastName;
				studentToUpdate.Age = student.Age;
				studentToUpdate.GroupId = student.GroupId;

				await context.SaveChangesAsync();

				logger.LogInformation($"Updated student with ID: {id} using Load-Update-Save pattern.");
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StudentExists(student.StudentId))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
		}
		ViewData["GroupId"] = new SelectList(context.Groups, "GroupId", "Name", student.GroupId);
		return View(student);
	}

	private bool StudentExists(int id)
	{
		return context.Students.Any(e => e.StudentId == id);
	}

	public async Task<IActionResult> Delete(int? id)
	{
		if (id == null) return NotFound();

		var student = await context.Students.Include(s => s.Group).FirstOrDefaultAsync(m => m.StudentId == id);
		if (student == null) return NotFound();

		return View(student);
	}

	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var student = await context.Students.FindAsync(id);
		context.Students.Remove(student);
		await context.SaveChangesAsync();

		logger.LogWarning($"Deleted student with ID: {id}");
		return RedirectToAction(nameof(Index));
	}
}