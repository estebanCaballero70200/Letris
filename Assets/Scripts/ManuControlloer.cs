using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManuControlloer : MonoBehaviour
{


    public Button boton_4, boton_5, boton_6, boton_7, boton_8, boton_music;
    public AudioSource audioSource;
    

    public void NewGame(){
        
        SceneManager.LoadScene(1);
    }

    public void Menu (){
        
        SceneManager.LoadScene(1);
    }

    public void Exit(){
        PlayerPrefs.SetInt("stars", GameManager.instance.stars);
        Application.Quit();
    }

    public void Music(){
        audioSource.mute = !audioSource.mute;

    }

    
}
