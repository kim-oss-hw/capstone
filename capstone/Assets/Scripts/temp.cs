/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshVrHeadMove : MonoBehaviour
{
    public Camera camera;
    public float speedForward = 1;
    public float speedSide = 1;
    public float speedRota = 1;
    public float equipDistance = 6;
    public GameObject rightHand;
    public GameObject leftHand;
    //public GameObject swordOneHand;
    public GameObject[] swords = new GameObject[3];
    public GameObject playerCharacter;

    private Transform tr;
    //private float dirX = 0;
    //private float dirZ = 0;
    private GameObject curSword = null;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        animator = playerCharacter.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        MovePlayer();
        if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
        {
            if (curSword)
            {
                unequipSword();
            }
            else
            {
                Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, equipDistance);
                if (hit.transform.tag == "Broadsword")
                {
                    equipSword(0, true);
                }
                else if (hit.transform.tag == "Shortsword")
                {
                    equipSword(1, true);
                }
                else if (hit.transform.tag == "Falchion")
                {
                    equipSword(2, true);
                }
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
        {
            if (curSword)
            {
                unequipSword();
            }
            else
            {
                Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, equipDistance);
                print(hit.transform.name);
                if (hit.transform.tag == "Broadsword")
                {
                    equipSword(0, false);
                }
                else if (hit.transform.tag == "Shortsword")
                {
                    equipSword(1, false);
                }
                else if (hit.transform.tag == "Falchion")
                {
                    equipSword(2, false);
                }
            }
        }
    }

    void MovePlayer()
    {
        Vector2 coordMove = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 coordRota = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        Vector3 moveDir = new Vector3(coordMove.x * speedSide, 0, coordMove.y * speedForward);
        Vector3 rotaDir = new Vector3(0f, coordRota.x * speedRota, 0f);

        transform.Translate(moveDir * Time.deltaTime);
        transform.Rotate(rotaDir * Time.deltaTime);
    }

    void equipSword(int swordIndex, bool isRight)
    {
        if (curSword)
        {
            unequipSword();
            return;
        }
        switch (swordIndex)
        {
            case 0: // Broadsword
                if (isRight)
                {
                    curSword = GameObject.Instantiate(swords[swordIndex], rightHand.transform.position, rightHand.transform.rotation);
                    curSword.transform.parent = rightHand.transform;
                    curSword.transform.localPosition = new Vector3(0.075f, -0.045f, -0.04f);
                    curSword.transform.localRotation = Quaternion.Euler(164.767f, -61.332f, 3.149002f);
                }
                else
                {
                    curSword = GameObject.Instantiate(swords[swordIndex], leftHand.transform.position, leftHand.transform.rotation);
                    curSword.transform.parent = leftHand.transform;
                    curSword.transform.localPosition = new Vector3(-0.0739f, 0.035f, 0.0282f);
                    curSword.transform.localRotation = Quaternion.Euler(-165.083f, 117.143f, -5.265015f);
                }
                break;
            case 1: // Shortsword
                if (isRight)
                {
                    curSword = GameObject.Instantiate(swords[swordIndex], rightHand.transform.position, rightHand.transform.rotation);
                    curSword.transform.parent = rightHand.transform;
                    curSword.transform.localPosition = new Vector3(0.09f, -0.048f, 0.008f);
                    curSword.transform.localRotation = Quaternion.Euler(164.767f, -61.332f, 3.149002f);
                }
                else
                {
                    curSword = GameObject.Instantiate(swords[swordIndex], leftHand.transform.position, leftHand.transform.rotation);
                    curSword.transform.parent = leftHand.transform;
                    curSword.transform.localPosition = new Vector3(-0.0924f, 0.0565f, 0.0023f);
                    curSword.transform.localRotation = Quaternion.Euler(-165.083f, 117.143f, -5.265015f);
                }
                break;
            case 2: // Falchion
                if (isRight)
                {
                    curSword = GameObject.Instantiate(swords[swordIndex], rightHand.transform.position, rightHand.transform.rotation);
                    curSword.transform.parent = rightHand.transform;
                    curSword.transform.localPosition = new Vector3(0.0948f, -0.0442f, 0.0044f);
                    curSword.transform.localRotation = Quaternion.Euler(164.767f, -61.332f, 3.149002f);
                }
                else
                {
                    curSword = GameObject.Instantiate(swords[swordIndex], leftHand.transform.position, leftHand.transform.rotation);
                    curSword.transform.parent = leftHand.transform;
                    curSword.transform.localPosition = new Vector3(-0.094f, 0.038f, -0.002f);
                    curSword.transform.localRotation = Quaternion.Euler(-165.083f, 117.143f, -5.265015f);
                }
                break;
            default: return;
        }
        if (isRight) animator.SetBool("rightGrabing", true);
        else animator.SetBool("leftGrabing", true);
    }

    void unequipSword()
    {
        if (!curSword) return;
        animator.SetBool("rightGrabing", false);
        animator.SetBool("leftGrabing", false);
        Destroy(curSword);
    }
}
//*/