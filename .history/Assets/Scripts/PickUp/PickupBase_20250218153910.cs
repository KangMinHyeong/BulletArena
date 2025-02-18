using UnityEngine;

public class PickupBase : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20.0f;

    WeaponSO weaponSO;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
