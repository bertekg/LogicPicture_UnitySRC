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
        buttonText.text = singleLevel.ProjectStoryEN.Title + "\nWidth: " + singleLevel.LevelData.WidthX +
            "\nHeight: " + singleLevel.LevelData.HeightY + "\nDescription:\n" + singleLevel.ProjectStoryEN.Description;
        ShowLevelDataInDebug();
    }
    void ShowLevelDataInDebug()
    {
        Debug.Log($"Project Title (English): [{singleLevel.ProjectStoryEN.Title}]");
        Debug.Log($"Project Description (English): [{singleLevel.ProjectStoryEN.Description}]");
        Debug.Log($"Project Title (Polish): [{singleLevel.ProjectStoryPL.Title}]");
        Debug.Log($"Project Description (Polish): [{singleLevel.ProjectStoryPL.Description}]");
        Debug.Log("Count of 'TilesData': " + singleLevel.LevelData.TilesData.Count);
        Debug.Log("Count of 'ColorsDataTiles': " + singleLevel.LevelData.ColorsDataTiles.Count);
        Debug.Log("Count of 'HintsDataHorizontal': " + singleLevel.LevelData.HintsDataHorizontal.Count);
        Debug.Log("Count of 'HintsDataVertical': " + singleLevel.LevelData.HintsDataVertical.Count);
        Debug.Log("*-*-*");
    }
}
