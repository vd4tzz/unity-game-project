using Player;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    private void Start() {}
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Update Spawn");
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().UpdateRespawn(transform.position);   
            Destroy(gameObject);
        }
    }
}
