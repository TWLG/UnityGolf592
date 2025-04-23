using UnityEngine;

public class ArrowOrbit : MonoBehaviour
{
    [Tooltip("Who to orbit around")]
    public Transform player;
    [Tooltip("Tag of your ball prefab")]
    public string ballTag = "Ball";
    [Tooltip("Orbit radius in world units")]
    public float radius = 1f; // Reduced radius to bring the arrow closer to the player
    [Tooltip("Stop rotating/orbiting until ball exists")]
    public bool waitForBall = true;
    [Tooltip("Height offset for the arrow")]
    public float heightOffset = .5f; // Adjust height as needed

    private Transform ball;
    private Renderer arrowRenderer;

    void Start()
    {
        // Cache the Renderer component for toggling visibility
        arrowRenderer = GetComponent<Renderer>();
        if (arrowRenderer == null)
        {
            Debug.LogError("ArrowOrbit: No Renderer component found on the arrow!");
        }
    }

    void Update()
    {
        // 1) Find the ball if we don’t have it yet
        if (ball == null)
        {
            GameObject go = GameObject.FindWithTag(ballTag);
            if (go != null)
                ball = go.transform;
            else if (waitForBall)
                return; // Skip all until ball spawns
        }

        // 2) Check if the ball is inside the orbit radius
        float distanceToPlayer = Vector3.Distance(ball.position, player.position);
        if (arrowRenderer != null)
        {
            arrowRenderer.enabled = distanceToPlayer > radius; // Hide arrow if ball is inside the circle
        }

        // 3) Position the arrow closer to the player
        Vector3 directionToBall = (ball.position - player.position).normalized; // Direction from player to ball
        Vector3 arrowPosition = player.position + directionToBall * radius + Vector3.up * heightOffset;
        transform.position = arrowPosition;

        // 4) Point the arrow toward the ball
        directionToBall.y = 0; // Ignore vertical differences
        if (directionToBall.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.LookRotation(directionToBall, Vector3.up);
        }
    }
}
