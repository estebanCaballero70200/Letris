using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersQuantity : MonoBehaviour
{
    SpawnBlock spawnBlock;

    
      
      TMPro.TMP_Text testText;

      
    // Start is called before the first frame update
    void Awake()
    {
        
        spawnBlock =  FindObjectOfType<SpawnBlock>();
        testText = GetComponent<TMPro.TMP_Text>();
        
    }
    
    void Start()
    {
        Letters();
    }

    // Update is called once per frame
    void Letters(){
        int count = spawnBlock.wordResolve.Length;

        testText.text = count + " LETRAS";

        

    }
}
