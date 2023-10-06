using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0,0,-10f);
    private float damping;
    
    private Vector3 zer = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target = player.transform.position + offset;
        target.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, target, ref zer, damping);

    }
}
