using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.Controllers
{
    public class LeadPricesController : Controller
    {
        private readonly Context _context;

        public LeadPricesController(Context context)
        {
            _context = context;
        }

        // Index LeadPrices function
        public async Task<IActionResult> Index()
        {

            try
            {
                return View(await _context.LeadPrices.ToListAsync());
            }
            catch(Exception Ex)
            {
                return View(Ex.Message);
            }
        }

        
        // GET: LeadPrices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeadPrices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("lpId,ETAA5000,ETAA4000,ETAA3000,ETAA2000,ETAB1999")] LeadPrice leadPrice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leadPrice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leadPrice);
        }

        // GET: LeadPrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LeadPrices == null)
            {
                return NotFound();
            }

            var leadPrice = await _context.LeadPrices.FindAsync(id);
            if (leadPrice == null)
            {
                return NotFound();
            }
            return View(leadPrice);
        }

        // POST: LeadPrices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("lpId,ETAA5000,ETAA4000,ETAA3000,ETAA2000,ETAB1999")] LeadPrice leadPrice)
        {
            if (id != leadPrice.lpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadPrice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadPriceExists(leadPrice.lpId))
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
            return View(leadPrice);
        }

        
        private bool LeadPriceExists(int id)
        {
          return (_context.LeadPrices?.Any(e => e.lpId == id)).GetValueOrDefault();
        }
    }
}
