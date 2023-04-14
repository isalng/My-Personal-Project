using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogZigZag : MonoBehaviour
{
    public float speed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.position = new Vector3(
            Mathf.Sin(Time.time*5)*5,
            transform.position.y, 
            transform.position.z 
        );
    }
}
