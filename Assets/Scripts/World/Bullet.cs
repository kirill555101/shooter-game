using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Live = 5.0f;
    public float Timer = 0f;
    public GameObject hitMetal;
    public GameObject hitEnemy;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        switch(collision.gameObject.name)
        {
            case "Enemy1 Variant":
                collision.gameObject.GetComponent<Enemy>().SetDamage();
                if (collision.gameObject.GetComponent<Enemy>().health == 0)
                    break;

                GameObject hitE1 = Instantiate<GameObject>(hitEnemy);
                hitE1.GetComponent<DeleteEnemyHit>().SetEnemy(collision.gameObject);
                hitE1.transform.position = contact.point + contact.normal * 0.01f;
                Destroy(hitE1, 7);
                hitE1.transform.rotation = Quaternion.LookRotation(-contact.normal);
                break;

            case "Enemy2 Variant":
                collision.gameObject.GetComponent<Enemy>().SetDamage();
                if (collision.gameObject.GetComponent<Enemy>().health == 0)
                    break;

                GameObject hitE2 = Instantiate<GameObject>(hitEnemy);
                hitE2.GetComponent<DeleteEnemyHit>().SetEnemy(collision.gameObject);
                hitE2.transform.position = contact.point + contact.normal * 0.01f;
                Destroy(hitE2, 7);
                hitE2.transform.rotation = Quaternion.LookRotation(-contact.normal);
                break;

            case "Enemy3 Variant":
                collision.gameObject.GetComponent<Enemy>().SetDamage();
                if (collision.gameObject.GetComponent<Enemy>().health == 0)
                    break;

                GameObject hitE3 = Instantiate<GameObject>(hitEnemy);
                hitE3.GetComponent<DeleteEnemyHit>().SetEnemy(collision.gameObject);
                hitE3.transform.position = contact.point + contact.normal * 0.01f;
                Destroy(hitE3, 7);
                hitE3.transform.rotation = Quaternion.LookRotation(-contact.normal);
                break;

            case "Enemy1 Variant(Clone)":
                collision.gameObject.GetComponent<Enemy>().SetDamage();
                if (collision.gameObject.GetComponent<Enemy>().health == 0)
                    break;

                GameObject hitE1C = Instantiate<GameObject>(hitEnemy);
                hitE1C.GetComponent<DeleteEnemyHit>().SetEnemy(collision.gameObject);
                hitE1C.transform.position = contact.point + contact.normal * 0.01f;
                Destroy(hitE1C, 7);
                hitE1C.transform.rotation = Quaternion.LookRotation(-contact.normal);
                break;

            case "Enemy2 Variant(Clone)":
                collision.gameObject.GetComponent<Enemy>().SetDamage();
                if (collision.gameObject.GetComponent<Enemy>().health == 0)
                    break;

                GameObject hitE2C = Instantiate<GameObject>(hitEnemy);
                hitE2C.GetComponent<DeleteEnemyHit>().SetEnemy(collision.gameObject);
                hitE2C.transform.position = contact.point + contact.normal * 0.01f;
                Destroy(hitE2C, 7);
                hitE2C.transform.rotation = Quaternion.LookRotation(-contact.normal);
                break;

            case "Enemy3 Variant(Clone)":
                collision.gameObject.GetComponent<Enemy>().SetDamage();
                if (collision.gameObject.GetComponent<Enemy>().health == 0)
                    break;

                GameObject hitE3C = Instantiate<GameObject>(hitEnemy);
                hitE3C.GetComponent<DeleteEnemyHit>().SetEnemy(collision.gameObject);
                hitE3C.transform.position = contact.point + contact.normal * 0.01f;
                Destroy(hitE3C, 7);
                hitE3C.transform.rotation = Quaternion.LookRotation(-contact.normal);
                break;

            case "Wall":
                GameObject hitM = Instantiate<GameObject>(hitMetal);
                hitM.transform.position = contact.point + contact.normal * 0.01f;
                Destroy(hitM, 7);
                hitM.transform.rotation = Quaternion.LookRotation(-contact.normal);
                break;

            case "Target":
                Destroy(collision.gameObject);
                GameObject.Find("World").GetComponent<World>().AddTarget();
                break;
        }

        Destroy(gameObject);
    }   

    void Update()
    {
        Timer += Time.deltaTime;
        if (Live <= Timer)
        {
            Destroy(gameObject);
        }
    }
}
