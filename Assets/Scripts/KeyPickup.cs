using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public bool isRedKey, isBlueKey, isPurpleKey;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isRedKey && !other.GetComponent<PlayerInventory>().hasRed)
            {
                other.GetComponent<PlayerInventory>().hasRed = true;
                Destroy(gameObject);
            }
            if (isBlueKey && !other.GetComponent<PlayerInventory>().hasBlue)
            {
                other.GetComponent<PlayerInventory>().hasBlue = true;
                Destroy(gameObject);
            }
            if (isPurpleKey && !other.GetComponent<PlayerInventory>().hasPurple)
            {
                other.GetComponent<PlayerInventory>().hasPurple = true;
                Destroy(gameObject);
            }
        }
    }
}
