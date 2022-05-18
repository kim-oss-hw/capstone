using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject _player; // Player Prefab ����
    public GameObject _Spawn1; //�÷��̾�1 ��������
    public GameObject _Spawn2; //�÷��̾�2 ��������
    public Text _nickName;

    void Start()
    {
        _nickName.text = NetworkManager.UserNickName;
    }

    void SpawnObj()
    {
        if (NetworkManager.PlayerID == 1)
        {
            Instantiate(_player, _Spawn1.transform.position, _Spawn1.transform.rotation);
        }
        else
            Instantiate(_player, _Spawn2.transform.position, _Spawn2.transform.rotation);
    }


}
