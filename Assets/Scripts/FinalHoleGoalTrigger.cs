using UnityEngine;

public class FinalHoleGoalTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.HoleCompleted(finalHole: true);
        }
    }
}