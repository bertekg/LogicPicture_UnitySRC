using System.Collections;
using System.Collections.Generic;
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
        levelWidth.text = levelDataGame.GetLevelWidth().ToString();
        levelHeight.text = levelDataGame.GetLevelHeight().ToString();
        levelTitle.text = levelDataGame.GetTitle();
        levelDescription.text = levelDataGame.GetDescription();
        finalImage.sprite = levelDataGame.GetFinalPictureSprite();
        levelId.text = levelDataGame.GetID();
    }
}
