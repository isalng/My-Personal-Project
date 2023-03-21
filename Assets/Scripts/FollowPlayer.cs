using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    private float clickRotateSpeed = 75.0f;
    private float fixRotateSpeed = 0.05f;
    private Vector3 lastMousePosition;
    // Start is called before the first frame update
    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //  Fix camera position.
        var playerDistance = Vector3.Distance(player.transform.position, transform.position);
        if (playerDistance > 10.0f)
        {
            transform.position -= (transform.position - player.transform.position).normalized * fixRotateSpeed;
        }
        if (playerDistance < 5.0f)
        {
            transform.position += (transform.position - player.transform.position).normalized * fixRotateSpeed;
        }
        
        //  Look at player.
        Vector3 relative = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relative, Vector3.up);
        transform.rotation = rotation;

        //  Rotate around player.
        var mousePosition = Input.mousePosition;
        var dtMousePosition = (lastMousePosition - mousePosition).normalized;
        lastMousePosition = mousePosition;
        if(Input.GetMouseButton(0)) 
        {
            transform.RotateAround(player.transform.position, Vector3.up, dtMousePosition.x * clickRotateSpeed * Time.deltaTime);
        }

        //  Lock camera's y position.
        transform.position = new Vector3(transform.position.x, 4.0f, transform.position.z);
    }

    //  Which way does the camera face on the flat plane?
    public Vector3 GetFlatDirection() {
        var res = transform.position - player.transform.position;
        res.y = 0.0f;
        return -res.normalized;
    }
}
