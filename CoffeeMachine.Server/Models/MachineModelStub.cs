using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoffeeMachine.Server.Models
{

    public enum State
    {
        Okay = 0,
        Alert = 1
    }
    public struct CoffeeCreationOptions
    {
        public int NumEspressoShots { get; set; }
        public bool AddMilk { get; set; }
    }
    public interface ICoffeeMachine
    {
        bool IsOn { get; }
        bool IsMakingCoffee { get; }
        State WaterLevelState { get; }
        State BeanFeedState { get; }
        State WasteCoffeeState { get; }
        State WaterTrayState { get; }
        Task TurnOnAsync();
        Task TurnOffAsync();
        Task MakeCoffeeAsync(CoffeeCreationOptions options);
    }
    public class MachineModelStub
    {

        public class CoffeeMachineStub : ICoffeeMachine
        {
            public bool IsOn { get; private set; }
            public bool IsMakingCoffee { get; private set; }
            public State WaterLevelState { get; private set; }
            public State BeanFeedState { get; private set; }
            public State WasteCoffeeState { get; private set; }
            public State WaterTrayState { get; private set; }
            private bool IsInAlertState => WaterLevelState == State.Alert
            || BeanFeedState == State.Alert
            || WasteCoffeeState == State.Alert
            || WaterTrayState == State.Alert;
            private readonly Random _randomStateGenerator;
            public CoffeeMachineStub()
            {
                _randomStateGenerator = new Random();
            }
            public async Task TurnOnAsync()
            {
                if (IsOn)
                    throw new InvalidOperationException("Invalid state");
                // Generate sample state for testing
                WaterLevelState = GetRandomState();
                BeanFeedState = GetRandomState();
                WasteCoffeeState = GetRandomState();
                WaterTrayState = GetRandomState();

                // [Machine turned on]
                IsOn = true;
            }
            public async Task TurnOffAsync()
            {
                if (!IsOn || IsMakingCoffee)
                    throw new InvalidOperationException("Invalid state");
                // [Machine turned off]
                IsOn = false;
            }
            public async Task MakeCoffeeAsync(CoffeeCreationOptions options)
            {
                if (!IsOn || IsMakingCoffee || IsInAlertState)
                    throw new InvalidOperationException("Invalid state");
                IsMakingCoffee = true;
                // [Make the coffee]
                Thread.Sleep(10000);
                IsMakingCoffee = false;
            }
            // Randomly create a state for testing. This can be replaced as  required.
            private State GetRandomState() => _randomStateGenerator.Next(1, 10)
            == 10 ? State.Alert : State.Okay;
        }
    }
}
