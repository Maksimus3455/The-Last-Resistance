using Assets.Scripts.Controllers.InputSystemControl;
using Assets.Scripts.Controllers.MovementControl;
using Assets.Scripts.Networking.NetworkMovement;
using Fusion;
using UnityEngine;

internal class MovementComponent : NetworkBehaviour
{
    [field: SerializeField] private float RotationSpeed { get; set; }
    [field: SerializeField] private float MoveSpeed { get; set; }
    private MovementController Controller { get; set; }
    private MovementInput MovementInput { get; set; }
    private void Awake()
    {
        Controller = new();
        MovementInput = GetComponent<MovementInput>();
    }
    public override void FixedUpdateNetwork()
    {
        Controller.PlayerMove(this.gameObject, this.gameObject, MovementInput.GetDirection(), MoveSpeed);
        Controller.PlayerRotation(this.gameObject, RotationSpeed, MovementInput.GetMousePosition());
    }
}
