using UnityEngine;
using TMPro;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System;
using UnityEngine.UI;

public class SingleLevelInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] Image levelPicture;
    [SerializeField] TextMeshProUGUI descriptionText;
    [SerializeField] Sprite defaultPicture;

    [SerializeField] SingleSO singleSO;
    
    private Level level;

    void Start()
    {
        ChangeToResoult(true);
    }
    private void ContentUpadateEN()
    {
        ContentUpadate(singleSO.GetProjectStoryEN());
    }
    private void ContentUpadatePL()
    {
        ContentUpadate(singleSO.GetProjectStoryPL());
    }
    private void ContentUpadate(ProjectStory projectStory)
    {
        titleText.text = projectStory.Title;
        descriptionText.text = projectStory.Description;
    }
    public void ContentUpadate(Language language)
    {
        if (language == Language.EN)
        {
            ContentUpadateEN();
        }
        else if(language == Language.PL)
        {
            ContentUpadatePL();
        }
    }
    public void ChangeToResoult(bool isSolve)
    {
        if (isSolve)
        {
            levelPicture.sprite = singleSO.GetLevelPicture();
            ContentUpadateEN();
        }
        else
        {
            levelPicture.sprite = defaultPicture;
            titleText.text = "??";
            descriptionText.text = "???";
        }
    }
    public void ShowLevelDetail()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(new StringReader(singleSO.GetLevelDataXml()));
        string xmlString = xmlDocument.OuterXml;
        using (StringReader read = new StringReader(xmlString))
        {
            Type outType = typeof(Level);

            XmlSerializer serializer = new XmlSerializer(outType);
            using (XmlReader reader = new XmlTextReader(read))
            {
                level = (Level)serializer.Deserialize(reader);
                reader.Close();
            }
            read.Close();
        }
        Debug.Log("Count of 'TilesData': " + level.TilesData.Count);
        Debug.Log("Count of 'ColorsDataTiles': " + level.ColorsDataTiles.Count);
        Debug.Log("Count of 'HintsDataHorizontal': " + level.HintsDataHorizontal.Count);
        Debug.Log("Count of 'HintsDataVertical': " + level.HintsDataVertical.Count);
        Debug.Log("*-*-*");
    }
    public void LoadLevel()
    {
        LevelDataGame levelDataGame = FindObjectOfType<LevelDataGame>();
        SaveableEntity saveableEntity = GetComponent<SaveableEntity>();
        levelDataGame.SetLevel(level, levelPicture.sprite, titleText.text, descriptionText.text, saveableEntity.Id);
    }
}
