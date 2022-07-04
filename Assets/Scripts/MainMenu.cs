using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Update(){
        if(Input.GetButtonDown("Cancel"))
            Application.Quit();
    }
    public void Play(){
        SceneManager.LoadScene("Level");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
