using Assets.Scripts.Controllers.InputSystemControl;
using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    internal class MovementInput : MonoBehaviour
    {
        InitInputSystem InputSystem { get; set; }
        private void Awake()
        {
            InputSystem = new();
        }
        private void OnEnable()
        {
            
        }
        private void OnDisable()
        {
            
        }

        public Vector2 GetDirection()
        {
            Vector2 direction = InputSystem.MainInputSystem.Player.Move.ReadValue<Vector2>();
            return direction;
        }
    }
}
