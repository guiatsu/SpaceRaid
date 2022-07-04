using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public void Update(){
        if(Input.anyKey)
            SceneManager.LoadScene("Menu");
    }
}
