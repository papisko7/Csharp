using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcApp.Annotations;

namespace MvcApp.Pages.Groups
{
	public class EditModel : PageModel
	{
		private readonly StudentDbContext _context;

		public EditModel(StudentDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Group Group { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Group = await _context.Groups.FindAsync(id);

			if (Group == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			var groupToUpdate = await _context.Groups.FindAsync(Group.GroupId);

			if (groupToUpdate == null)
			{
				return NotFound();
			}

			groupToUpdate.Name = Group.Name;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!GroupExists(Group.GroupId))
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

		private bool GroupExists(int id)
		{
			return _context.Groups.Any(e => e.GroupId == id);
		}
	}
}