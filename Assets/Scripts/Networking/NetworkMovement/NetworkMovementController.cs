using Assets.Scripts.Controllers.MovementControl;
using Fusion;
using UnityEngine;

namespace Assets.Scripts.Networking.NetworkMovement
{
    public sealed class NetworkMovementController : NetworkBehaviour
    {
        private MovementController _movement;
        private NetworkInputReceiver _inputReceiver;

        public override void Spawned()
        {
            _movement = new();
            _inputReceiver = GetComponent<NetworkInputReceiver>();
        }

        public override void FixedUpdateNetwork()
        {
            _movement.PlayerMove(this.gameObject, _inputReceiver.MovementDir, Runner.DeltaTime);
        }

    }
}
