using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public bool isAggro;

    public Material aggroMaterial;

    private void Update()
    {
        if (isAggro)
        {
            GetComponent<MeshRenderer>().material = aggroMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            isAggro = true;
        }
    }
}
