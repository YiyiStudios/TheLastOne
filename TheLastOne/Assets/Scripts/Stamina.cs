using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    PlayerController playercontrol;
    public float staminabar;
    public Image imagelifebar;
    public float reduction;
    // Use this for initialization
    void Start()
    {
        playercontrol = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        StaminaBar();
    }
    public void StaminaBar()
    {
        if (playercontrol.mov != Vector2.zero)
        {
            imagelifebar.fillAmount = Mathf.InverseLerp(staminabar, 0, reduction);
            reduction++;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            imagelifebar.fillAmount = staminabar;
        }
    }
}
