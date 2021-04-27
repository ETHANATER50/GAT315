using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShape : Shape
{
    public override Type type => Type.Circle;

    public float radius { get => size * .5f; }
    public override float size { get => transform.localScale.x; set => transform.localScale = Vector2.one * value; }

    public override float mass => density * (Mathf.PI * (radius * radius));

}
