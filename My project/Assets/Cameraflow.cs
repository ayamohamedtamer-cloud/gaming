using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cameraflow : MonoBehaviour
{
    public Transform target;        // The object (player) the camera will follow
    public float cameraSpeed = 0.125f;  // Controls how quickly the camera follows the player
    public float minX, maxX;        // Camera horizontal limits
    public float minY, maxY;        // Camera vertical limits

    private void FixedUpdate()
    {
        if (target != null)
        {
            // Interpolates (smoothly moves) camera between its current position and the player's position
            Vector2 newPosition = Vector2.Lerp(transform.position, target.position, cameraSpeed * Time.deltaTime);

            // Clamp limits so camera doesn’t go beyond the level borders
            float clampX = Mathf.Clamp(newPosition.x, minX, maxX);
            float clampY = Mathf.Clamp(newPosition.y, minY, maxY);

            // Apply the new clamped position with fixed Z (so the camera stays behind the scene)
            transform.position = new Vector3(clampX, clampY, -10f);
        }
    }
}