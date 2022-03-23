using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllerBehaviour : MonoBehaviour
{


    public event Action OnMoveRightPressed;
    public event Action OnMoveLeftPressed;

    public event Action OnMoveDownPressed;
    public BlockBehaviour blockMove;

    private String buttonName;


      

    public void MoveRigthPressed(){
        
        blockMove.SquareMoveRight();
    }

    public void MoveLeftPressed(){
        blockMove.SquareMoveLeft();
    }

    public void MoveDownPressed(){
        blockMove.fallTime = blockMove.fallTime /5;
    }

     public void MoveDownPressedUp(){
        blockMove.fallTime = 0.8f;
    }


}


