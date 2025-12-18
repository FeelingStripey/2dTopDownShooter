using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCamera : MonoBehaviour
{
    public CameraSettings settings;
    public Tilemap tilemap;


    private Vector2 initialLocation = Vector2.zero;
    private Vector2 shakeOffset = Vector2.zero;

    public Vector2 ViewSize
    {
        get
        {
            float viewHeight = Camera.main.orthographicSize;
            float viewWidth = viewHeight * Camera.main.aspect;
            return new Vector2(viewWidth, viewHeight);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialLocation = transform.position;
        if (tilemap != null)
        {
            // Compress the bounds to ensure accuracy
            tilemap.CompressBounds();
        }
    }

        // Update is called once per frame
        void Update()
    {
        if (Game.Instance.GetPlayer.state != EPlayerState.Dead)
        {
            // Get player and camera locations
            Vector2 playerLocation = Game.Instance.PlayerGameObject.transform.position;
            Vector2 cameraLocation = transform.position;

            // Calculate the X and Y camera location values
            cameraLocation.x = Mathf.MoveTowards(cameraLocation.x, playerLocation.x, Time.deltaTime * settings.MaxDeltaMovement) + shakeOffset.x;
            cameraLocation.y = Mathf.MoveTowards(cameraLocation.y, playerLocation.y, Time.deltaTime * settings.MaxDeltaMovement) + shakeOffset.y;

            // Set the camera location
            SetCameraLocation(cameraLocation);
        }
    }

    public void SetCameraLocation(Vector2 location)
    {
        Vector2 viewSize = ViewSize;
        BoundsInt levelBounds = tilemap.cellBounds;

        float maxCameraX = (float)levelBounds.max.x - viewSize.x;
        float minCameraX = (float)levelBounds.min.x + viewSize.x;
        float maxCameraY = (float)levelBounds.max.y - viewSize.y;
        float minCameraY = (float)levelBounds.min.y + viewSize.y;

        Vector3 cameraLocation = Vector3.zero;
        cameraLocation.x = Mathf.Clamp(location.x, minCameraX, maxCameraX);
        cameraLocation.y = Mathf.Clamp(location.y, minCameraY, maxCameraY);
        cameraLocation.z = transform.position.z;

        transform.position = cameraLocation;
    }

}
