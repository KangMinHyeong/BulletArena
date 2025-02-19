using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject ExplosionVFX;
    [SerializeField] float ExplosionTime = 2.0f;
    [SerializeField] float ExplosionRadius = 2.0f;
    [SerializeField] int ExplosionDamage = 10;

    string CollisionEnabelTag = "Player";

    void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;

        if (tag != CollisionEnabelTag) return;
        
        StartCoroutine(OnExplosion());
    }

    IEnumerator OnExplosion()
    {
        yield return new WaitForSeconds(ExplosionTime);

        Instantiate(ExplosionVFX, transform);

        var others = Physics.OverlapSphere(transform.position, ExplosionRadius);

        foreach(var other in others)
        {
            var tag = other.gameObject.tag;

            if (tag == CollisionEnabelTag) 
            {
                var Player = other.GetComponent<Player>();
                Player.TakeDamage(ExplosionDamage);
            }
        }
    }
}
