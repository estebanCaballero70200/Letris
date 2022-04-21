using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelector : MonoBehaviour
{
    public bool isUnlock;
    public GameObject lockGo;
    public GameObject unLockGo;

    public int mapIndex;
    public int questNum;
    public int startLevel;
    public int endLevel;


    void Update()
    {
        UpdateMapStatus();
        UpdateMap();
    }

    private void UpdateMapStatus(){
        if(isUnlock){
            unLockGo.SetActive(true);
            lockGo.SetActive(false);
        }
        else{
            unLockGo.SetActive(false);
            lockGo.SetActive(true);
        }
    }

    private void UpdateMap(){
        
        if (GameManager.instance.stars >= questNum)
        {
            isUnlock = true;
        }else{
            isUnlock = false;
        }
    }


}
