using System.Collections.Generic;
using UnityEngine;

public class DebugSwitchLanguage : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons;

    private Language language;

    void Start()
    {
        language = Language.EN;
    }
    public void ChangeLanguage()
    {
        if (language == Language.EN)
        {
            language = Language.PL;
        }
        else
        {
            language = Language.EN;
        }
        foreach (GameObject button in buttons)
        {
            button.GetComponent<SingleLevelInfo>().ContentUpadate(language);
        }
    }
}
public enum Language { EN, PL};