using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] ParticleSystem HitVFX;

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
    }

}
