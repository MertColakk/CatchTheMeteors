using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    //Variable
    float rotateSpeed=30f,fallSpeed = 8f;
    Rigidbody rb;
    ScoreManager scoreManager;
    GameManager gameManager;

    void Start(){
        GameObject scoreObj = GameObject.Find("ScoreManager");
        GameObject gameManagerObj = GameObject.Find("GameManager");
        rb = GetComponent<Rigidbody>();
        if(scoreObj!=null&&gameManagerObj!=null){
            gameManager = gameManagerObj.GetComponent<GameManager>();
            scoreManager = scoreObj.GetComponent<ScoreManager>();
        }
           
        gameObject.SetActive(true);

    }
    void FixedUpdate(){
        if(transform.position.x<-10.1f)
            transform.position = new Vector3(-10f,transform.position.y,transform.position.z);
        else if(transform.position.x>10.1f)
            transform.position = new Vector3(10f,transform.position.y,transform.position.z);
    }

    void Update(){
        transform.Rotate(rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime,rotateSpeed*Time.deltaTime);

        if(rb!=null){
            Vector3 newVelocity = rb.velocity;
            newVelocity.y = -fallSpeed;
            rb.velocity = newVelocity;
        }

        if(transform.position.y<-4f && this.gameObject.tag != "Planet"){
            this.gameObject.SetActive(false);
            gameManager.gameOver=true;
        }
            
        if(this.gameObject.tag == "Planet" && transform.position.y<-4f)
        {
            this.gameObject.SetActive(false);
            scoreManager.addToScore(2);
        }
    }
}
