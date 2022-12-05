using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : Zone                                                            //inheritance from "Zone" script
{
    protected abstract void PowerUpActivate(GameObject marble);

    protected override void ZoneTrigger(GameObject marble)                                      //triggers when a marble enters the same zone as the power up
    {
        if(isDeactivating == false)                                                             //if boolean isDeactivating is false
        {
            StartCoroutine(DisableWithDelay(gameObject, 0.2f , 2f));                            //runs "DisableWithDelay" function
        }

        PowerUpActivate(marble);                                                                //run the "PowerUpActivate" function on that marble
    }
}
