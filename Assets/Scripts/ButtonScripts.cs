using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonScripts : MonoBehaviour
{
    bool isOpen=false,isOpenSound=true;
    [SerializeField] Image howToPlayImage;
    [SerializeField] Image onImage;
    [SerializeField] Sprite off,on;
    [SerializeField] AudioClip audioClip;    
    private AudioSource musicSource;

    void Start(){
        isOpen=false;
        isOpenSound=true;
        howToPlayImage.gameObject.SetActive(isOpen);
        musicSource = gameObject.AddComponent<AudioSource>();
    
        playMusic();
    }

    public void restartGame(){
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        Time.timeScale=1;
    }

    public void returnMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame(){
        SceneManager.LoadScene("Game Scene");
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void showOrHideInterface(){
        isOpen = !isOpen;
        howToPlayImage.gameObject.SetActive(isOpen);
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
