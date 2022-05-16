/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshVrHeadMove : MonoBehaviour
{
    public Camera camera;
    public float speedForward = 1;
    public float speedSide = 1;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject swordOneHand;

    private bool grabbing = false;
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
        RaycastHit hit;

        MovePlayer();
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 3);

            if (grabbing)
            {
                Transform sword = rightHand.transform.Find("1HandSword(Clone)");
                if (sword)
                {
                    Destroy(sword.gameObject);
                    grabbing = false;
                } else
                {
                    sword = leftHand.transform.Find("1HandSword(Clone)");
                    Destroy(sword.gameObject);
                    grabbing = false;
                }
            }
            else
            {
                print(hit.transform.parent.name);
                if (hit.transform.parent.tag == "Weapon")
                {
                    GameObject.Instantiate(swordOneHand, rightHand.transform.position, rightHand.transform.rotation).transform.parent = rightHand.transform;
                    GameObject sword = rightHand.transform.Find("1HandSword(Clone)").gameObject;
                    sword.transform.localPosition = new Vector3(0.102f, -0.052f, -0.01f);
                    sword.transform.localRotation = Quaternion.Euler(49.934f, -61.109f, -85.92f);
                    grabbing = true;
                }
            }
        } else if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 3);

            if (grabbing)
            {
                Transform sword = leftHand.transform.Find("1HandSword(Clone)");
                if (sword)
                {
                    Destroy(sword.gameObject);
                    grabbing = false;
                } else
                {
                    sword = rightHand.transform.Find("1HandSword(Clone)");
                    Destroy(sword.gameObject);
                    grabbing = false;
                }
                
            }
            else
            {
                print(hit.transform.parent.name);
                if (hit.transform.parent.tag == "Weapon")
                {
                    GameObject.Instantiate(swordOneHand, leftHand.transform.position, leftHand.transform.rotation).transform.parent = leftHand.transform;
                    GameObject sword = leftHand.transform.Find("1HandSword(Clone)").gameObject;
                    sword.transform.localPosition = new Vector3(-0.109f, 0.051f, -0.01f);
                    sword.transform.localRotation = Quaternion.Euler(-83.931f, 0f, 23.141f);
                    grabbing = true;
                }
            }
        }
    }

    void MovePlayer()
    {
        Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 moveDir = new Vector3(coord.x * speedSide, 0, coord.y * speedForward);

        transform.Translate(moveDir * Time.deltaTime);
    }
}
//*/