using UnityEngine;

[CreateAssetMenu(fileName = "DungeonGeneratorData", menuName = "Scriptable Objects/DungeonGeneratorData")]
public class DungeonGeneratorData : ScriptableObject
{
    public int numberOfCrawlers;
    public int iterationMin;
    public int iterationMax;
}
