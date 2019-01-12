using Wimym.Backend.Data;

namespace Wimym.Backend.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Wimym.Backend.Models;

    public class OriginsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OriginsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string sort,
            string currentFilter,
            string searchFilter,
            int? page)
        {
            ViewData["CodeSortparam"] = string.IsNullOrEmpty(sort) ? "code_desc" : "";
            ViewData["NameSortparam"] = sort == "name_asc" ? "name_desc" : "name_asc";

            if (searchFilter != null)
            {
                page = 1;
            }
            else
            {
                searchFilter = currentFilter;
            }


            ViewData["CurrentFilter"] = searchFilter;
            ViewData["CurrentSort"] = sort;

            var origins = from s in _context.Origins select s;

            if (!string.IsNullOrEmpty(searchFilter))
            {//alt + 124
                origins = origins.Where(s => s.Code.Contains(searchFilter) || s.Name.Contains(searchFilter));
            }

            switch (sort)
            {
                case "code_desc":
                    origins = origins.OrderByDescending(s => s.Code);
                    break;
                case "name_desc":
                    origins = origins.OrderByDescending(s => s.Name);
                    break;
                case "name_asc":
                    origins = origins.OrderBy(s => s.Name);
                    break;
                default:
                    origins = origins.OrderBy(s => s.Code);
                    break;

            }

            int pageSize = 2;
            return View(await Pagination<Origin>.CreateAsync(origins.AsNoTracking(), page ?? 1, pageSize));

            // return View( await origins.AsNoTracking().ToListAsync());
            // return View(await _context.Origins.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origins = await _context.Origins
                .FirstOrDefaultAsync(m => m.OriginId == id);
            if (origins == null)
            {
                return NotFound();
            }

            return View(origins);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Origin origin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(origin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origin);
        }

        

 

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origins = await _context.Origins
                .FirstOrDefaultAsync(m => m.OriginId == id);
            if (origins == null)
            {
                return NotFound();
            }

            return View(origins);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var origins = await _context.Origins.FindAsync(id);
            _context.Origins.Remove(origins);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OriginsExists(int id)
        {
            return _context.Origins.Any(e => e.OriginId == id);
        }
    }
}
