using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public struct Circle
    {
        public float radius;
        public Vector2 center;

        public Circle(Vector2 center, float radius)
        {
            this.radius = radius;
            this.center = center;
        }

        public bool contains(Circle c)
        {
            Vector2 direction = c.center - center;
            float squareDist = direction.sqrMagnitude;
            float squareRadius = (radius + c.radius) * (radius + c.radius);

            return squareDist <= squareRadius;
        }
    }
