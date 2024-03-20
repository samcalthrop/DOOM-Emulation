using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    private Transform target;

    void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        transform.LookAt(target);
    }
}
