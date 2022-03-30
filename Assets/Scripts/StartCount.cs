using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCount : MonoBehaviour
{ public Sprite[] sprites;
    private SpriteRenderer spriteVisible;

       
    SpawnBlock spawnBlock;
    AudioSource musicSource;
    

    void Start()
    {
        spawnBlock = FindObjectOfType<SpawnBlock>();
        spriteVisible = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(initCountDown());
        musicSource = Camera.main.GetComponent<AudioSource>();
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator initCountDown()
    {
        
        for (int i = 0; i <= sprites.Length; i++)
        {
            
            if (i<3)
            {
                spriteVisible.sprite = sprites[i];
                spawnBlock.audioSource.PlayOneShot(spawnBlock.audioCountDown[0]);
                yield return new WaitForSeconds(1);
                                      
            }
            
            
            if (i == 3)
            {
                spriteVisible.sprite = sprites[i];
                spawnBlock.audioSource.PlayOneShot(spawnBlock.audioCountDown[1]);
                yield return new WaitForSeconds(1);
            }
            if (i == sprites.Length)
            {
                this.gameObject.SetActive(false);
                spawnBlock.startGame = true;
                spawnBlock.NewBlock();
                musicSource.Play();
                yield return new WaitForSeconds(1);
            }
        }
        
    }
}
