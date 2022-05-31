using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class HitJudgment : MonoBehaviourPunCallbacks, IPunObservable
{
    public PhotonView PV;

    public float HP = 100.0f;
    public float FinishMove = 100.0f;
    public GameObject HPbar_top;
    public GameObject AnimationObject;

    public bool GameStart = false;
    public bool WeaponSelect = false;

    public GameObject SwordS;
    public GameObject SwordE;
    public GameObject SwordS_2;
    public GameObject SwordE_2;

    public GameObject SwordLS;
    public GameObject SwordLE;

    public GameObject Player_Character;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(HP);
            stream.SendNext(WeaponSelect);
        }
        else
        {
            this.HP = (float)stream.ReceiveNext();
            this.WeaponSelect = (bool)stream.ReceiveNext();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
        if (GameStart == true)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch) > 0.2f || OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.2f)
            {
                if (FinishMove >= 100.0f)
                {
                    GameObject E_Player = GameObject.Find("Player(Clone)").gameObject;
                    GameObject EnemyPlayer = E_Player.transform.GetChild(0).gameObject;

                    GameObject LastSound = Instantiate(SwordLS);
                    GameObject LastEffect = Instantiate(SwordLE, EnemyPlayer.transform.position, EnemyPlayer.transform.rotation);

                    Destroy(LastSound, 0.8f);
                    Destroy(LastEffect, 3.0f);

                    PV.RPC("LastAttack", RpcTarget.Others);
                    FinishMove = 0.0f;
                }
            }
        }
        
    }

    void MakeHitSound()
    {
        GameObject SwordSound = Instantiate(SwordS);
        GameObject SwordEffect = Instantiate(SwordE, Player_Character.transform.position, Player_Character.transform.rotation);
        Destroy(SwordSound, 0.8f);
        Destroy(SwordEffect, 1.0f);
    }

    void MakeHitSound2()
    {
        GameObject SwordSound = Instantiate(SwordS_2);
        GameObject SwordEffect = Instantiate(SwordE_2, Player_Character.transform.position, Player_Character.transform.rotation);
        Destroy(SwordSound, 0.8f);
        Destroy(SwordEffect, 1.0f);
    }

    public void Spark() // 서로 튕기는 함수
    {
        GameObject EnemyPlayer = GameObject.Find("Player(Clone)").gameObject;
        GameObject MyPlayer = GameObject.Find("MyPlayer").gameObject;
        GameObject MyCamera = GameObject.Find("OVRPlayerCamera").gameObject;

        Vector3 hitVec = EnemyPlayer.transform.position - MyPlayer.transform.position;
        hitVec.y = 0;
        hitVec = -(hitVec.normalized);
        MyCamera.GetComponent<Rigidbody>().AddForce(hitVec * 200.0f);
        MyCamera.GetComponent<Rigidbody>().AddForce(transform.up * 100.0f);
    }

    public void HitCalculation(Collider collider)
    {
        if (collider.gameObject.tag == "Weapon" && GameStart == true)
        {

            WeaponSystem EnemyWeapon = collider.gameObject.GetComponent<WeaponSystem>();

            if (EnemyWeapon.Attackable == true)
            {
                MakeHitSound();

                HP -= EnemyWeapon.Damage;

                EnemyWeapon.Attackable = false;
                EnemyWeapon.CoolTimeStart = true;

                //피격자 경직 애니메이션 부분
                //Animator animator = AnimationObject.GetComponent<Animator>();
                //animator.SetTrigger("Hit");
                Spark();
            }
        }
    }

    public void WeaponHitCalculation(Collider collider)
    {
        if (collider.gameObject.tag == "Weapon" && GameStart == true)
        {

            WeaponSystem EnemyWeapon = collider.gameObject.GetComponent<WeaponSystem>();

            if (EnemyWeapon.Attackable == true)
            {
                MakeHitSound2();

                FinishMove += (EnemyWeapon.Damage) * 15.0f;

                EnemyWeapon.Attackable = false;
                EnemyWeapon.CoolTimeStart = true;

                //피격자 경직 애니메이션 부분
                //Animator animator = AnimationObject.GetComponent<Animator>();
                //animator.SetTrigger("Hit");
                Spark();
            }
        };
    }

    
    [PunRPC]
    void LastAttack()
    {
        GameObject M_Player = GameObject.Find("MyPlayer").gameObject;
        GameObject MyPlayer = M_Player.transform.GetChild(0).gameObject;

        GameObject LastSound = Instantiate(SwordLS);
        GameObject LastEffect = Instantiate(SwordLE, MyPlayer.transform.position, MyPlayer.transform.rotation);

        Destroy(LastSound, 0.8f);
        Destroy(LastEffect, 3.0f);

        HitJudgment My_HitJud = MyPlayer.GetComponent<HitJudgment>();
        My_HitJud.HP -= 30.0f;
    }

}