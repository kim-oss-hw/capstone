using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class HitJudgment : MonoBehaviourPunCallbacks
{
    public float HP = 100.0f;
    public GameObject HPbar_top;
    public GameObject HPbar_ui;
    public GameObject AnimationObject;
    WeaponSystem WeaponSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {
            WeaponSystem EnemyWeapon = collider.gameObject.GetComponent<WeaponSystem>();

            if (EnemyWeapon.Attackable == true) {
                HP -= EnemyWeapon.Damage;
                EnemyWeapon.Attackable = false;
                EnemyWeapon.CoolTimeStart = true;

                RectTransform HPbar_rect = HPbar_top.GetComponent<RectTransform>();
                RectTransform HPbarUI_rect = HPbar_ui.GetComponent<RectTransform>();

                HPbar_rect.offsetMin = new Vector2(0.0f, 235.0f);
                HPbar_rect.offsetMax = new Vector2(-1000.0f + HP * 10.0f, -235.0f);

                HPbarUI_rect.offsetMin = new Vector2(-237.0f, 17.0f - HP * 10.0f);
                HPbarUI_rect.offsetMax = new Vector2(1363.0f, -383.0f);

                //�ǰ��� ���� �ִϸ��̼� �κ�
                Animator animator = AnimationObject.GetComponent<Animator>();
                animator.SetTrigger("Hit");
            }
        }
    }
}
