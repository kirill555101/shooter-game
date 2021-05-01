using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Shoot : MonoBehaviour
{
    public int AmmoCount; //Патронов в обоймах
    public int CurAmmo; //Кол-во патроеов
    public int Ammo; //Кол-во патронов в 1ой обойме
    public float ShootSpeed; // Скорострельность
    public float ReloadSpeed; // Скорость Перезарядки
    public float ReloadTimer = 0.0f; // Время перезарядки(НЕ ТРОГАТЬ|НЕ МЕНЯТЬ)
    public float ShootTimer = 0.0f; // Время выстрела(НЕ ТРОГАТЬ|НЕ МЕНЯТЬ
    public Transform bullet; // Патрон
    public AudioClip[] clips;
    public Text message;
    public Text extramessage;

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
        source.loop = false;
    }

    private void Update()
    {
        message.text = "Патроны: " + CurAmmo + "/" + Ammo;
        if (CurAmmo == 0) extramessage.text = "Для перезарядки нажмите R";
        else extramessage.text = "";
        if (Input.GetMouseButtonDown(0) && CurAmmo > 0 && ReloadTimer <= 0 && ShootTimer <= 0)
        {
            Transform BulletInstance = (Transform)Instantiate(bullet, transform.position, transform.rotation);
            BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
            CurAmmo -= 1;

            source.clip = clips[0];
            source.Play();

            ShootTimer = ShootSpeed;
        } 

        if (ShootTimer > 0)
        {
            ShootTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadTimer = ReloadSpeed;
            CurAmmo = Ammo;

            source.clip = clips[1];
            source.Play();

            if (ShootTimer > 0)
            {
                    ShootTimer -= Time.deltaTime;
            }

        }

        if (ReloadTimer > 0)
        {
            ReloadTimer -= Time.deltaTime;
        }
    }
}
