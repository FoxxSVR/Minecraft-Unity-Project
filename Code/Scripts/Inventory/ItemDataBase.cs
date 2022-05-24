using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public struct Item
{
    public int ID;
    public string Name;
    public bool isStackable;
    public string Lowerc;

    public Item(int id, string name, bool stackable, string lowerc)
    {
        ID = id;
        Name = name;
        isStackable = stackable;
        Lowerc = lowerc;
    }
}
public class ItemDataBase : MonoBehaviour
{
    public List<Item> itemDataBase = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {
        GetDataBase("Assets/Resources/ItemData.txt");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GetDataBase(string path)
    {
        StreamReader streamReader = new StreamReader(path);
        AddItem: 
        itemDataBase.Add(new Item(
        int.Parse(streamReader.ReadLine().Replace("id: ", "")),
        streamReader.ReadLine().Replace("name: ", ""),
        bool.Parse(streamReader.ReadLine().Replace("stackable: ", "")),
        streamReader.ReadLine().Replace("lowerc: ", "")
        ));

        string a = streamReader.ReadLine();
        if (a == ",")
        { goto AddItem; }
        else if (a == ";")
        { }
        else Debug.LogError("ItemData does not end correctly");
        streamReader.Close();
    }
}
