using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkTest : MonoBehaviour
{
    public GameObject My_Player;
    public GameObject Enermy_Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        My_Player = GameObject.Find("MyPlayer");
        Enermy_Player = GameObject.Find("Player(clone)");

        Debug.Log("My Player : " + My_Player.transform.position);
        Debug.Log("Enermy Player : " + Enermy_Player.transform.position);
    }
}
