using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesCheckPoint : MonoBehaviour
{
    private BoxCollider2D bc;

    [Header("Spikes Check Point Setting")]
    [SerializeField] private List<Spike> spikes = new List<Spike>();

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();    
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        foreach(Spike spike in spikes)
        {
            spike?.Fall();
        }

        spikes.Clear();

        // Destroy(gameObject);
    }
}
