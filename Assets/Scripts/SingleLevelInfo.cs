using UnityEngine;
using TMPro;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System;

public class SingleLevelInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] TextAsset jsonFile;
    
    private SingleLevel singleLevel;

    void Start()
    {
        //singleLevel = JsonConvert.DeserializeObject<SingleLevel>(jsonFile.text);
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(new StringReader(jsonFile.text));
        string xmlString = xmlDocument.OuterXml;
        using (StringReader read = new StringReader(xmlString))
        {
            Type outType = typeof(SingleLevel);

            XmlSerializer serializer = new XmlSerializer(outType);
            using (XmlReader reader = new XmlTextReader(read))
            {
                singleLevel = (SingleLevel)serializer.Deserialize(reader);
                reader.Close();
            }
            read.Close();
        }
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
