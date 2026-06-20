using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MvcApp.Annotations;

namespace MvcApp.Pages.Groups;

public class IndexModel : PageModel
{
	private readonly StudentDbContext _context;

	public IndexModel(StudentDbContext context)
	{
		_context = context;
	}

	public IList<Group> Groups { get; set; } = new List<Group>();

	[BindProperty]
	public Group NewGroup { get; set; } = new Group();

	[TempData]
	public string ErrorMessage { get; set; }

	[TempData]
	public string SuccessMessage { get; set; }

	public async Task OnGetAsync()
	{
		Groups = await _context.Groups.OrderBy(g => g.Name).ToListAsync();
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid)
		{
			await OnGetAsync();
			return Page();
		}

		_context.Groups.Add(NewGroup);
		await _context.SaveChangesAsync();

		SuccessMessage = "Group added successfully!";
		return RedirectToPage();
	}
}