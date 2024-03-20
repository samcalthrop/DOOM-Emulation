using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int health;

    public int maxArmour = 50;
    private int armour;

    void Start()
    {
        health = maxHealth;
        armour = maxArmour;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            DamagePlayer(30);
            Debug.Log("-30 health");
        }
    }

    public void DamagePlayer(int damage)
    {
        if (armour > 0)
        {
            if (armour >= damage)
            {
                armour -= damage;
            } else if (armour < damage)
            {
                int remainingDamage;
                remainingDamage = damage - armour;
                armour = 0;

                health -= remainingDamage;
            }
        } else
        {
            health -= damage;
        }

        if (health <= 0)
        {
            Debug.Log("player died");

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }
}
