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
    
    




    
    // Start is called before the first frame update
   void Awake()
   {
        
        reader = new WordDataReader();
       
        wordResolve = reader.FinalWord();
        
   }

   
   
    void Start()
    {
        
        Margins();
        
        SquareHolders();

      
        
        
    }

    void Update()
    {

       /*  if (fin)
        {
            Transform square;
            StringBuilder myStringBuilder = new StringBuilder();
            for (int i = 0; i < wordResolve.Length; i++)
            {
                Vector3 letra = new Vector3 ((leftMargin + i + 0.02f ),3.56f, 0);
                if (transform.position == letra)
                {
                    square.position = letra; 
                    string letter = letra.FindObjectOfType<GameObject>().GetComponent<Text>().text;
		            myStringBuilder.Insert(i, letter);
                    
                }
                
              
            }

            
        } */
        
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
            }
            fin = true;
            StartCoroutine(YourWord());
            

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

        private void SquareHolders () {
            Debug.Log("instanciando placeholder");
            
            for (int i = 0; i < wordResolve.Length; i++)
            {
                Instantiate(placeholder ,new Vector2 ((leftMargin + i + 0.02f ),3.56f) , Quaternion.identity );
              
            }

        } 

        IEnumerator YourWord () {
            StringBuilder myStringBuilder = new StringBuilder();
                                  
            for (int i = 0; i < wordResolve.Length; i++)
            {
                Debug.Log("Llega esto :"); 
                Vector2 point = new Vector2 ((leftMargin + i ), 3.5f);
                Vector2 area = new Vector2(1,1);
                
                Collider2D collider = Physics2D.OverlapBox(point, area, 0f, 6);
                if(collider != null)
                {
                        Debug.Log(collider.gameObject.name);
                        
                        /* GameObject go = collider.gameObject; //This is the game object you collided with
                        string letter = go.GetComponentInChildren<Text>().text;
		                myStringBuilder.Insert(i, letter); */
                }
              
            }
            /* GameManager.instance.YourWord = myStringBuilder.ToString();
            Debug.Log ("La palabra tuya: " +  myStringBuilder.ToString()); */
            yield return null;
            SceneManager.LoadScene(2);
        }
}
