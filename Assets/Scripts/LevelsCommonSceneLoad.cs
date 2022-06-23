using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsCommonSceneLoad : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
