using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 8f;
    public bool isAggro;
    public Material aggroMaterial;
    private Transform playersTransform;


    private void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, playersTransform.position);

        if (distance > awarenessRadius)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            GetComponent<MeshRenderer>().material = aggroMaterial;
        }
    }
}
