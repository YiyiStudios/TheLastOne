using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour {

    public Item item;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void select(){
        
        Debug.Log("Soy " + item.name);

        Inventory_.instance.Add(item);
    }
}
