using MvcApp.Annotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MvcApp.Pages.Students;

public class IndexModel : PageModel
{
	private readonly StudentDbContext _context;

	public IndexModel(StudentDbContext context)
	{
		_context = context;
	}

	public IList<Student> Students { get; set; } = new List<Student>();
	public IList<Group> Groups { get; set; } = new List<Group>();

	[BindProperty]
	public Student NewStudent { get; set; } = new Student();

	[TempData]
	public string ErrorMessage { get; set; }

	[TempData]
	public string SuccessMessage { get; set; }

	public async Task OnGetAsync()
	{
		Students = await _context.Students.Include(s => s.Group).ToListAsync();
		Groups = await _context.Groups.OrderBy(g => g.Name).ToListAsync();
	}

	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid)
		{
			await OnGetAsync();
			return Page();
		}

		_context.Students.Add(NewStudent);
		await _context.SaveChangesAsync();

		SuccessMessage = "Student added successfully!";
		return RedirectToPage();
	}
}