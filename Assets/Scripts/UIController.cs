using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text strokeText;
    public TMP_Text holeText;

    [Header("Final Score UI")]
    [SerializeField] GameObject finalScorePanel;
    [SerializeField] TMP_Text finalScoreText;

    void Awake()
    {
        // ensure panel is hidden at start
        if (finalScorePanel != null)
            finalScorePanel.SetActive(false);
    }

    public void ShowFinalScorePanel(List<int> strokesPerHole)
    {
        int total = 0;
        string scoreBreakdown = "Final Score:\n";
        for (int i = 0; i < strokesPerHole.Count; i++)
        {
            int s = strokesPerHole[i];
            scoreBreakdown += $"Hole {i + 1}: {s} stroke{(s == 1 ? "" : "s")}\n";
            total += s;
        }
        scoreBreakdown += $"Total: {total} strokes";

        // set TMP text and show panel
        finalScoreText.text = scoreBreakdown;
        finalScorePanel.SetActive(true);

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