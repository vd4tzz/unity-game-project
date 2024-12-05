using Player;
using UnityEngine;


public class HealPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if(obj.CompareTag("Player"))
        {
            obj.GetComponent<PlayerController>().Heal(1);
            Destroy(gameObject); 
        }
    }
}
