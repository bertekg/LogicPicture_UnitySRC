using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ColorMarkClick : MonoBehaviour
{
    [SerializeField] byte ColorSelectId;
    [SerializeField] bool IsMark;
    public void SetColorSelectId(byte newId)
    {
        ColorSelectId = newId;
    }
    public byte GetColorSelectId()
    {
        return ColorSelectId;
    }
    public void SetIsMark(bool newIsMark)
    {
        IsMark = newIsMark;
    }
    public bool GetIsMark()
    {
        return IsMark;
    }
    public void SetFull(string key)
    {
        if (key == "Blank")
        {
            IsMark = true;
            ColorSelectId = 0;
        }
        else
        {
            IsMark = false;
            ColorSelectId = Convert.ToByte(key.Substring(6));
        }
        Debug.Log(key + "," + IsMark.ToString() + "," + ColorSelectId.ToString());
        UpdateButtonView(key);
    }

    private void UpdateButtonView(string buttonName)
    {
        SetColors[] arraySetColors = FindObjectsOfType<SetColors>();
        foreach (var setColor in arraySetColors)
        {
            if (buttonName == setColor.name)
            {
                setColor.SetColorFrame(Color.red);
            }
            else
            {
                setColor.SetColorFrame(Color.white);
            }
        }
    }
}
