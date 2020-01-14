using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet2(Clone)" || collision.gameObject.name == "Enemy(Clone)" 
            || collision.gameObject.name == "BackWall")
            Destroy(gameObject);
    }
}
