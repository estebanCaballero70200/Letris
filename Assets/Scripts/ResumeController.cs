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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MaingManu (){
        SceneManager.LoadScene(0);
    }
}
