using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs Input;

    bool bFire = false;

    void Start()
    {
        Input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        if(Input.shoot && bFire)
        {
            bFire = true;
            StartCoroutine();
        }
    }

    void 

}
