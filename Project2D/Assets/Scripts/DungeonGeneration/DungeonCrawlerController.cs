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
    public static DungeonCrawlerController instance;

    public static List<Vector2Int> positionsVisited = new List<Vector2Int>();

    private static readonly Dictionary<ECrawlerDirection, Vector2Int> directionMovementMap = new Dictionary<ECrawlerDirection, Vector2Int>
    {
        { ECrawlerDirection.up, Vector2Int.up },
        { ECrawlerDirection.left, Vector2Int.left },
        { ECrawlerDirection.down, Vector2Int.down },
        { ECrawlerDirection.right, Vector2Int.right }
    };

    private void Awake()
    {
        instance = this;
    }

    public static List<Vector2Int> GenerateDungeon(DungeonGeneratorData dungeonData)
    {
        List<DungeonCrawler> dungeonCrawlers = new List<DungeonCrawler>();

        for (int i = 0; i < dungeonData.numberOfCrawlers; i++)
        {
            GameObject go = new GameObject();
            go.AddComponent<DungeonCrawler>();
            DungeonCrawler crawler = go.GetComponent<DungeonCrawler>();
            dungeonCrawlers.Add(crawler);

            //SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
            //DungeonCrawler dc = gameObject.AddComponent<DungeonCrawler>();

            //DungeonCrawler dc = instance.AddComponent<DungeonCrawler>();
            //BoxCollider2D dc = instance.AddComponent<BoxCollider2D>();
            //dungeonCrawlers.Add(dc);
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
