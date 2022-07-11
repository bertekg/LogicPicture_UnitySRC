using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDataGame : MonoBehaviour
{
    private static LevelDataGame instance = null;
    // Start is called before the first frame update
    private Level level;
    private Sprite finalPicture;
    private string title;
    private string description;
    private string id;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void SetLevel(Level levelGame, Sprite finalPic, string titleText, string descriptionText, string idLevel)
    {
        level = levelGame;
        finalPicture = finalPic;
        title = titleText;
        description = descriptionText;
        id = idLevel;
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
