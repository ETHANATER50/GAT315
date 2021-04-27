using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxShape : Shape
{
    public override Type type => Type.Box;

    public override float size { get => transform.localScale.x; set => transform.localScale = Vector2.one * value; }

    public override float mass => density * size * size;

}
