using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColors : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image frameImage;
    [SerializeField] UnityEngine.UI.Image insideImage;
    public void SetColorFrame(Color color)
    {
        frameImage.color = color;
    }
    public Color GetColorFrame()
    {
        return frameImage.color;
    }
    public void SetColorInside(Color color)
    {
        insideImage.color = color;
    }
    public Color GetColorInside()
    {
        return insideImage.color;
    }
}
