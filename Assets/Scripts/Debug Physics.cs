// Attach this to the golf ball
using UnityEngine;

public class DebugPhysics : MonoBehaviour
{
    private Rigidbody rb;
    public float stopThreshold = 0.1f; // Threshold for stopping the ball

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Log the current velocity and angular velocity
        //Debug.Log($"Velocity: {rb.linearVelocity}, Angular Velocity: {rb.angularVelocity}");

        // Check if the ball's velocity is below the threshold
        if (rb.linearVelocity.magnitude < stopThreshold && rb.angularVelocity.magnitude < stopThreshold)
        {
            rb.linearVelocity = Vector3.zero; // Stop linear movement
            rb.angularVelocity = Vector3.zero; // Stop rotation
        }
    }
}