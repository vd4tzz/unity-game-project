using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Setting")]
    public GameObject player;
    public Vector3    offset;
    [Range(0, 1)]
    public float      speed;
    private Vector3   velocity;

    void Start()
    {

    }

    
    void FixedUpdate()
    {
        Vector3 target;
        if(player.transform.localScale.x > 0)
        {
            target = player.transform.position + new Vector3(0.2f, 0, 0) + offset;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, speed);
        }
        else if(player.transform.localScale.x < 0)
        {
            target = player.transform.position + new Vector3(-0.2f, 0, 0) + offset;
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, speed);
        }
    }
}
