using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//메인메뉴 컨트롤러
public class cshMainMenu : MonoBehaviour
{

    //Quit 버튼 누르면 게임 끝내기
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    //Online 버튼 -> createRoom or enterRoom 버튼 -> strat 누르면 Online 씬 불러옴  
    public void StartGame()
    {
        SceneManager.LoadScene("Online");
    }

    //single Player 버튼 누르면 Single 씬 로드
    public void SinglePlay()
    {
        SceneManager.LoadScene("Single");
    }

    //Training 버튼 누르면 Training 씬 로드
    public void Training()
    {
        SceneManager.LoadScene("Training");

    }
}
