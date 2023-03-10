using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiehealth : objecthealth
{
    public GameObject ZombieRemains;
    public GameObject ZombieExplosion;

    public override void HandleCollision(GameObject otherObject)
    {
        if (otherObject.gameObject.CompareTag("Bullet"))
        {
            Bullet bulletdamage= otherObject.GetComponent<Bullet>();
            int amount = bulletdamage.Damage;
            SubtractHealth(amount);
        }
            base.HandleCollision(otherObject);
    }
    public override void OnDeath()
    {
        Instantiate(ZombieRemains,transform.position, Quaternion.identity);
        Instantiate(ZombieExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        base.OnDeath();
    }
}

