using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem HitVFX;
    [SerializeField] float Speed = 2.0f;

    Rigidbody rb;

    int Damage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    public void Init(int Damage)
    {
        this.Damage = Damage;
        rb.linearVelocity = transform.forward * speed;
    }

}
