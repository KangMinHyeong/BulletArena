using UnityEngine;

public class Pickup_Ammo : PickupBase
{
    [SerializeField] int AmmoAmount = 5;
    protected override void HandlePickup(Collider other)
    {
        var weapon = other.gameObject.GetComponentInChildren<Weapon>();
        weapon.UpdateAmmo(AmmoAmount);
    }
    
}
