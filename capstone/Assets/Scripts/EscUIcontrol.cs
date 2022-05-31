using UnityEngine;

public class EscUIcontrol : MonoBehaviour
{
    GameMainSystem _gameMainSystem;
    PlayerSpawnManager _playerSpawnManager;

    private void Start()
    {
        _gameMainSystem = GameObject.Find("OVRPlayerCamera").GetComponent<GameMainSystem>();
        _playerSpawnManager = GameObject.Find("NetworkManager").GetComponent<PlayerSpawnManager>();
        _gameMainSystem.UIHelpers.SetActive(true);
        transform.GetComponent<OVRRaycaster>().pointer = GameObject.Find("UIHelpers").transform.GetChild(0).gameObject;
    }
   

    
    public void QuitGame()
    {
        _playerSpawnManager.BackToRoom();
    }
    //public void SurrenderGame()
    //{
    //    _playerSpawnManager.SurrenderGame();
    //}

    public void UIRemove()
    {
        GameObject.Find("UIHelpers").SetActive(false);
        Destroy(gameObject);
    }
}
