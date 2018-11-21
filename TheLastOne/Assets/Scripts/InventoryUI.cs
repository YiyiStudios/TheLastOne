using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;

    InventoryController inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {

        inventory = InventoryController.instance;
        inventory.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();

        if (inventory.items.Count != 0)
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                slots[i].AddItem(inventory.items[i]);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
