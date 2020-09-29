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
    public class StudentInfosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentInfosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentInfos
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentInfos.ToListAsync());
        }

        // GET: StudentInfos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
           
            var studentInfos = await _context.StudentInfos
                .FirstOrDefaultAsync(m => m.StdId == id);
          
            return View(studentInfos);
        }

        // GET: StudentInfos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentInfos/Create

        [HttpPost]

        public async Task<IActionResult> Create([Bind("StdId,FirstName,LastName,Gender,MyProperty")] StudentInfos studentInfos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentInfos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentInfos);
        }

        // GET: StudentInfos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var studentInfos = await _context.StudentInfos.FindAsync(id);
         
            return View(studentInfos);
        }

        // POST: StudentInfos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StdId,FirstName,LastName,Gender,MyProperty")] StudentInfos studentInfos)
        {
          
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentInfos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return RedirectToAction(nameof(Index));
            }
            return View(studentInfos);
        }

        // GET: StudentInfos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
         

            var studentInfos = await _context.StudentInfos
                .FirstOrDefaultAsync(m => m.StdId == id);
           

            return View(studentInfos);
        }

        // POST: StudentInfos/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentInfos = await _context.StudentInfos.FindAsync(id);
            _context.StudentInfos.Remove(studentInfos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentInfosExists(int id)
        {
            return _context.StudentInfos.Any(e => e.StdId == id);
        }
    }
}
