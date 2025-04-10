using Assets.Scripts.Controllers.MovementControl;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Networking.NetworkMovement
{
    public sealed class NetworkMovementController : NetworkBehaviour
    {
        [SerializeField] private MovementController _movement;
        [SerializeField] private NetworkInputReceiver _inputReceiver;

        public override void FixedUpdateNetwork()
        {
            _movement.PlayerMove(this.gameObject, _inputReceiver.MovementDir, Runner.DeltaTime);
        }

    }
}
