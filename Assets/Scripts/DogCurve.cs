using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCurve : MonoBehaviour
{
    public float speed = 5.0f;
    public float theta = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        Vector3 normal = new Vector3(Mathf.Cos(theta), 0.0f, Mathf.Sin(theta))/100;
        transform.Translate(normal);
        theta += 0.005f;
    }
}
