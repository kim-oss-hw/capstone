using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject obj; // Player Prefab 설정
    public Text UserNickNameText; //유저 닉네임 따오기
    public GameObject _Spawn1; //플레이어1 스폰지역
    public GameObject _Spawn2; //플레이어2 스폰지역
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
