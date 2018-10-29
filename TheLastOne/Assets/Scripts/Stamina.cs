using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour {

    public int staminabar;
    public Image imagelifebar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StaminaBar();
    }

    public void StaminaBar()
    {
        imagelifebar.fillAmount = Mathf.InverseLerp(staminabar, 0, Time.fixedTime);
    }
}
