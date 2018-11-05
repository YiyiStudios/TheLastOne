using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_ : MonoBehaviour {

    public static Inventory_ instance;

    void Awake ()
    {
        if (instance != null)
            return;
        
        instance = this;
    }

    public List<Item> items = new List<Item>();

    public void Add (Item item)
    {
        items.Add(item);
    }

    public void Remove (Item item)
    {
        items.Remove(item);
    }



}
