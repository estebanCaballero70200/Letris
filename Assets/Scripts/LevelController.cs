using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update

    public LayerMask moveLayer;
    Transform squareOne;
    Transform squareTwo;

    Vector2 squareOneVector;

    Vector2 squareTwoVector;

    public bool oneSelected;

    public bool move;

    private SpawnBlock spawnBlock;

      
    void Start()
    {

        spawnBlock = FindObjectOfType<SpawnBlock>();
        
        oneSelected = false;
        move = false;
               
    }

    void Update()
    {
        
        if (isSquare())
        {
            
                if (Input.GetMouseButtonDown(0))
                {
                
                    if (!oneSelected)
                    {
                        OneSquareClick();  
                        
                    }
                    if (oneSelected)
                    {
                        Debug.Log("if en update");
                        SecondSquareClick(); 
                    }
                    
                    
                }

                if(Input.GetMouseButtonUp(0) && !oneSelected){
                            
                            oneSelected = true;
                            Debug.Log(" onselected esta en " + oneSelected);
                                    
                            
                }
                
                if(Input.GetMouseButtonUp(0) && move) {
                        Debug.Log("Arranca Corrutina");
                        StartCoroutine (Move());
                        spawnBlock.UpdateGrid();

                        
                }
        }

    }

       

        void OneSquareClick(){

            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, moveLayer);
            if (hit.collider != null && oneSelected == false )
            {
                squareOne = hit.collider.transform;
                squareOneVector = new Vector2 (squareOne.position.x, squareOne.position.y);
                
                Debug.Log("primerIf");
                
                
            }  

        }

        void SecondSquareClick(){
            Debug.Log("Segundo Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, moveLayer);

            if (hit.collider != null && oneSelected == true)
            {
                squareTwo = hit.collider.transform;
                if (squareOne != squareTwo)
                {
                    squareTwoVector = new Vector2 (squareTwo.position.x, squareTwo.position.y);
                    Debug.Log("SegundoIf");
                    move = true;
                }
                
            }

            
           
        }

        IEnumerator Move (){
             
                squareOne.position = Vector2.MoveTowards(squareOneVector, squareTwoVector, 2000f * Time.deltaTime);
                squareTwo.position = Vector2.MoveTowards(squareTwoVector, squareOneVector, 2000f * Time.deltaTime);
                move= false;
                oneSelected = false;

            yield return new WaitForSeconds (0.5f);
                

                
                

        }

        bool isSquare(){

             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, moveLayer);
            if (hit.collider != null){
                return true;
            }
            return false;
        }


        
}
