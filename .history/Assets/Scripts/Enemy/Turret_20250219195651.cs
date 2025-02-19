using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] Transform ProjectileSpwanPoint;

    [SerializeField] float FireRate = 3.0f;
    [SerializeField] int Damage = 1;

    Player Player;
    Transform PlayerPoint;

    void Start()
    {
        Player = FindAnyObjectByType<Player>();
        StartCoroutine(SpawnProjectile());
    }

    void Update()
    {
        transform.LookAt(PlayerPoint.transform);
    }

    IEnumerator SpawnProjectile()
    {
        while(Player)
        {
            var Projectile = Instantiate(ProjectilePrefab, ProjectileSpwanPoint.position, Quaternion.identity).GetComponent<Projectile>();
            
            Projectile.transform.LookAt(PlayerPoint.transform);
            Projectile.Init(Damage);

            yield return new WaitForSeconds(FireRate);
        }
    }
}
