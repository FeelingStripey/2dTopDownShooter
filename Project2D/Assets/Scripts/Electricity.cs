using UnityEngine;

public class Electricity : Enemy
{
    GameObject Darfish;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyType = EEnemyType.Electricity;
        Darfish = this.transform.parent.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
