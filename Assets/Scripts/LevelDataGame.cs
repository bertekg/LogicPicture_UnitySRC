using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDataGame : MonoBehaviour
{
    // Start is called before the first frame update
    private Level level;
    private Sprite finalPicture;
    private string title;
    private string description;
    private string id;
    public void SetLevel(Level levelGame, Sprite finalPic, string titleText, string descriptionText, string idLevel)
    {
        level = levelGame;
        finalPicture = finalPic;
        title = titleText;
        description = descriptionText;
        id = idLevel;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("LevelGame");
    }
    public byte GetLevelWidth()
    {
        return level.WidthX;
    }
    public byte GetLevelHeight()
    {
        return level.HeightY;
    }
    public Sprite GetFinalPictureSprite()
    {
        return finalPicture;
    }
    public string GetTitle()
    {
        return title;
    }
    public string GetDescription()
    {
        return description;
    }
    public string GetID()
    {
        return id;
    }
}
