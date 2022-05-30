using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class HitJudgment : MonoBehaviourPunCallbacks, IPunObservable
{
    public float HP = 100.0f;
    public GameObject HPbar_top;
    public GameObject AnimationObject;

    public bool GameStart = false;
    public bool WeaponSelect = false;

    public GameObject SwordS;
    public GameObject SwordE;
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

    }

    void MakeHitSound()
    {
        GameObject SwordSound = Instantiate(SwordS);
        GameObject SwordEffect = Instantiate(SwordE, Player_Character.transform.position, Player_Character.transform.rotation);
        Destroy(SwordSound, 0.8f);
        Destroy(SwordEffect, 1.0f);
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

                RectTransform HPbar_rect = HPbar_top.GetComponent<RectTransform>();
                HPbar_rect.offsetMin = new Vector2(0.0f, 235.0f);
                HPbar_rect.offsetMax = new Vector2(-1000.0f + HP * 10.0f, -235.0f);

                //�ǰ��� ���� �ִϸ��̼� �κ�
                //Animator animator = AnimationObject.GetComponent<Animator>();
                //animator.SetTrigger("Hit");
                Spark();
            }
        }
    }

    public void Spark() // ���� ƨ��� �Լ�
    {
        GameObject EnemyPlayer = GameObject.Find("Player(Clone)").gameObject;
        GameObject MyPlayer = GameObject.Find("MyPlayer").gameObject;
        GameObject MyCamera = GameObject.Find("OVRPlayerCamera").gameObject;

        Vector3 hitVec = -((EnemyPlayer.transform.position - MyPlayer.transform.position).normalized);
        MyCamera.GetComponent<Rigidbody>().AddForce(hitVec * 200.0f);
        MyCamera.GetComponent<Rigidbody>().AddForce(transform.up * 100.0f);
    }
}