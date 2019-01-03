namespace Wimym.Backend.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using ModelsClass;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CurrenciesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CurrencyModels _currencyModels;

        public CurrenciesController(ApplicationDbContext context)
        {
            _context = context;
            _currencyModels = new CurrencyModels(_context);
        }

        public async Task<IActionResult> Index()
        {
            //return View(await _context.Currencies.ToListAsync());
            return View();
        }
        //this name is how is called on the ajax action, its not neccesary called like the 
        //function on the model 
        public Task<List<IdentityError>> SaveCurrency(string code, string name, string state)
        { //sometimes its a good practice make this call syncronous, in that case we need make the function
            //on the model syncronous too
            return _currencyModels.SaveCurrency(code, name, state);
        }

        public List<Currency> GetCurrencies(int id)
        {
            return _currencyModels.GetCurrencies(id);
        }

        public List<IdentityError> EditCurrency(int id, string code, string name,
            bool state, int type)
        {
            return _currencyModels.EditCurrency(id, code, name, state, type);
        }
        public List<object[]> FilterData(int pageNumber, string filterValue,string order)
        {
            return _currencyModels.FilterData(pageNumber, filterValue,order);
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var currency = await _context.Currencies
        //        .SingleOrDefaultAsync(m => m.CurrencyId == id);
        //    if (currency == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(currency);
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var currency = await _context.Currencies.SingleOrDefaultAsync(m => m.CurrencyId == id);
        //    if (currency == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(currency);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, Currency currency)
        //{
        //    if (id != currency.CurrencyId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(currency);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CurrencyExists(currency.CurrencyId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(currency);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var currency = await _context.Currencies
        //        .SingleOrDefaultAsync(m => m.CurrencyId == id);
        //    if (currency == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(currency);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var currency = await _context.Currencies.SingleOrDefaultAsync(m => m.CurrencyId == id);
        //    _context.Currencies.Remove(currency);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CurrencyExists(int id)
        //{
        //    return _context.Currencies.Any(e => e.CurrencyId == id);
        //}
    }
}
