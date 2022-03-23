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
        spriteVisible.sprite = sprites[0];
        yield return new WaitForSeconds(1);
        spriteVisible.sprite = sprites[1];
        yield return new WaitForSeconds(1);
        spriteVisible.sprite = sprites[2];
        yield return new WaitForSeconds(1);
        spriteVisible.sprite = sprites[3];
        spawnBlock.startGame = true;
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
        
    }

    
}
