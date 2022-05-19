using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class VRNetworkPlayerRig : MonoBehaviourPunCallbacks
{
    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;

    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public PhotonView PV;
    public GameObject vrPlayer;
    public Transform headConstraint;
    public Vector3 headBodyOffset;
    public float turnSmoothness = 3f;

    private void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;

        head.vrTarget = GameObject.Find("VRplayer").transform.Find("Camera Offset/Main Camera");
        leftHand.vrTarget = GameObject.Find("VRplayer").transform.Find("Camera Offset/LeftHand Controller");
        rightHand.vrTarget = GameObject.Find("VRplayer").transform.Find("Camera Offset/RightHand Controller");
    }

    private void Update()
    {
        if (PV.IsMine)
        {
            vrPlayer.SetActive(false);

            transform.position = headConstraint.position + headBodyOffset;
            transform.forward = Vector3.Lerp(transform.forward,
            Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

            head.Map();
            leftHand.Map();
            rightHand.Map();
        }
    }
}