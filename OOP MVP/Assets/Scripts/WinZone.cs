using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinZone : Zone                                                     
{
    [SerializeField] protected Text _winnerText;                                //sets up the text box on the canvas for the winner text
    protected static List<GameObject> _winners;                                 //sets up a list thatll hold the name of the marbles that "win"

    public HighScoreManager highScore;                                          //gets the "HighScoreManager" script and saves it in the varible "highScore"

    private bool _isFirst = true;                                               //sets a default true boolean up

    protected void Start()
    {
        _isFirst = true;                                                        //sets boolean to true just in case

        if (_winners == null)                                                   //if there is no winners list run the following
        {
            _winners = new List<GameObject>();                                  //creates a new winners list
        }

        _winnerText.text = "";                                                  //set the "_winnerText" to display nothing

        if (highScore == null)                                                  //if "HighScoreManager" script isnt saved to the "highScore" variable
        {
            highScore = FindObjectOfType<HighScoreManager>();                   //find the script and save it to the variable
        }
    }
    protected void DisplayWinningText(string marbleName)                        //fucntion responsible for displaying the winning marbles "names"
    {
        _winnerText.text += marbleName + "\n";                                  //display the marble name and enter a new line
    }

    protected override void ZoneTrigger(GameObject marble)                      //triggers when a marble enters the zone associated with this function
    {
        if(_isFirst)                                                            //for the first marble, run the following. if "_isFirst" is set to true, run the following
        {
            StartCoroutine(DisplayListWithDelay());                             //run the function "DisplayListWithDelay"
        }
        _isFirst = false;                                                       //sets boolean to false

        if (!_winners.Contains(marble))                                         //if the not winners list contains the marble
        {
            _winners.Add(marble);                                               //add the marble to the winners list
        }

        StartCoroutine(DisableWithDelay(marble, 3f));                           //runs the function "DisableWithDelay" for 3 seconds

        highScore.GameWon();                                                    //runs the GameWon function from the "HighScoreManbager script
    }


    protected IEnumerator DisplayListWithDelay()                                //function responsible for displaying the winners list with a delay
    {
        yield return new WaitForSeconds(3f);                                    //wait for 3 seconds

        for (int i = 0; i < _winners.Count; i++)                                //for ever winner
        {
            DisplayWinningText(_winners[i].name);                               //run the "DisplayWinningText function with the winners name
        }
    }
}
