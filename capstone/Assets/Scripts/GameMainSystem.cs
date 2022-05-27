using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class GameMainSystem : MonoBehaviourPunCallbacks
{

    public GameObject My_Player;
    public GameObject Enermy_Player;

    private HitJudgment My_HitJudgment;
    private HitJudgment Enermy_HitJudgment;

    private HitJudgment MyPlayer_HitJud;
    private HitJudgment Enermy_HitJud;

    private RectTransform My_HPbar_rect;
    private RectTransform Enermy_HPbar_rect;


    public float My_HP = 100.0f;
    public float Enermy_HP = 100.0f;

    public GameObject My_HPbar;
    public GameObject Enermy_HPbar;

    public GameObject CountDownUI;
    public GameObject GameTimeUI;


    public bool CountDownBool = true;
    public bool GameStartBool = false;
    public bool GameEndBool = false;

    IEnumerator StartCountDown()
    {
        CountDownUI = GameObject.Find("countdown");
        Text CountDownUItext = CountDownUI.GetComponent<Text>();

        int i = 0;

        while (i < 3)
        {
            i += 1;
            CountDownUItext.text = (4 - i).ToString();
            yield return new WaitForSeconds(1.0f);
        }

        CountDownUItext.text = "";
        GameStartBool = true;
        MyPlayer_HitJud.GameStart = true;
        Enermy_HitJud.GameStart = true;

    }

    IEnumerator GameCountDown()
    {
        GameTimeUI = GameObject.Find("gametime");
        Text GameTimeUItext = GameTimeUI.GetComponent<Text>();

        int i = 0;

        while (i < 100)
        {
            i += 1;
            if(i > 90)
                GameTimeUItext.text = "0"+(100 - i).ToString();
            else
                GameTimeUItext.text = (100 - i).ToString();
            yield return new WaitForSeconds(1.0f);
        }

        MyPlayer_HitJud.GameStart = false;
        Enermy_HitJud.GameStart = false;
        GameEndBool = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!My_Player || !Enermy_Player)
        {
            My_Player = GameObject.Find("MyPlayer");
            Enermy_Player = GameObject.Find("Player(Clone)");
            
            MyPlayer_HitJud = My_Player.GetComponent<HitJudgment>();
            Enermy_HitJud = Enermy_Player.GetComponent<HitJudgment>();
            
            My_HPbar_rect = My_HPbar.GetComponent<RectTransform>();
            Enermy_HPbar_rect = Enermy_HPbar.GetComponent<RectTransform>();

        }
        else
        {
            My_HP = MyPlayer_HitJud.HP;
            Enermy_HP = Enermy_HitJud.HP;

            My_HPbar_rect.offsetMin = new Vector2(537.0f, 668.0f);
            My_HPbar_rect.offsetMax = new Vector2(-2137.0f, -1068.0f - 1000.0f + (10.0f * My_HP));

            Enermy_HPbar_rect.offsetMin = new Vector2(2137.0f, 668.0f);
            Enermy_HPbar_rect.offsetMax = new Vector2(-537.0f, -1068.0f - 1000.0f + (10.0f * Enermy_HP));

            if(MyPlayer_HitJud.GetComponent<HitJudgment>().WeaponSelect == true && Enermy_HitJud.GetComponent<HitJudgment>().WeaponSelect == true && CountDownBool == true)
            {
                CountDownBool = false;
                StartCoroutine("StartCountDown");
            }

            if (GameStartBool == true)
            {
                GameStartBool = false;
                StartCoroutine("GameCountDown");
            }
        }

    }
    public void GameLose()
    {
        CountDownUI = GameObject.Find("countdown");
        Text CountDownUItext = CountDownUI.GetComponent<Text>();
        CountDownUItext.text = "LOSE";
    }
    public void GameWin()
    {
        CountDownUI = GameObject.Find("countdown");
        Text CountDownUItext = CountDownUI.GetComponent<Text>();
        CountDownUItext.text = "WIN";
    }

}
