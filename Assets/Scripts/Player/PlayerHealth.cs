using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int minHealth = 0;
    public SimpleHealthBar healthBar;
    public Text health;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.GetComponent<Image>().color = Color.green;
        healthBar.UpdateBar(currentHealth, maxHealth);
        health.text = Mathf.Round(currentHealth) + "/" + maxHealth;
    }

    /*private void Update()
    {
        healthBar.UpdateBar(currentHealth, maxHealth);
    }*/

    public void SetDamage(int damage)
    {
        currentHealth -= damage*Time.deltaTime;

        if (currentHealth <= minHealth)
        {
            currentHealth = 0;
            Death();
        }

        UpdateInformation();
    }

    private void UpdateInformation()
    {
        if (66 <= currentHealth && currentHealth <= 100)
            healthBar.GetComponent<Image>().color = Color.green;
        else if (33 <= currentHealth && currentHealth < 66)
            healthBar.GetComponent<Image>().color = Color.yellow;
        else
            healthBar.GetComponent<Image>().color = Color.red;

        health.text = Mathf.Round(currentHealth) + "/" + maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
    }

    private void Death()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void Heal()
    {
        currentHealth += 10;

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;

        UpdateInformation();

    }

}
