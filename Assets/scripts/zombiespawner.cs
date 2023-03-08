using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiespawner : objecthealth
{
    public GameObject ZombiePrefab;
    public GameObject SpawnerExplosion;
    public float SpawnTime = 5;
    public float SpawnArea = 2;

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
        Bullet bullet = otherObject.GetComponent<Bullet>();
        int amount = bullet.Damage;
        SubtractHealth(amount);
        base.HandleCollision(otherObject);
    }
    public override void OnDeath()
    {
        Instantiate(SpawnerExplosion);
        Destroy(gameObject);
        base.OnDeath();
    }
}
