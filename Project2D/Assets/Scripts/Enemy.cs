using UnityEngine;

public enum EEnemyType : byte
{
    Unknown,
    Darfish,
    Electricity
}

// Start is called once before the first execution of Update after the MonoBehaviour is created
public class Enemy : MonoBehaviour
{
    protected EEnemyType enemyType = EEnemyType.Unknown;
    protected Vector2 startPosition;

    public EEnemyType EnemyType
    {
        get { return enemyType; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Reset()
    {
        transform.position = startPosition;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}