using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiespawner : objecthealth
{
    public GameObject ZombiePrefab;
    public GameObject ZombieExplosion;
    public float SpawnTime = 5;
    public float SpawnArea = 2;
    public int amount;
    public int MaxZombiesToSpawn = 10;
    int numberOfZombiesSpawned;

    private void Start()
    {
        InvokeRepeating("SpawnZombie", 2, 5);
    }
    void SpawnZombie()
    {
        Vector3 randomPosition = Random.insideUnitCircle * SpawnArea;

        Instantiate(ZombiePrefab, transform.position + randomPosition, Quaternion.identity);
        numberOfZombiesSpawned++;

        if (numberOfZombiesSpawned >= MaxZombiesToSpawn)
        {
            CancelInvoke("SpawnZombie");
        }
    }
    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.CompareTag("Bullet"))
        {
            Bullet bullet = otherObject.GetComponent<Bullet>();
            amount = bullet.Damage;
            SubtractHealth(bullet.Damage);
        }
        base.HandleCollision(otherObject);
    }
    public override void OnDeath()
    {
        Instantiate(ZombieExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        base.OnDeath();
    }
}
