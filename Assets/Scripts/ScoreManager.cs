using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    //Variables
    [SerializeField] TMP_Text text;
    [SerializeField]Image gameOverImage;
    GameManager gameManager;
    
    int gameScore;


    void Start()
    {
        GameObject gameManagerObj = GameObject.Find("GameManager");
        if(gameManagerObj!=null){
            gameScore = 0;
            gameOverImage.gameObject.SetActive(false);
            gameManager = gameManagerObj.GetComponent<GameManager>();
        }
        
    }

    void Update(){
        if(gameManager.gameOver==true){
            gameOverImage.gameObject.SetActive(true);
        }
    }

    public void addToScore(int amount){
        gameScore += amount;
        text.text = "Score: "+gameScore.ToString();
    }
}
