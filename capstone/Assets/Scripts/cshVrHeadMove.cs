using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshVrHeadMove : MonoBehaviour
{
    public float speedForward = 1;
    public float speedSide = 1;

    private Transform tr;
    private float dirX = 0;
    private float dirZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 moveDir = new Vector3(coord.x * speedSide, 0, coord.y * speedForward);

        transform.Translate(moveDir * Time.deltaTime);
    }
}
