using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshVrHeadMove : MonoBehaviour
{
    public float speedForward = 1;
    public float speedSide = 1;

    private Transform tr;
    private float dirX = 0;
    private float dirY = 0;
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
        dirX = 0;
        dirY = 0;
    }
}
