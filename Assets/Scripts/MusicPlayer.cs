using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;    
    [SerializeField] Image onImage;
    [SerializeField] Sprite off,on;
    private AudioSource musicSource;
    bool isOpenSound=true;    
    
    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        playMusic();
        isOpenSound=true;
    }

    public void volumeSound(){
        isOpenSound = !isOpenSound;
        if(!isOpenSound)
            musicSource.volume=0f;
        else
            musicSource.volume=.02f;
        
        updateSprite(isOpenSound);
        
    }

    void updateSprite(bool isOpenSound){
        if(isOpenSound)
            onImage.sprite = on;
        else
            onImage.sprite = off;
    }

    void playMusic(){
        musicSource.clip = audioClip;
        musicSource.loop = true;
        musicSource.volume = .03f;
        musicSource.Play();
    }
}
