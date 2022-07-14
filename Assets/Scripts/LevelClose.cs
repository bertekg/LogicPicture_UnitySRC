using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class LevelClose : MonoBehaviour
{
    [SerializeField] TMP_InputField debugNumberOfErrors;
    public void CloseLevelNoSolve()
    {
        DestroyLevelData();
        SceneManager.LoadScene("SingleLevelSelection");
    }
    public void CloseLevelSolveWithErrors()
    {
        int numberOfErrors = Convert.ToInt16(debugNumberOfErrors.text);
        Debug.Log(numberOfErrors);
        LevelDataGame levelDataGame = FindObjectOfType<LevelDataGame>();
        SavingLoading savingLoading = new SavingLoading();
        savingLoading.SaveThisLevel(levelDataGame.GetID(), numberOfErrors);
        DestroyLevelData();

        SceneManager.LoadScene("SingleLevelSelection");
    }
    private void DestroyLevelData()
    {
        Destroy(GameObject.Find("LevelDataToLoad"));
    }
}
