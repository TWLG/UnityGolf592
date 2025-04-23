using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class VRStartMenu : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;
    public GameObject settingsPanel; // need to find out what settings we are allowing, if not change or delete
    
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
       
        exitButton.onClick.AddListener(ExitGame);
    }
    
   

    void StartGame()
    {
        //SceneManager.LoadScene("Scenes/FIRST COURSE"); // Change scene name to starting course/scene
	//LoadScene.Instance.Load_Scene("FIRST COURSE");
	Addressables.LoadSceneAsync("Assets/Scenes/FIRST COURSE.unity");
	
    }

    

    //   void ExitGame()
    //   {

    //UnityEditor.EditorApplication.isPlaying = false;

    ////Application.Quit();


    //   }
    void ExitGame()
    {
        Debug.Log("Exit button clicked");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}

