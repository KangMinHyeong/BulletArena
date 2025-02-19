using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject ProjectilePrefab;
    [SerializeField] Transform ProjectileSpwanPoint;
    [SerializeField] Transform PlayerPoint;
    [SerializeField] float FireRate = 3.0f;

    Player Player;

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
            Instantiate(ProjectilePrefab, ProjectileSpwanPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(FireRate);
        }
    }
}
