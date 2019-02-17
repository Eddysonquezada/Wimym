using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Wymim.DatabaseContext;
using Wymim.Domain;
using Wymim.Models;
using Wymim.Services.Repositories;

namespace Wimym.Backend.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AccountRepository _repository;
        private readonly WalletRepository _walletRepository;

        public AccountsController(DataContext context)
        {
            _repository = new AccountRepository(context);
            _walletRepository = new WalletRepository(context);
        }

        public async Task<IActionResult> Index()
        {
            var myEntList = await _repository.FindByClause();
            return View(myEntList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var myEntity = await _repository.GetByClause(p=>p.AccountId==id);

            if (myEntity == null)
            {
                return NotFound();
            }

            return View(myEntity);

            //var account = await _context.Accounts
            //    .Include(a => a.Wallet)
            //    .FirstOrDefaultAsync(m => m.AccountId == id);
            //if (account == null)
            //{
            //    return NotFound();
            //}

            //return View(account);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["WalletId"] = new SelectList(await _walletRepository.FindByClause(), "WalletId", "Code");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Account myEntity)
        {
            var dd = new AccountDto();

            if (ModelState.IsValid)
            {
                await _repository.AddAsync(myEntity);
                return RedirectToAction(nameof(Index));
            }
            ViewData["WalletId"] = new SelectList(await _walletRepository.FindByClause(), "WalletId", "Code", myEntity.WalletId);

            return View(myEntity);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var myEntity = await _repository.FindByIdAsync(id);
            if (myEntity == null)
            {
                return NotFound();
            }
            ViewData["WalletId"] = new SelectList(await _walletRepository.FindByClause(), "WalletId", "Code", myEntity.WalletId);

            return View(myEntity);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Account myEntity)
        {
            if (id != myEntity.AccountId)
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
                    if (!AccountExists(myEntity.WalletId))
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
            ViewData["WalletId"] = new SelectList(await _walletRepository.FindByClause(), "WalletId", "Code", myEntity.WalletId);

            return View(myEntity);

        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var myEntity = await _repository.FindByIdAsync(id);
            if (myEntity == null)
            {
                return NotFound();
            }
            return View(myEntity);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myEntity = await _repository.FindByIdAsync(id);
            await _repository.DeleteAsync(myEntity);
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
