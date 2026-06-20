using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group = MvcApp.Annotations.Group;

namespace MvcApp.Controllers.MVC;

public class MvcGroupsController(StudentDbContext context, ILogger<MvcGroupsController> logger)
	: Controller
{
	public async Task<IActionResult> Index()
	{
		logger.LogInformation("Fetched the list of all groups.");
		var groups = await context.Groups.ToListAsync();
		return View(groups);
	}

	public async Task<IActionResult> Details(int? id)
	{
		if (id == null) return NotFound();

		var group = await context.Groups
			.Include(g => g.Students)
			.FirstOrDefaultAsync(m => m.GroupId == id);

		if (group == null) return NotFound();

		logger.LogInformation($"Viewed details for group: {group.Name} (ID: {id}).");
		return View(group);
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create([Bind("GroupId,Name")] Group @group)
	{
		if (ModelState.IsValid)
		{
			context.Add(@group);
			await context.SaveChangesAsync();
			logger.LogInformation($"Successfully created a new group: {@group.Name}.");
			return RedirectToAction(nameof(Index));
		}
		return View(@group);
	}

	public async Task<IActionResult> Edit(int? id)
	{
		if (id == null) return NotFound();

		var @group = await context.Groups.FindAsync(id);
		if (@group == null) return NotFound();

		return View(@group);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("GroupId,Name")] Group @group)
	{
		if (id != @group.GroupId) return NotFound();

		if (ModelState.IsValid)
		{
			try
			{
				context.Update(@group);
				await context.SaveChangesAsync();
				logger.LogInformation($"Updated group with ID: {id}. New name: {@group.Name}.");
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!GroupExists(@group.GroupId)) return NotFound();
				else throw;
			}
			return RedirectToAction(nameof(Index));
		}
		return View(@group);
	}

	// GET: MvcGroups/Delete/5
	// Requirement: Ask for confirmation before deleting
	public async Task<IActionResult> Delete(int? id)
	{
		if (id == null) return NotFound();

		var @group = await context.Groups
			.FirstOrDefaultAsync(m => m.GroupId == id);
		if (@group == null) return NotFound();

		return View(@group);
	}

	// POST: MvcGroups/Delete/5
	[HttpPost, ActionName("Delete")]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		var @group = await context.Groups.FindAsync(id);
		if (@group != null)
		{
			context.Groups.Remove(@group);
			await context.SaveChangesAsync();
			logger.LogWarning($"Deleted group: {@group.Name} (ID: {id}).");
		}

		return RedirectToAction(nameof(Index));
	}

	private bool GroupExists(int id)
	{
		return context.Groups.Any(e => e.GroupId == id);
	}
}