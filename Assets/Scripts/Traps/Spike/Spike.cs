using UnityEngine;


public class Spike : MonoBehaviour
{
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private Vector2 spawnPoint;

    [Header("Spike Setting")]
    [SerializeField] private float fallSpeed;
    [SerializeField] private int damage;


    void Start()
    {
        bc = GetComponent<BoxCollider2D>();    
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = transform.position;
    }

    public void Fall()
    {
        rb.velocity = Vector2.down * fallSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ICombatEntity entity = collision.gameObject.GetComponent<ICombatEntity>();
        if(entity != null)
        {
            entity?.TakeDamage(damage);
            Destroy(gameObject);
        }

        if(collision.gameObject.CompareTag("Ground"))
            Destroy(gameObject);
    }

}
