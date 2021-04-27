using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public enum forceMode
    {
        Force,
        Acceleration,
        Velocity
    }

    public enum Type
    {
        Static,
        Kinematic,
        Dynamic
    }

    public Shape shape; 

    public Type type { get; set; }
    public Vector2 force { get; set; } = Vector2.zero;
    public Vector2 acceleration { get; set; } = Vector2.zero;
    public Vector2 velocity { get; set; } = Vector2.zero;
    public Vector2 position { get { return transform.position; } set { transform.position = value; } }
    public float mass { get => shape.mass; }
    public float inverseMass { get => (mass == 0) ? 0 : 1 / mass; }
    public float damping { get; set; } = 0;
    public float restitution { get; set; } = .5f;


    public void addForce(Vector2 force, forceMode fm = forceMode.Force)
    {
        if (type != Type.Static)
        {
            switch (fm)
            {
                case forceMode.Force:
                    this.force += force;
                    break;
                case forceMode.Acceleration:
                    acceleration = force;
                    break;
                case forceMode.Velocity:
                    velocity = force;
                    break;
                default:
                    break;
            }
        }

    }

    public void step(float dt)
    {
        if (type == Type.Dynamic)
        {
            acceleration = World.Instance.Gravity + force * inverseMass;
        }
    }
}
