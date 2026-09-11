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

    public float roomLoadTimer = 8.0f;

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
        if (roomLoadTimer >= 0)
        {
            roomLoadTimer -= Time.deltaTime;
            if (roomLoadTimer < 0)
            {
                RoomController.instance.RoomsLoaded();
            }
        }
    }
}
