using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnManager : MonoBehaviourPunCallbacks
{
    public GameObject VRplayerPrefab; // Player Prefab 설정
    public GameObject OVRplayer; // Player Prefab 설정

    public Transform SpawnPoint1; //플레이어1 스폰지역
    public Transform SpawnPoint2; //플레이어2 스폰지역

    GameMainSystem GameMainSys;



    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        //StartCoroutine(this.CreatePlayer());

    }

    void Start()
    {
        GameMainSys = GameObject.Find("OVRPlayerCamera").GetComponent<GameMainSystem>();
        CreatePlayer();
    }

    void Update()
    {

        //if (OVRInput.GetDown(OVRInput.Button.One))
        //{
        //    PhotonNetwork.LeaveRoom();
        //    SceneManager.LoadScene("MainMenu2");
        //}

        if (PhotonNetwork.PlayerList.Length < 2)
        {
            GameMainSys.GameWin();
            Invoke("BackToRoom", 5);
        }
        else if (GameMainSys.My_HP <= 0.0f)
        {
            GameMainSys.GameWin();
            Invoke("BackToRoom", 5);
        }

    }
    void CreatePlayer()
    {
        if (NetworkManager.PlayerID == 1)
        {
            OVRplayer = GameObject.Find("OVRPlayerCamera");
            OVRplayer.transform.position = SpawnPoint1.transform.position;
            OVRplayer.transform.rotation = SpawnPoint1.transform.rotation;

            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
            VRplayerPrefab.name = "MyPlayer";

        }
        else if (NetworkManager.PlayerID == 2)
        {
            OVRplayer = GameObject.Find("OVRPlayerCamera");
            OVRplayer.transform.position = SpawnPoint2.transform.position;
            OVRplayer.transform.rotation = SpawnPoint2.transform.rotation;

            VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
            VRplayerPrefab.name = "MyPlayer";
        }
    }

    //IEnumerator CreatePlayer()
    //{

    //    if (NetworkManager.PlayerID % 2 == 1)
    //    {
    //        OVRplayer = GameObject.Find("OVRPlayerCamera");
    //        OVRplayer.transform.position = SpawnPoint1.transform.position;
    //        OVRplayer.transform.rotation = SpawnPoint1.transform.rotation;

    //        VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
    //        VRplayerPrefab.name = "MyPlayer";

    //    }
    //    else if (NetworkManager.PlayerID % 2 == 0)
    //    {
    //        OVRplayer = GameObject.Find("OVRPlayerCamera");
    //        OVRplayer.transform.position = SpawnPoint2.transform.position;
    //        OVRplayer.transform.rotation = SpawnPoint2.transform.rotation;

    //        VRplayerPrefab = PhotonNetwork.Instantiate("Player", SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
    //        VRplayerPrefab.name = "MyPlayer";
    //    }
    //    yield return null;
    //}

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(VRplayerPrefab);
    }
    public void BackToRoom()
    {
        SceneManager.LoadScene("BackToMainMenu");
    }
}
