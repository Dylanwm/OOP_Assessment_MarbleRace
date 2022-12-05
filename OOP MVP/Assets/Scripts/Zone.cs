using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Polymorphism: a class instance can be treated as though they were any class that is inherited from.
//Abstract:instance of this class cant be created means
public abstract class Zone : MonoBehaviour
{
    protected bool isDeactivating = false;                                          //sets up a boolean under the varibale "isDeactivating"

    protected abstract void ZoneTrigger(GameObject marble);                         //triggers when a marble enters the zone it is associated with

    private void OnTriggerEnter(Collider other)                                     //triggers when marble collides
    {
        if (!gameObject.activeSelf) return;

        if (other.tag == "Marble")                                                  //if the object is tagged as a marble
        {
            ZoneTrigger(other.gameObject);                                          //trigger the Zonetrigger for the object
        }
    }


    protected IEnumerator DisableWithDelay(GameObject go, float delay, float returnDelay)                   //same name as function below but different parameters, fucntion responsible for disabling a game object for a set period of time
    {
        isDeactivating = true;                                                                              //set the boolean to true

        yield return new WaitForSeconds(delay);                                                             //return after a set timeframe
        go.SetActive(false);                                                                                //set the game object to false

        yield return new WaitForSeconds(returnDelay);                                                       //return after a set timeframe

        go.SetActive(true);                                                                                 //set the game object back to true once the timer is up

        isDeactivating = false;                                                                             //set the boolean back to false
    }
    protected IEnumerator DisableWithDelay(GameObject go, float delay = 1f)                                 //same function AS above but different parameters
    {
        isDeactivating = true;                                                                              //sets the boolean to true

        yield return new WaitForSeconds(delay);                                                             //return after the set timeframe
        go.SetActive(false);                                                                                //disable the game obect

        isDeactivating = false;                                                                             //set the boolean back to false
    }
}
