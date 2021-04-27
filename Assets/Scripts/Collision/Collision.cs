using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class Collision
    {
        public static void createContacts(List<Body> bodies, out List<Contact> contacts)
        {
            contacts = new List<Contact>();

            for (int i = 0; i < bodies.Count - 1; i++)
            {
                for (int j = i + 1; j < bodies.Count; j++)
                {
                    Body bodyA = bodies[i];
                    Body bodyB = bodies[j];

                if (bodyA.type == Body.Type.Static && bodyB.type == Body.Type.Static) continue;

                Circle circleA = new Circle(bodyA.position, ((CircleShape)bodyA.shape).radius);
                Circle circleB = new Circle(bodyB.position, ((CircleShape)bodyB.shape).radius);


                    if (circleA.contains(circleB))
                    {
                        Contact c = new Contact() { bodyA = bodyA, bodyB = bodyB };
                        float distance = (circleA.center - circleB.center).magnitude;
                        c.depth = circleA.radius + circleB.radius - distance;
                        c.normal = (circleA.center - circleB.center).normalized;
                        contacts.Add(c);
                    }
                }
            }
        }
    }

