using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteEnemyHit : MonoBehaviour
{
    private GameObject enemy;
    private float distance;

    public void SetEnemy(GameObject e)
    {
        enemy = e;
    }

    private void Update()
    {
        distance = Vector3.Distance(enemy.transform.position, transform.position);

        if (enemy.GetComponent<Enemy>().isDead || distance > 4)
            Destroy(gameObject);
    }
}
