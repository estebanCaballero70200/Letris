using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllsBehaviour : MonoBehaviour
{

    private Touch touch;
    public BlockController block;



    public void MoveRight(){

        block.MoveRight();

     
    }

    public void MoveLeft(){
       block.MoveLeft();
    }

    public void MoveDownFast(){
        block.MoveDown();
    }



    



    

    
}
