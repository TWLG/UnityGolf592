using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class VRStartMenu : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button exitButton;
    public GameObject settingsPanel; // need to find out what settings we are allowing, if not change or delete
    
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(ToggleSettings);
        exitButton.onClick.AddListener(ExitGame);
    }
    
   

    void StartGame()
    {
        //SceneManager.LoadScene("Scenes/FIRST COURSE"); // Change scene name to starting course/scene
	//LoadScene.Instance.Load_Scene("FIRST COURSE");
	Addressables.LoadSceneAsync("Assets/Scenes/FIRST COURSE.unity");
	
    }

    void ToggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    void ExitGame()
    {
        
	UnityEditor.EditorApplication.isPlaying = false;
	
	//Application.Quit();
		
		
    }
}

