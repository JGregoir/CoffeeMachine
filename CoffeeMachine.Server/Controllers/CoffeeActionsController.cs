using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CoffeeMachine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeActionsController : ControllerBase
    {
        private readonly MachineContext _context;

        public CoffeeActionsController(MachineContext context)
        {
            _context = context;
        }

        // GET: api/CoffeeActions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeAction>>> GetCoffeeActions()
        {
            return await _context.CoffeeActions.ToListAsync();
        }

        // GET: api/CoffeeActions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoffeeAction>> GetCoffeeAction(long id)
        {
            var coffeeAction = await _context.CoffeeActions.FindAsync(id);

            if (coffeeAction == null)
            {
                return NotFound();
            }

            return coffeeAction;
        }

        // PUT: api/CoffeeActions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoffeeAction(long id, CoffeeAction coffeeAction)
        {
            if (id != coffeeAction.Id)
            {
                return BadRequest();
            }

            _context.Entry(coffeeAction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoffeeActionExists(id))
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

        // POST: api/CoffeeActions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoffeeAction>> PostCoffeeAction(CoffeeAction coffeeAction)
        {
            coffeeAction.TimeStamp = DateTime.Now.ToString();
            _context.CoffeeActions.Add(coffeeAction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoffeeAction), new { id = coffeeAction.Id }, coffeeAction);
        }



        // DELETE: api/CoffeeActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoffeeAction(long id)
        {
            var coffeeAction = await _context.CoffeeActions.FindAsync(id);
            if (coffeeAction == null)
            {
                return NotFound();
            }

            _context.CoffeeActions.Remove(coffeeAction);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // action commands

        [Route("api/[controller]/reqPowerOn")]
        [HttpPost]
        public async Task<ActionResult<bool>> PostCoffeeReqPowerON(long id)
        {
            //not implemented
            Console.WriteLine("PowerOn requested but function not implemented");
            return false;
        }

        [Route("api/[controller]/reqPowerOFF")]
        [HttpPost]
        public async Task<ActionResult<bool>> PostCoffeeReqPowerOFF(long id)
        {
            //not implemented
            Console.WriteLine("PowerOFF requested but function not implemented");
            return false;
        }

        [Route("api/[controller]/reqCoffee")]
        [HttpPost]
        public async Task<ActionResult<bool>> PostCoffeeReqCoffee(long id)
        {
            //not implemented
            Console.WriteLine(id + " coffees requested but function not implemented");
            return false;
        }

        private bool CoffeeActionExists(long id)
        {
            return _context.CoffeeActions.Any(e => e.Id == id);
        }
    }
}
