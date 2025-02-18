using System.Collections;
using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float RapidSpeed = 0.2f;

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
            StartCoroutine(Fire());
        }
    }

    public IEnumerator Fire()
    {

        yield return new WaitForSeconds(RapidSpeed);
        bFire = false;
    }

}
