using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    
    public static MusicController instance;
    #region AudioClips
    //public AudioClip walkClip;
    public AudioClip coinClip;
    //public AudioClip item1Clip;
    //public AudioClip item2Clip;
    #endregion  
    public AudioSource backgroundAudioSource;
    public AudioSource soundAudioSource;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    public void CoinEffect()
    {
        PlaySound(coinClip);
    }
    //public void WalkClip()
    //{
    //    PlaySound(walkClip);
    //}
    public void PlaySound(AudioClip ac)
    {
        soundAudioSource.clip = ac;
        soundAudioSource.Play();
    }
}
