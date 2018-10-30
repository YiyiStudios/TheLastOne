using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {

    PlayerController player;

    public int staminabar;
    public Image imagelifebar;
    float time;

    // Use this for initialization
    void Start() {
        player = GetComponent<PlayerController>();
        time = 1f;
    }

    // Update is called once per frame
    void Update() {
        StaminaBar();
    }

    public void StaminaBar()
    {
        if (player.mov != Vector2.zero)
        {
            imagelifebar.fillAmount = Mathf.InverseLerp(staminabar, 0, time++);
        }
        if (imagelifebar.fillAmount != 0 && Input.GetKeyDown(KeyCode.K))
        {
            imagelifebar.fillAmount = staminabar;
            GameController.instance.PlayerLose();
        }
    }
}



