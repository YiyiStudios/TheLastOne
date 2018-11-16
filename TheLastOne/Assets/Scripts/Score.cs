using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    int value = 5;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreController.totalscore += value;
            MusicController.instance.CoinEffect();
            gameObject.SetActive(false);
        }
    }
}
