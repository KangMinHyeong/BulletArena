using UnityEngine;

public class Turret : MonoBehaviour
{
    Player Player;

    void Start()
    {
        Player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
