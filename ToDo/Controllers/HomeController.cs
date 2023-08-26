using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using ToDoDemo.Models;

namespace ToDoDemo.Controllers
{
    public class HomeController : Controller
    {
        private ToDoContext context;


        public HomeController(ToDoContext ctx)
        {
          context = ctx;
        }
        /// <summary>
        /// Displays a list of tasks based on filters.
        /// </summary>
        /// <param name="id">A filter identifier string.</param>
        /// <returns>The view with a list of tasks.</returns>

        public IActionResult Index(string id)
        {
            //Code to filter and display tasks based on provided filters
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statues.ToList();
            ViewBag.DueFilters = Filters.DueFilterValues;
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Statuses = context.Statues.ToList();
            IQueryable<ToDo> query = context.ToDos.
                Include(t => t.Category).Include(t => t.Status);

            if (filters.HasCategory)
            {
                query = query.Where(t => t.CategoryId == filters.CategoryId);
            }
            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }
            if (filters.HasDue)
            {
                var today = DateTime.Today;
                if (filters.IsPast)
                {
                    query = query.Where(t => t.DueDate < today);
                }
                else if (filters.IsFuture)
                {
                    query = query.Where(t => t.DueDate > today);
                }
                else if (filters.IstToday)
                {
                    query = query.Where(t => t.DueDate == today);
                }
            }
            var tasks = query.OrderBy(t => t.DueDate).ToList();
            
            return View(tasks);
        }

        /// <summary>
        /// Displays a form to add a new task.
        /// </summary>
        /// <returns>The view with the task creation form.</returns>
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Statuses   = context.Statues.ToList();
            var tasks = new ToDo { StatusId = "open" };
            return View(tasks);
        }

        /// <summary>
        /// Handles the submission of the task creation form.
        /// </summary>
        /// <param name="task">The task to be added.</param>
        /// <returns>Redirects to the Index action if successful, or returns the view with errors.</returns>
        [HttpPost]
        public IActionResult Add(ToDo task)
        {
            // Code to process the submitted task and add it to the database.
            if (ModelState.IsValid) 
            {
                context.ToDos.Add(task);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                ViewBag.Statuss = context.Statues.ToList();
                return View(task);
            }

            
        }

        /// <summary>
        /// Handles the submission of a filter form.
        /// </summary>
        /// <param name="filter">An array of filter values.</param>
        /// <returns>Redirects to the Index action with applied filters.</returns>
        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            // Code to apply filters and redirect to the Index action

            string id = string.Join("-", filter);
            return RedirectToAction("Index", new {ID = id });
        }
        /// <summary>
        /// Marks a task as complete.
        /// </summary>
        /// <param name="id">The task identifier.</param>
        /// <param name="selected">The selected task.</param>
        /// <returns>Redirects to the Index action after marking the task as complete.</returns>
        [HttpPost]
        public IActionResult MarkComplete([FromRoute] string id, ToDo selected)
        {
            // Code to mark a task as complete in the database
            selected = context.ToDos.Find(selected.Id)!;

            if (selected != null)
            {
                selected.StatusId = "closed";
                context.SaveChanges();
            }
            return RedirectToAction("Index", new { ID = id });
        }
        /// <summary>
        /// Deletes completed tasks.
        /// </summary>
        /// <param name="id">A filter identifier string.</param>
        /// <returns>Redirects to the Index action after deleting completed tasks.</returns>
        [HttpPost]
        public IActionResult DeleteComplete(string id) 
        {
            var toDelete = context.ToDos.Where(t => t.StatusId == "closed").ToList();
            foreach (var task in toDelete)
            {
                context.ToDos.Remove(task);
            }
            context.SaveChanges();
            return RedirectToAction("Index", new {ID =  id });
        }
        
    }
}