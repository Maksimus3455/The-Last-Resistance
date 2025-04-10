
using Assets.Scripts.Controllers.InputSystemControl;
using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    internal class SinglePlayerMovementInput : MonoBehaviour
    {
        private CharacterController Controller { get; set; }
        private InitInputSystem InputSystem { get;  set; }
        [field: SerializeField] private float MoveSpeed { get; set; }

        private void Awake()
        {
            InputSystem = new();

            Controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            Controller.Move(GetDirection());
        }
        public Vector3 GetDirection()
        {
            var direction = InputSystem.MainInputSystem.Player.Move.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(-direction.y, 0, direction.x) * Time.deltaTime * MoveSpeed;
            return moveDirection;
        }

    }
}
