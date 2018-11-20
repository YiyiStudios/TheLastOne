using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaController : MonoBehaviour
{
    PlayerController playercontrol;
    public float staminabar;
    public Image imagelifebar;
    public float reduction;
    public float timetoreduction;
    public float elapsedtime=0;
    float time;
    bool iswalk = false;
    float colorlerp = 0f;
    // Use this for initialization
    void Start()
    {
        playercontrol = GetComponent<PlayerController>();
        time = elapsedtime;
    }
    // Update is called once per frame
    void Update()
    {
        ReduceStaminaBar();

    }
    public void ReduceStaminaBar()
    {
        if (PlayerController.mov != Vector2.zero)
        {
            imagelifebar.fillAmount = Mathf.InverseLerp(staminabar, 0, reduction);
            elapsedtime += Time.deltaTime;
            if (elapsedtime >= timetoreduction)
            {
                reduction++;
                iswalk = true;
                StaminaColor(iswalk);
                elapsedtime = time;
            }
        }
    }
    void StaminaColor(bool iswalk )
    {       
        if (iswalk==true )
        {
            colorlerp += 0.006f;
            imagelifebar.color = Color.Lerp(new Color32(255, 23, 67, 255), new Color32(0, 25, 135, 255), colorlerp);
        }
        iswalk = false;
    }
}
