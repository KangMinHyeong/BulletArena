using UnityEngine;

public class PickupBase : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 20.0f;
    [SerializeField] WeaponSO weaponSO;

    string CollisionEnabelTag = "Player";

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("sdfsdf");
        var tag = other.gameObject.tag;

        if(tag != CollisionEnabelTag) return;

        var weapon = other.gameObject.GetComponentInChildren<Weapon>();
        weapon.SwitchWeapon(weaponSO);

        Destroy(this.gameObject);
    }
}
