using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Scriptable Objects/EnemySettings")]
public class EnemySettings : ScriptableObject
{
    [Header("Darfish")]
    public float DarfishSpeed = 2.5f;
    public float DarfishDeathDuration = 1.0f;
    public float DarfishAttackDelay = 3.0f;
    public float DarfishAttackDuration = 1.0f;
}
