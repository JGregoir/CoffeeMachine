using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Models
{
    public class MachineContext : DbContext
    {
        public MachineContext(DbContextOptions<MachineContext> options)
       : base(options)
        {
        }

        public DbSet<CoffeeAction> CoffeeActions { get; set; } = null!;
    }
}
