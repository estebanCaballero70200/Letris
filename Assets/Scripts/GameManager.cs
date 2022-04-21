using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
   
   public static GameManager instance;

   private int qletters;
   public int Qletters {
        get
        {
            return qletters;
        }
         set
        {
            qletters = value;
        }
    }

     
    public string YourWord {get; set;}
    public string TheWord {get;set;}

    public int stars = 1;

    




   void Awake()
   {
       if ( GameManager.instance == null)
       {
            GameManager.instance = this;
            DontDestroyOnLoad(gameObject);
       } else {
           Destroy(gameObject);
       }


   }

   void Start()
   {
       if (PlayerPrefs.HasKey("stars"))
       {
           stars = PlayerPrefs.GetInt("stars");
           Debug.Log ("Estrellas guardadas: " + stars);
           if (stars == 0){
               stars = 1;
           }
       } 
   }

   void OnDisable()
   {
       PlayerPrefs.Save();
   }

  

   
   
   

  
}
