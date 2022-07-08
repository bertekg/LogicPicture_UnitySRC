using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour, ISaveable
{
    [SerializeField] private bool IsFinished = false;
    [SerializeField] private int ErrorCount = 0;
    public object CaptureState()
    {
        return new SaveData
        {
            isFinished = IsFinished,
            errorCount = ErrorCount
        };
    }

    public void RestoreState(object state)
    {
        SaveData saveData = (SaveData)state;

        IsFinished = saveData.isFinished;
        ErrorCount = saveData.errorCount;
    }

    [Serializable]
    private struct SaveData
    {
        public bool isFinished;
        public int errorCount;
    }
}
