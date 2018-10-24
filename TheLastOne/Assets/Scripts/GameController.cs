﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;
    public bool gameOver = false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if(instance!=this)
        {
            Destroy(this.gameObject);
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameOver == true && Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
    public void PlayerLose()
    {
        gameOver = true;
    }
}
