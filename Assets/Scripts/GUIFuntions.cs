using TMPro;
using UnityEngine;

public class GUIFuntions : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    
    private int pressCounter = 0;

    public void HelloWorldButton_Click()
    {
        pressCounter++;
        text.text = $"You press button {pressCounter} times!";
    }
}
