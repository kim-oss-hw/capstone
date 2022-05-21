using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject VRplayerPrefab; // Player Prefab ����
    public GameObject OVRplayer; // Player Prefab ����

    public Transform SpawnPoint1; //�÷��̾�1 ��������
    public Transform SpawnPoint2; //�÷��̾�2 ��������


    private void Awake()
    {
        //PhotonNetwork.ConnectUsingSettings();
        StartCoroutine(this.CreatePlayer());
    }

    IEnumerator CreatePlayer()
    {

        if (NetworkManager.PlayerID % 2 == 1)
        {
            OVRplayer = GameObject.Find("OVRPlayerCamera");
            OVRplayer.transform.position = SpawnPoint1.transform.position;
            OVRplayer.transform.rotation = SpawnPoint1.transform.rotation;

            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
            VRplayerPrefab.name = "MyPlayer";

        }
        else if (NetworkManager.PlayerID % 2 == 0)
        {
            OVRplayer = GameObject.Find("OVRPlayerCamera");
            OVRplayer.transform.position = SpawnPoint2.transform.position;
            OVRplayer.transform.rotation = SpawnPoint2.transform.rotation;

            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
            VRplayerPrefab.name = "MyPlayer";
        }
        yield return null;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(VRplayerPrefab);
    }

}
