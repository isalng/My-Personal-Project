using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private float speed = 3.0f;
    private Vector3 lastMousePosition;
    private Vector3 offset = new Vector3(0, 5, -10);
    // Start is called before the first frame update
    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position
        /* transform.position = player.transform.position + offset + new Vector3(Mathf.Cos(theta)); */

        Vector3 relative = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relative, Vector3.up);
        transform.rotation = rotation;

        if(Input.GetMouseButton(0)) 
        {
            var mousePosition = Input.mousePosition;
            var dtMousePosition = (lastMousePosition - mousePosition).normalized;
            lastMousePosition = mousePosition;
            transform.RotateAround(player.transform.position, Vector3.up, dtMousePosition.x * speed);
        }
    }
}
