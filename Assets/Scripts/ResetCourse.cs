using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ResetCourse : MonoBehaviour
{


    public void ResetScene()
    {
        // Reload the current active scene. Do the below for running it in a full build
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        print("Scene Reloaded");
        Addressables.LoadSceneAsync("Assets/Scenes/FIRST COURSE.unity", UnityEngine.SceneManagement.LoadSceneMode.Single);
        //log to unity console
        Debug.Log("Scene Reloaded");
    }
}
