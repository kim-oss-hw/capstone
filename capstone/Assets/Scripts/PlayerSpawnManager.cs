using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject obj; // Player Prefab ����
    public Text UserNickNameText; //���� �г��� ������
    public GameObject _Spawn1; //�÷��̾�1 ��������
    public GameObject _Spawn2; //�÷��̾�2 ��������
    void Start()
    {
        UserNickNameText.text = NetworkManager.UserNickName;
    }

   

    void SpawnObj()
    {
        if (NetworkManager.PlayerID == 1)
        {
            Instantiate(obj, _Spawn1.transform.position, _Spawn1.transform.rotation);
        }
        else
            Instantiate(obj, _Spawn2.transform.position, _Spawn2.transform.rotation);
    }


}
