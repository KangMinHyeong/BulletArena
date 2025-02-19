using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
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

            yield return new WaitForSeconds();
        }
    }
}
