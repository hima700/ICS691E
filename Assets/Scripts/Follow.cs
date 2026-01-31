using UnityEngine;
 
public class Follow : MonoBehaviour
{
    public Transform player;        // The player to follow
    public Vector3 offset;          // Distance from player
    public float smoothSpeed = 5f;  // Follow speed
 
    void FixedUpdate()
    {
        // Calculate the position we want to be at
        Vector3 desiredPosition = player.position + offset;
 
        // Smoothly move from current position to desired position
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.fixedDeltaTime
        );
 
        // Optional: make the camera look at the player
        transform.LookAt(player);
    }
}