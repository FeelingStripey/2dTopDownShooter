using UnityEngine;

[CreateAssetMenu(fileName = "CameraSettings", menuName = "Scriptable Objects/CameraSettings")]
public class CameraSettings : ScriptableObject
{
    [Header("Movement")]
    public float CameraSpeed = 5.0f;
    public float MaxDeltaMovement = 30.0f;
}
