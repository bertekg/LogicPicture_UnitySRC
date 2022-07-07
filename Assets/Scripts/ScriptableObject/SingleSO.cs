using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "1 Single Project", fileName = "New Single")]
public class SingleSO : ScriptableObject
{
    [SerializeField] ProjectStory storyEN;
    [SerializeField] ProjectStory storyPL;
    [SerializeField] TextAsset level;
    [SerializeField] Sprite sprite;
    
    public ProjectStory GetProjectStoryEN()
    {
        return storyEN;
    }
    public ProjectStory GetProjectStoryPL()
    {
        return storyPL;
    }
    public string GetLevelDataXml()
    {
        return level.text;
    }
    public Sprite GetLevelPicture()
    {
        return sprite;
    }
}
