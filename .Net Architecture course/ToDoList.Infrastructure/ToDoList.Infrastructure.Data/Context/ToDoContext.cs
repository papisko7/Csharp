using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Model;

namespace ToDoList.Infrastructure.Data.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        {
        }

        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}