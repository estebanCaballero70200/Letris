using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockBehaviour : MonoBehaviour
{

    private float previousTime;
    [SerializeField]
    public float fallTime = 0.8f;

    private static int height = 20;
    private static  int widht = 10;
    

    private static Transform [,] grid = new Transform [widht, height];

    private WordDataReader reader;

    private TextMesh letraMesh;

    private bool letterGo = true;

    public bool startGame = false;

    private int rightMarginMove;
    private int leftMarginMove;

    SpawnBlock spawnBlock;

    ControllerBehaviour controller;


    

    
    void Awake()
    {
        controller = FindObjectOfType<ControllerBehaviour>();
        spawnBlock = FindObjectOfType<SpawnBlock>();
        letraMesh = GetComponentInChildren<TextMesh>();
                
    }

    // Start is called before the first frame update
    void Start()
    {
        rightMarginMove = FindObjectOfType<SpawnBlock>().rightMargin;
        leftMarginMove = FindObjectOfType<SpawnBlock>().leftMargin;
        Debug.Log(rightMarginMove.ToString());
        Debug.Log(leftMarginMove.ToString());
        controller.blockMove= this;
        
                
    }

    // Update is called once per frame
    void Update()
    {
            if(letterGo){
                NewLetter();
                letterGo = false;
            }
                       
            SquareMove();

            startGame = spawnBlock.startGame;
    }

    

    void NewLetter(){
        letraMesh.text = FindObjectOfType<SpawnBlock>().NewLetter();
    }


    

    public void SquareMoveLeft(){
        transform.position += new Vector3 ( -1f, 0,0);
            if(!ValidMove())
            transform.position -= new Vector3 ( -1f, 0,0);

    }

    public void SquareMoveRight(){
        transform.position += new Vector3 (1f, 0,0);
            if(!ValidMove())
            transform.position -= new Vector3 (1f, 0,0);
    }

    void SquareMove(){

           if (Time.time - previousTime > fallTime && startGame) {
                
                transform.position += new Vector3 ( 0, -1, 0);
                if(!ValidMove()){
                    transform.position -= new Vector3 ( 0, -1, 0);
                    AddToGrid();
                    this.enabled = false;
                    if (!FindObjectOfType<SpawnBlock>().fin)
                    {
                        FindObjectOfType<SpawnBlock>().NewBlock();
                    } else {
                        Destroy(gameObject);
                    }
                    letterGo = true;
                }

                previousTime = Time.time;
            }
} 

void AddToGrid(){

        foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                grid[roundedX, roundedY] = children;
            }

            
    }


    

        

    

    bool ValidMove(){

         
        foreach (Transform children in transform){
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            
            if(roundedX < leftMarginMove || roundedX >= widht - rightMarginMove || roundedY < 4 || roundedY >= height){
                
                return false;
            }

            if ( grid[roundedX,roundedY] != null){
                Destroy(gameObject);
                return false;
            }

            if (FindObjectOfType<SpawnBlock>().fin){
                return false;
            }            

        }
        return true;
        {
            
        }
    }

      
        
        




   

}

    

