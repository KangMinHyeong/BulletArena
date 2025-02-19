using UnityEngine;

public class Pickup_Weapon : PickupBase
{
    [SerializeField] public WeaponSO weaponSO;
    
    protected override void HandlePickup(Collider other)
    {
        var weapon = other.gameObject.GetComponentInChildren<Weapon>();
        weapon.SwitchWeapon(weaponSO);
    }
}
