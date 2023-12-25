using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{

    public void restartGame(){
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);
        Time.timeScale=1;
    }

    public void returnMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
