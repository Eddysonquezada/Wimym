using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Back.Data;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Back.Controllers
{
    public class ContactsController : DI_BasePageModel
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
            _context = context;
        }
        //public ContactsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public IList<Contact> Contact { get; set; }
        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            var contacts = from c in Context.Contact
                select c;

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
                               User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner.
            if (!isAuthorized)
            {
                contacts = contacts.Where(c => c.Status == ContactStatus.Approved
                                               || c.OwnerID == currentUserId);
            }

          //  Contact = await contacts.ToListAsync();
            return View(await contacts.ToListAsync());
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Contact = await Context.Contact.FirstOrDefaultAsync(m => m.ContactId == id);

            if (Contact == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
                               User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Contact.OwnerID
                && Contact.Status != ContactStatus.Approved)
            {
                return new ChallengeResult();
            }

            if (id == null)
            {
                return NotFound();
            }

            var contact = await _context.Contact
                .FirstOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(  Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            contact.OwnerID = UserManager.GetUserId(User);

            // requires using ContactManager.Authorization;
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, contact,
                ContactOperations.Create);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Contact.Add(contact);
            await Context.SaveChangesAsync();
            
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Contacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            contact = await Context.Contact.FirstOrDefaultAsync(
                m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Contact,
                ContactOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }


            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var contact = await _context.Contact.FindAsync(id);
            //if (contact == null)
            //{
            //    return NotFound();
            //}
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [BindProperty]
        public Contact contact { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Contact viewContact)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Fetch Contact from DB to get OwnerID.
            var contact = await Context
                .Contact.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, contact,
                ContactOperations.Update);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            contact.OwnerID = contact.OwnerID;

            Context.Attach(Contact).State = EntityState.Modified;

            if (contact.Status == ContactStatus.Approved)
            {
                // If the contact is updated after approval, 
                // and the user cannot approve,
                // set the status back to submitted so the update can be
                // checked and approved.
                var canApprove = await AuthorizationService.AuthorizeAsync(User,
                    contact,
                    ContactOperations.Approve);

                if (!canApprove.Succeeded)
                {
                    contact.Status = ContactStatus.Submitted;
                }
            }

            await Context.SaveChangesAsync();
            //if (id != contact.ContactId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(contact);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ContactExists(contact.ContactId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Contact = await Context.Contact.FirstOrDefaultAsync(
                m => m.ContactId == id);

            if (Contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, Contact,
                ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var contact = await _context.Contact
            //    .FirstOrDefaultAsync(m => m.ContactId == id);
            //if (contact == null)
            //{
            //    return NotFound();
            //}

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Contact = await Context.Contact.FindAsync(id);

            var contact = await Context
                .Contact.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                User, contact,
                ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return new ChallengeResult();
            }

            Context.Contact.Remove(Contact);
            await Context.SaveChangesAsync();
            //var contact = await _context.Contact.FindAsync(id);
            //_context.Contact.Remove(contact);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }
    }
}
