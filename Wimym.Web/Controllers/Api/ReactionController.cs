using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wimym.Web.Data;
using Wimym.Web.Data.Repositories.Contracts;
using Wimym.Web.Helpers;
using Wimym.Web.Models;

namespace Wimym.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IReaction _reactionRepository;


        public ReactionController(DataContext context, IReaction reactionRepository, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _reactionRepository = reactionRepository;
        }

        // GET: api/Reaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reaction>>> GetReactions()
        {
            return await _context.Reactions.ToListAsync();
        }

        // GET: api/Reaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reaction>> GetReaction(long id)
        {
            var reaction = await _context.Reactions.FindAsync(id);

            if (reaction == null)
            {
                return NotFound();
            }

            return reaction;
        }

        // PUT: api/Reaction/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReaction(long id, Reaction reaction)
        {
            if (id != reaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(reaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reaction
        [HttpPost]
        public async Task<ActionResult<Reaction>> PostReaction(Wimym.Common.Models.ReactionResponse reaction)
        {
            var user = await _userHelper.GetUserByEmailAsync(reaction.User.Email);
            if (user == null)
            {
                return this.BadRequest("Invalid user");
            }

            //TODO: Upload images
            var entityReaction = new Reaction
            {
                Punctuation = reaction.Punctuation,
                Name = reaction.Name,
                Email = reaction.Email,
                Observation = reaction.Observation,
                ApplicationUser = user
            };

            var newReaction = await _reactionRepository.CreateAsync(entityReaction);
            // _context.Reactions.Add(newReaction);
            // await _context.SaveChangesAsync();
            return Ok(newReaction);

            //  return CreatedAtAction("GetReaction", new { id = reaction.Id }, reaction);
        }

        // DELETE: api/Reaction/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reaction>> DeleteReaction(long id)
        {
            var reaction = await _context.Reactions.FindAsync(id);
            if (reaction == null)
            {
                return NotFound();
            }

            _context.Reactions.Remove(reaction);
            await _context.SaveChangesAsync();

            return reaction;
        }

        private bool ReactionExists(long id)
        {
            return _context.Reactions.Any(e => e.Id == id);
        }
    }
}
