using UnityEngine;

public class HoleGoalTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.AddStroke(); // optional
            GameManager.Instance.HoleCompleted();
        }
    }
}
