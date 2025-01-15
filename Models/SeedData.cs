using Microsoft.EntityFrameworkCore;
using TPTodoList.Data;

namespace TPTodoList.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TPTodoListContext(serviceProvider.GetRequiredService<DbContextOptions<TPTodoListContext>>()))
            {
                if (context.TodoList.Any())
                {
                    return;
                }
                context.TodoList.AddRange(
                    new TodoList
                    {
                        Task = "Acheter du pain",
                        DueDateTime = DateTime.Parse("2025-01-16 07:00:00"),
                        IsComplete = true
                    },
                    new TodoList
                    {
                        Task = "Faire les courses",
                        DueDateTime = DateTime.Parse("2025-01-16 09:30:00"),
                        IsComplete = true
                    },
                    new TodoList
                    {
                        Task = "Préparer le repas",
                        DueDateTime = DateTime.Parse("2025-01-16 11:00:00"),
                        IsComplete = true
                    },
                    new TodoList
                    {
                        Task = "Préparer le dîner",
                        DueDateTime = DateTime.Parse("2025-01-16 18:30:00"),
                        IsComplete = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
