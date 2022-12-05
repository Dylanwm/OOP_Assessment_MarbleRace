using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : Zone                                               //inheritance from "Zone" script
{
    protected static List<GameObject> _dead;
    protected void Start()                                           
    {
        if (_dead == null)                                                  //if a list doesnt exist then do the following
        {
            _dead = new List<GameObject>();                                 //create a list under the variable "_dead"
        }
    }
    protected override void ZoneTrigger(GameObject marble)                  //triggers when marble enters the zone, 
    {
        if (!_dead.Contains(marble))                                        //if the marble is in the not dead list
        {
            _dead.Add(marble);                                              //add to the dead list
        }
        marble.SetActive(false);                                            //set the marble to false, basically destroy the marble
    }
}
