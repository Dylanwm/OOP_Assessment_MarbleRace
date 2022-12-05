using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PowerUp                                                              //inheritance from "PowerUp" script
{
    [SerializeField] protected float _speed;                                                //sets up a float thatll change the speed of the marble

    protected override void PowerUpActivate(GameObject marble)                              //function responsible for speeding up the marble
    {
        Rigidbody rb = marble.GetComponent<Rigidbody>();                                    //gets the rigid body from the marble

        if (!rb) return;                                                                    //if the marble doesnt have a rigid body then return
        rb.AddForce(rb.velocity.normalized * _speed, ForceMode.VelocityChange);             //speeds up the marble


    }
}
