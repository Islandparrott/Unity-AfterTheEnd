// Ailand Parriott
// created: 23.04.21
//
// This script adds functionality to the dot pointer.


using UnityEngine;

public class DotController : MonoBehaviour
{
    // has to get mouse position from camera
    public Camera mainCamera;
    public float radius = 0.5f;

    private float distance;
    private GameObject player;
    // vector2 of the dot.
    private Vector2 dotPos, mousePosition, offset, playerPos;
    

    void Start()
    {
        mainCamera = Camera.main;

        // get position of the player, set it to playerPos
        player = GameObject.Find("Player");
        playerPos = player.transform.position;

        // sets position at start
        transform.position = playerPos;
    }

    void FixedUpdate()
    {
        playerPos = player.transform.position;

        // move mouseposition using camera
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        // distance between mouse and centerpoint
        offset = mousePosition - playerPos;
        // clamp distance to the radius
        distance = Mathf.Clamp(offset.magnitude, 0f, 1f) * radius; 
        
        // set the dot position
        transform.position = playerPos + offset.normalized * distance;
    }
}
