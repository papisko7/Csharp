using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcApp.Annotations;

namespace MvcApp.Pages.Groups
{
	public class DeleteModel : PageModel
	{
		private readonly StudentDbContext _context;

		public DeleteModel(StudentDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Group Group { get; set; }

		public int StudentCount { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Group = await _context.Groups.FirstOrDefaultAsync(m => m.GroupId == id);

			if (Group == null)
			{
				return NotFound();
			}

			// Count students assigned to this group
			StudentCount = await _context.Students.CountAsync(s => s.GroupId == id);

			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Group = await _context.Groups.FindAsync(id);

			if (Group != null)
			{
				// Check if there are any students assigned to this group
				var studentCount = await _context.Students.CountAsync(s => s.GroupId == id);

				if (studentCount > 0)
				{
					ErrorMessage = $"Cannot delete group '{Group.Name}'. There are {studentCount} student(s) assigned to this group. Please reassign or remove these students before deleting the group.";
					return RedirectToPage("./Index");
				}

				_context.Groups.Remove(Group);
				await _context.SaveChangesAsync();
			}

			return RedirectToPage("./Index");
		}
	}
}