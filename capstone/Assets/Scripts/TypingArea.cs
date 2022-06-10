using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingArea : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject righttHand;
    public GameObject leftTypingHand;
    public GameObject rightTypingHand;

    private void OnTriggerEnter(Collider other)
    {
        GameObject hand = other.GetComponentInParent<OVRGrabber>().gameObject;
        if (hand == null) return;
        if(hand == leftHand)
        {
            leftTypingHand.SetActive(true);
        }else if(hand == righttHand)
        {
            rightTypingHand.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hand = other.GetComponentInParent<OVRGrabber>().gameObject;
        if (hand == null) return;
        if (hand == leftHand)
        {
            leftTypingHand.SetActive(false);
        }
        else if (hand == righttHand)
        {
            rightTypingHand.SetActive(false);
        }
    }

}
