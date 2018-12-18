namespace Wimym.Backend.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Wimym.Backend.Models;

    public class CurrenciesController : Controller
    {
        private readonly LocalDataContext _context;

        public CurrenciesController(LocalDataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sort)
        {
            ViewData["CodeSortparam"] = string.IsNullOrEmpty(sort) ? "code_desc" : "";
            ViewData["NameSortparam"] =  sort =="name_asc" ? "name_desc" : "name_asc";

            var currencies = from s in _context.Currencies select s;

            switch (sort)
            {
                case "code_desc":
                    currencies = currencies.OrderByDescending(s =>s.Code);
                    break;
                case "name_desc":
                    currencies = currencies.OrderByDescending(s => s.Name);
                    break;
                case "name_asc":
                    currencies = currencies.OrderBy(s => s.Name);
                    break;
                default:
                    currencies = currencies.OrderBy(s => s.Code);
                    break;

            }
            return View( await currencies.AsNoTracking().ToListAsync());
           // return View(await _context.Currencies.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _context.Currencies
                .FirstOrDefaultAsync(m => m.CurrencyId == id);
            if (currencies == null)
            {
                return NotFound();
            }

            return View(currencies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Currency currency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currency);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _context.Currencies.FindAsync(id);
            if (currencies == null)
            {
                return NotFound();
            }
            return View(currencies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Currency currency)
        {
            if (id != currency.CurrencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrenciesExists(currency.CurrencyId))
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
            return View(currency);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _context.Currencies
                .FirstOrDefaultAsync(m => m.CurrencyId == id);
            if (currencies == null)
            {
                return NotFound();
            }

            return View(currencies);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currencies = await _context.Currencies.FindAsync(id);
            _context.Currencies.Remove(currencies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrenciesExists(int id)
        {
            return _context.Currencies.Any(e => e.CurrencyId == id);
        }
    }
}
