using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public Body bodyA { get; set; } = null;
    public Body bodyB { get; set; } = null;

    public float restLength { get; set; } = 0;
    public float k { get; set; } = 20f;

    public void applyForce()
    {
        Vector2 force = Utilities.springForce(bodyA.position, bodyB.position, restLength, k);

        bodyA.addForce(-force);
        bodyB.addForce(force);
    }
}
