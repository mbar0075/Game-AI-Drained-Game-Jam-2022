using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{   
    //To hold the AI Path
    [SerializeField] private AIPath aiPath;

    // Update is called once per frame
    private void Update()
    {
        //To make the enemy flip on the x axis
        if (aiPath.desiredVelocity.x >= 0.01f )
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x < 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }
}
