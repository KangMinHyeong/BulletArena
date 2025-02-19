using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float ExplosionTime = 2.0f;
    [SerializeField] GameObject ExplosionVFX;

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

        Physics.OverlapSphere(ExplosionRadius);
    }
}
