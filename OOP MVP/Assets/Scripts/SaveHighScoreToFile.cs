using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHighScoreToFile : MonoBehaviour
{
    public void Save(HighScoreData data)                                                    //function responsible for saving the highscore to a file
    {
        try                                                                                 //try to run the following, if it cant then run the catch
        {
            string json = JsonUtility.ToJson(data);                                         //converts the data into a json format

            string path = Application.dataPath + "/highscore.txt";                          //give the data a location to save the file

            StreamWriter writer = new StreamWriter(path, false);                            //sets up the stream writer

            writer.Write(json);                                                             //write the data in json format to the txt file

            writer.Close();                                                                 //close the write so it can be accessed by other things
        }
        catch (System.Exception e)                                                          //if the try fails
        {
            Debug.LogError("Exception: " + e);                                              //log the exception
        }
    }
    public HighScoreData Load()                                                             //function responsible for loading the highscore from a file
    {
        try                                                                                 //try to run the following, if it cant then run the catch
        {
            string path = Application.dataPath + "/highscore.txt";                          //sets up the file location

            StreamReader reader = new StreamReader(path);                                   //sets up the stream reader

            string fileData = reader.ReadToEnd();                                           //read the whole file and put the data from the file into a varibale "fileData"

            HighScoreData data = JsonUtility.FromJson<HighScoreData>(fileData);             //converts the data back from json format into something unity can use

            //Always close the file
            reader.Close();                                                                 //closes the reader so that it can be accessed by other things

            return data;                                                                    //return the highscore data
        }
        catch (FileNotFoundException e)                                                     //if the try fails
        {
            Debug.LogError("No Save File: " + e);                                           //log the exception
            return new HighScoreData();                                                     //return the highscore data from that game
        }

    }

}
