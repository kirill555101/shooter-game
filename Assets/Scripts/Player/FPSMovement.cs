using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FPSMovement : MonoBehaviour
{
    public float _speed = 6.0F;
    public float _jumpSpeed = 8.0F;
    public float _gravity = 20.0F;
    public AudioClip[] clips;

    private AudioSource source;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
            Debug.Log("Controllet is null");
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
        source.clip = clips[0];
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            moveDirection = new Vector3(hor, 0, ver);
            moveDirection = transform.TransformDirection(moveDirection);

            if (!Input.GetKey(KeyCode.LeftShift))
            {
                moveDirection *= _speed;
                source.clip = clips[0];
            }
            else
            {
                source.clip = clips[1];
                moveDirection *= (3 * _speed);
            }

            bool jump;
            if (jump = Input.GetButton("Jump"))
            {
                moveDirection.y = _jumpSpeed;
                source.Stop();
            }

            if (ver != 0 || hor!=0)
            {
                if (!source.isPlaying)
                {
                    if (!jump)
                    {
                        source.Play();
                    }
                }
            }
            else source.Stop();
        }

        moveDirection.y -= _gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
