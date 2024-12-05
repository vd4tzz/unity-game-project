using UnityEngine;


public class TrunkBullet : MonoBehaviour
{
    private BoxCollider2D bc;
    private Rigidbody2D rb;

    public float Speed { get; set;}
    public int Damage { get; set; }

    private float timeAlive = 10f; // Thoi gian song cho vien dan 
    
    void Start()
    {
        Debug.Log("Instantiateee");
        bc = GetComponent<BoxCollider2D>();    
        rb = GetComponent<Rigidbody2D>();

        
    }

    
    void Update()
    {
        if(timeAlive > 0)
            timeAlive -= Time.deltaTime;
        else
            Destroy(gameObject);
    }

    public void Attack(int direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(Speed * direction, 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ICombatEntity entity = collider.gameObject.GetComponent<ICombatEntity>();
        if(entity != null)
        {
            entity.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
