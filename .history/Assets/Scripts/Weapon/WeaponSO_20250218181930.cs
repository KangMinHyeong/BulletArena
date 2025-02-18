using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public GameObject WeaponMesh;
    public GameObject HitVFX;

    public bool bZoom = false;
    public float WeaponDistance = 2000.0f;
    public float RapidSpeed = 0.2f;
    public float ZoomAngle = 20.0f;
    public float ZoomRotationSpeed = ;
    public int DamageAmount = 10;


}
