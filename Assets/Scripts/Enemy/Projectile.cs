using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem HitVFX;
    [SerializeField] float Speed = 2.0f;

    Rigidbody rb;
    int Damage;

    public void Init(int Damage)
    {
        this.Damage = Damage;

        rb = GetComponentInChildren<Rigidbody>();
        rb.linearVelocity = transform.forward * Speed;
    }

    void OnTriggerEnter(Collider other)
    {
        Player Player = other.GetComponentInParent<Player>();
        Player?.TakeDamage(Damage);

        Instantiate(HitVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
