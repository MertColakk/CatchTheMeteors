using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    float horizontalInput,moveSpeed=20f;
    ScoreManager scoreManager;
    GameManager gameManager;
    
    void Start(){
        GameObject scoreObj = GameObject.Find("ScoreManager");
        GameObject gameManagerObj = GameObject.Find("GameManager");
        if(scoreObj!=null&&gameManagerObj!=null){
            gameManager = gameManagerObj.GetComponent<GameManager>();
            scoreManager = scoreObj.GetComponent<ScoreManager>();
        }
            
    }
    void FixedUpdate(){
        if(transform.position.x<-10.1f)
            transform.position = new Vector3(-10f,transform.position.y,transform.position.z);
        else if(transform.position.x>10.1f)
            transform.position = new Vector3(10f,transform.position.y,transform.position.z);

        //Input and movement operation
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput*Time.deltaTime*moveSpeed*Vector3.right);
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Meteor")){
            scoreManager.addToScore(1);
            other.gameObject.SetActive(false);
        }else if(other.gameObject.CompareTag("GemStone")){
            scoreManager.addToScore(3);
            other.gameObject.SetActive(false);
        }else if(other.gameObject.CompareTag("Planet")){
            gameManager.gameOver=true;
            other.gameObject.SetActive(false);
        }
    }

    
}
