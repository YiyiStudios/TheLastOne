﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectItem : MonoBehaviour {

    public Item item;

	// Use this for initialization
	void Start () {
        item.state = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void select(){

        InventoryController.instance.Add(item);

        //if (!item.state)
        //{
        //    InventoryController.instance.Add(item);
        //    item.state = true;
        //}
        //else
        //    Debug.Log("Ya me seleccionaste!");
    }
}
