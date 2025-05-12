using Assets.Scripts.Controllers.InputSystemControl;
using UnityEngine;

namespace Assets.Scripts.Networking.NetworkMovement
{
    internal class MovementInput : MonoBehaviour
    {
        private InitInputSystem InputSystem { get; set; }

        private void Awake()
        {
            InputSystem = new();
        }
        public Vector2 GetDirection()
        {
            Vector2 direction = InputSystem.MainInputSystem.Player.Move.ReadValue<Vector2>();
            return direction;
        }

        public Vector3 GetPosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            return mousePosition;
        }
    }
}
