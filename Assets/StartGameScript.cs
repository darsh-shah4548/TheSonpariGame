using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    public string sceneToLoad = "SampleScene"; // Change this to your actual game scene name

    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
