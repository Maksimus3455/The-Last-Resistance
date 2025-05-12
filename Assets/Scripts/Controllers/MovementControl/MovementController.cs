using UnityEngine;

namespace Assets.Scripts.Controllers.MovementControl
{
    internal class MovementController
    {
        private Camera Camera { get; set; }

        public MovementController()
        {
            Camera = Camera.main;
        }
        private void MovementToTargetDirection(GameObject player, Vector2 InputDirection, Vector3 targetDirection, float moveSpeed)
        {
            InputDirection.x = targetDirection.x;
            targetDirection.y = 0;
            InputDirection.y = targetDirection.y;
            var moveDir = new Vector3(targetDirection.x, targetDirection.y, targetDirection.z);
            player.transform.position += moveSpeed * Time.deltaTime * moveDir;
        }

        public void PlayerMove(GameObject player, GameObject targetVector, Vector2 InputDirection, float moveSpeed)
        {
            if (InputDirection.y > 0)
                MovementToTargetDirection(player, InputDirection, targetVector.transform.forward, moveSpeed);

            if (InputDirection.y < 0)
                MovementToTargetDirection(player, InputDirection, -targetVector.transform.forward, moveSpeed);

            if (InputDirection.x > 0)
                MovementToTargetDirection(player, InputDirection, targetVector.transform.right, moveSpeed);

            if (InputDirection.x < 0)
                MovementToTargetDirection(player, InputDirection, -targetVector.transform.right, moveSpeed);
        }

        public void PlayerRotation(GameObject player, float rotationSpeed, Vector3 targetInput)
        {
            Ray ray = Camera.ScreenPointToRay(targetInput);
            Quaternion targetRotation;

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 rayPosition = new(hitInfo.point.x, 0, hitInfo.point.z);
                Vector3 playerPosition = new(player.transform.position.x, 0, player.transform.position.z);
                Vector3 relativPos = rayPosition - playerPosition;
                targetRotation = Quaternion.LookRotation(relativPos, Vector3.up);
                player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

        }
    }
}
