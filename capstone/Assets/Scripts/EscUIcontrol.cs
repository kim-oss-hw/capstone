using UnityEngine;

public class EscUIcontrol : MonoBehaviour
{
    GameMainSystem _gameMainSystem;
    PlayerSpawnManager _playerSpawnManager;

    private void Start()
    {
        _gameMainSystem = GameObject.Find("OVRPlayerCamera").GetComponent<GameMainSystem>();
        _playerSpawnManager = GameObject.Find("NetworkManager").GetComponent<PlayerSpawnManager>();
        transform.GetComponent<OVRRaycaster>().pointer = GameObject.Find("UIHelpers").transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (GameObject.Find("EscPrefab(Clone)"))
        {
            _gameMainSystem.UIHelpers.SetActive(true);
        }
        else
        {
            _gameMainSystem.UIHelpers.SetActive(false);
        }
    }

    public void ButtonDownMoveDown(RectTransform target)
    {
        target.anchoredPosition += Vector2.down * 8.0f;
    }
    public void ButtonUpMoveUp(RectTransform target)
    {
        target.anchoredPosition += Vector2.up * 8.0f;

        target.localScale = Vector3.one;
    }
    public void ButtonDownScaleRestore(RectTransform target)
    {
        target.localScale *= 0.9f;
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
