using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    private string filePath;

    public int bestScore = int.MaxValue;
    public string bestPlayer = "";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            filePath = Path.Combine(Application.persistentDataPath, "highscores.txt");
            LoadHighScore();
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void CheckHighScore(int strokes)
    {
        // Example logic for checking and updating high scores
        int highScore = PlayerPrefs.GetInt("HighScore", int.MaxValue);
        if (strokes < highScore)
        {
            PlayerPrefs.SetInt("HighScore", strokes);
            Debug.Log("New high score: " + strokes);
            // UIController.Instance.PromptForName(strokes); 

        }
    }

    public void SaveHighScore(string name, int score)
    {
        bestScore = score;
        bestPlayer = name;
        File.WriteAllText(filePath, $"{name}:{score}");
    }

    public void LoadHighScore()
    {
        if (File.Exists(filePath))
        {
            string[] data = File.ReadAllText(filePath).Split(':');
            bestPlayer = data[0];
            bestScore = int.Parse(data[1]);
        }
    }
}