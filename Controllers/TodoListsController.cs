using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TPTodoList.Data;
using TPTodoList.Models;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace TPTodoList.Controllers
{
    public class TodoListsController : Controller
    {
        private readonly TPTodoListContext _context;

        public TodoListsController(TPTodoListContext context)
        {
            _context = context;
        }

        // GET: TodoLists
        public async Task<IActionResult> Index(string filter = "all", int pageNumber = 1, int pageSize = 10)
        {
            IQueryable<TodoList> query = _context.TodoList;

            switch (filter.ToLower())
            {
                case "finished":
                    query = query.Where(t => t.IsComplete);
                    break;
                case "inprogress":
                    query = query.Where(t => !t.IsComplete);
                    break;
                default:
                    break;
            }

            var totalItems = await query.CountAsync();
            var todoLists = await query
                .OrderByDescending(t => t.IsComplete)
                .ThenBy(t => t.DueDateTime)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.Filter = filter;

            return View(todoLists);
        }

        // GET: TodoLists/Form
        public IActionResult Form()
        {
            return View();
        }

        // POST: TodoLists/Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form([Bind("Id,Task,IsComplete")] TodoList todoList, DateTime DueDate, TimeSpan DueTime)
        {
            if (ModelState.IsValid)
            {
                todoList.DueDateTime = DueDate.Add(DueTime);
                _context.Add(todoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoList);
        }
        public async Task<IActionResult> MarkComplete(int id)
        {
            var todoList = await _context.TodoList.FindAsync(id);
            if (todoList != null)
            {
                todoList.IsComplete = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteTask(int id)
        {
            var todoList = await _context.TodoList.FindAsync(id);
            if (todoList != null)
            {
                _context.TodoList.Remove(todoList);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
