using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 lastStoppedPos;
    [Tooltip("When below this speed we consider the ball stopped.")]
    public float stopThreshold = 0.1f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastStoppedPos = transform.position;
    }

    void FixedUpdate()
    {
        // record position when ball is effectively stopped
        if (rb.linearVelocity.magnitude < stopThreshold)
            lastStoppedPos = transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Club"))
        {
            lastStoppedPos = transform.position;
            GameManager.Instance.AddStroke();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // reset‐hazard marker
        if (other.GetComponent<ResetHazard>() != null)
        {
            ResetToLastStoppedPos();
            return;
        }

        // legacy water tag
        if (other.CompareTag("Water"))
            ResetToLastStoppedPos();
    }

    void ResetToLastStoppedPos()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = lastStoppedPos;
    }
}