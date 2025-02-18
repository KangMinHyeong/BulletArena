using System.Collections;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{    
    [SerializeField] WeaponSO WeaponSO;
    [SerializeField] Animator FireAnim;
    [SerializeField] string  SHOOT_String;
    // [SerializeField] 

    StarterAssetsInputs Input;
    GameObject RootObj;
    GameObject CurrentWeaponMesh;
    ParticleSystem FireVFX;

    bool bFire = false;


    void Start()
    {
        RootObj = Camera.main.gameObject;
        Input = GetComponentInParent<StarterAssetsInputs>();
        InitWeapon();
    }

    void Update()
    {
        if(Input.shoot && !bFire)
        {
            bFire = true;
            StartCoroutine(Fire());
        }
    }
    
    void InitWeapon()
    {
        CurrentWeaponMesh = Instantiate(WeaponSO.WeaponMesh, transform);
        FireVFX = CurrentWeaponMesh.GetComponent<ParticleSystem>();
    }

    void SwitchWeapon(WeaponSO weaponSO)
    {
        this.WeaponSO = weaponSO;

        Destroy(CurrentWeaponMesh);
        InitWeapon();
    }

    IEnumerator Fire()
    {
        Debug.Log("sdf");
        // FireVFX.Play();
        FireAnim.Play(SHOOT_String, 0, 0.0f);

        RaycastHit HitResult;
        if(Physics.Raycast(RootObj.transform.position, RootObj.transform.forward, out HitResult, WeaponSO.WeaponDistance))
        {
            Instantiate(WeaponSO.HitVFX, HitResult.point, Quaternion.identity);
            HitEnemy(HitResult);
        }
        yield return new WaitForSeconds(WeaponSO.RapidSpeed);
        bFire = false;
    }

    void HitEnemy(RaycastHit HitResult)
    {
        Enemy enemy = HitResult.collider.GetComponentInParent<Enemy>();
        if(!enemy) return;
        
        enemy.TakeDamage(WeaponSO.DamageAmount);
    }
}
