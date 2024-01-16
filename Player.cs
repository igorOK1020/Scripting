using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 10;
    public int maxHealth = 10;
    public int coins = 10;
    public GameObject fireballPrefab;
    public Transform attackPoint;

    //Компонент, отвечающий за проигрывание звуков
    public AudioSource audioSource;

    //Звуковой файл, содержащий звуковой эффект нанесения урона
    public AudioClip damageSound;

    //Метод, увеличивающий число монеток
    public void CollectCoins()
    {
        coins++;
        //print("Собранные монетки: " + coins);
    }

    //Метод, понижающий здоровье игрока
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health > 0)
        {
            audioSource.PlayOneShot(damageSound);

        }

        else
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, attackPoint.position, attackPoint.rotation);
        }
    }
}
