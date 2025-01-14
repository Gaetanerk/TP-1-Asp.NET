using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TPTodoList.Models;

namespace TPTodoList.Data
{
    public class TPTodoListContext : DbContext
    {
        public TPTodoListContext (DbContextOptions<TPTodoListContext> options)
            : base(options)
        {
        }

        public DbSet<TPTodoList.Models.TodoList> TodoList { get; set; } = default!;
    }
}
