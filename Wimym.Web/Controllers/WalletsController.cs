namespace Wimym.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;
    using Wimym.Web.Data;
    using Wimym.Web.Data.Entities;

    public class WalletsController : Controller
    {
        private readonly DataContext _context;

        public WalletsController(DataContext context)
        {
            _context = context;
        }

        // GET: Wallets
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Wallets.Include(w => w.CreatedUser).Include(w => w.DeletedUser).Include(w => w.UpdatedUser);
            return View(await dataContext.ToListAsync());
        }

        // GET: Wallets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallets
                .Include(w => w.CreatedUser)
                .Include(w => w.DeletedUser)
                .Include(w => w.UpdatedUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wallet == null)
            {
                return NotFound();
            }

            return View(wallet);
        }

        // GET: Wallets/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["DeletedBy"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Wallets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description,State,Amount,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,DeletedAt,DeletedBy")] Wallet wallet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wallet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.UpdatedBy);
            return View(wallet);
        }

        // GET: Wallets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallets.FindAsync(id);
            if (wallet == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.UpdatedBy);
            return View(wallet);
        }

        // POST: Wallets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Description,State,Amount,CreatedAt,CreatedBy,UpdatedAt,UpdatedBy,DeletedAt,DeletedBy")] Wallet wallet)
        {
            if (id != wallet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wallet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletExists(wallet.Id))
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
            ViewData["CreatedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.CreatedBy);
            ViewData["DeletedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.DeletedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "Id", "Id", wallet.UpdatedBy);
            return View(wallet);
        }

        // GET: Wallets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wallet = await _context.Wallets
                .Include(w => w.CreatedUser)
                .Include(w => w.DeletedUser)
                .Include(w => w.UpdatedUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wallet == null)
            {
                return NotFound();
            }

            return View(wallet);
        }

        // POST: Wallets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wallet = await _context.Wallets.FindAsync(id);
            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WalletExists(int id)
        {
            return _context.Wallets.Any(e => e.Id == id);
        }
    }
}
