using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_DataAccess;
using Project_Model;

namespace WebApplication1.Controllers
{
    public class SehirsController : Controller
    {
        private readonly ApplicationDbContext _context;
       
        public SehirsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sehirs
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sehirs.ToListAsync());
        }

        // GET: Sehirs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sehirs == null)
            {
                return NotFound();
            }

            var sehir = await _context.Sehirs
                .FirstOrDefaultAsync(m => m.SehirID == id);
            if (sehir == null)
            {
                return NotFound();
            }

            return View(sehir);
        }

        // GET: Sehirs/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sehirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SehirID,SehirAdı")] Sehir sehir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sehir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sehir);
        }

        // GET: Sehirs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sehirs == null)
            {
                return NotFound();
            }

            var sehir = await _context.Sehirs.FindAsync(id);
            if (sehir == null)
            {
                return NotFound();
            }
            return View(sehir);
        }

        // POST: Sehirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SehirID,SehirAdı")] Sehir sehir)
        {
            if (id != sehir.SehirID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sehir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SehirExists(sehir.SehirID))
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
            return View(sehir);
        }

        // GET: Sehirs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sehirs == null)
            {
                return NotFound();
            }

            var sehir = await _context.Sehirs
                .FirstOrDefaultAsync(m => m.SehirID == id);
            if (sehir == null)
            {
                return NotFound();
            }

            return View(sehir);
        }

        // POST: Sehirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sehirs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sehirs'  is null.");
            }
            var sehir = await _context.Sehirs.FindAsync(id);
            if (sehir != null)
            {
                _context.Sehirs.Remove(sehir);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SehirExists(int id)
        {
          return _context.Sehirs.Any(e => e.SehirID == id);
        }
    }
}
