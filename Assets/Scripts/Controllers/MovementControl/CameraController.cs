using Fusion_Network_Library;
using Unity.Cinemachine;
using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    public sealed class CameraController : MonoBehaviour
    {
        [field: SerializeField] private PlayerSpawner Spawner { get; set; }
        public CinemachineCamera CameraFollow {  get; set; }

        private void Awake()
        {
            CameraFollow = GetComponent<CinemachineCamera>();
            Spawner.OnFollowTargetSpawned += GetFollowTarget;
        }

        private void GetFollowTarget()
        {
            GameObject followTarget = GameObject.FindGameObjectWithTag("Player");
            CameraFollow.Target.TrackingTarget = followTarget.transform;
        }
    }
}
