using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    public Collision2D collision; [HideInInspector]
    public bool colliding = false; [HideInInspector]
    // Use this for initialization
    void OnCollisionStay2D(Collision2D collisionInfo)
    {
        collision = collisionInfo;

    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        collision = collisionInfo;
        colliding = true;
    }
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        colliding = false;
    }
}
