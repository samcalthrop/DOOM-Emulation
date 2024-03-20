using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int health;

    public int maxArmour;
    private int armour;

    void Start()
    {
        health = maxHealth;
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

    public void GiveHealth(int amount, GameObject pickup)
    {
        if (health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void GiveArmour(int amount, GameObject pickup)
    {
        if (armour < maxArmour)
        {
            armour += amount;
            Destroy(pickup);
        }

        if (armour > maxArmour)
        {
            armour = maxArmour;
        }
    }
}
