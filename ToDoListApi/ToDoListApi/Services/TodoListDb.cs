using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;

namespace ToDoListApi.Services
{
    public class TodoListDbContext:DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) 
        {
            
            Database.EnsureCreated();
            
        }

        public DbSet<Note> ToDoList { get; set; }
       
    }

    
}
