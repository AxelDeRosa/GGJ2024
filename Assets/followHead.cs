using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followHead : MonoBehaviour
{

    public Transform Camera;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Camera.transform.rotation, speed * Time.deltaTime);
    }
}
