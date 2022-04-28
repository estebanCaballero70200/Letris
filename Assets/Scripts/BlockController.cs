using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class BlockController : MonoBehaviour
{
     private float previousTime;
    [SerializeField]
    public float fallTime;

    /* private static int height = 20;
    private static  int widht = 10;
    private static Transform [,] grid = new Transform [widht, height]; */

    private WordDataReader reader;

    private TextMesh letraMesh;

    private bool letterGo = true;

    public bool startGame = false;

    private int rightMarginMove;
    private int leftMarginMove;

    SpawnBlock spawnBlock;

    ControllsBehaviour controlls;

    Button button;     

    
    void Awake()
    {
        spawnBlock = FindObjectOfType<SpawnBlock>();
        letraMesh = GetComponentInChildren<TextMesh>();
        controlls = FindObjectOfType<ControllsBehaviour>();
         
    
                
    }

    // Start is called before the first frame update
    void Start()
    {
        rightMarginMove = FindObjectOfType<SpawnBlock>().rightMargin;
        leftMarginMove = FindObjectOfType<SpawnBlock>().leftMargin;
        Debug.Log(rightMarginMove.ToString());
        Debug.Log(leftMarginMove.ToString());
        controlls.block = this;
        fallTime = 0.8f;
        
                
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

    public void MoveRight(){

        transform.position += new Vector3 (1f, 0,0);
        spawnBlock.audioSource.PlayOneShot(spawnBlock.audioBlocks[0]);
                if(!ValidMove())
                    transform.position -= new Vector3 (1f, 0,0);

    }

    public void MoveLeft(){
          transform.position += new Vector3 ( -1f, 0,0);
          spawnBlock.audioSource.PlayOneShot(spawnBlock.audioBlocks[0]);
                if(!ValidMove())
                    transform.position -= new Vector3 ( -1f, 0,0);

    }

    public void MoveDown(){
         
        fallTime = fallTime/10;
         
    }


    
   void SquareMove(){

            if (Time.time - previousTime >  fallTime  && startGame) {
                transform.position += new Vector3 ( 0, -1, 0);
                spawnBlock.audioSource.PlayOneShot(spawnBlock.audioBlocks[0]); 
                if(!ValidMove()){
                    transform.position -= new Vector3 ( 0, -1, 0);
                    spawnBlock.AddToGrid(this.transform);
                    this.gameObject.layer = 7; 
                    this.enabled = false;
                    if (!spawnBlock.fin)
                    {
                        spawnBlock.NewBlock();
                       
                    } else {
                        Destroy(gameObject);
                    }
                    letterGo = true;
                }

                previousTime = Time.time;
            }
} 

   /*  void AddToGrid(){

        foreach (Transform children in transform)
            {
                int roundedX = Mathf.RoundToInt(children.transform.position.x);
                int roundedY = Mathf.RoundToInt(children.transform.position.y);

                grid[roundedX, roundedY] = children;

            }

            
    } */

    


     bool ValidMove()
     {

         
        foreach (Transform children in transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            
            if(roundedX < leftMarginMove || roundedX >= spawnBlock.widht - rightMarginMove || roundedY < 4 || roundedY >= spawnBlock.height){
                
                return false;
            }

            if ( spawnBlock.grid[roundedX,roundedY] != null && spawnBlock.grid[roundedX,roundedY].gameObject != spawnBlock.placeholder ){
        
                Destroy(gameObject);
                return false;
            }

            if (spawnBlock.fin){
                return false;
            }            

        }
        return true;
        {
            
        }
    }

}
