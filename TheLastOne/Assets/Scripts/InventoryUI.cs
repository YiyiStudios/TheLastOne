using UnityEngine;
using UnityEngine.UI;

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

        UsarItems();
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

    void UsarItems()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (inventory.items.Count >= 1)
                inventory.items[0].Use();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (inventory.items.Count >= 2)
                inventory.items[1].Use();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (inventory.items.Count >= 3)
                inventory.items[2].Use();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (inventory.items.Count >= 4)
                inventory.items[3].Use();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (inventory.items.Count >= 5)
                inventory.items[4].Use();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            if (inventory.items.Count >= 6)
                inventory.items[5].Use();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (inventory.items.Count >= 7)
                inventory.items[6].Use();
        }

    }
}
