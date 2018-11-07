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
    public float timetoreduction;
    public float elapsedtime=0;
    float time;
    // Use this for initialization
    void Start()
    {
        playercontrol = GetComponent<PlayerController>();
        time = elapsedtime;
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
            elapsedtime += Time.deltaTime;
            if (elapsedtime >= timetoreduction)
            {
                reduction++;
                elapsedtime = time;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            imagelifebar.fillAmount = staminabar;
        }
    }
}
