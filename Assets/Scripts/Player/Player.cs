using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera DestroyCamera;
    [SerializeField] int HP = 50;

    void TakeDamage(int Damage)
    {
        HP -= Damage;
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            DestroyCamera.Priority = 20;
        }
    }
}
