using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1, enemy2, enemy3;
    public GameObject exit;
    public float distance;
    public Text inforamtion;
    public Text textInf;
    public Text enemies;
    public Text time;

    private float timeCount = 0;
    private int count = 0;
    private int targets = 0;
    private bool isOpen = false;

    private void Update()
    {
        timeCount += Time.deltaTime;
        time.text = "Прошло времени: " + Mathf.Round(timeCount) + " секунд";
        inforamtion.text = "Мишеней уничтожено: " + targets + "/15";

        enemies.text = "Пауков убито: " + count;
        if (isOpen)
            textInf.text = "Найдите выход!";
        else
            textInf.text = "";

        distance = Vector3.Distance(player.transform.position, exit.transform.position);

        if (distance < 5)
            ShowWinScene();

        if (targets == 15 && !isOpen)
        {
            Destroy(GameObject.Find("Destroy"));
            isOpen = true;
        }
    }

    public void AddTarget()
    {
        targets += 1;
    }

    public void EnemySpawn()
    {
        count += 1;
        Vector3 position = new Vector3(Random.Range(-90, 144), 0.4f, Random.Range(144, -90));

        int num = Random.Range(0, 99);

        if (0 <= num && num <= 32)
        {
            Instantiate(enemy1, position, Quaternion.identity);
        }
        else if (33 <= num && num <= 65)
        {
            Instantiate(enemy2, position, Quaternion.identity);
        }
        else
        {
            Instantiate(enemy3, position, Quaternion.identity);
        }
    }

    public void ShowWinScene()
    {
        SceneManager.LoadScene("Win Scene");
    }
}
