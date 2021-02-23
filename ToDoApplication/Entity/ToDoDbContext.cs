using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApplication.Entity
{
    public class ToDoDbContext : DbContext
    {
     
        public DbSet<ToDo> toDos { get; set; }
        public DbSet<User> users { get; set; }

        public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
       : base(options)
        { }
    }
}
