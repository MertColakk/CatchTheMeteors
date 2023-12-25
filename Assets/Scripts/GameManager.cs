using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public bool gameOver=false;
    [SerializeField] TMP_Text countdownText;
    ScoreManager scoreManager;
    void Start(){
        GameObject scoreMan = GameObject.Find("ScoreManager");

        if(scoreMan!=null)
            scoreManager = scoreMan.GetComponent<ScoreManager>();
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
    void Update(){
        if(gameOver){
            Time.timeScale=0;
            scoreManager.gameOverImage.gameObject.SetActive(true);  
        }
    }
}
