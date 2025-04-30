using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 lastStoppedPos;
    public float stopThreshold = 0.1f;

    [Tooltip("Seconds between valid club‐hit strokes")]
    public float hitCooldown = 1f;
    float lastHitTime = -Mathf.Infinity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastStoppedPos = transform.position;
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude < stopThreshold)
            lastStoppedPos = transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log($"[BallController] Collided with {col.gameObject.name} (Tag={col.gameObject.tag})");

        if (col.gameObject.CompareTag("Club"))
        {
            // only count a hit if enough time has passed
            if (Time.time - lastHitTime >= hitCooldown)
            {
                lastStoppedPos = transform.position;
                lastHitTime = Time.time;
                GameManager.Instance.AddStroke();
                Debug.Log($"[BallController] Stroke added (cooldown ok)");
            }
            else
            {
                Debug.Log($"[BallController] Hit ignored (cooldown): {Time.time - lastHitTime:F2}s");
            }
        }
        else if (col.gameObject.CompareTag("Water"))
        {
            Debug.Log("[BallController] Hit water – asking GameManager to reset");
            GameManager.Instance.ResetBall(lastStoppedPos);
        }
    }

    public Vector3 GetLastStoppedPos() => lastStoppedPos;
}