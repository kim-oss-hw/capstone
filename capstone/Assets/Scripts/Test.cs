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
        InvokeRepeating("GoForce", 0, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GoForce()
    {
        GameObject EnemyPlayer = GameObject.Find("Player(Clone)").gameObject;
        GameObject MyPlayer = GameObject.Find("MyPlayer").gameObject;
        GameObject MyCamera = GameObject.Find("OVRPlayerCamera").gameObject;

        Vector3 hitVec = -((EnemyPlayer.transform.position - MyPlayer.transform.position).normalized);
        MyCamera.GetComponent<Rigidbody>().AddForce(hitVec * 200.0f);
        MyCamera.GetComponent<Rigidbody>().AddForce(transform.up * 100.0f);
    }
}
