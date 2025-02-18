using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Scriptable Objects/WeaponSO")]
public class WeaponSO : ScriptableObject
{
public:
    float WeaponDistance = 2000.0f;
    float RapidSpeed = 0.2f;
    int DamageAmount = 10;
}
