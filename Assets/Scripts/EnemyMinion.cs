using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMinion : MonoBehaviour
{
    public GameObject enemyAttack;
    public float health = 2000f;

    public float lastAttack;
    public float attackDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastAttack > attackDelay)
        {
            lastAttack = Time.time;

            GameObject projectile = Instantiate(enemyAttack, transform.TransformPoint(0f, 0f, -1f), Quaternion.identity) as GameObject;
            projectile.GetComponent<Rigidbody>().AddForce(0, 0, -1500 * Time.deltaTime, ForceMode.VelocityChange);
        }

        if (health <= 0)
            Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet1(Clone)")
            health = health - 250f;
    }
}
