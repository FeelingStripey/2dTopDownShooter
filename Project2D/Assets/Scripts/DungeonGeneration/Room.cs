using UnityEngine;

public class Room : MonoBehaviour
{

    public int width;
    public int height;
    public int X;
    public int Y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (RoomController.instance == null)
        {
            Debug.Log("Room Controller Null - pressed play in wrong scene");
            return;
        }

        RoomController.instance.RegisterRoom(this);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    public Vector3 GetRoomCentre()
    {
        return new Vector3(X * width, Y * height);
    }
}
