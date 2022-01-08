using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly ParkingContext _context;

        public EnrollmentController(ParkingContext context)
        {
            _context = context;
        }

        // GET: Enrollment
        public async Task<IActionResult> Index()
        {
            var parkingContext = _context.Enrollments.Include(e => e.Bus).Include(e => e.Car).Include(e => e.Spot).Include(e => e.User);
            return View(await parkingContext.ToListAsync());
        }

        // GET: Enrollment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Bus)
                .Include(e => e.Car)
                .Include(e => e.Spot)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollment/Create
        public IActionResult Create()
        {
            ViewData["BusID"] = new SelectList(_context.Bus, "BusID", "BusID");
            ViewData["CarID"] = new SelectList(_context.Car, "CarID", "CarID");
            ViewData["SpotID"] = new SelectList(_context.Spot, "SpotID", "SpotID");
            ViewData["UserID"] = new SelectList(_context.User, "ID", "ID");
            return View();
        }

        // POST: Enrollment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentID,UserID,CarID,BusID,SpotID,Arrival,Departure")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "BusID", "BusID", enrollment.BusID);
            ViewData["CarID"] = new SelectList(_context.Car, "CarID", "CarID", enrollment.CarID);
            ViewData["SpotID"] = new SelectList(_context.Spot, "SpotID", "SpotID", enrollment.SpotID);
            ViewData["UserID"] = new SelectList(_context.User, "ID", "ID", enrollment.UserID);
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["BusID"] = new SelectList(_context.Bus, "BusID", "BusID", enrollment.BusID);
            ViewData["CarID"] = new SelectList(_context.Car, "CarID", "CarID", enrollment.CarID);
            ViewData["SpotID"] = new SelectList(_context.Spot, "SpotID", "SpotID", enrollment.SpotID);
            ViewData["UserID"] = new SelectList(_context.User, "ID", "ID", enrollment.UserID);
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentID,UserID,CarID,BusID,SpotID,Arrival,Departure")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentID))
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
            ViewData["BusID"] = new SelectList(_context.Bus, "BusID", "BusID", enrollment.BusID);
            ViewData["CarID"] = new SelectList(_context.Car, "CarID", "CarID", enrollment.CarID);
            ViewData["SpotID"] = new SelectList(_context.Spot, "SpotID", "SpotID", enrollment.SpotID);
            ViewData["UserID"] = new SelectList(_context.User, "ID", "ID", enrollment.UserID);
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollments
                .Include(e => e.Bus)
                .Include(e => e.Car)
                .Include(e => e.Spot)
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollments.Any(e => e.EnrollmentID == id);
        }
    }
}
