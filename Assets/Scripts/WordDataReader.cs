using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WordDataReader : MonoBehaviour

{
    
    void Start()
    {
        
        
    }

    public string ReadCSVFile(){

        StreamReader streamReader = new StreamReader("C:\\Users\\ecaballero\\Desktop\\UnityGameZip\\WordTrisPyxis\\Assets\\Scripts\\palabras.csv");
        bool endOfFile = false;
        
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

    }

    public string FinalWord (){
        string word = ReadCSVFile();

        while (word.Length > 8)
        {
            word = ReadCSVFile();
        }
        
        Debug.Log(word);

        return word;
        }

        

    }

