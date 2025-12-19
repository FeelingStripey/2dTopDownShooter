using UnityEngine;

public class Game : MonoBehaviour
{
    private static Game sInstance;
    public GameSettings settings;

    public GameObject playerGameObject;
    public PlayerCamera playerCamera;

    private float localTimeScale = 1.0f;
    
    public static Game Instance
    { get { return sInstance; } }

    public GameObject PlayerGameObject
    { get { return playerGameObject; } }

    public Player GetPlayer
    {  get { return playerGameObject.GetComponent<Player>(); } }

    public PlayerCamera PlayerCamera
    { get { return playerCamera; } }

    public float LocalTimeScale
    { get { return localTimeScale; } }


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
            localTimeScale = settings.GameTimeScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
