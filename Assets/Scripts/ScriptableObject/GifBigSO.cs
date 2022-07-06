using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "4 Gif Big Project", fileName ="New Gif Big")]
public class GifBigSO : ScriptableObject
{
    [SerializeField] ProjectStory storyEN;
    [SerializeField] ProjectStory storyPL;
    [SerializeField] List<BigFrame> Frames;
}
