using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wimym.Backend.Data;
using Wimym.Backend.Models;

namespace Wimym.Backend.Controllers
{
    public class AccountTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AccountTypes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AccountTypes.Include(a => a.Origin);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AccountTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountTypes
                .Include(a => a.Origin)
                .SingleOrDefaultAsync(m => m.AccountTypeId == id);
            if (accountType == null)
            {
                return NotFound();
            }

            return View(accountType);
        }

        // GET: AccountTypes/Create
        public IActionResult Create()
        {
            ViewData["OriginId"] = new SelectList(_context.Origins, "OriginId", "Code");
            return View();
        }

        // POST: AccountTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountTypeId,Code,Name,Description,State,OriginId")] AccountType accountType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OriginId"] = new SelectList(_context.Origins, "OriginId", "Code", accountType.OriginId);
            return View(accountType);
        }

        // GET: AccountTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountTypes.SingleOrDefaultAsync(m => m.AccountTypeId == id);
            if (accountType == null)
            {
                return NotFound();
            }
            ViewData["OriginId"] = new SelectList(_context.Origins, "OriginId", "Code", accountType.OriginId);
            return View(accountType);
        }

        // POST: AccountTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountTypeId,Code,Name,Description,State,OriginId")] AccountType accountType)
        {
            if (id != accountType.AccountTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountTypeExists(accountType.AccountTypeId))
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
            ViewData["OriginId"] = new SelectList(_context.Origins, "OriginId", "Code", accountType.OriginId);
            return View(accountType);
        }

        // GET: AccountTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountType = await _context.AccountTypes
                .Include(a => a.Origin)
                .SingleOrDefaultAsync(m => m.AccountTypeId == id);
            if (accountType == null)
            {
                return NotFound();
            }

            return View(accountType);
        }

        // POST: AccountTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountType = await _context.AccountTypes.SingleOrDefaultAsync(m => m.AccountTypeId == id);
            _context.AccountTypes.Remove(accountType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountTypeExists(int id)
        {
            return _context.AccountTypes.Any(e => e.AccountTypeId == id);
        }
    }
}
