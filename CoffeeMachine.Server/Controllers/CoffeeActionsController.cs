using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeMachine.Models;

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


        [Route("Log")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoffeeAction>>> GetCoffeeActions()
        {
            return await _context.CoffeeActions.ToListAsync();
        }



        [Route("Log")]
        [HttpPost]
        public async Task<ActionResult<CoffeeAction>> PostCoffeeAction(CoffeeAction coffeeAction)
        {

            coffeeAction.TimeStamp = DateTime.Now.ToString();
            _context.CoffeeActions.Add(coffeeAction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostCoffeeAction), new { id = coffeeAction.Id }, coffeeAction);
        }


        [Route("reqPowerON")]
        [HttpPost]
        public async Task<ActionResult<bool>> PostCoffeeReqPowerON(long id)
        {
            //not implemented - could not make persistent data in Entity Framework.
            //TODO : test logic + await stub.TurnOnAsync()
            Console.WriteLine("PowerOn requested but function not implemented");
            return false;
        }

        [Route("reqPowerOFF")]
        [HttpPost]
        public async Task<ActionResult<bool>> PostCoffeeReqPowerOFF(long id)
        {
            //not implemented - could not make persistent data in Entity Framework.
            //TODO : test logic + await stub.TurnOFFAsync()
            Console.WriteLine("PowerOFF requested but function not implemented");
            return false;
        }

        [Route("reqCoffee")]
        [HttpPost]
        public async Task<ActionResult<bool>> PostCoffeeReqCoffee(long id)
        {
            //not implemented - could not make persistent data in Entity Framework.
            //TODO : test logic + await stub.MakeCoffeeAsync(id,0);
            Console.WriteLine("1 coffee requested but function not implemented");

            // add a default successful coffee to fill the logs for demo purpose.
            CoffeeAction coffeeAction = new CoffeeAction();
            coffeeAction.TimeStamp = DateTime.Now.ToString();
            coffeeAction.Quantity = 1;
            _context.CoffeeActions.Add(coffeeAction);
            await _context.SaveChangesAsync();


            return false;
        }


        private bool CoffeeActionExists(long id)
        {
            return _context.CoffeeActions.Any(e => e.Id == id);
        }
    }
}
