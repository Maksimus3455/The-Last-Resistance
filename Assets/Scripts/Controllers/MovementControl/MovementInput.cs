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

        public Vector3 GetDirection()
        {
            Vector2 dir = InputSystem.MainInputSystem.Player.Move.ReadValue<Vector2>();
            Vector3 direction = new Vector3(dir.x, dir.y, 0);
            return direction;
        }

        public Vector3 GetMousePosition()
        {
            Vector3 mousePosition = Input.mousePosition;
            return mousePosition;
        }
    }
}
