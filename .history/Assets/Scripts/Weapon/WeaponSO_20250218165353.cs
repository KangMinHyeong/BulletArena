using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject WeaponMesh;
    public GameObject HitVFX;

    public float WeaponDistance = 2000.0f;
    public float RapidSpeed = 0.2f;
    public int DamageAmount = 10;
    public bool bZoom = false;
}
