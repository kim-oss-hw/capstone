using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject _player1; // Player Prefab ����
    public GameObject _player2; // Player Prefab ����

    public Transform _Spawn1; //�÷��̾�1 ��������
    public Transform _Spawn2; //�÷��̾�2 ��������

    void Start()
    {
        StartCoroutine(this.CreatePlayer());
    }

    
    IEnumerator CreatePlayer()
    {
        if (NetworkManager.PlayerID%2 == 1)
        {
            PhotonNetwork.Instantiate("Player1", _Spawn1.position, _Spawn1.rotation);
        }
        else if (NetworkManager.PlayerID%2 == 0)
        {
            PhotonNetwork.Instantiate("Player2", _Spawn2.position, _Spawn2.rotation);
        }
        else
            PhotonNetwork.Instantiate("Player1", _Spawn1.position, _Spawn1.rotation);
        yield return null;

    }


}
