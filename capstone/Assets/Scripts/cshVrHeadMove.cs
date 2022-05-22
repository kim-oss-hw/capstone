using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshVrHeadMove : MonoBehaviour
{
    public float speedForward = 1;
    public float speedSide = 1;

    public float RimitX_po = 1;
    public float RimitX_ne = 1;
    public float RimitZ_po = 1;
    public float RimitZ_ne = 1;

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

        transform.Translate(new Vector3(Mathf.Clamp(transform.position.x, RimitX_ne, RimitX_po), transform.position.y, Mathf.Clamp(transform.position.z, RimitZ_po, RimitZ_po)));

        //Rigidbody PlayerRigidbody = gameObject.GetComponent<Rigidbody>();
        //PlayerRigidbody.velocity = Vector3.zero;
    }
}
