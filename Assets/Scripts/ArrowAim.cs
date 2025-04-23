using UnityEngine;

[ExecuteAlways]
public class ArrowAim : MonoBehaviour
{
    [Tooltip("Tag of your ball prefab")]
    public string ballTag = "Ball";

    private Transform ball;

    void Update()
    {
        // Find the ball if we don’t have it yet
        if (ball == null)
        {
            var go = GameObject.FindWithTag(ballTag);
            if (go != null) ball = go.transform;
            else return;
        }

        // Point the arrow’s forward axis directly at the ball
        Vector3 dir = ball.position - transform.position;
        if (dir.sqrMagnitude > 0.0001f)
        {
            // Calculate the base rotation to face the ball
            Quaternion baseRotation = Quaternion.LookRotation(dir.normalized, Vector3.up);

            // Add +90 degrees rotation on the Y-axis
            Quaternion additionalRotation = Quaternion.Euler(0, 90, 0);

            // Apply the combined rotation
            transform.rotation = baseRotation * additionalRotation;
        }
    }
}
