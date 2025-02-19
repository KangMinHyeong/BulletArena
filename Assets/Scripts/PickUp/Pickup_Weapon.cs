using UnityEngine;

public class Pickup_Weapon : PickupBase
{
    [SerializeField] WeaponSO weaponSO;
    
    protected override void HandlePickup(Collider other)
    {
        var weapon = other.gameObject.GetComponentInChildren<Weapon>();
        weapon.SwitchWeapon(weaponSO);
    }
}
