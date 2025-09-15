using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Model;

namespace ToDoList.Infrastructure.Data.Context
{
    public class ToDo_Context : DbContext
    {
        public ToDo_Context(DbContextOptions<ToDo_Context> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}