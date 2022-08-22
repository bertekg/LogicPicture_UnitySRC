using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPanel : MonoBehaviour
{
    [SerializeField] GameObject finalPanel;
    [SerializeField] GameObject mainPanel;
    public void ShowFinalPanel()
    {
        bool opositPanelState = !finalPanel.activeSelf;
        mainPanel.SetActive(!opositPanelState);
        finalPanel.SetActive(opositPanelState);
    }
}
