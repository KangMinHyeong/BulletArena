using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject EnemyPrefabs;
    [SerializeField] float SpawnRate = 4.0f;
    
    void Start()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while(Player)
        {
            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
