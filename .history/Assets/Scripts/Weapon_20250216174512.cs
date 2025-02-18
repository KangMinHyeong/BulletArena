using System.Collections;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{    
    [SerializeField] float WeaponDistance = 2000.0f;
    [SerializeField] float RapidSpeed = 0.2f;
    [SerializeField] int DamageAmount = 10;
    
    StarterAssetsInputs Input;
    GameObject RootObj;
    bool bFire = false;


    void Start()
    {
        RootObj = Camera.main.gameObject;
        Input = GetComponentInParent<StarterAssetsInputs>();
    }

    void Update()
    {
        if(Input.shoot) Debug.Log("what");
        if(Input.shoot && !bFire)
        {
            Debug.Log("dsdfs");
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
