using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "2 Big Project", fileName = "New Big")]
public class BigSO : ScriptableObject
{
    [SerializeField] ProjectStory storyEN;
    [SerializeField] ProjectStory storyPL;
    [SerializeField] List<Part> parts;
    [SerializeField] Image fullImage;
}
