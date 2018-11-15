using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour {
    int value = 5;
    public GameObject scorePoints;
    public int totalscore=0;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            totalscore += value;
            scorePoints.GetComponent<Text>().text = totalscore.ToString();
            gameObject.SetActive(false);
        }
    }
}
