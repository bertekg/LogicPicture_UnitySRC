using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class SingleLevelInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] TextAsset jsonFile;
    void Start()
    {
        SingleLevel singleLevel = JsonConvert.DeserializeObject<SingleLevel>(jsonFile.text);
        buttonText.text = singleLevel.Name + "\nWidth: " + singleLevel.Width + "\nHeight: " + singleLevel.Height;
    }    
}
