using System.Collections;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{    
    [SerializeField] WeaponSO WeaponSO;
    [SerializeField] Animator FireAnim;
    [SerializeField] string  SHOOT_String;
    [SerializeField] ParticleSystem ShootFire;
    // [SerializeField] 

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
        if(Input.shoot && !bFire)
        {
            bFire = true;
            StartCoroutine(Fire());
        }
    }

    public IEnumerator Fire()
    {
        FireAnim.Play(SHOOT_String, 0, 0.0f);

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
        Enemy enemy = HitResult.collider.GetComponentInParent<Enemy>();
        if(!enemy) return;
        
        enemy.TakeDamage(DamageAmount);
    }
}
