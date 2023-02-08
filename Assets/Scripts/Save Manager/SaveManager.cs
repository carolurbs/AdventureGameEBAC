
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class SaveManager : Singleton<SaveManager>
{
    private SaveSetup _saveSetup;
    protected override void Awake()
    {
        base.Awake();
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 2;
        _saveSetup.playerName = "Carol";
    }
   
    
    #region SAVE
    private void Save()
    {
 
        string setupToJson=JsonUtility.ToJson(_saveSetup, true);
        Debug.Log(setupToJson);
        SaveFile(setupToJson);
    }
    public void SaveLastLevel(int level)
    {
        _saveSetup.lastLevel=level;
        Save();
    }
    public void SaveName(string text)
    {
        _saveSetup.playerName=text;
        Save();
    }
    #endregion
    [NaughtyAttributes.Button]
    private void SaveFile(string json)
    {
        string path = Application.dataPath + "/save.txt";
        File.WriteAllText(path, json);  
    }
    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }
}
[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;

}
