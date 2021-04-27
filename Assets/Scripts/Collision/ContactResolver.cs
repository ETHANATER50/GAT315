using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Collision
{
    public static class ContactResolver
    {
        public static void resolve(List<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                float totalInverseMass = contact.bodyA.inverseMass + contact.bodyB.inverseMass;
                Vector2 separation = contact.normal * contact.depth / totalInverseMass;
                contact.bodyA.position += separation * contact.bodyA.inverseMass;
                contact.bodyB.position -= separation * contact.bodyB.inverseMass;

                Vector2 relativeVelocity = contact.bodyA.velocity - contact.bodyB.velocity;
                float normalVelocity = Vector2.Dot(relativeVelocity, contact.normal);

                if (normalVelocity > 0) continue;

                float restitution = (contact.bodyA.restitution + contact.bodyB.restitution) * .5f;
                float  impulseMagnetude = -(1 + restitution) * normalVelocity / totalInverseMass;

                Vector2 impulse = contact.normal * impulseMagnetude;
                contact.bodyA.addForce(contact.bodyA.velocity + impulse * contact.bodyA.inverseMass, Body.forceMode.Velocity);
                contact.bodyB.addForce(contact.bodyB.velocity - impulse * contact.bodyB.inverseMass, Body.forceMode.Velocity);


            }
        }
    }
}
