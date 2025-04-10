
namespace Assets.Scripts.Controllers.InputSystemControl
{
    internal class InitInputSystem
    {
        public MainInputSystem InputSystem {  get;  }
        public InitInputSystem()
        {
            InputSystem = new();
            InputSystem.Enable();
        }
    }
}
