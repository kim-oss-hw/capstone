using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool addforce;
    public Rigidbody rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        InvokeRepeating("GoForce", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GoForce()
    {
        Debug.Log("Go");
        rd.AddForce(transform.forward * 200.0f);
        rd.AddForce(transform.up * 100.0f);
    }
}
