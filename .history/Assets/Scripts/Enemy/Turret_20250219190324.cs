using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] Transform ProjectileSpwanPoint;
    [SerializeField] float FireRate = 3.0f;

    Player Player;

    void Start()
    {
        Player = FindAnyObjectByType<Player>();
        StartCoroutine(SpawnProjectile());
    }

    void Update()
    {
        transform.LookAt(Player.transform);
    }

    IEnumerator SpawnProjectile()
    {
        while(Player)
        {
            Instantiate(ProjectilePrefab, ProjectileSpwanPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(FireRate);
        }
    }
}
