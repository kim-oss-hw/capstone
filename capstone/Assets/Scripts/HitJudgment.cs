using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitJudgment : MonoBehaviour
{
    public int HP = 100;
    public GameObject HPbar;
    public GameObject AnimationObject;
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
            HP -= 10;

            RectTransform HPbar_rect = HPbar.GetComponent<RectTransform>();
            HPbar_rect.offsetMin = new Vector2(0.0f, 235.0f);
            HPbar_rect.offsetMax = new Vector2(-1000.0f + HP * 10.0f, -235.0f);

            Animator animator = AnimationObject.GetComponent<Animator>();
            animator.SetTrigger("Hit");
        }
    }
}
