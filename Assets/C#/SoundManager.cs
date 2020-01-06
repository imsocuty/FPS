using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip soundExplosion;
    AudioSource myAudio;

    public static SoundManager instance;

    void Awake(){
        if( SoundManager.instance == null)
            SoundManager.instance = this;
    }
    void Start()
    {
     myAudio = GetComponent<AudioSource>();   
    }
    public void PlaySound(){

        myAudio.PlayOneShot(soundExplosion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
