using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnBlock : MonoBehaviour
{

    public GameObject [] blocks;

    public Camera cam;

    public GameObject fondo;

    WordDataReader reader;
    public string wordResolve;
    
    
    public bool fin = false;

    public int rightMargin;
    public int leftMargin;

    public bool startGame = false;

    public AudioSource audioSource;

    public AudioClip[] audioBlocks;

    public AudioClip[] audioCountDown;

    public GameObject placeholder;

    GameManager gmanager;

    public  int height = 20;
    public  int widht = 10;
    public  Transform [,] grid = new Transform [10, 20];
    
    
    // Start is called before the first frame update
   void Awake()
   {
        gmanager = GameManager.instance;
        reader = new WordDataReader();
       
        wordResolve = reader.FinalWord();
        
   }

   
   
    void Start()
    {
        
        Margins();
        
        SquareHolders();

        if(!IsPair(wordResolve.Length)){
            cam.transform.position += new Vector3 (0.5f, 0f, 0f);
            fondo.transform.position += new Vector3 (0.5f, 0f, 0f);
        }

      
        
        
    }

    void Update()
    {

       
        
    }

    
    public void NewBlock(){
      
      var rand = new System.Random();
      Instantiate(blocks[rand.Next(blocks.Length)],transform.position, Quaternion.identity );
        
        
    }

        public String NewLetter (){

            if(wordResolve.Length > 0) {

                var rand = new System.Random();
                int index = rand.Next(wordResolve.Length);
                String letra =   wordResolve[index].ToString();            
                    
                wordResolve = wordResolve.Remove(index, 1);
                

                return letra;
            } else {
                StartCoroutine(YourWord());
                return null;
                
            }
            
            

                    
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

        private void SquareHolders () {
            Debug.Log("instanciando placeholder");
            
            for (int i = 0; i < wordResolve.Length; i++)
            {
                Instantiate(placeholder ,new Vector2 ((leftMargin + i + 0.02f ),3.56f) , Quaternion.identity );
              
            }

        } 

        IEnumerator YourWord () {

           AddToGrid();
            
            GameObject [] finaLetters = GameObject.FindGameObjectsWithTag("letter");
            var word = "";

                            
                for (int i = 0; i < finaLetters.Length; i++)
                    {   

                        int index = (Mathf.RoundToInt(finaLetters[i].transform.position.x))- leftMargin + 1;
                        word += finaLetters[i].GetComponent<TextMesh>().text;
                                               
                    }
            

            
            GameManager.instance.YourWord = word;
                                  
            Debug.Log( "palabra final: " + word);


            yield return null;
            SceneManager.LoadScene(2);
        }

        public void AddToGrid(){
        grid = new Transform [10, 20];
        foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                grid[roundedX, roundedY] = children;

            }

            
    }
}
