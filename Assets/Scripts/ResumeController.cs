using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeController : MonoBehaviour
{
    
    public Text text1, text2, text3;
    
    private SceneManager sceneManager;

    
    
    void Start()
    {
        text2.GetComponent<Text>().text = GameManager.instance.TheWord;
        text1.GetComponent<Text>().text = GameManager.instance.YourWord;
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Resume(){
        if(text1.text == text2.text){
            text3.GetComponent<Text>().text = "Great!!!";
            text3.GetComponent<Text>().color = Color.green;
            GameManager.instance.stars += 1; 
            PlayerPrefs.SetInt("stars", GameManager.instance.stars);
            Debug.Log( "estrellas guardadas en juego: " + PlayerPrefs.GetInt("stars"));


        }else{
            text3.GetComponent<Text>().text = "Upsss!!!";
            text3.GetComponent<Text>().color = Color.red;
            if (GameManager.instance.stars > 0)
            {
                GameManager.instance.stars -= 1; 
                PlayerPrefs.SetInt("stars", GameManager.instance.stars);
            } 
        }

    }

    public void MaingManu (){
        UIManager.instance.mapSelectionPanel.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Reload(){

        SceneManager.LoadScene(2);
        PlayerPrefs.Save();
    }
}
