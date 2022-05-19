using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class cshVrRig : MonoBehaviour
{
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public PhotonView PV;
    public GameObject vrPlayer;
    public float turnSmoothness = 5;
    public Transform headConstraint;
    public Vector3 headBodyOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            headBodyOffset = transform.position - headConstraint.position;

            head.vrTarget = GameObject.Find("OVRPlayerCamera").transform.Find("TrackingSpace/CenterEyeAnchor");
            leftHand.vrTarget = GameObject.Find("OVRPlayerCamera").transform.Find("TrackingSpace/LeftHandAnchor");
            rightHand.vrTarget = GameObject.Find("OVRPlayerCamera").transform.Find("TrackingSpace/RightHandAnchor");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PV.IsMine)
        {
            //vrPlayer.SetActive(false);

            transform.position = headConstraint.position + headBodyOffset;
            transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(-1 * headConstraint.up, Vector3.up).normalized,Time.deltaTime * turnSmoothness);

            head.Map();
            rightHand.Map();
            leftHand.Map();
        }

    }
}
