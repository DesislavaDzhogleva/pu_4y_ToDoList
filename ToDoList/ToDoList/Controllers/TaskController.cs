using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Data.Models;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationContext context;

        public TaskController(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.context.Tasks.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Data.Models.Task task)
        {
            if (ModelState.IsValid)
            {
                this.context.Add(task);
                await this.context.SaveChangesAsync();
                return this.RedirectToAction("Edit", new { id = task.Id });
            }
            return View(task);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await this.context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Data.Models.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.context.Update(task);
                    await this.context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await this.context.Tasks.FindAsync(id);
            this.context.Tasks.Remove(task);
            await this.context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return this.context.Tasks.Any(e => e.Id == id);
        }
    }
}
