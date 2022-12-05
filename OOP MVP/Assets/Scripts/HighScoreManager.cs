using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    private HighScoreData highScore;                                            //the variable "highScore" contains the "HighScoreData" script
    public Text score;                                                          //contains the score
    private Timer timer;                                                        //contains the timer script
    public SaveHighScoreToFile saveSystem;                                      //contains the "SaveHighScoreToFile" script

    void Start()
    {
        timer = new Timer();                                                    //creates a new timer

        highScore = saveSystem.Load();                                          //runs the "Load" function from the "SaveHighScoreToFile" script and contains it in the "highScore" variable
        score.text = "High Score = " + highScore.score;                         //displays the highscore in the score text

        GameStarted();                                                          //runs the "GameStarted" function below
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))                                        //if key "x" is pressed do the following
        {
            saveSystem.Save(highScore);                                         //save the highscore
        }
    }

    void GameStarted()                                                          //function responsible for starting the time when the game starts
    {
        timer.StartTimer();                                                     //run the "StartTimer" function from the timer script
    }

    public void GameWon()                                                       //fucntion responsible for stoping the timer, setting the score and highscore aswell
    {
        float timerScore = timer.StopTimer();                                   //run the "StopTimer" fucntion from the "Timer" script and save it to the "timerScore" variable 

        highScore.SubmitScore(timerScore);                                      //run the SubmitScore function, 

        score.text = "High Score = " + highScore.score;                         //displau the highscore in the highscore text box on the canvas
    }

}

