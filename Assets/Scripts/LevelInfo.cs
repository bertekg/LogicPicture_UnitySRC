using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelWidth; 
    [SerializeField] TextMeshProUGUI levelHeight;
    [SerializeField] TextMeshProUGUI levelTitle;
    [SerializeField] TextMeshProUGUI levelDescription;
    [SerializeField] Image finalImage;
    [SerializeField] TextMeshProUGUI levelId;
    void Start()
    {
        LevelDataGame levelDataGame = FindObjectOfType<LevelDataGame>();
        levelWidth.text = "Width: " + levelDataGame.GetLevelWidth().ToString();
        levelHeight.text = "Height: " + levelDataGame.GetLevelHeight().ToString();
        levelTitle.text = "Title: " + levelDataGame.GetTitle();
        levelDescription.text = "Description:\n" + levelDataGame.GetDescription();
        finalImage.sprite = levelDataGame.GetFinalPictureSprite();
        levelId.text = "ID:\n" + levelDataGame.GetID();
    }
}
