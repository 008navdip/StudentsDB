using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentsDB.Data;
using StudentsDB.Models;

namespace StudentsDB.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
        

            var courses = await _context.Courses
                .FirstOrDefaultAsync(m => m.CID == id);
            
            return View(courses);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }
        private bool CoursesExists(int id)
        {
            return _context.Courses.Any(e => e.CID == id);
        }
        // POST: Courses/Create

        [HttpPost]

        public async Task<IActionResult> Create([Bind("CID,CourseName,Description")] Courses courses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var courses = await _context.Courses.FindAsync(id);
         
            return View(courses);
        }

        // POST: Courses/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CID,CourseName,Description")] Courses courses)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                }
                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            

            var courses = await _context.Courses
                .FirstOrDefaultAsync(m => m.CID == id);
          
            return View(courses);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courses);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

     
    }
}
