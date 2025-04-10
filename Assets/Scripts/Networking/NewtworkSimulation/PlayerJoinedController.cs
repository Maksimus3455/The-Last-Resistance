﻿using Fusion;

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
            if (!Runner.IsServer)
                return;

            _playerSpawner.SpawnPlayer(playerRef);
        }

        void IPlayerLeft.PlayerLeft(PlayerRef playerRef)
        {
            if (!Runner.IsServer)
                return;

            _playerDespawner.DespawnPlayer(playerRef);
        }
    }
}
