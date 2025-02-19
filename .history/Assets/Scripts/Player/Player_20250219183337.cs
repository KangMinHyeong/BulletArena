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
        UpdateHPBar(-Damage);

        HP -= Damage;
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            DestroyCamera.Priority = 20;
        }   
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
            int HPBarCount = Grid.transform.childCount;
            while(Amount != 0)
            {
                if(HPBarCount <= 0) break;

                Debug.Log(HPBarCount.ToString());
                var CurrentHPBar = Grid.transform.GetChild(--HPBarCount);
                Destroy(CurrentHPBar.gameObject);
                Amount++;
            }
        }
    }
}
