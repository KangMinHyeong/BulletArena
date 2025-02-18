using System.Collections;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float WeaponDistance = 2000.0f;
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
        RaycastHit HitResult;
        if(Physics.Raycast(RootObj.transform.position, RootObj.transform.forward, out HitResult, WeaponDistance))
        {
            HitEnemy(HitResult);
        }
        yield return new WaitForSeconds(RapidSpeed);
        bFire = false;
    }

    void HitEnemy(RaycastHit HitResult)
    {
        Enemy enemy = HitResult.collider.GetComponent<Enemy>();
        if(!enemy) return;
        
        enemy.TakeDamage(DamageAmount);
    }

}
