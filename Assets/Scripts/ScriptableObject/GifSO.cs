using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "3 Gif Project", fileName = "New Gif")]
public class GifSO : ScriptableObject
{
    [SerializeField] ProjectStory storyEN;
    [SerializeField] ProjectStory storyPL;
    [SerializeField] List<Frame> frames;
}
