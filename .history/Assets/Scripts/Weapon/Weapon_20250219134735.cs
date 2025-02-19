using System.Collections;
using Cinemachine;
using StarterAssets;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{    
    [SerializeField] WeaponSO WeaponSO;
    [SerializeField] Animator FireAnim;
    [SerializeField] string  SHOOT_String;
    [SerializeField] GameObject ZoomImage;

    StarterAssetsInputs Input;
    GameObject RootObj;
    GameObject CurrentWeaponMesh;
    ParticleSystem FireVFX;
    CinemachineVirtualCamera CVCamera;
    FirstPersonController firstPersonController;
    CinemachineCollisionImpulseSource ImpulseSource;

    bool bFire = false;
    bool ZoomCheck = false;
    float DefaultZoomAngle;
    float DefaultRotationSpeed;
    int CurrentAmmo;

    void Awake()
    {
        Input = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
    }

    void Start()
    {
        RootObj = Camera.main.gameObject;
        CVCamera = FindFirstObjectByType<CinemachineVirtualCamera>();

        DefaultZoomAngle = CVCamera.m_Lens.FieldOfView;
        DefaultRotationSpeed = firstPersonController.RotationSpeed;

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
        // Component Init
        CurrentWeaponMesh = Instantiate(WeaponSO.WeaponMesh, transform);
        FireVFX = CurrentWeaponMesh.GetComponentInChildren<ParticleSystem>();
        ImpulseSource = CurrentWeaponMesh.GetComponentInChildren<CinemachineCollisionImpulseSource>();

        // Camera Init
        CVCamera.m_Lens.FieldOfView = DefaultZoomAngle;
        ZoomCheck = false;
        firstPersonController.ChangeRotationSpeed(DefaultRotationSpeed);
        ZoomImage.SetActive(ZoomCheck);

        // Ammo Init
        CurrentAmmo = WeaponSO.DefaultAmmo;
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        this.WeaponSO = weaponSO;
        
        Destroy(CurrentWeaponMesh);
        InitWeapon();
    }

    public void UpdateAmmo(int AmmoAmount)
    {
        CurrentAmmo = Mathf.Clamp(CurrentAmmo + AmmoAmount , 0, WeaponSO.DefaultAmmo);
        Debug.Log("%d", CurrentAmmo);
    }

    IEnumerator Fire()
    {
        // Ammo Check
        if(CurrentAmmo <= 0) yield break;
        UpdateAmmo(-1);

        // Shoot Effect
        FireVFX.Play();
        FireAnim.Play(SHOOT_String, 0, 0.0f);
        ImpulseSource.GenerateImpulse();

        // Hit Check
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

    public void Zoom()
    {
        if(!WeaponSO.bZoom) return;
        
        if(ZoomCheck)
        {
            CVCamera.m_Lens.FieldOfView = DefaultZoomAngle;
            ZoomCheck = false;
            firstPersonController.ChangeRotationSpeed(DefaultRotationSpeed);
        }
        else
        {
            CVCamera.m_Lens.FieldOfView = WeaponSO.ZoomAngle;
            ZoomCheck = true;
            firstPersonController.ChangeRotationSpeed(WeaponSO.ZoomRotationSpeed);
        }

        ZoomImage.SetActive(ZoomCheck);
    }
}
