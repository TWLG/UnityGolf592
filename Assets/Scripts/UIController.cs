using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using TMPro; // Add this import


public class UIController : MonoBehaviour
{
    // public Text strokeText;
    // public Text holeText;
    public TMP_Text strokeText; // Change Text to TMP_Text
    public TMP_Text holeText;

    public void ShowFinalScorePanel(List<int> strokesPerHole)
    {
        int total = 0;
        string scoreBreakdown = "Final Score:\n";

        for (int i = 0; i < strokesPerHole.Count; i++)
        {
            int strokes = strokesPerHole[i];
            scoreBreakdown += $"Hole {i + 1}: {strokes} strokes\n";
            total += strokes;
        }

        scoreBreakdown += $"Total: {total} strokes";

        Debug.Log(scoreBreakdown);
    }


    public void UpdateStrokeCount(int strokes)
    {
        strokeText.text = strokes.ToString();
    }

    public void UpdateHoleNumber(int hole)
    {
        holeText.text = hole.ToString();
    }
}
