using UnityEngine;

public class Timer
{

    private float startTime = -1f;                                          //sets up a float to hold the start time

    public void StartTimer()                                                //function responsible for saving the start time
    {
        startTime = Time.time;                                              //saves the time the game started into varibale "startTime"
    }

    public float StopTimer()                                                //function responsible for saving the time the game stopped and figuring out the total time
    {
        // Score = elapsed time (less is more)
        float score = Time.time - startTime;                                //the current time subtract the start time equals the score
        startTime = -1f;                                                    //reset the "startTime" variable
        return score;                                                       //return the time
    }
}
