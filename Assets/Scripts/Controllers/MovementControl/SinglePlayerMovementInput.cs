
using Assets.Scripts.Controllers.InputSystemControl;
using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    internal class SinglePlayerMovementInput : MonoBehaviour
    {
        [field: SerializeField] private float MoveSpeed { get; set; }
        [field: SerializeField] private float RotationSpeed { get; set; }
        private InitInputSystem InputSystem { get;  set; }
        private MovementController Controller { get; set; }
        private void Awake()
        {
            InputSystem = new();
            Controller = new();
        }

        private void FixedUpdate()
        {

            Controller.PlayerMove(this.gameObject, this.gameObject, InputSystem.MainInputSystem.Player.Move.ReadValue<Vector2>(), MoveSpeed);
            Controller.PlayerRotation(this.gameObject, RotationSpeed);

        }

    }
}
