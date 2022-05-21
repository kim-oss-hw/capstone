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
    public GameObject playerCharacter;
    private Transform tr;
    private GameObject curSword = null;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (!playerCharacter) // playerCharacter = null ¿œ∂ß
        {
            if (GameObject.Find("MyPlayer"))
            {
                playerCharacter = GameObject.Find("MyPlayer");
                playerCharacter = playerCharacter.transform.Find("PlayerCharacter").gameObject;
                rightHand = playerCharacter.transform.
                    Find("root/pelvis/spine_01/spine_02/spine_03/clavicle_r/upperarm_r/lowerarm_r/hand_r").gameObject;
                leftHand = playerCharacter.transform.
                    Find("root/pelvis/spine_01/spine_02/spine_03/clavicle_l/upperarm_l/lowerarm_l/hand_l").gameObject;
                animator = playerCharacter.GetComponent<Animator>();
            }
        }

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
                    curSword = rightHand.transform.Find("BroadswordEquip").gameObject;
                    curSword.SetActive(true);
                }
                else
                {
                    curSword = leftHand.transform.Find("BroadswordEquip").gameObject;
                    curSword.SetActive(true);
                }
                break;
            case 1: // Shortsword
                if (isRight)
                {
                    curSword = rightHand.transform.Find("ShortswordEquip").gameObject;
                    curSword.SetActive(true);
                }
                else
                {
                    curSword = leftHand.transform.Find("ShortswordEquip").gameObject;
                    curSword.SetActive(true);
                }
                break;
            case 2: // Falchion
                if (isRight)
                {
                    curSword = rightHand.transform.Find("FalchionEquip").gameObject;
                    curSword.SetActive(true);
                }
                else
                {
                    curSword = leftHand.transform.Find("FalchionEquip").gameObject;
                    curSword.SetActive(true);
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
        curSword.SetActive(false);
        curSword = null;
    }
}
//*/