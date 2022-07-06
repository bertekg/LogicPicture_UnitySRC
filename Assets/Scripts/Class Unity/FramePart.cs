using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FramePart
{
    [SerializeField] byte locX;
    [SerializeField] byte locY;
    [SerializeField] TextAsset partFrame;
    [SerializeField] Image partFrameImage;
}
