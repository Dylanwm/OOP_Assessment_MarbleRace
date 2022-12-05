using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]                                                                   //allows data to be broken up/serialized and saved
public class HighScoreData
{
    public float score;                                                                 //creates a float variable thatll hold the score

    // constructor (same name as class and no return type)
    public HighScoreData()                                                              //a constructor,usually has the same name as a class but no return type
    {
        score = float.MaxValue;                                                         //sets the float to max value so that almost any score will beat it. (low = good, like golf)
    }

    public HighScoreData(float prevScore)                                               
    {
        score = prevScore;                                                              //sets the current score to the previous score
    }

    public void SubmitScore(float newScore)                                             //function responsible for submitting the score if it beat the old score
    {
        if (newScore < score)                                                           //if the new score is lower (better) then the current score run the following
        {
            score = newScore;                                                           //current highscore equals new highscore
        }
    }
}
