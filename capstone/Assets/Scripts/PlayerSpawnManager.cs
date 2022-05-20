using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject VRplayerPrefab; // Player Prefab 설정
    public GameObject OVRplayer; // Player Prefab 설정

    public Transform SpawnPoint1; //플레이어1 스폰지역
    public Transform SpawnPoint2; //플레이어2 스폰지역


    private void Awake()
    {
        //PhotonNetwork.ConnectUsingSettings();
        StartCoroutine(this.CreatePlayer());
    }

    IEnumerator CreatePlayer()
    {
        Debug.Log(NetworkManager.PlayerID);
        if (NetworkManager.PlayerID % 2 == 1)
        {
            OVRplayer = GameObject.Find("OVRPlayerCamera");
            OVRplayer.transform.position = SpawnPoint1.transform.position;
            OVRplayer.transform.rotation = SpawnPoint1.transform.rotation;

            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
            VRplayerPrefab.name = "Player1";

        }
        else if (NetworkManager.PlayerID % 2 == 0)
        {
            OVRplayer = GameObject.Find("OVRPlayerCamera");
            OVRplayer.transform.position = SpawnPoint2.transform.position;
            OVRplayer.transform.rotation = SpawnPoint2.transform.rotation;

            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
            VRplayerPrefab.name = "Player2";
        }
        else
        {
            OVRplayer = GameObject.Find("OVRPlayerCamera");
            OVRplayer.transform.position = SpawnPoint2.transform.position;
            OVRplayer.transform.rotation = SpawnPoint2.transform.rotation;

            PhotonNetwork.Instantiate("Player", SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
        }
        yield return null;
    }

    /*public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(VRplayerPrefab);
    }*/

}
