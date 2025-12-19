using UnityEngine;

public enum EDarfishState : byte
{
    Unknown,
    Idle,
    Moving,
    Dying,
    Attacking
}

public class Darfish : Enemy
{
    public GameObject electricity;
    public EnemySettings settings;
    public EDarfishState state;

    private Animator animator;
    private float deathTimer;
    private float attackDelayTimer;
    private float attackTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyType = EEnemyType.Darfish;
        electricity = transform.Find("Electricity").gameObject;
        electricity.GetComponent<SpriteRenderer>().enabled = false;
        electricity.GetComponent<CircleCollider2D>().isTrigger = true;
        animator = GetComponent<Animator>();
        state = EDarfishState.Moving;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (state == EDarfishState.Moving)
        {
            Vector3 dir = Game.Instance.PlayerGameObject.transform.position - transform.position;
            float magnitude = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
            dir /= magnitude;

            Vector3 velocity = dir * settings.DarfishSpeed;
            transform.position += velocity * Time.deltaTime * Game.Instance.LocalTimeScale;

            attackDelayTimer -= Time.deltaTime;
            if (attackDelayTimer < 0)
            {
                SetState(EDarfishState.Attacking);
            }
        }
        if (state == EDarfishState.Attacking)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer < 0)
            {
                SetState(EDarfishState.Moving);
                electricity.GetComponent<SpriteRenderer>().enabled = false;
                //electricity.GetComponent<CircleCollider2D>().isTrigger = true;
            }
        }
        if (state == EDarfishState.Dying)
        {
            deathTimer -= Time.deltaTime;
            if (deathTimer < 0)
            {
                Destroy(gameObject);
            }
        }
        //Time.deltaTime * Game.Instance.LocalTimeScale
    }

    void SetState(EDarfishState State)
    {
        if (state != State)
        {
            state = State;
            if (state == EDarfishState.Idle)
            {
                animator.Play("DarfishIdle");
            }
            if (state == EDarfishState.Moving)
            {
                animator.Play("DarfishIdle");
                attackDelayTimer = settings.DarfishAttackDelay;
            }
            if (state == EDarfishState.Dying)
            {
                animator.Play("DarfishDead");
                this.GetComponent<BoxCollider2D>().isTrigger = true;
                deathTimer = settings.DarfishDeathDuration;
            }
            if (state == EDarfishState.Attacking)
            {
                animator.Play("DarfishAttack");
                attackTimer = settings.DarfishAttackDuration;
                electricity.GetComponent<SpriteRenderer>().enabled = true;
                //electricity.GetComponent<CircleCollider2D>().isTrigger = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Bubble"))
        //{
        //    SetState(EDarfishState.Dying);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            SetState(EDarfishState.Dying);
        }
    }
}
