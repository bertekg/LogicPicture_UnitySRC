using UnityEngine;

[System.Serializable]
public class ProjectStory
{
    [SerializeField] public string Title;
    [TextArea(2,6)]
    [SerializeField] public string Description;
}
