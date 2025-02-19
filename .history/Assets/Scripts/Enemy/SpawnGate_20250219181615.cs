using System.Collections;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefabs;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] float SpawnRate = 4.0f;
    
    Player Player;

    void Start()
    {
        Player = FindAnyObjectByType<Player>();

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while(Player)
        {
            Instantiate(EnemyPrefabs, SpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
