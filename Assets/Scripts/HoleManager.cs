using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public Transform[] ballPositions;  // Empty GameObjects for ball positions at each hole
    public Transform[] playerPositions; // Empty GameObjects for player positions at each hole
    public GameObject ballPrefab;      // Prefab for the ball
    public GameObject player;
    public GameObject golfClubPrefab;  // Prefab for the golf club

    private GameObject currentGolfClub; // Reference to the currently active golf club
    private int currentHoleIndex = 0;

    void Start()
    {
        SpawnBallAtHole(currentHoleIndex);
        SpawnGolfClubAtHole(currentHoleIndex);
        MovePlayerToHole(currentHoleIndex);
    }

    public bool MoveToNextHole()
    {
        currentHoleIndex++;
        if (currentHoleIndex >= ballPositions.Length || currentHoleIndex >= playerPositions.Length)
        {
            GameManager.Instance.ShowFinalScore();
            return false; // No more holes
        }

        DeleteAllBalls(); // Delete all existing balls
        DeleteGolfClub(); // Delete the existing golf club
        SpawnBallAtHole(currentHoleIndex);
        SpawnGolfClubAtHole(currentHoleIndex);
        MovePlayerToHole(currentHoleIndex);
        return true; // Successfully moved to the next hole
    }

    void SpawnBallAtHole(int index)
    {
        // Ensure the index is valid
        if (index < 0 || index >= ballPositions.Length)
        {
            Debug.LogError("Invalid ball position index: " + index);
            return;
        }

        // Spawn a new ball at the designated position
        Instantiate(ballPrefab, ballPositions[index].position, Quaternion.identity);
        Debug.Log($"Spawned a new ball at hole {index + 1}");
    }

    void SpawnGolfClubAtHole(int index)
    {
        // Ensure the index is valid
        if (index < 0 || index >= ballPositions.Length)
        {
            Debug.LogError("Invalid ball position index: " + index);
            return;
        }

        // Destroy the current golf club if it exists
        if (currentGolfClub != null)
        {
            Destroy(currentGolfClub);
        }

        // Spawn a new golf club beside the hole (ball position)
        Vector3 clubPosition = ballPositions[index].position + Vector3.right * 1.5f; // Adjust the offset as needed
        currentGolfClub = Instantiate(golfClubPrefab, clubPosition, Quaternion.identity);
        Debug.Log($"Spawned a new golf club beside the hole at hole {index + 1}");
    }


    void MovePlayerToHole(int index)
    {
        // Ensure the index is valid
        if (index < 0 || index >= playerPositions.Length)
        {
            Debug.LogError("Invalid player position index: " + index);
            return;
        }

        // Move the player to the designated position
        player.transform.position = playerPositions[index].position;

        // Find the direction to the ball
        Vector3 directionToBall = ballPositions[index].position - player.transform.position;
        directionToBall.y = 0; // Ignore vertical differences to keep the rotation on the horizontal plane

        // Set the player's rotation to face the ball
        if (directionToBall != Vector3.zero)
        {
            player.transform.rotation = Quaternion.LookRotation(directionToBall);
        }
        else
        {
            player.transform.rotation = Quaternion.identity; // Default rotation if the direction is zero
        }

        Debug.Log($"Moved player to hole {index + 1} and set their rotation to face the ball.");
    }

    void DeleteAllBalls()
    {
        // Find all objects tagged as "Ball" and destroy them
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ball in balls)
        {
            Destroy(ball);
        }
        Debug.Log("Deleted all balls before moving to the next hole.");
    }

    void DeleteGolfClub()
    {
        // Destroy the current golf club if it exists
        if (currentGolfClub != null)
        {
            Destroy(currentGolfClub);
            Debug.Log("Deleted the golf club before moving to the next hole.");
        }
    }
}
