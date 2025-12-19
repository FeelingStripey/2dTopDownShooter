using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSettings", menuName = "Scriptable Objects/WeaponSettings")]
public class WeaponSettings : ScriptableObject
{
    [Header("Bubble")]
    public float BubbleSpeed = 10.0f;
    public float BubbleLifetime = 2.0f;
    public float BubbleDamage = 5.0f;
    public float BubbleCooldown = 0.1f;
}
