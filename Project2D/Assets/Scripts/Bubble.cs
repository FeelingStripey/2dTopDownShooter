using UnityEngine;
using UnityEngine.Rendering;

public enum EBubbleState : byte
{
    Unknown,
    Moving,
    Destroyed
}

public class Bubble : MonoBehaviour
{
    //public BoxCollider2D collider;
    public WeaponSettings settings;

    private BubbleParticle particle;

    private Vector3 velocity = Vector3.zero;
    private EBubbleState state;
    private float lifeTimer;
    private new Rigidbody2D rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //collider = GetComponent<BoxCollider2D>();
        //state = EBubbleState.Unknown;
        rigidbody = GetComponent<Rigidbody2D>();
        particle = GetComponent<BubbleParticle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == EBubbleState.Moving)
        {
            lifeTimer -= Time.deltaTime;
            if (lifeTimer < 0)
            {
                DestroyThis();
            }
        }
    }

    private void FixedUpdate()
    {
        if (state == EBubbleState.Moving)
        {
            transform.position += velocity * Time.deltaTime * Game.Instance.LocalTimeScale;
        }
    }

    public void SetDir(Vector2 dir)
    {
        velocity = dir * settings.BubbleSpeed;
        state = EBubbleState.Moving;
        lifeTimer = settings.BubbleLifetime;
        //particle.animator.Play("BubbleParticle");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("colenter");
    //    if (collision.gameObject.CompareTag("World"))
    //    {
    //        DestroyThis();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("World"))
        {
            DestroyThis();
        }
    }

    private void DestroyThis()
    {
        //Debug.Log("Destroy Called");
        Destroy(gameObject);
    }
}
