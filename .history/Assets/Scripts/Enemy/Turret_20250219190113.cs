using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
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
        yield return new WaitForSeconds()
    }
}
