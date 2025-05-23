using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public HoleManager holeManager;
    public UIController ui;
    public GameObject ballPrefab;        // assign your ball prefab here

    public int strokes = 0;
    public int totalHoles = 1; // Start at 1 instead of 0

    public List<int> strokesPerHole = new List<int>();

    private void Awake() => Instance = this;

    private void Start()
    {
        // Update the UI to reflect the initial hole number
        ui.UpdateHoleNumber(totalHoles);
    }

    public void AddStroke()
    {
        strokes++;
        ui.UpdateStrokeCount(strokes); // Update the stroke count in the UI
    }

    public void AddHoleCount()
    {
        totalHoles++;
        ui.UpdateHoleNumber(totalHoles); // Update the hole number in the UI
    }

    public void HoleCompleted(bool finalHole = false)
    {
        strokesPerHole.Add(strokes);

        if (finalHole || !holeManager.MoveToNextHole())
        {
            ShowFinalScore();
        }
        else
        {
            strokes = 0; // Reset for the next hole
            ui.UpdateStrokeCount(strokes); // Update the stroke count in the UI
            AddHoleCount();
        }
    }

    public void ShowFinalScore()
    {
        Debug.Log("Game Over! Final Score: " + GetTotalStrokes());
        // show UI panel instead of only logging
        ui.ShowFinalScorePanel(strokesPerHole);  // ↳ Assets/Scripts/UIController.cs
    }

    public int GetTotalStrokes()
    {
        int total = 0;
        foreach (int s in strokesPerHole)
            total += s;
        return total;
    }

    /// <summary>
    /// Call this from the Inspector context menu to test adding a stroke.
    /// </summary>
    [ContextMenu("Test Add Stroke")]
    void TestAddStroke()
    {
        AddStroke();
    }

    /// <summary>
    /// Called by BallController when it hits water.
    /// Destroys the current ball and respawns a new one at lastStoppedPos.
    /// </summary>
    public void ResetBall(Vector3 lastStoppedPos)
    {

        var oldBall = GameObject.FindWithTag("Ball");
        if (oldBall != null) Destroy(oldBall);

        var newBall = Instantiate(ballPrefab, lastStoppedPos, Quaternion.identity);
        newBall.tag = "Ball";
        Debug.Log($"[GameManager] Ball respawned at {lastStoppedPos}");
    }
}