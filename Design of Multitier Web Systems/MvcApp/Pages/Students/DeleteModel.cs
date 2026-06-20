using MvcApp.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MvcApp.Pages.Students
{
	public class DeleteModel : PageModel
	{
		private readonly StudentDbContext _context;

		public DeleteModel(StudentDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Student Student { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Student = await _context.Students.Include(s => s.Group).FirstOrDefaultAsync(m => m.StudentId == id);

			if (Student == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Student = await _context.Students.FindAsync(id);

			if (Student != null)
			{
				_context.Students.Remove(Student);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}