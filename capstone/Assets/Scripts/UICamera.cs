using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    private Camera UICameraTarget;

    // Start is called before the first frame update
    void Start()
    {
        UICameraTarget = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(UICameraTarget.fieldOfView);
        UICameraTarget.fieldOfView = 60;
    }
}
