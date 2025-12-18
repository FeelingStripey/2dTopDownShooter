using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game sInstance;

    public GameObject playerGameObject;
    public PlayerCamera playerCamera;
    
    public static Game Instance
    { get { return sInstance; } }

    public GameObject PlayerGameObject
    { get { return playerGameObject; } }

    public Player GetPlayer
    {  get { return playerGameObject.GetComponent<Player>(); } }

    public PlayerCamera PlayerCamera
    { get { return playerCamera; } }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (sInstance != null && sInstance != this)
        {
            Destroy(this);
        }
        else
        {
            sInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
