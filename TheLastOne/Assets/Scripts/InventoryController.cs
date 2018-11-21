using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour {
   
    public static InventoryController instance;
    void Awake ()
    {
        if (instance != null)
            return;
        
        instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 5;
    public List<Item> items = new List<Item>();

    public void Add (Item item)
    {
        if (items.Count >= space)
        {
            Debug.Log("No hay espacio disponible.");
            return;
        }

        items.Add(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
    public void Remove (Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
