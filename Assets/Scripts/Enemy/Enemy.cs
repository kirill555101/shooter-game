using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour
{
    public int health { get; set; }
    public GameObject player;
    public float distance;
    public float Radius = 10;
    public AudioClip[] sounds;
    public bool isDead = false;

    private AudioSource source;
    private NavMeshAgent nav;
    private bool isStartMusic = false;

    public void SetDamage()
    {
        health -= 1;
        source.clip = sounds[3];
        source.Play();
        gameObject.GetComponent<Animator>().SetBool("Run Forward", false);
        gameObject.GetComponent<Animator>().SetTrigger("Idle");
        gameObject.GetComponent<Animator>().SetTrigger("Take Damage");
    }

    private void Start()
    {
        health = 4;
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
        nav = GetComponent<NavMeshAgent>();
    }

    private void Die()
    {
        source.clip = sounds[4];
        source.Play();
        GameObject.Find("World").GetComponent<World>().EnemySpawn();
        gameObject.GetComponent<Animator>().SetTrigger("Die");
    }

    private void Update()
    {

        if (isDead)
            return;

        if (health == 0 && !isDead)
        {
            Die();
            isDead = true;
            return;
        }

        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < Radius)
        {
            if (distance < 5.5f)
            {
                if (!source.isPlaying)
                {
                    if (!isStartMusic)
                    {
                        source.clip = sounds[0];
                        isStartMusic = true;
                    }
                    else
                    {
                        source.clip = sounds[1];
                        isStartMusic = false;
                    }

                    source.Play();
                }

                nav.enabled = false;
                gameObject.GetComponent<Animator>().SetBool("Run Forward", false);

                int num = Random.Range(0, 99);

                if (0 <= num && num <= 32)
                { 
                    gameObject.GetComponent<Animator>().SetTrigger("Idle");
                    gameObject.GetComponent<Animator>().SetTrigger("Stab Attack");
                    player.GetComponent<PlayerHealth>().SetDamage(5);
                }
                else if (33 <= num && num <= 65)
                {   
                    gameObject.GetComponent<Animator>().SetTrigger("Idle");
                    gameObject.GetComponent<Animator>().SetTrigger("Smash Attack");
                    player.GetComponent<PlayerHealth>().SetDamage(15);
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetTrigger("Idle");
                    gameObject.GetComponent<Animator>().SetTrigger("Cast Spell");
                    player.GetComponent<PlayerHealth>().SetDamage(7);
                }

                //GameObject.Find("World").GetComponent<World>().SetRunMusic(true);
            }
            else
            {
                isStartMusic = false;
                if (!source.isPlaying)
                {
                    source.clip = sounds[2];
                    source.Play();
                }

                gameObject.GetComponent<Animator>().SetTrigger("Idle");
                nav.enabled = true;
                nav.SetDestination(player.transform.position);
                gameObject.GetComponent<Animator>().SetBool("Run Forward", true);
            }
        }
        
        if (distance >= Radius)
        {
            //GameObject.Find("World").GetComponent<World>().SetRunMusic(false);
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
            gameObject.GetComponent<Animator>().SetBool("Run Forward", false);
            nav.enabled = false;
        }
    }
}
