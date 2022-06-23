using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoad : MonoBehaviour
{
    public void LoadSingleLevelSelectionMenu()
    {
        SceneManager.LoadScene("SingleLevelSelection");
    }
    public void LoadMultipleLevelSelectionMenu()
    {
        Debug.Log("TODO! Add Multiple Level Selection logic");
    }
    public void LoadOpionMenu()
    {
        Debug.Log("TODO! Add Option Menu logic");
    }
    public void QuiteGame()
    {
        Debug.Log("Game will close soon!");
        Application.Quit();
    }
}
