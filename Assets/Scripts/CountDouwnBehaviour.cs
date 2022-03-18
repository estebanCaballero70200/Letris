using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDouwnBehaviour : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer spriteVisible;

       
    SpawnBlock spawnBlock;


    void Start()
    {
        spawnBlock = FindObjectOfType<SpawnBlock>();
        spriteVisible = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(initCountDown());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator initCountDown()
    {
       for (int i = 0; i < sprites.Length; i++)
        {
            spriteVisible.sprite = sprites[i];
            yield return new WaitForSeconds(1);
            if ( i == (sprites.Length -1)){
                spawnBlock.startGame = true;
                this.gameObject.SetActive(false);
                spawnBlock.NewBlock();
            }
        }
        
    }


    
}
