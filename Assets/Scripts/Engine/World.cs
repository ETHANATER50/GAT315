using Assets.Scripts.Collision;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public BoolData simulate;
    public FloatData gravity;
    public FloatData fps;
    public FloatData gravitation;
    public StringData fpsText;
    public BoolData collision;
    public BoolData wrap;

    private Vector2 size;

    static World instance;
    static float timeAccumulator = 0;
    public float fixedDT { get { return 1f / fps.value; } }

    public static World Instance { get { return instance; } }

    public Vector2 Gravity { get { return new Vector2(0, gravity.value); } }
    public List<Body> bodies { get; set; } = new List<Body>();
    public List<Spring> springs { get; set; } = new List<Spring>();

    private void Awake()
    {
        instance = this;
        size = Camera.main.ViewportToWorldPoint(Vector2.one);
    }

    void Update()
    {
        Debug.Log($"system fps:{1.0f / Time.deltaTime}");
        Debug.Log($"fixed fps:{1.0f / fixedDT}");

        fpsText.value = $"FPS: {(1.0f / Time.deltaTime).ToString("F1")}";

        if (!simulate)
        {
            return;
        }

        float dt = Time.deltaTime;
        timeAccumulator += dt;

        GravitationalForce.ApplyForce(bodies, gravitation);
        springs.ForEach(spring => spring.applyForce());

        while (timeAccumulator >= fixedDT)
        {
            bodies.ForEach(body => body.step(fixedDT));
            bodies.ForEach(body => Integrator.semiImplicitEuler(body, fixedDT));

            bodies.ForEach(body => body.shape.color = Color.red);

            if (collision)
            {
                Collision.createContacts(bodies, out List<Contact> contacts);
                ContactResolver.resolve(contacts);

                contacts.ForEach(contact => contact.bodyA.shape.color = Color.cyan);
                contacts.ForEach(contact => contact.bodyB.shape.color = Color.cyan);
            }
            if (wrap) { bodies.ForEach(body => body.position = Utilities.wrap(body.position, -size, size)); }

            timeAccumulator -= fixedDT;
        }
        bodies.ForEach(body => body.force = Vector2.zero);
        bodies.ForEach(body => body.acceleration = Vector2.zero);
    }

}
