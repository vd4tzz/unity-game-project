using Player;
using UnityEngine;


public class Coin : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("Coin");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Player"))
        {
            obj.GetComponent<PlayerController>().Coin++;
            Destroy(gameObject);
        }
    }
}
