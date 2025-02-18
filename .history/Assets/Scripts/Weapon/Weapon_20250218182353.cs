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

    StarterAssetsInputs Input;
    GameObject RootObj;
    GameObject CurrentWeaponMesh;
    ParticleSystem FireVFX;
    CinemachineVirtualCamera CVCamera;
    FirstPersonController firstPersonController;

    bool bFire = false;
    bool ZoomCheck = false;
    float DefaultZoomAngle;
    float DefaultRotationSpeed;

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
        CurrentWeaponMesh = Instantiate(WeaponSO.WeaponMesh, transform);
        FireVFX = CurrentWeaponMesh.GetComponentInChildren<ParticleSystem>();

        CVCamera.m_Lens.FieldOfView = DefaultZoomAngle;
        ZoomCheck = false;
        firstPersonController.ChangeRotationSpeed(DefaultRotationSpeed);
        ZoomImage.SetActive(ZoomCheck);
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
