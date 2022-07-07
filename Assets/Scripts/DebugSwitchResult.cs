using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSwitchResult : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons;
    bool isVisable = true;
    public void ChangeResult()
    {
        isVisable = !isVisable;
        foreach (GameObject button in buttons)
        {
            button.GetComponent<SingleLevelInfo>().ChangeToResoult(isVisable);
        }
    }
}