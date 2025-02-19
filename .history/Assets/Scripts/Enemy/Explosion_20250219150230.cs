using UnityEngine;

public class Explosion : MonoBehaviour
{
    string CollisionEnabelTag = "Player";

    void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;

        if (tag != CollisionEnabelTag) return;
        
        Destroy(this.gameObject);

        HandlePickup(other);
    }
}
