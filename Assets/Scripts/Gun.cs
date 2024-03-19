using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 20f;
    public float verticalRange = 20f;
    public float bigDamage = 2f;
    public float smallDamage = 1f;
    public float gunShotRadius = 20f;
    
    public float fireRate = 1f;
    private float nextTimetoFire;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;

    public LayerMask raycastLayerMask;
    public LayerMask enemyLayerMask;

    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * .5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimetoFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        // simulate gunshot radius
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

        // alert enemies in earshot (radius)
        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }

        // stop any previous audio + play audio
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();

        // damage enemy
        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            //get direction between player + enemy
            var direction = enemy.transform.position - transform.position;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    // deal damage based on range
                    float distance = Vector3.Distance(enemy.transform.position, transform.position);

                    if (distance > 0.5f * range)
                    {
                        enemy.TakeDamage(smallDamage);
                    } else
                    {
                        enemy.TakeDamage(bigDamage);
                    }

                    Debug.DrawRay(transform.position, direction, Color.white);
                }
            }
        }

        // reset timer
        nextTimetoFire = Time.time + fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        // add potential enemy to shoot
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // remove enemy
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemy(enemy);
        }
    }
}
