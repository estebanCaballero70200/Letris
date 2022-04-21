using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  
    public static UIManager instance;

    public GameObject mapSelectionPanel;
    public GameObject[] levelSelectionPanel;

    public MapSelector[] mapSelector;
    public Text[] questStartText;
    public Text[] loquedStartText;
    public Text[] unlockedStartText;

    void Awake()
    {
      if ( instance == null)
       {
            instance = this;
            DontDestroyOnLoad(gameObject);
       } else {
            
            Destroy(gameObject);
       }

       
    }

     void Update()
   {
       UpdateLockedStarUI();
   }

    private void UpdateLockedStarUI(){
      
       for (int i = 0; i < mapSelector.Length ; i++)
       {
           questStartText[i].text = mapSelector[i].questNum.ToString();
           if (mapSelector[i].isUnlock == false)
           {
               loquedStartText[i].text = GameManager.instance.stars.ToString() + "/" + mapSelector[i].endLevel; 
           }else
           {
               if (GameManager.instance.stars < mapSelector[i].endLevel )
               {
                    unlockedStartText[i].text = GameManager.instance.stars.ToString() + "/" + mapSelector[i].endLevel;
               }else
               {
                   unlockedStartText[i].text = mapSelector[i].endLevel + "/" + mapSelector[i].endLevel;
               }
           }
       }
    }

    public void PressMapButton(int _mapIndex){
       if(mapSelector[_mapIndex].isUnlock == true){
           levelSelectionPanel[_mapIndex].SetActive(true);
           mapSelectionPanel.SetActive(false);
           GameManager.instance.Qletters = _mapIndex + 4;
        }
       else
       {
           Debug.Log("Este nivel está bloqueado");
       }
     }

    public void BackMapButton(){
          mapSelectionPanel.SetActive(true);
          for (int i = 0; i < levelSelectionPanel.Length; i++)
          {
              levelSelectionPanel[i].SetActive(false);
          }
    }

    public void StartLevel(){
          for (int i = 0; i < levelSelectionPanel.Length; i++)
          {
              levelSelectionPanel[i].SetActive(false);
          }
          SceneManager.LoadScene(2);   
    }


}
