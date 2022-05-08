using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJudgment : MonoBehaviour
{
    public float HP = 100.0f;
    public GameObject HPbar;
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

                RectTransform HPbar_rect = HPbar.GetComponent<RectTransform>();
                HPbar_rect.offsetMin = new Vector2(0.0f, 235.0f);
                HPbar_rect.offsetMax = new Vector2(-1000.0f + HP * 10.0f, -235.0f);

                //피격자 경직 애니메이션 부분
                Animator animator = AnimationObject.GetComponent<Animator>();
                animator.SetTrigger("Hit");
            }
        }
    }
}
