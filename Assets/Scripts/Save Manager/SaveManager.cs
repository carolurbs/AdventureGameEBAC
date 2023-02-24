
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Clothes;
public class SaveManager : Singleton<SaveManager>
{
   [SerializeField] private SaveSetup _saveSetup;
    private string _path = Application.streamingAssetsPath + "/save.txt";
    public int lastLevel;
    public  Action<SaveSetup> FileLoaded; 
     public SaveSetup Setup
    {
        get { return _saveSetup; }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        CreateNewSave();
    }
    private void CreateNewSave()
    {
        _saveSetup = new SaveSetup();
        _saveSetup.lastLevel = 0;
        _saveSetup.playerName = "Carol";
    }
    private void Start()
    {
        Invoke(nameof(Load),.1f);
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
        SaveItens();
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
        string path = Application.persistentDataPath + "/save.txt";
        File.WriteAllText(path, json);  
    }
    [NaughtyAttributes.Button]

    private void Load( )
    {
        string fileLoaded = "";
        if (File.Exists(_path))
        {
        fileLoaded = File.ReadAllText(_path);
        _saveSetup=JsonUtility.FromJson<SaveSetup>(fileLoaded);
        lastLevel = _saveSetup.lastLevel;  
        
        }
        else
        {
            CreateNewSave();
            Save();
        }
        FileLoaded.Invoke(_saveSetup);
}
    [NaughtyAttributes.Button]
    private void SaveLevelOne()
    {
        SaveLastLevel(1);
    }
    public void SaveItens()
    {
        _saveSetup.coins = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.COIN).soInt.value ;
        _saveSetup.health = Itens.ItemManager.Instance.GetItemByType(Itens.ItemType.LIFE_PACK).soInt.value;
        _saveSetup.activeCloth = Player.Instance.activeClothType;
        
        Save();
    }
public void SaveCheckPoints(int key)
{
        _saveSetup.key = key;
        Debug.Log(_saveSetup.key);
        Save();
}
}
[System.Serializable]
public class SaveSetup
{
    public int lastLevel;
    public string playerName;
    public float coins;
    public float health;
    public int key;
    public ClothType? activeCloth = null;

}
