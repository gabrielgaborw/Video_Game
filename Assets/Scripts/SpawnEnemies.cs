using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject Enemy;
    public int xPos;
    public int enemyCount;
    private int previousPos;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (true)
        {
            // Prevents the enemies from spawning out of bounds
            xPos = Random.Range(-15, 15);
            if (previousPos > xPos + 2 || previousPos < xPos + 2)
            {
                Instantiate(Enemy, new Vector3(xPos, 1, -2), Quaternion.identity);
                yield return new WaitForSeconds(5f);
                enemyCount += 1;
            }
            previousPos = xPos;
        }
    }
}
