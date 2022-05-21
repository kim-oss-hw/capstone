using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObjDestroy : MonoBehaviour
{
    public void ImageDestroy()
    {
        transform.parent.gameObject.SetActive(false);
    }
}