using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {

    public int staminabar;
    public Image imagelifebar;
    float time;

<<<<<<< HEAD
    // Use this for initialization
    void Start() {
        player = GetComponent<PlayerController>();
        time = 1f;
    }

    // Update is called once per frame
    void Update() {
=======
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
>>>>>>> 73616fbcc84c0beee9eda29e1646857c1b21d323
        StaminaBar();
    }

    public void StaminaBar()
    {
<<<<<<< HEAD
        if (player.mov != Vector2.zero)
        {
            imagelifebar.fillAmount = Mathf.InverseLerp(staminabar, 0, time++);
        }
        if (imagelifebar.fillAmount != 0 && Input.GetKeyDown(KeyCode.K))
        {
            imagelifebar.fillAmount = staminabar;
            GameController.instance.PlayerLose();
        }
=======
        imagelifebar.fillAmount = Mathf.InverseLerp(staminabar, 0, Time.fixedTime);
>>>>>>> 73616fbcc84c0beee9eda29e1646857c1b21d323
    }
}
