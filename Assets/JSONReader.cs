using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : BaseSingleton<JSONReader>
{
    public TextAsset textJSON;

    [System.Serializable]
    public class NameList
    {
        public string[] names;
    }

    public NameList myPlayerList = new NameList();
    
    void Awake()
    {
        myPlayerList = JsonUtility.FromJson<NameList>(textJSON.text);
    }

    public string GetRandomName()
    {
        return myPlayerList.names[Random.Range(0,myPlayerList.names.Length-1)];
    }
}
