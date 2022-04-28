using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
   public static GameManager instance;

   private int qletters = 5;
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
}
