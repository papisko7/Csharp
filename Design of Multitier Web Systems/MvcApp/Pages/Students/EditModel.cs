using MvcApp.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MvcApp.Pages.Students
{
	public class EditModel : PageModel
	{
		private readonly StudentDbContext _context;

		public EditModel(StudentDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Student Student { get; set; }

		public IList<Group> Groups { get; set; } = new List<Group>();

		[TempData]
		public string ErrorMessage { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Student = await _context.Students.FindAsync(id);

			if (Student == null)
			{
				return NotFound();
			}

			Groups = await _context.Groups.OrderBy(g => g.Name).ToListAsync();
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				Groups = await _context.Groups.OrderBy(g => g.Name).ToListAsync();
				return Page();
			}

			var studentToUpdate = await _context.Students.FindAsync(Student.StudentId);

			if (studentToUpdate == null)
			{
				return NotFound();
			}

			studentToUpdate.FirstName = Student.FirstName;
			studentToUpdate.LastName = Student.LastName;
			studentToUpdate.Age = Student.Age;
			studentToUpdate.GroupId = Student.GroupId;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!StudentExists(Student.StudentId))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Index");
		}

		private bool StudentExists(int id)
		{
			return _context.Students.Any(e => e.StudentId == id);
		}
	}
}