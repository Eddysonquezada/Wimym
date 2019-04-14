namespace Wimym.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using Wimym.Web.Data.Entities;
    using Wimym.Web.Data.Repositories.Contracts;

    [Authorize]
    public class ReactionsController : Controller
    {
        private readonly IReaction _reactionRepository;

        public ReactionsController(
            IReaction reactionRepository)
        {
            _reactionRepository = reactionRepository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _reactionRepository.GetReactionsAsync(this.User.Identity.Name);
            return View(model);
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reaction model)
        {
            model.Date = DateTime.UtcNow;
            //model.ApplicationUser = User;
            if (this.ModelState.IsValid)
            {
                await _reactionRepository.CreateReactionAsync(model, this.User.Identity.Name);
                return this.RedirectToAction("Create");
            }

            return this.View(model);
        }

    }
}