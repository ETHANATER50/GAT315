using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Integrator
{
    public static void exlpicitEuler(Body body, float dt)
    {
        body.position += body.velocity * dt;
        body.velocity += body.acceleration * dt;
        body.velocity *= 1f / (1f + (body.damping * dt));
    }

    public static void semiImplicitEuler(Body body, float dt)
    {
        body.velocity += body.acceleration * dt; // acceleration calculated in Body.cs
        body.position += body.velocity * dt;
        body.velocity *= 1f / (1f + (body.damping * dt)); // figured I should include dampening
    }
}
