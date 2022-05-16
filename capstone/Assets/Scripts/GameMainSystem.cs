using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameMainSystem : MonoBehaviourPunCallbacks
{

    public GameObject Player_1;
    public GameObject Player_2;

    public HitJudgment P1_HitJudgment;
    public HitJudgment P2_HitJudgment;

    public float P1_HP;
    public float P2_HP;

    // Start is called before the first frame update
    void Start()
    {
        Player_1 = GameObject.Find("Name");
        Player_2 = GameObject.Find("Name");

        P1_HitJudgment = Player_1.GetComponent<HitJudgment>();
        P2_HitJudgment = Player_2.GetComponent<HitJudgment>();

        P1_HP = P1_HitJudgment.HP;
        P2_HP = P2_HitJudgment.HP;
    }

    // Update is called once per frame
    void Update()
    {
        P1_HP = P1_HitJudgment.HP;
        P2_HP = P2_HitJudgment.HP;

        if (P1_HP <= 0.0f)
        {

        }

        else if (P2_HP <= 0.0f)
        {

        }
    }

}
