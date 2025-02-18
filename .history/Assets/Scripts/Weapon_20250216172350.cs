using System.Collections;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float RapidSpeed = 0.2f;

    GameObject RootObj;
    StarterAssetsInputs Input;
    bool bFire = false;


    void Start()
    {
        RootObj = Camera.main.GameObject();
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
        Physics.Raycast();
        yield return new WaitForSeconds(RapidSpeed);
        bFire = false;
    }

}
