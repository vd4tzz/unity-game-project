using Player;
using UnityEngine;


public class Spawn : MonoBehaviour
{
    private void Start() {}
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().UpdateRespawn(transform.position);
            
        }
    }
}
