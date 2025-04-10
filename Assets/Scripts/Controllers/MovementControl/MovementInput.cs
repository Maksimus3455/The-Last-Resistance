using Assets.Scripts.Controllers.InputSystemControl;
using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    internal class MovementInput : MonoBehaviour
    {
        [field: SerializeField] private float MoveSpeed {  get; set; }  
        InitInputSystem InputSystem { get; set; }
        MovementController Controller { get; set; }
        private void Awake()
        {
            InputSystem = new();
            Controller = new();
        }
        private void FixedUpdate()
        {
            Controller.PlayerMove(this.gameObject, GetDirection(), MoveSpeed);
        }

        public Vector2 GetDirection()
        {
            var direction = InputSystem.MainInputSystem.Player.Move.ReadValue<Vector2>();
            return direction;
        }
    }
}
