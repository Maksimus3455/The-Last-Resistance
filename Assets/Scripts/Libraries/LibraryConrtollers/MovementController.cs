using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LibraryConrtollers
{
    internal class MovementComponent
    {
        private Camera Camera { get; set; } = Camera.main;
        private void Movement(GameObject player, Vector2 InputDirection, Vector3 cameraDirection, float moveSpeed)
        {
            InputDirection.x = cameraDirection.x;
            cameraDirection.y = 0;
            InputDirection.y = cameraDirection.y;
            var moveDir = new Vector3(cameraDirection.x, cameraDirection.y, cameraDirection.z);
            var currentRot = player.transform.rotation;
            var newRot = Quaternion.LookRotation(Vector3.Normalize(moveDir));
            player.transform.rotation = Quaternion.Lerp(currentRot, newRot, Time.deltaTime * 20);
            player.transform.position += moveSpeed * Time.deltaTime * moveDir;
        }

        public void PlayerMove(GameObject player, Vector2 InputDirection, float moveSpeed)
        {
            if (InputDirection.y > 0)
                Movement(player, InputDirection, Camera.transform.forward, moveSpeed);

            if (InputDirection.y < 0)
                Movement(player, InputDirection, -Camera.transform.forward, moveSpeed);

            if (InputDirection.x > 0)
                Movement(player, InputDirection, Camera.transform.right, moveSpeed);

            if (InputDirection.x < 0)
                Movement(player, InputDirection, -Camera.transform.right, moveSpeed);
        }
    }
}
