using MvcApp.Annotations;
using Microsoft.EntityFrameworkCore;

namespace MvcApp;

public class StudentDbContext(DbContextOptions<StudentDbContext> options) : DbContext(options)
{
	public DbSet<Student> Students { get; set; }

	public DbSet<Group> Groups { get; set; }
}