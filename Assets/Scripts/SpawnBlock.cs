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

    private string forYourWord;
    
    
    // Start is called before the first frame update
   void Awake()
   {
        gmanager = GameManager.instance;
        reader = new WordDataReader();
       
        wordResolve = reader.FinalWord();

        forYourWord = wordResolve;
        
   }

   
   
    void Start()
    {
        
        Margins();
        
        SquareHolders();
        
        //METODO QUE INSTANCIA OBSTÁCULOS EN EL CAMINO
        //SquareBloquers();

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
                YourWord();
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

        void YourWord () {

            Debug.Log("palabra en yourWord: " + forYourWord);

            List<GameObject> finalSquares = new List<GameObject>(GameObject.FindGameObjectsWithTag("square"));
            
            GameObject[] resultSquares = new GameObject[forYourWord.Length];
            Debug.Log( "GameObjectRecogidos: " + finalSquares.Count);
            string yourWord = "";

            if(finalSquares.Count != forYourWord.Length){
                int index = forYourWord.Length;
                finalSquares.Remove(finalSquares[index]);
            }

            Debug.Log( "array de objetos procesado: " + finalSquares.Count);

            for (int i = 0; i < finalSquares.Count; i++)
            {
                int index = (Mathf.RoundToInt(finalSquares[i].transform.position.x))- leftMargin;
                Debug.Log("square en index: " + index + " con letra: " + finalSquares[i].GetComponentInChildren<TextMesh>().text );
                resultSquares[index] = finalSquares[i];

                
            }
            for (int i = 0; i < resultSquares.Length; i++)
            {
                yourWord += resultSquares[i].GetComponentInChildren<TextMesh>().text;
                Debug.Log( "yourWord en interación " + i + " : " + yourWord);
            
            }
            Debug.Log(yourWord);
            gmanager.YourWord = yourWord;


            SceneManager.LoadScene(3);
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

         void SquareBloquers ()
         {
            var rand = new System.Random();
            int index = 0;
            for (int i = 0; i < 8; i++)
            {
                int p = rand.Next(wordResolve.Length);
                while (p==index)
                {
                    p = rand.Next(wordResolve.Length);
                }
                Instantiate(placeholder ,new Vector2 (((leftMargin + p + 0.02f )-1), (6.56f + i)) , Quaternion.identity );
            }
         } 
              
            

}
