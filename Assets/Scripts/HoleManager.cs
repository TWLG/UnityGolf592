using UnityEngine;
public class HoleManager : MonoBehaviour
{
    public Transform[] teePoints;     // Drag all tee GameObjects in order
    public GameObject ball;
    private int currentHoleIndex = 0;

    void Start()
    {
        MoveToHole(currentHoleIndex);
    }

    public void MoveToNextHole()
    {
        currentHoleIndex++;
        if (currentHoleIndex >= teePoints.Length)
        {
            GameManager.Instance.ShowFinalScore();
            return;
        }

        MoveToHole(currentHoleIndex);
    }

    void MoveToHole(int index)
    {
        ball.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.position = teePoints[index].position;
    }
}
