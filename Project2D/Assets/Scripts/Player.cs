using UnityEngine;

public enum EPlayerState : byte
{
    Alive,
    Dead
}

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerSettings settings;

    private float shootTimer = 0;

    public EPlayerState state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<PlayerController>();
        state = EPlayerState.Alive;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null)
        {
            
        }
    }
}
