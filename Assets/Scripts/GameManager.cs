using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver=false;
    [SerializeField] TMP_Text countdownText;
    void Start(){
        gameOver=false;
        StartCoroutine(waitStartGame());
        countdownText.text="2";
    }

    IEnumerator waitStartGame()
    {
        Time.timeScale = 0;
        
        yield return new WaitForSecondsRealtime(1);
        countdownText.text  = "1";
        yield return new WaitForSecondsRealtime(1);
        countdownText.text  = "0";
        yield return new WaitForSecondsRealtime(1);
        countdownText.gameObject.SetActive(false);
        Time.timeScale = 1;
        
    }
    void FixedUpdate(){
        if(gameOver){
            Time.timeScale=0;
        }
    }
}
