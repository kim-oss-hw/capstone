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

    public HitJudgment My_HitJudgment;
    public HitJudgment Enermy_HitJudgment;

    private HitJudgment MyPlayer_HitJud;
    private HitJudgment Enermy_HitJud;

    private RectTransform My_HPbar_rect;
    private RectTransform Enermy_HPbar_rect;


    public float My_HP;
    public float Enermy_HP;

    public GameObject My_HPbar;
    public GameObject Enermy_HPbar;

    public GameObject CountDownUI;
    public GameObject GameTimeUI;
    private bool GameStartBool = false;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GameCountDown");

        My_Player = GameObject.Find("MyPlayer");
        Enermy_Player = GameObject.Find("Player(Clone)");

        My_HitJudgment = My_Player.GetComponent<HitJudgment>();
        Enermy_HitJudgment = Enermy_Player.GetComponent<HitJudgment>();

        MyPlayer_HitJud = My_Player.GetComponent<HitJudgment>();
        Enermy_HitJud = Enermy_Player.GetComponent<HitJudgment>();

        My_HPbar_rect = My_HPbar.GetComponent<RectTransform>();
        Enermy_HPbar_rect = Enermy_HPbar.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        My_HP = My_HitJudgment.HP;
        Enermy_HP = Enermy_HitJudgment.HP;

        My_HPbar_rect.offsetMin = new Vector2(537.0f, 1068.0f + (10.0f * My_HP));
        My_HPbar_rect.offsetMax = new Vector2(2137.0f, 668.0f);

        Enermy_HPbar_rect.offsetMin = new Vector2(2137.0f, 1068.0f + (10.0f * Enermy_HP));
        Enermy_HPbar_rect.offsetMax = new Vector2(537.0f, 668.0f);

        if (My_HP <= 0.0f)
        {
            CountDownUI = GameObject.Find("countdown");
            Text CountDownUItext = CountDownUI.GetComponent<Text>();
            CountDownUItext.text = "LOSE";

            //������ �ڵ�
        }

        else if (Enermy_HP <= 0.0f)
        {
            CountDownUI = GameObject.Find("countdown");
            Text CountDownUItext = CountDownUI.GetComponent<Text>();
            CountDownUItext.text = "WIN";

            //������ �ڵ�
        }
    }

}
