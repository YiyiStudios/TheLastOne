using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;

    InventoryController inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {

        inventory = InventoryController.instance;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();


           for (int i = 0; i < inventory.items.Count; i++)
           {
               slots[i].AddItem(inventory.items[i]);
           }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
