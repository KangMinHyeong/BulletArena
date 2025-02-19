using UnityEngine;

public abstract class PickupBase : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20.0f;
    [SerializeField] WeaponSO weaponSO;

    string CollisionEnabelTag = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;

        if (tag != CollisionEnabelTag) return;
        
        Destroy(this.gameObject);

        HandlePickup(other);
    }

    protected abstract void HandlePickup(Collider other)
    {
        var weapon = other.gameObject.GetComponentInChildren<Weapon>();
        weapon.SwitchWeapon(weaponSO);
    }
}
