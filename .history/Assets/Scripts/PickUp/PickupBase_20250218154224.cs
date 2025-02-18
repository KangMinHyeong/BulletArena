using UnityEngine;

public class PickupBase : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20.0f;

    WeaponSO weaponSO;
    string CollisionEnabelTag = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnCollisionEnter(Collision other)
    {
        var tag = other.gameObject.tag;

        if(tag != CollisionEnabelTag) return;

        var weapon = other.gameObject.GetComponentInChildren<Weapon>();
        weapon.SwitchWeapon(weaponSO);
    }
}
