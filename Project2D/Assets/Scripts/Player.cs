using UnityEngine;
using static UnityEditor.FilePathAttribute;

public enum EPlayerState : byte
{
    Idle,
    Shooting,
    Dead
}

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerSettings settings;
    public WeaponSettings weaponSettings;
    public GameObject bubblePrefab;

    private float shootTimer = 0;
    private Animator animator;
    

    public EPlayerState state;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        state = EPlayerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null)
        {
            
        }
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0)
            {

            }
        }
    }

    public void SpawnFire()
    {
        Vector2 shootDir = controller.getCurrentShootDirection();
        //Vector2 shortControlDir
        //controlDir.
        //GameObject fireObject = Instantiate(firePrefab, new Vector3(transform.position.x + controlDir.x, transform.position.y + controlDir.y, -1.5f), Quaternion.identity);
        GameObject bubbleObject = Instantiate(bubblePrefab, new Vector3(transform.position.x, transform.position.y, -1.5f), Quaternion.identity);
        Bubble bubble = bubbleObject.GetComponent<Bubble>();
        bubble.SetDir(shootDir);
        shootTimer = weaponSettings.BubbleCooldown;
        SetState(EPlayerState.Idle);
    }

    public void SetState(EPlayerState State)
    {
        if (state != State)
        {
            state = State;
            if (state == EPlayerState.Idle)
            {
                animator.Play("EmbyIdle");
            }
            if (state == EPlayerState.Shooting)
            {
                animator.Play("EmbyShoot");
            }
        }
    }

    public float GetShootTimer()
    {
        return shootTimer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EEnemyType enemyType = collision.gameObject.GetComponent<Enemy>().EnemyType;

            if (enemyType == EEnemyType.Electricity)
            {
                if (collision.gameObject.GetComponent<SpriteRenderer>().enabled == true)
                {
                    OnHurt();
                }
            }
            if (enemyType == EEnemyType.Darfish)
            {
                if (collision.gameObject.GetComponent<Darfish>().state != EDarfishState.Dying)
                {
                    OnHurt();
                }
            }
            
        }
    }

    private void OnHurt()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
    }
}
