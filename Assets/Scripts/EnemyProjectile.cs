using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Wall (2)")
            Destroy(gameObject);
    }
}
