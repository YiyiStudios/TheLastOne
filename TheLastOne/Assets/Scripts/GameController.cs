using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    Stamina staminacontrol;

    GameController instance;
    public string scenename;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start () {
        staminacontrol = GetComponent<Stamina>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);     
        }	
	}

    
}
