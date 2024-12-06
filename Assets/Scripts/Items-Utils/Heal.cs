using Player;
using UnityEngine;


public class HealPoint : MonoBehaviour
{
    private ItemsAudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("ItemsAudio").GetComponent<ItemsAudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Player"))
        {
            audioManager.PlaySFX(ItemsAudioManager.HEAL);
            obj.GetComponent<PlayerController>().Heal(1);
            Destroy(gameObject);  
        }
    }
}
