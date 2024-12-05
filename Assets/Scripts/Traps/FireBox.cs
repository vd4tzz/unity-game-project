using Player;
using UnityEngine;


public class FireBox : MonoBehaviour
{
    private Animator animator;
    private BoxCollider2D bc;

    [Header("Firebox Setting")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float extraHeight;
    [SerializeField] private int damage;

    [SerializeField] private float fireDuration;
    private float timer;
    public bool isFire;

    private void Start()
    {
        animator = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();

        timer = fireDuration;
        isFire = false;

        animator.Play("Firebox");
    }

    private void Update()
    {
        HandleFire();
        IsBurned();
    }

    private void HandleFire()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }
        
        timer = fireDuration;
        isFire = !isFire;

        if (isFire)
        {
            animator.Play("Firebox");
        }
        else
        {
            animator.Play("Off");
        }
    }

    private void IsBurned() 
    {
        if(!isFire) return;

        RaycastHit2D ray = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0, Vector2.up, extraHeight, playerLayer);
        if(!ray) return;
        PlayerController player = ray.collider.gameObject.GetComponent<PlayerController>();
        player.TakeDamage(damage);
    }

}
