using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BackToRoom : MonoBehaviourPunCallbacks
{
 
    void Update()
    {
        if(PhotonNetwork.PlayerList.Length < 2)
        {
            PhotonNetwork.LoadLevel("MainMenu2");
        }
    }
}
