using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameMainSystem : MonoBehaviourPunCallbacks
{

    public GameObject My_Player;
    public GameObject Enermy_Player;

    public HitJudgment My_HitJudgment;
    public HitJudgment Enermy_HitJudgment;

    public float My_HP;
    public float Enermy_HP;

    // Start is called before the first frame update
    void Start()
    {
        My_Player = GameObject.Find("MyPlayer");
        Enermy_Player = GameObject.Find("Player(Clone)");

        My_HitJudgment = My_Player.GetComponent<HitJudgment>();
        Enermy_HitJudgment = Enermy_Player.GetComponent<HitJudgment>();

        My_HP = My_HitJudgment.HP;
        Enermy_HP = Enermy_HitJudgment.HP;
    }

    // Update is called once per frame
    void Update()
    {
        My_HP = My_HitJudgment.HP;
        Enermy_HP = Enermy_HitJudgment.HP;

        if (My_HP <= 0.0f)
        {

        }

        else if (Enermy_HP <= 0.0f)
        {

        }
    }

}
