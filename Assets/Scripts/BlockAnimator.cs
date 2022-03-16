using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAnimator : MonoBehaviour
{
     
    Animator animator;
    public bool isSelecetd = false;
    void Start()
    {
       animator = GetComponentInChildren<Animator>(); 

    }

    
    void Update()
    {
        if(isSelecetd){
            animator.SetBool("isSelected", true);
            Debug.Log("Animando");
        }else{
            animator.SetBool("isSelected", false);
        }
        
    }
}
