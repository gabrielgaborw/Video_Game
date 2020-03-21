using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : MonoBehaviour
{
    public GameObject enemyAttack;
    public GameObject explosion;
    public float health = 2000f;

    public float lastAttack;
    public float attackDelay = 1f;

    // Update is called once per frame
    void Update()
    {
        // Enemy attack delay
        if (Time.time - lastAttack > attackDelay)
        {
            lastAttack = Time.time;

            GameObject projectile = Instantiate(enemyAttack, transform.TransformPoint(0f, 0f, -1f), Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody>().AddForce(0, 0, -1500 * Time.deltaTime, ForceMode.VelocityChange);
        }

        // Enemy health
        if (health <= 0)
        {
            // When health is at 0, the death animation will play, as well as adding score to the player
            explosion.transform.localPosition = gameObject.transform.localPosition;
            GameObject explode = Instantiate(explosion, explosion.transform.localPosition, Quaternion.identity);
            FindObjectOfType<PlayerScore>().AddScore();
            Destroy(gameObject);
        }

    }

    // Detects the collision with the player and the player's projectiles
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet1(Clone)")
            health = health - 250f;
        if (collision.gameObject.name == "Player")
            health = 0;
    }
}
