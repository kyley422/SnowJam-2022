using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float cameraZoom = 8f; // Distance between camera and 2D plane
    public Vector2 offset = new Vector2(0f, 0f); // x-y offset of camera

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Constantly follow the player's transform location
        transform.position = player.transform.position + new Vector3(offset.x, offset.y, -10);
        Camera.main.orthographicSize = cameraZoom;
    }
}
