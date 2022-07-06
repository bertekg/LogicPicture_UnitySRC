using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Part
{
    [SerializeField] byte locX;
    [SerializeField] byte locY;
    [SerializeField] TextAsset part;
    [SerializeField] Image partImage;
}
