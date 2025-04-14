using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public HoleManager holeManager;
    public UIController ui;

    public int strokes = 0;
    public int totalHoles;

    public List<int> strokesPerHole = new List<int>();

    private void Awake() => Instance = this;

    public void AddStroke() => strokes++;

    public void HoleCompleted(bool finalHole = false)
    {
        strokesPerHole.Add(strokes);

        if (finalHole)
        {
            ShowFinalScore();
        }
        else
        {
            strokes = 0; // reset for next hole
            holeManager.MoveToNextHole();
        }
    }

    public void ShowFinalScore()
    {
        ui.ShowFinalScorePanel(strokesPerHole); // pass total strokes
        HighScoreManager.Instance.CheckHighScore(GetTotalStrokes());
    }

    public int GetTotalStrokes()
    {
        int total = 0;
        foreach (int s in strokesPerHole)
            total += s;
        return total;
    }
}
