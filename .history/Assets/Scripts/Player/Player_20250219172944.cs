using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera DestroyCamera;
    [SerializeField] Image HPBar;
    [SerializeField] GridLayoutGroup Grid;
    [SerializeField] int HP = 8;

    void Start()
    {
        UpdateHPBar(HP);
    }

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            DestroyCamera.Priority = 20;
        }
        
        UpdateHPBar(-Damage);
    }

    void UpdateHPBar(int Amount)
    {
        if(Amount > 0)
        {
            while(Amount != 0)
            {
                var newImage = Instantiate(HPBar, Grid.transform);
                newImage.transform.SetParent(Grid.transform, false); // 부모 설정
                
                Amount--;
            }
        }
        else if(Amount < 0)
        {
            while(Amount != 0)
            {
                int HPBarCount = Grid.transform.childCount;
                if(HPBarCount <= 0) break;

                var CurrentHPBar = Grid.transform.GetChild(HPBarCount - 1);
                Destroy(CurrentHPBar.gameObject);
                Amount++;
            }
        }
    }
}
