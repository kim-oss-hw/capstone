using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject VRplayerPrefab; // Player Prefab ����

    public Transform SpawnPoint1; //�÷��̾�1 ��������
    public Transform SpawnPoint2; //�÷��̾�2 ��������



    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        base.OnJoinedRoom();
        StartCoroutine(this.CreatePlayer());

    }
    IEnumerator CreatePlayer ()
    {
        if (NetworkManager.PlayerID % 2 == 1)
        {
            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
            VRplayerPrefab.name = "Player1";
        }
        else if (NetworkManager.PlayerID % 2 == 0)
        {
            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
            VRplayerPrefab.name = "Player2";
        }

        else
        {
            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
            VRplayerPrefab.name = "Player1";    
        }

        yield return null;
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(VRplayerPrefab);
    }

    


}
