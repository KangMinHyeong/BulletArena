using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera DestroyCamera;
    [SerializeField] Image HPBar;
    [SerializeField] int HP = 8;

    void Start()
    {

    }

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            DestroyCamera.Priority = 20;
        }
        
        UpdateHPBar(Damage);
    }

    void UpdateHPBar()
    {

    }
}
