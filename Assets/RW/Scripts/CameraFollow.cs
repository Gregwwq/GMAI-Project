using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float OffsetX, OffsetY, OffsetZ, XAngleOffset;

    Transform player;
    float damping = 5f;

    void Start()
    {
        player = GameObject.Find("Character").transform;
    }

    void Update()
    {
        transform.position = 
            Vector3.Lerp(
                transform.position, 
                player.TransformPoint(new Vector3(OffsetX, OffsetY, OffsetZ)),
                damping * Time.deltaTime
            );

        transform.rotation = 
            Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(new Vector3(XAngleOffset, player.eulerAngles.y, player.eulerAngles.z)),
                damping * Time.deltaTime
            );
    }
}