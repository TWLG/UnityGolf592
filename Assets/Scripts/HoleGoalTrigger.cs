using UnityEngine;

public class HoleGoalTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log($"Ball entered the hole: {gameObject.name}");

            GameManager.Instance.AddStroke(); // optional
            GameManager.Instance.AddHoleCount(); // optional
            GameManager.Instance.HoleCompleted();
        }
    }
}
