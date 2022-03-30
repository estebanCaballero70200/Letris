using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordDataReader : MonoBehaviour

{

    private GameManager gmanager;
    
    
    
    void Start()
    {
        GameManager manager = GameManager.instance;
                
    }

    /* public string ReadCSVFile(){

        

        StreamReader streamReader = new StreamReader("C:\\Users\\ecaballero\\Desktop\\UnityGameZip\\WordTrisPyxis\\Assets\\Resources\\palabras.csv");
        //StreamReader streamReader = new StreamReader(Resources.Load<TextAsset>("palabras").text);
        bool endOfFile = false;
        Debug.Log(streamReader);
        while(!endOfFile){
            string data_String = streamReader.ReadLine();
            if (data_String == null){
                endOfFile = true;
                break;
            }
            var data_values = data_String.Split(',');
            
            var rand = new System.Random();
            int index = rand.Next(data_values.Length);
            string word = data_values[index].ToUpper();



            return word;
        }
        return null;

    } */

    public string WordFromString(){

        TextAsset myTextAsset = Resources.Load<TextAsset>("palabras"); 
        string csvText = myTextAsset.text;
        Debug.Log("Texto desde Rosource= " + csvText);

        var data_values = csvText.Split(',');
            
            var rand = new System.Random();
            int index = rand.Next(data_values.Length);
            string word = data_values[index].ToUpper();
        
        return word;

    }

    /* public string FinalWord (){
        string word = ReadCSVFile();
        while (word.Length > 8 )
        {
            word = ReadCSVFile();
        }
        
        Debug.Log(word);

        return word;
        } */

        public string FinalWord (){
        string word = WordFromString();
        while (word.Length != GameManager.instance.Qletters)
        {
            word = WordFromString();
        }
        GameManager.instance.TheWord = word;
        Debug.Log("Palabra a resolver " + GameManager.instance.TheWord);

        return word;
        }

        

    }
