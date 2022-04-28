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
        }else{
            text3.GetComponent<Text>().text = "Upsss!!!";
            text3.GetComponent<Text>().color = Color.red; 
        }

    }

    public void MaingManu (){
        SceneManager.LoadScene(0);
    }
}
