using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FirstAidKit : MonoBehaviour
{
    public AudioClip sound;
    public GameObject player;
    public float distance;

    private AudioSource source;
    private bool isHealed = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < 3 && !isHealed)
        {
            isHealed = true;
            player.GetComponent<PlayerHealth>().Heal();
            source.clip = sound;
            source.Play();
            Destroy(gameObject, 1);
        }
    }
}
