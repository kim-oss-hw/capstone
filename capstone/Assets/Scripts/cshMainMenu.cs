using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���θ޴� ��Ʈ�ѷ�
public class cshMainMenu : MonoBehaviour
{

    //Quit ��ư ������ ���� ������
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    //Online ��ư -> createRoom or enterRoom ��ư -> strat ������ Online �� �ҷ���  
    public void StartGame()
    {
        SceneManager.LoadScene("Online");
    }

    //single Player ��ư ������ Single �� �ε�
    public void SinglePlay()
    {
        SceneManager.LoadScene("Single");
    }

    //Training ��ư ������ Training �� �ε�
    public void Training()
    {
        SceneManager.LoadScene("Training");

    }
}
