using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {

    PlayerController player;

    public int staminabar;
    public Image imagelifebar;

    // Use this for initialization
    void Start() {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        StaminaBar();
    }

    public void StaminaBar()
    {
        if (player.mov != Vector2.zero)
        {
            imagelifebar.fillAmount = Mathf.InverseLerp(staminabar, 0, Time.fixedTime);
        }
        if (imagelifebar.fillAmount != 0 && Input.GetKeyDown(KeyCode.K))
        {
            imagelifebar.fillAmount = staminabar;
            GameController.instance.PlayerLose();
        }
    }
}



