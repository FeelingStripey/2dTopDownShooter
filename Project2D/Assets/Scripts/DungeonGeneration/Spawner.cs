using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SpawnerData spawnerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(Vector2 roomSize, Vector2 roomPosition)
    {
        if (spawnerData.itemToSpawn != null)
        {
            int toSpawn = Random.Range(spawnerData.minSpawn, spawnerData.maxSpawn + 1);
            for (int i = 0; i < toSpawn; i++)
            {
                float x = Random.Range(roomPosition.x, roomPosition.x + roomSize.x) - roomSize.x / 2;
                float y = Random.Range(roomPosition.y, roomPosition.y + roomSize.y) - roomSize.y / 2;
                GameObject go = Instantiate(spawnerData.itemToSpawn, new Vector3(x, y, 0), Quaternion.identity, transform) as GameObject;
            }
        }
    }
}
