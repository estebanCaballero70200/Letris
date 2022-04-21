using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class LevelSelection : MonoBehaviour
{
   public bool isUnlocked = false;
   public Image lockImg;
   public Image[] starsImgs;

   void Update()
   {
       UpdateLevelButton();
   }

   public void UpdateLevelButton(){

       int level = int.Parse(this.gameObject.name);

       if (GameManager.instance.stars >= level)
       {
        isUnlocked = true;   
       }else
       {
        isUnlocked = false;   
           
       }

       if (!isUnlocked)
       {
           lockImg.gameObject.SetActive(true);
           this.gameObject.GetComponent<Button>().enabled = false;
                      
       } else 
       {
           lockImg.gameObject.SetActive(false);
           this.gameObject.GetComponent<Button>().enabled = true;
       }
   }

   
}
