using System.Collections;
using Cinemachine;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{    
    [SerializeField] WeaponSO WeaponSO;
    [SerializeField] Animator FireAnim;
    [SerializeField] string  SHOOT_String;
    [SerializeField] GameObject ZoomImage;
    // [SerializeField] 

    StarterAssetsInputs Input;
    GameObject RootObj;
    GameObject CurrentWeaponMesh;
    ParticleSystem FireVFX;
    CinemachineVirtualCamera CVCamera;


    bool bFire = false;
    bool ZoomCheck = false;
    float DefaultZoomAngle;


    void Start()
    {
        RootObj = Camera.main.gameObject;
        Input = GetComponentInParent<StarterAssetsInputs>();
        CVCamera = FindFirstObjectByType<CinemachineVirtualCamera>();
        DefaultZoomAngle = CVCamera.m_Lens.FieldOfView;
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
        FireVFX = CurrentWeaponMesh.GetComponentInChildren<ParticleSystem>();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        this.WeaponSO = weaponSO;

        Destroy(CurrentWeaponMesh);
        InitWeapon();
    }

    IEnumerator Fire()
    {
        FireVFX.Play();
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

    public void Zoom(InputAction.CallbackContext context)
    {
        if(!WeaponSO.bZoom) return;
        
        if(ZoomCheck)
        {
            CVCamera.m_Lens.FieldOfView = DefaultZoomAngle;
            ZoomCheck = false;
        }
        else
        {
            CVCamera.m_Lens.FieldOfView = WeaponSO.ZoomAngle;
            ZoomCheck = true;
        }

        ZoomImage.SetActive(ZoomCheck);
    }
}
