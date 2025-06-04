using Fusion;

namespace Fusion_Network_Library
{
    public sealed class PlayerJoinedController : SimulationBehaviour, IPlayerJoined, IPlayerLeft
    {
        private PlayerSpawner _playerSpawner;
        private PlayerDespawner _playerDespawner;

        private void Awake()
        {
            _playerSpawner = GetComponent<PlayerSpawner>();
            _playerDespawner = GetComponent<PlayerDespawner>();
        }

        void IPlayerJoined.PlayerJoined(PlayerRef playerRef)
        {
            if (playerRef == Runner.LocalPlayer)
                _playerSpawner.SpawnPlayer(playerRef);
        }

        void IPlayerLeft.PlayerLeft(PlayerRef playerRef)
        {
            if (playerRef == Runner.LocalPlayer)
                _playerDespawner.DespawnPlayer(playerRef);
        }
    }
}
