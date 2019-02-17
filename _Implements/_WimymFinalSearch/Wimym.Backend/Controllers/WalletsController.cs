using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wymim.DatabaseContext;
using Wymim.Domain;
using Wymim.Services.Repositories;

namespace Wimym.Backend.Controllers
{
    //this is the controller name, 
    public class WalletsController : Controller
    {
        //this is the object than indicate the link to our database
        //   private readonly ApplicationContext _context;
        private readonly WalletRepository _repository;
        //in this case i can call directly to the generic repository, but, 
        //maybe in the future, i need custom methods on the wallet, than i cant do
        //on the account, for example, on the account repository, maybe 
        //i will need to update the amount of the wallet too.
        public WalletsController(DataContext context)
        {
            //  _context = context;
            _repository = new WalletRepository(context);
        }

        //show a list from the object (table) with all the data
        //this is the action index, each action is a part of the controller
        //than we can call for the reason than we want
        public async Task<IActionResult> Index()
        {
            var myEntList = await _repository.FindByClause();

            return View(myEntList);
        }

        // show details from one specific row on the table
        public async Task<IActionResult> Details(int id)
        {
            var myEntity = await _repository.FindByIdAsync(id);

            if (myEntity == null)
            {
                return NotFound();
            }

            return View(myEntity);
        }

        // show the create screen
        public IActionResult Create()
        {
            return View();
        }

        // receive the data from the view (screen) and if its valid create a new row, on the table
        //allways remove the binding
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Wallet myEntity)
        {
            if (ModelState.IsValid)
            {
                await _repository.AddAsync(myEntity);
                return RedirectToAction(nameof(Index));
            }
            return View(myEntity);
        }

        // send you to the screen for edit the information of the selected row
        public async Task<IActionResult> Edit(int id)
        {
            var myEntity = await _repository.FindByIdAsync(id);
            if (myEntity == null)
            {
                return NotFound();
            }
            return View(myEntity);
        }

        // received the data, and update the row
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Wallet myEntity)
        {
            if (id != myEntity.WalletId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(myEntity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WalletExists(myEntity.WalletId))
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
            return View(myEntity);
        }

        // send you to the delete screen
        public async Task<IActionResult> Delete(int id)
        {
            var myEntity = await _repository.FindByIdAsync(id);
                                   return View(myEntity);
        }

        // receive the confirmation, and remove that row from database
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var wallet = await _context.Wallets.FindAsync(id);
            //_context.Wallets.Remove(wallet);
            //await _context.SaveChangesAsync();
            var myEntity = await _repository.FindByIdAsync(id);
            await _repository.DeleteAsync(myEntity);
            return RedirectToAction(nameof(Index));
        }

        //validate if the row, given an Id, exist
        private bool WalletExists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
