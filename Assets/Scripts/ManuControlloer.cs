using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManuControlloer : MonoBehaviour
{


    private GameManager gManager;
    public Button boton_4, boton_5, boton_6, boton_7, boton_8;

    void Start()
    {
        gManager = GameManager.instance; 
        
        if(boton_4){
            boton_4.GetComponent<Button>().onClick.AddListener(()=> gManager.Qletters = 4);
            boton_4.GetComponent<Button>().onClick.AddListener(()=> NewGame());
        }
        if(boton_5){
            boton_5.GetComponent<Button>().onClick.AddListener(()=> gManager.Qletters = 5);
            boton_5.GetComponent<Button>().onClick.AddListener(()=> NewGame());
        }
        if(boton_6){
            boton_6.GetComponent<Button>().onClick.AddListener(()=> gManager.Qletters = 6);
            boton_6.GetComponent<Button>().onClick.AddListener(()=> NewGame());
        }
        if(boton_7){
            boton_7.GetComponent<Button>().onClick.AddListener(()=> gManager.Qletters = 7);
            boton_7.GetComponent<Button>().onClick.AddListener(()=> NewGame());
        }
        if(boton_8){
            boton_8.GetComponent<Button>().onClick.AddListener(()=> gManager.Qletters = 8);
            boton_8.GetComponent<Button>().onClick.AddListener(()=> NewGame());
        }       
    }
   
    public void NewGame(){
        
        SceneManager.LoadScene(1);
    }

    public void Menu (){
        SceneManager.LoadScene(0);
    }

    public void Exit(){
        Application.Quit();
    }

    
}
