using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapController : MonoBehaviour
{
    private int mapWidth;
    private int mapHeight;
    private float horizontalOffset;
    private float verticalOffset;


    private Room room;

    public Tilemap collisionMap;
    public Tilemap backgroundMap;
    public TileBase backgroundTile;
    //public Dictionary<string, TileBase> WallTiles;

    //turn this into a fucking dictionary please
    [SerializeField]
    TileBase leftWall, rightWall, topWall, bottomWall, topLeftCorner, topRightCorner, bottomLeftCorner, bottomRightCorner;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        room = GetComponentInParent<Room>();
        mapWidth = room.width;
        mapHeight = room.height;

        horizontalOffset += room.width / 2;
        verticalOffset += room.height / 2;
        //replace this hardcoding with data later

        //how do i tell the code a tilebase will exist and be set in the editor?
        //WallTiles.Add("Leftwall", leftWall);
        //WallTiles.Add
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateMap()
    {
        //generate background
        //for (int x = 0; x < mapWidth; x++)
        //{
        //    for (int y = 0; y < mapHeight; y++)
        //    {
        //        backgroundMap.SetTile(new Vector3Int(x, y, 0), backgroundTile);
        //    }
        //}



        //make top and bottom walls
        for (int x = 0; x < mapWidth; x++)
        {
            if (x != 0 && x != mapWidth)
            {
                collisionMap.SetTile(new Vector3Int(x, 0, 0), bottomWall);
                collisionMap.SetTile(new Vector3Int(x, mapHeight, 0), topWall);
            }
        }

        //set corners
        collisionMap.SetTile(new Vector3Int(0, 0, 0), bottomLeftCorner);
        collisionMap.SetTile(new Vector3Int(mapHeight, 0, 0), topLeftCorner);
        collisionMap.SetTile(new Vector3Int(0, mapWidth, 0), bottomRightCorner);
        collisionMap.SetTile(new Vector3Int(mapHeight, mapWidth, 0), topRightCorner);

        //make left and right walls
        for (int y = 0; y < mapHeight; y++)
        {
            if (y != 0 && y != mapWidth)
            {
                collisionMap.SetTile(new Vector3Int(0, y, 0), bottomWall);
                collisionMap.SetTile(new Vector3Int(mapWidth, y, 0), topWall);
            }
        }

        

        backgroundMap.transform.position -= new Vector3(horizontalOffset, verticalOffset, 0);
        collisionMap.transform.position -= new Vector3(horizontalOffset, verticalOffset, 0);
    }

}
