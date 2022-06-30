using UnityEngine;
using TMPro;
using Newtonsoft.Json;

public class SingleLevelInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] TextAsset jsonFile;
    
    private SingleLevel singleLevel;

    void Start()
    {
        singleLevel = JsonConvert.DeserializeObject<SingleLevel>(jsonFile.text);
        buttonText.text = singleLevel.NameEnglish + "\nWidth: " + singleLevel.LevelData.WidthX + "\nHeight: " + singleLevel.LevelData.HeightY;
        ShowLevelDataInDebug();
    }
    void ShowLevelDataInDebug()
    {
        Debug.Log($"Level name (English): [{singleLevel.NameEnglish}]");
        Debug.Log($"Level name (Polish): [{singleLevel.NamePolish}]");
        Debug.Log("Count of 'TilesData': " + singleLevel.LevelData.TilesData.Count);
        Debug.Log("Count of 'ColorsDataTiles': " + singleLevel.LevelData.ColorsDataTiles.Count);
        Debug.Log("Count of 'HintsDataHorizontal': " + singleLevel.LevelData.HintsDataHorizontal.Count);
        Debug.Log("Count of 'HintsDataVertical': " + singleLevel.LevelData.HintsDataVertical.Count);
        Debug.Log("*-*-*");
    }
}
