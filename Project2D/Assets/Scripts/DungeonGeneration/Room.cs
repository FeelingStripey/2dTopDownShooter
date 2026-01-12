using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    public int width;
    public int height;
    public int X;
    public int Y;

    public Door leftDoor;
    public Door rightDoor;
    public Door topDoor;
    public Door bottomDoor;

    public List<Door> doors = new List<Door>();
    public Spawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (RoomController.instance == null)
        {
            Debug.Log("Room Controller Null - pressed play in wrong scene");
            return;
        }

        Door[] ds = GetComponentsInChildren<Door>();
        foreach(Door d in ds)
        {
            doors.Add(d);
            switch(d.type)
            {
                case Door.EDoorType.right:
                    rightDoor = d;
                    break;
                case Door.EDoorType.left:
                    leftDoor = d;
                    break;
                case Door.EDoorType.top:
                    topDoor = d;
                    break;
                case Door.EDoorType.bottom:
                    bottomDoor = d;
                    break;
            }
        }

        //Debug.Log("Register Called: " + this);
        RoomController.instance.RegisterRoom(this);
    }

    public void RemoveUnconnectedDoors()
    {
        foreach(Door door in doors)
        {
            switch(door.type)
            {
                case Door.EDoorType.right:
                    if(GetRight() == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.EDoorType.left:
                    if (GetLeft() == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.EDoorType.top:
                    if (GetTop() == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
                case Door.EDoorType.bottom:
                    if (GetBottom() == null)
                    {
                        door.gameObject.SetActive(false);
                    }
                    break;
            }
        }
    }

    public Room GetRight()
    {
        if (RoomController.instance.DoesRoomExist(X + 1, Y))
        {
            return RoomController.instance.FindRoom(X + 1, Y);
        }
        return null;
    }

    public Room GetLeft()
    {
        if (RoomController.instance.DoesRoomExist(X - 1, Y))
        {
            return RoomController.instance.FindRoom(X - 1, Y);
        }
        return null;
    }

    public Room GetTop()
    {
        if (RoomController.instance.DoesRoomExist(X, Y + 1))
        {
            return RoomController.instance.FindRoom(X, Y + 1);
        }
        return null;
    }

    public Room GetBottom()
    {
        if (RoomController.instance.DoesRoomExist(X, Y - 1))
        {
            return RoomController.instance.FindRoom(X, Y - 1);
        }
        return null;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            RoomController.instance.OnPlayerEnterRoom(this);
        }
    }
}
