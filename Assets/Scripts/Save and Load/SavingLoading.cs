using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SavingLoading : MonoBehaviour
{
    private string SavePath => $"{Application.persistentDataPath}/save.txt";
    [ContextMenu("Save")]
    private void Save()
    {
        var state = LoadFile();
        CaptureState(state);
        SaveFile(state);
    }
    private void SaveFile(object state)
    {
        using (var stream = File.Open(SavePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }
    [ContextMenu("Load")]
    private void Load()
    {
        var state = LoadFile();
        RestoreState(state);
    }
    public void SaveThisLevel(string id, int numberOfErrors)
    {
        var state = LoadFile();
        object obj1 = state[id];
        System.Type type = obj1.GetType();
        Dictionary<string, object> saveDict = (Dictionary<string, object>)obj1;
        SaveData saveData = (SaveData)saveDict["LevelSystem"];
        saveData.isFinished = true;
        saveData.errorCount = numberOfErrors;
        saveDict["LevelSystem"] = saveData;
        state[id] = saveDict;
        SaveFile(state);
    }
    private Dictionary<string, object> LoadFile()
    {
        if (!File.Exists(SavePath))
        {
            return new Dictionary<string, object>();
        }
        using(FileStream stream = File.Open(SavePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }
    }
    public void CaptureState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            state[saveable.Id] = saveable.CaptureState();
        }
    }
    public void RestoreState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            if (state.TryGetValue(saveable.Id, out object value))
            {
                saveable.RestoreState(value);
            }
        }
    }
}
