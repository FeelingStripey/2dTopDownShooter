using Unity.VisualScripting;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

public enum ECrawlerDirection : byte
{
    up = 0, 
    left = 1, 
    down = 2, 
    right = 3
}

public class DungeonCrawlerController : MonoBehaviour
{

    public static List<Vector2Int> positionsVisited = new List<Vector2Int>();

    private static readonly Dictionary<ECrawlerDirection, Vector2Int> directionMovementMap = new Dictionary<ECrawlerDirection, Vector2Int>
    {
        { ECrawlerDirection.up, Vector2Int.up },
        { ECrawlerDirection.left, Vector2Int.left },
        { ECrawlerDirection.down, Vector2Int.down },
        { ECrawlerDirection.right, Vector2Int.right }
    };

    public static List<Vector2Int> GenerateDungeon(DungeonGeneratorData dungeonData)
    {
        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();

        for (int i = 0; i < dungeonData.numberOfCrawlers; i++)
        {
            dungeonCrawlers.Add(new DungeonCrawler(Vector2Int.zero));
        }
        int iterations = Random.Range(dungeonData.iterationMin, dungeonData.iterationMax);

        for (int i = 0; i < iterations; i++)
        {
            foreach(DungeonCrawler dungeonCrawler in dungeonCrawlers)
            {
                Vector2Int newPos = dungeonCrawler.Move(directionMovementMap);
                positionsVisited.Add(newPos);
            }
        }

        return positionsVisited;
    }
}
