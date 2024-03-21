using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator doorAnim;
    public GameObject areaToSpawn;

    public bool requiresKey;
    public bool reqRed, reqPurple, reqBlue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (requiresKey)
            {
                if (reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    // open door
                    doorAnim.SetTrigger("OpenDoor");

                    // spawn enemies in area
                    areaToSpawn.SetActive(true);
                }
                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }
                if (reqPurple && other.GetComponent<PlayerInventory>().hasPurple)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    areaToSpawn.SetActive(true);
                }
            } else
            {
                doorAnim.SetTrigger("OpenDoor");
                areaToSpawn.SetActive(true);
            }
        }
    }
}
