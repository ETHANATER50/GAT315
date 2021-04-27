using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGraphics : MonoBehaviour
{
    public AIPath aiPath;
    void Update()
    {
        if(aiPath.desiredVelocity.x >= .1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(aiPath.desiredVelocity.x <= .1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
