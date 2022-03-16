using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnBlock : MonoBehaviour
{

    public GameObject block;

    WordDataReader reader;
    public string wordResolve;
    
    
    public bool fin = false;

    public int rightMargin;
    public int leftMargin;

    public bool startGame = false;




    
    // Start is called before the first frame update
   void Awake()
   {
        
        reader = new WordDataReader();
       
        wordResolve = reader.FinalWord();
   }

   
   
    void Start()
    {
        
        NewBlock();
        Margins();

      
        
        
    }

    void Update()
    {
        
    }

    
    public void NewBlock(){
        Instantiate(block,transform.position, Quaternion.identity );




        
    }

        public String NewLetter (){

            if(wordResolve.Length > 0) {

            var rand = new System.Random();
            int index = rand.Next(wordResolve.Length);
            String letra =   wordResolve[index].ToString();            
                
            wordResolve = wordResolve.Remove(index, 1);

            return letra;
            }
            fin = true;
            return null;
                    
        }

        static bool IsPair(int numero)
        {
            if((numero % 2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void Margins (){
            if (IsPair(wordResolve.Length)){
                rightMargin = (10 - wordResolve.Length) / 2;
                leftMargin = rightMargin;
            }else {
                rightMargin = (10 - wordResolve.Length) / 2;
                leftMargin = rightMargin + 1;
            }
        }

        

         

               


  }
   


