using UnityEngine;

public class Door : MonoBehaviour
{
    public enum EDoorType : byte
    {
        left,
        right,
        top,
        bottom
    }

    public EDoorType type;
}
