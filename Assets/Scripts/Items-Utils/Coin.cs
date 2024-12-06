using Player;
using UnityEngine;


public class Coin : MonoBehaviour
{
    private Animator animator;
    private ItemsAudioManager audioManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.Play("Coin");
    }

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("ItemsAudio").GetComponent<ItemsAudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Player"))
        {
            audioManager.PlaySFX(ItemsAudioManager.COIN);
            obj.GetComponent<PlayerController>().Coin++;
            Destroy(gameObject);
        }
    }
}
