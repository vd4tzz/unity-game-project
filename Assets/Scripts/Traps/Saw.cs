using UnityEngine;


public class Saw : MonoBehaviour
{
    private BoxCollider2D bc;
    private Rigidbody2D rb;
    private Vector2 spawnPoint;

    [Header("Saw Setting")]
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private int damage;
    [SerializeField] private MovingStyle movingStyle = MovingStyle.Horizontal;

    private Vector2 direction = Vector2.left;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = transform.position;
    }


    private void Update()
    {
        if(movingStyle == MovingStyle.Horizontal)
            HorizontalMove();
        else if(movingStyle == MovingStyle.Circular)
            CircularMove();
    }

    private void HorizontalMove()
    {
        if (transform.position.x > spawnPoint.x + distance)
            direction = Vector2.left;

        if (transform.position.x < spawnPoint.x - distance)
            direction = Vector2.right;

        rb.velocity = speed * direction;
    }


    private void CircularMove()
    {
        float deltaX = transform.position.x - spawnPoint.x;
        float deltaY = Mathf.Sin(deltaX);

        float vX = speed;
        float vY = deltaY * speed;

        if(transform.position.x > spawnPoint.x + distance)
            direction = Vector2.left;
        if(transform.position.x < spawnPoint.x - distance)
            direction = Vector2.right;

        rb.velocity = new Vector2(direction.x * vX, vY);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            ICombatEntity entity = collider.gameObject.GetComponent<ICombatEntity>();
            entity?.TakeDamage(damage);
        }
    }
}

enum MovingStyle
{
    Horizontal,
    Circular
}
