using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBar : MonoBehaviour
{
    
    // Start is called before the first frame update


    public Slider backVolume;
    public AudioSource audio;

    private float backVol = 1f;

    void Awake(){

    //    DontDestroyOnLoad(gameObject); 
    }
    void Start()

    {
          
        backVol = PlayerPrefs.GetFloat("backvo1",1f);
        backVolume.value = backVol;
        audio.volume = backVolume.value;
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    private void SoundSlider(){

        audio.volume = backVolume.value;
        PlayerPrefs.SetFloat("backvol", backVol);
    }
}
