using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public GameObject   scorePoints;
    public static int totalscore=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scorePoints.GetComponent<Text>().text = totalscore.ToString();
	}
}
