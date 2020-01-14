using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bullet;
    private float health = 100f;
    private Vector3 inputs = Vector3.zero;
    public GameObject explosion;

    private float lastAttack;
    public float attackDelay = 0.3f;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //------------MOVEMENT---------------
        inputs = Vector3.zero;
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = 0;
        inputs.z = Input.GetAxis("Vertical");
        //------------------------------------


        //----------------ATTACK--------------
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - lastAttack > attackDelay)
            {
                lastAttack = Time.time;

                GameObject projectile = Instantiate(bullet, transform.TransformPoint(2f, 0f, 8f), Quaternion.identity) as GameObject;
                projectile.GetComponent<Rigidbody>().AddForce(0, 0, 2500 * Time.deltaTime, ForceMode.VelocityChange);

                GameObject projectile2 = Instantiate(bullet, transform.TransformPoint(-2f, 0f, 8f), Quaternion.identity) as GameObject;
                projectile2.GetComponent<Rigidbody>().AddForce(0, 0, 2500 * Time.deltaTime, ForceMode.VelocityChange);
            }
        }
        //------------------------------------

        FindObjectOfType<Healthbar>().GetHealth(health);

        if (health <= 0)
        {
            explosion.transform.localPosition = gameObject.transform.localPosition;
            GameObject explode = Instantiate(explosion, explosion.transform.localPosition, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + inputs * speed * Time.deltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet2(Clone)")
            health = health - 10f;
        if (collision.gameObject.name == "Enemy(Clone)")
            health = 0;
    }
}
