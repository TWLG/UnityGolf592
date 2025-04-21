using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetCourse : MonoBehaviour
{


    public void ResetScene()
    {
        // Reload the current active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        print("Scene Reloaded");
        //log to unity console
        Debug.Log("Scene Reloaded");
    }
}
